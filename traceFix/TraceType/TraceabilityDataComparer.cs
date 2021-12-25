using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	public static class TraceabilityDataComparer
	{
		private struct PackagingMapInfo
		{
			public PackagingUnit PackagingUnit;

			public List<string> RefIDs;
		}

		public struct CompareResultData
		{
			public TraceabilityDataComparer.CompareError ErrorId;

			public string ErrorCause;

			public string Item1;

			public string Item2;
		}

		public enum CompareError
		{
			IDENTICAL,
			NOT_IDENTICAL,
			EXCEPTION,
			DIFFERENT_FILE_COUNT,
			FILE_NOT_FOUND_IN_DB,
			TRACE_NOT_FOUND,
			HEADER_NOT_EQUAL,
			JOB_NOT_FOUND,
			JOB_COUNT_ERROR,
			CTYPE_NOT_FOUND,
			PACKAGING_CTYPE_NOT_EQUAL,
			PACKAGING_NOT_EQUAL,
			LOCATION_COUNT_ERROR,
			PACKAGING_MISSING_ERROR,
			PLACEMENT_DIFFERS_ERROR,
			PLACEMENT_NOT_FOUND,
			PACKAGING_CTYPE_NOT_FOUND,
			PACKAGING_COUNT_ERROR
		}

		public static TraceabilityDataComparer.CompareResultData CompareTraceabilityData(TraceabilityData td1, TraceabilityData td2)
		{
			return TraceabilityDataComparer.CompareTraceabilityData(td1, td2, false, false, false);
		}

		public static TraceabilityDataComparer.CompareResultData CompareTraceabilityData(TraceabilityData td1, TraceabilityData td2, bool ignoreErrorLabel, bool ignoreEndDate, bool ignoreAdditionalPUs)
		{
			string errorCause;
			TraceabilityDataComparer.CompareResultData result;
			if (!td1.IsEqualHeader(td2, ignoreErrorLabel, ignoreEndDate, out errorCause))
			{
				result = new TraceabilityDataComparer.CompareResultData
				{
					ErrorId = TraceabilityDataComparer.CompareError.HEADER_NOT_EQUAL,
					ErrorCause = errorCause,
					Item1 = td1.ToString(),
					Item2 = td2.ToString()
				};
			}
			else
			{
				if (td1.Jobs.Count > 1 || td2.Jobs.Count > 1)
				{
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < td1.Jobs.Count - 1; i++)
					{
						for (int j = i + 1; j < td1.Jobs.Count; j++)
						{
							if (td1.Jobs[i].Equals(td1.Jobs[j]))
							{
								num++;
							}
						}
					}
					for (int i = 0; i < td2.Jobs.Count - 1; i++)
					{
						for (int j = i + 1; j < td2.Jobs.Count; j++)
						{
							if (td2.Jobs[i].Equals(td2.Jobs[j]))
							{
								num2++;
							}
						}
					}
					if (td1.Jobs.Count - num != td2.Jobs.Count - num2)
					{
						result = new TraceabilityDataComparer.CompareResultData
						{
							ErrorId = TraceabilityDataComparer.CompareError.JOB_COUNT_ERROR,
							ErrorCause = "Job count is different",
							Item1 = TraceabilityDataComparer.SerializeObject(td1.Jobs),
							Item2 = TraceabilityDataComparer.SerializeObject(td2.Jobs)
						};
						return result;
					}
				}
				foreach (Job current in td1.Jobs)
				{
					bool flag = false;
					foreach (Job current2 in td2.Jobs)
					{
						if (current.IsEqual(current2))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						result = new TraceabilityDataComparer.CompareResultData
						{
							ErrorId = TraceabilityDataComparer.CompareError.JOB_NOT_FOUND,
							ErrorCause = "Job data is different",
							Item1 = TraceabilityDataComparer.SerializeObject(current),
							Item2 = string.Empty
						};
						return result;
					}
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				for (int i = 0; i < td1.ComponentTypes.Count; i++)
				{
					dictionary.Add(td1.ComponentTypes[i].Id, string.Format("{0}:{1}", td1.ComponentTypes[i].Name, td1.ComponentTypes[i].PackForm));
				}
				for (int i = 0; i < td2.ComponentTypes.Count; i++)
				{
					dictionary2.Add(td2.ComponentTypes[i].Id, string.Format("{0}:{1}", td2.ComponentTypes[i].Name, td2.ComponentTypes[i].PackForm));
				}
				Dictionary<string, string> dictionary3;
				Dictionary<string, string> dictionary4;
				if (ignoreAdditionalPUs)
				{
					dictionary3 = dictionary;
					dictionary4 = dictionary2;
				}
				else if (dictionary.Count >= dictionary2.Count)
				{
					dictionary3 = dictionary;
					dictionary4 = dictionary2;
				}
				else
				{
					dictionary3 = dictionary2;
					dictionary4 = dictionary;
				}
				foreach (string current3 in dictionary3.Values)
				{
					if (!dictionary4.ContainsValue(current3))
					{
						result = new TraceabilityDataComparer.CompareResultData
						{
							ErrorId = TraceabilityDataComparer.CompareError.CTYPE_NOT_FOUND,
							ErrorCause = "ComponentTypes are different",
							Item1 = ((dictionary3 == dictionary) ? ("ComponentType and Packform: " + current3.ToString()) : ""),
							Item2 = ((dictionary3 == dictionary2) ? ("ComponentType and Packform: " + current3.ToString()) : "")
						};
						return result;
					}
				}
				Dictionary<string, List<string>> dictionary5 = TraceabilityDataComparer.CreatePanelMap(td1);
				Dictionary<string, List<string>> dictionary6 = TraceabilityDataComparer.CreatePanelMap(td2);
				if (!ignoreAdditionalPUs && td1.Locations.Count != td2.Locations.Count)
				{
					result = new TraceabilityDataComparer.CompareResultData
					{
						ErrorId = TraceabilityDataComparer.CompareError.LOCATION_COUNT_ERROR,
						ErrorCause = "Location count differs",
						Item1 = string.Format("Count1 = {0}", td1.Locations.Count),
						Item2 = string.Format("Count2 = {0}", td2.Locations.Count)
					};
				}
				else
				{
					Dictionary<string, TraceabilityDataComparer.PackagingMapInfo> dictionary7 = TraceabilityDataComparer.CreatePackagingMap(td1);
					Dictionary<string, TraceabilityDataComparer.PackagingMapInfo> dictionary8 = TraceabilityDataComparer.CreatePackagingMap(td2);
					if (!ignoreAdditionalPUs && dictionary7.Count != dictionary8.Count)
					{
						result = new TraceabilityDataComparer.CompareResultData
						{
							ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_COUNT_ERROR,
							ErrorCause = "Packaging count differs",
							Item1 = string.Format("Count1 = {0}", dictionary7.Count),
							Item2 = string.Format("Count2 = {0}", dictionary8.Count)
						};
					}
					else
					{
						foreach (KeyValuePair<string, TraceabilityDataComparer.PackagingMapInfo> current4 in dictionary7)
						{
							TraceabilityDataComparer.PackagingMapInfo value = current4.Value;
							TraceabilityDataComparer.PackagingMapInfo packagingMapInfo;
							if (!dictionary8.TryGetValue(current4.Key, out packagingMapInfo))
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_MISSING_ERROR,
									ErrorCause = "Packaging " + value.PackagingUnit.PackagingId + " not found in [2]",
									Item1 = string.Format("Missing PUID on Position: PUID={0}, PositionId(Loc:TableID:Track:Div:Level:Tower:PackagingId:VerifiedDate)={1}", current4.Value.PackagingUnit.PackagingId, current4.Key),
									Item2 = string.Empty
								};
								return result;
							}
							string text;
							if (!dictionary.TryGetValue(value.PackagingUnit.ComponentTypeId, out text))
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_CTYPE_NOT_FOUND,
									ErrorCause = "Packaging component id " + value.PackagingUnit.ComponentTypeId + " not found in type list of [1]",
									Item1 = TraceabilityDataComparer.SerializeObject(value.PackagingUnit),
									Item2 = string.Empty
								};
								return result;
							}
							string text2;
							if (!dictionary2.TryGetValue(packagingMapInfo.PackagingUnit.ComponentTypeId, out text2))
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_CTYPE_NOT_FOUND,
									ErrorCause = "Packaging component id " + packagingMapInfo.PackagingUnit.ComponentTypeId + " not found in type list of [2]",
									Item1 = TraceabilityDataComparer.SerializeObject(packagingMapInfo.PackagingUnit),
									Item2 = string.Empty
								};
								return result;
							}
							if (text != text2)
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_CTYPE_NOT_EQUAL,
									ErrorCause = "Packaging component type differs",
									Item1 = string.Format("Packaging: {0}", TraceabilityDataComparer.SerializeObject(value.PackagingUnit)),
									Item2 = string.Format("Expected: {0} Found: {1}", text, text2)
								};
								return result;
							}
							List<string> list = new List<string>();
							List<string> list2 = new List<string>();
							foreach (string current5 in value.RefIDs)
							{
								List<string> list3;
								if (dictionary5.TryGetValue(current5, out list3))
								{
									foreach (string current6 in list3)
									{
										if (!list.Contains(current6))
										{
											list.Add(current6);
										}
									}
								}
							}
							foreach (string current5 in packagingMapInfo.RefIDs)
							{
								List<string> list3;
								if (dictionary6.TryGetValue(current5, out list3))
								{
									foreach (string current6 in list3)
									{
										if (!list2.Contains(current6))
										{
											list2.Add(current6);
										}
									}
								}
							}
							if (list.Count != list2.Count)
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PLACEMENT_DIFFERS_ERROR,
									ErrorCause = "Placement count differs",
									Item1 = string.Format("Count1={0}, Count2={1}", list.Count, list2.Count),
									Item2 = string.Format("PackagingUnit1={0}", TraceabilityDataComparer.SerializeObject(value.PackagingUnit))
								};
								return result;
							}
							foreach (string current6 in list)
							{
								if (!list2.Contains(current6))
								{
									result = new TraceabilityDataComparer.CompareResultData
									{
										ErrorId = TraceabilityDataComparer.CompareError.PLACEMENT_NOT_FOUND,
										ErrorCause = "Placement position not found",
										Item1 = string.Format("Packaging: {0}", TraceabilityDataComparer.SerializeObject(value.PackagingUnit)),
										Item2 = string.Format("Missing Placement: {0}", current6)
									};
									return result;
								}
							}
							if (!value.PackagingUnit.IsEqual(packagingMapInfo.PackagingUnit, out errorCause))
							{
								result = new TraceabilityDataComparer.CompareResultData
								{
									ErrorId = TraceabilityDataComparer.CompareError.PACKAGING_NOT_EQUAL,
									ErrorCause = errorCause,
									Item1 = TraceabilityDataComparer.SerializeObject(value.PackagingUnit),
									Item2 = TraceabilityDataComparer.SerializeObject(packagingMapInfo.PackagingUnit)
								};
								return result;
							}
						}
						result = new TraceabilityDataComparer.CompareResultData
						{
							ErrorId = TraceabilityDataComparer.CompareError.IDENTICAL,
							ErrorCause = "",
							Item1 = string.Empty,
							Item2 = string.Empty
						};
					}
				}
			}
			return result;
		}

		private static string SerializeObject(object o)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
				{
					XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
					xmlSerializerNamespaces.Add("", "");
					xmlSerializer.Serialize(xmlWriter, o, xmlSerializerNamespaces);
					string text = stringWriter.ToString();
					text = text.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
					result = text;
				}
			}
			return result;
		}

		private static Dictionary<string, List<string>> CreatePanelMap(TraceabilityData td)
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (Panel current in td.Panels)
			{
				foreach (PanelId current2 in current.IDs)
				{
					List<string> list;
					if (!dictionary.TryGetValue(current2.Ref, out list))
					{
						list = new List<string>();
						dictionary.Add(current2.Ref, list);
					}
					if (current2.IDs != null && current2.IDs.Count > 0)
					{
						foreach (PanelRefDes current3 in current2.IDs)
						{
							list.Add(string.Format("MR_{0}:{1}:{2}:{3}", new object[]
							{
								current.PanelName,
								current.PanelID,
								current.Omit,
								current3.Name
							}));
						}
					}
					else
					{
						list.Add(string.Format("OR_{0}:{1}:{2}", current.PanelName, current.PanelID, current.Omit));
					}
				}
			}
			return dictionary;
		}

		private static Dictionary<string, TraceabilityDataComparer.PackagingMapInfo> CreatePackagingMap(TraceabilityData td)
		{
			Dictionary<string, TraceabilityDataComparer.PackagingMapInfo> dictionary = new Dictionary<string, TraceabilityDataComparer.PackagingMapInfo>();
			for (int i = 0; i < td.Locations.Count; i++)
			{
				Location location = td.Locations[i];
				for (int j = 0; j < location.Positions.Count; j++)
				{
					Position position = location.Positions[j];
					for (int k = 0; k < position.PackagingUnits.Count; k++)
					{
						PackagingUnit packagingUnit = position.PackagingUnits[k];
						string key = string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}", new object[]
						{
							location.Loc,
							location.TableID ?? "",
							position.Track,
							(position.Div < 1) ? 0 : position.Div,
							(position.Level < 1) ? 0 : position.Level,
							(position.Tower < 1) ? 0 : position.Tower,
							packagingUnit.PackagingId
						});
						TraceabilityDataComparer.PackagingMapInfo value;
						if (dictionary.TryGetValue(key, out value))
						{
							string str;
							if (!packagingUnit.IsEqual(value.PackagingUnit, out str))
							{
								throw new InvalidOperationException("Equal ID but different PackagingUnit error - the id should be unique for each different packaging unit. Detailed Error: " + str);
							}
							value.RefIDs.Add(packagingUnit.Id);
						}
						else
						{
							value = new TraceabilityDataComparer.PackagingMapInfo
							{
								PackagingUnit = packagingUnit,
								RefIDs = new List<string>()
							};
							value.RefIDs.Add(packagingUnit.Id);
							dictionary.Add(key, value);
						}
					}
				}
			}
			return dictionary;
		}

		public static string CompareAttributeText(string name, object objA, object objB)
		{
			string text = (objA == null) ? "<Empty>" : objA.ToString();
			string text2 = (objB == null) ? "<Empty>" : objB.ToString();
			if (string.IsNullOrEmpty(text))
			{
				text = "<Empty>";
			}
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "<Empty>";
			}
			return string.Format("{0} is different: '{1}'<>'{2}'", name, text, text2);
		}
	}
}
