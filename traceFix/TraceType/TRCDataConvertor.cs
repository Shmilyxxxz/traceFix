using System;
using System.Collections.Generic;

namespace ASM.TraceabilityProxy.Service
{
	public class TRCDataConvertor
	{
		private static string s_strPackUnitPrefix = "pu";

		private static string s_strCompTypePrefix = "ct";

		public static TraceabilityData Convert(TraceabilityData1_x oldTRCData)
		{
			int num = 0;
			TraceabilityData traceabilityData = new TraceabilityData();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			TraceabilityData result;
			if (oldTRCData == null)
			{
				result = traceabilityData;
			}
			else
			{
				traceabilityData.Accuracy = Accuracy.StationBased;
				traceabilityData.BaseType = BaseType.Board;
				traceabilityData.Line = oldTRCData.Line;
				traceabilityData.Lane = Lane.Unknown;
				traceabilityData.SubLane = SubLane.None;
				traceabilityData.Station = oldTRCData.Station;
				traceabilityData.BoardID = oldTRCData.BoardID;
				traceabilityData.DateBegin = oldTRCData.DateBegin;
				traceabilityData.DateComplete = oldTRCData.DateComplete;
				traceabilityData.ErrorLabel = oldTRCData.ErrorLevel;
				traceabilityData.Jobs.Add(new Job
				{
					Recipe = oldTRCData.Job,
					BoardName = oldTRCData.BoardName,
					Setup = oldTRCData.Setup
				});
				foreach (Panel1_1 current in oldTRCData.Panels)
				{
					Panel panel = new Panel();
					panel.Omit = current.Omit;
					panel.PanelID = current.PanelID;
					panel.PanelName = current.PanelName;
					panel.IDs = new List<PanelId>();
					foreach (int current2 in current.IDs)
					{
						panel.IDs.Add(new PanelId
						{
							Ref = TRCDataConvertor.s_strPackUnitPrefix + current2.ToString()
						});
					}
					traceabilityData.Panels.Add(panel);
				}
				foreach (Charge c in oldTRCData.Charges)
				{
					Location location = traceabilityData.Locations.Find((Location l) => l.Loc == c.Loc);
					if (location == null)
					{
						location = new Location
						{
							Loc = c.Loc,
							TableID = c.TableID,
							Station = string.Empty
						};
						traceabilityData.Locations.Add(location);
					}
					Position position = location.Positions.Find((Position p) => p.Div == c.Div && p.Track == c.Track && p.Tower == c.MTCTower && p.Level == c.MTCTray);
					if (position == null)
					{
						position = new Position
						{
							Div = c.Div,
							Tower = c.MTCTower,
							Track = c.Track,
							Level = c.MTCTray
						};
						location.Positions.Add(position);
					}
					string text = string.Empty;
					if (dictionary.ContainsKey(c.Comp))
					{
						text = dictionary[c.Comp];
					}
					else
					{
						num++;
						text = TRCDataConvertor.s_strCompTypePrefix + num.ToString();
						dictionary.Add(c.Comp, text);
						traceabilityData.ComponentTypes.Add(new ComponentType
						{
							Id = text,
							Name = c.Comp,
							PackForm = c.PackForm
						});
					}
					PackagingUnit packagingUnit = new PackagingUnit();
					packagingUnit.ComponentTypeId = text;
					packagingUnit.Id = TRCDataConvertor.s_strPackUnitPrefix + c.ID.ToString();
					packagingUnit.Operator = c.Operator;
					packagingUnit.ComponentBarcode = c.Barc1;
					packagingUnit.BatchId = c.Barc2;
					packagingUnit.OriginalQuantity = System.Convert.ToInt32(c.Barc3);
					packagingUnit.PackagingId = c.Barc6;
					TRCDataConvertor.AddPackagingDataIgnoreDuplicates(position.PackagingUnits, packagingUnit, traceabilityData.Panels);
				}
				result = traceabilityData;
			}
			return result;
		}

		public static TraceabilityData Convert(TraceabilityData2_x oldTRCData, bool importSpliceEvents)
		{
			int num = 0;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			TraceabilityData traceabilityData = new TraceabilityData();
			traceabilityData.Accuracy = Accuracy.StationBased;
			traceabilityData.BaseType = BaseType.Board;
			traceabilityData.Line = oldTRCData.Line;
			traceabilityData.Lane = Lane.Unknown;
			traceabilityData.SubLane = SubLane.None;
			traceabilityData.Station = oldTRCData.Station;
			traceabilityData.BoardID = oldTRCData.BoardID;
			traceabilityData.DateBegin = oldTRCData.DateBegin;
			traceabilityData.DateComplete = oldTRCData.DateComplete;
			traceabilityData.ErrorLabel = oldTRCData.ErrorLevel;
			traceabilityData.Jobs.Add(new Job
			{
				Recipe = oldTRCData.Job,
				BoardName = oldTRCData.BoardName,
				Setup = oldTRCData.Setup
			});
			traceabilityData.Panels = new List<Panel>();
			foreach (Panel2_1 current in oldTRCData.Panels)
			{
				Panel panel = new Panel();
				panel.Omit = current.Omit;
				panel.PanelID = current.PanelID;
				panel.PanelName = current.PanelName;
				foreach (PanelId2_1 current2 in current.IDs)
				{
					PanelId panelId = new PanelId();
					panelId.Ref = TRCDataConvertor.s_strPackUnitPrefix + current2.Ref;
					foreach (string current3 in current2.IDs)
					{
						panelId.IDs.Add(new PanelRefDes
						{
							Name = current3
						});
					}
					panel.IDs.Add(panelId);
				}
				traceabilityData.Panels.Add(panel);
			}
			foreach (Charge c in oldTRCData.Charges)
			{
				Location location = traceabilityData.Locations.Find((Location l) => l.Loc == c.Loc);
				if (location == null)
				{
					location = new Location
					{
						Loc = c.Loc,
						TableID = c.TableID,
						Station = string.Empty
					};
					traceabilityData.Locations.Add(location);
				}
				Position position = location.Positions.Find((Position p) => p.Div == c.Div && p.Track == c.Track && p.Tower == c.MTCTower && p.Level == c.MTCTray);
				if (position == null)
				{
					position = new Position
					{
						Div = c.Div,
						Tower = c.MTCTower,
						Track = c.Track,
						Level = c.MTCTray
					};
					location.Positions.Add(position);
				}
				string text = string.Empty;
				if (dictionary.ContainsKey(c.Comp))
				{
					text = dictionary[c.Comp];
				}
				else
				{
					num++;
					text = TRCDataConvertor.s_strCompTypePrefix + num.ToString();
					dictionary.Add(c.Comp, text);
					traceabilityData.ComponentTypes.Add(new ComponentType
					{
						Id = text,
						Name = c.Comp,
						PackForm = c.PackForm
					});
				}
				PackagingUnit packagingUnit = new PackagingUnit();
				packagingUnit.ComponentTypeId = text;
				packagingUnit.Id = TRCDataConvertor.s_strPackUnitPrefix + c.ID.ToString();
				packagingUnit.Operator = c.Operator;
				packagingUnit.ComponentBarcode = c.Barc1;
				packagingUnit.BatchId = c.Barc2;
				packagingUnit.OriginalQuantity = System.Convert.ToInt32(c.Barc3);
				packagingUnit.PackagingId = c.Barc6;
				TRCDataConvertor.AddPackagingDataIgnoreDuplicates(position.PackagingUnits, packagingUnit, traceabilityData.Panels);
			}
			if (importSpliceEvents)
			{
				foreach (SpliceEvent2_1 current4 in oldTRCData.SpliceEvents)
				{
					traceabilityData.SpliceEvents.Add(new SpliceEvent
					{
						Count = current4.Count,
						Div = current4.Div,
						Loc = current4.Loc,
						Track = current4.Track
					});
				}
			}
			return traceabilityData;
		}

		private static void AddPackagingDataIgnoreDuplicates(List<PackagingUnit> puList, PackagingUnit puNew, List<Panel> panels)
		{
			foreach (PackagingUnit current in puList)
			{
				if (current.PackagingId == puNew.PackagingId)
				{
					string id = puNew.Id;
					string id2 = current.Id;
					if (panels != null)
					{
						foreach (Panel current2 in panels)
						{
							foreach (PanelId current3 in current2.IDs)
							{
								if (current3.Ref == id)
								{
									current3.Ref = id2;
								}
							}
						}
					}
					return;
				}
			}
			puList.Add(puNew);
		}

		public static string RemovePrefixes(string input)
		{
			string result;
			if (string.IsNullOrEmpty(input))
			{
				result = string.Empty;
			}
			else
			{
				int num = input.LastIndexOf('\\');
				if (num >= 0)
				{
					result = input.Substring(num + 1, input.Length - num - 1);
				}
				else
				{
					result = input;
				}
			}
			return result;
		}

		public static bool IsEqualIgnorePrefixesAndConcats(string name1, string name2)
		{
			string text = TRCDataConvertor.RemovePrefixes(name1);
			string text2 = TRCDataConvertor.RemovePrefixes(name2);
			return text == text2 || text.StartsWith(text2) || text2.StartsWith(text);
		}
	}
}
