using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), XmlType(TypeName = "TraceabilityData")]
	[Serializable]
	public class TraceabilityData
	{
		public enum SerializeType
		{
			ITRACE,
			FULL
		}

		protected bool m_bSerialize = false;

		protected TraceabilityData.SerializeType m_SerializeType;

		[XmlIgnore]
		public static string TRACEABILITY_VERSION = "4.0";

		[XmlIgnore]
		private ErrorCodes m_ErrorCodes = null;

		[XmlIgnore]
		private List<Job> m_Jobs = null;

		[XmlIgnore]
		private List<ComponentType> m_ComponentTypes = null;

		[XmlIgnore]
		private List<Location> m_Locations = null;

		[XmlIgnore]
		private List<PackagingUnit> m_PackagingUnits = null;

		[XmlIgnore]
		private List<Consumption> m_Consumptions = null;

		[XmlIgnore]
		private List<Panel> m_Panels = null;

		[XmlIgnore]
		private List<SpliceEvent> m_SpliceEvents = null;

		[XmlIgnore]
		private string m_strVersion;

		[XmlIgnore]
		private int m_nBaseType;

		[XmlIgnore]
		private Accuracy m_nAccuracy;

		[XmlIgnore]
		private string m_strLine;

		[XmlIgnore]
		private Lane m_nLane;

		[XmlIgnore]
		private SubLane m_nSubLane;

		[XmlIgnore]
		private string m_strStation;

		[XmlIgnore]
		private string m_strMachineId;

		[XmlIgnore]
		private string m_strBoardId;

		[XmlIgnore]
		private DateTime m_DateBegin;

		[XmlIgnore]
		private DateTime? m_DateComplete = null;

		[XmlIgnore]
		private DateTime? m_DateCorrelationBegin = null;

		[XmlIgnore]
		private DateTime? m_DateCorrelationEnd = null;

		[XmlIgnore]
		private int m_nErrorLevel;

		[XmlAttribute(AttributeName = "version", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Version
		{
			get
			{
				return this.m_strVersion;
			}
			set
			{
				this.m_strVersion = value;
			}
		}

		[XmlAttribute(AttributeName = "basetype", Form = XmlSchemaForm.Qualified)]
		public BaseType BaseType
		{
			get
			{
				return (BaseType)this.m_nBaseType;
			}
			set
			{
				this.m_nBaseType = (int)value;
			}
		}

		[XmlAttribute(AttributeName = "accuracy", Form = XmlSchemaForm.Qualified)]
		public Accuracy Accuracy
		{
			get
			{
				return this.m_nAccuracy;
			}
			set
			{
				this.m_nAccuracy = value;
			}
		}

		[XmlAttribute(AttributeName = "line", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Line
		{
			get
			{
				return this.m_strLine;
			}
			set
			{
				this.m_strLine = value;
			}
		}

		[XmlIgnore]
		public Lane Lane
		{
			get
			{
				return this.m_nLane;
			}
			set
			{
				this.m_nLane = value;
			}
		}

		[XmlAttribute(AttributeName = "lane", Form = XmlSchemaForm.Qualified)]
		public string __Lane
		{
			get
			{
				string result;
				if (this.m_nLane == Lane.Unknown)
				{
					result = null;
				}
				else
				{
					result = this.m_nLane.ToString();
				}
				return result;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.m_nLane = Lane.Unknown;
				}
				else
				{
					this.m_nLane = (Lane)Enum.Parse(typeof(Lane), value);
				}
			}
		}

		[XmlIgnore]
		public SubLane SubLane
		{
			get
			{
				return this.m_nSubLane;
			}
			set
			{
				this.m_nSubLane = value;
			}
		}

		[XmlAttribute(AttributeName = "sublane", Form = XmlSchemaForm.Qualified)]
		public string __SubLane
		{
			get
			{
				string result;
				if (this.m_nLane == Lane.Unknown)
				{
					result = null;
				}
				else
				{
					result = this.m_nSubLane.ToString();
				}
				return result;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.m_nSubLane = SubLane.None;
				}
				else
				{
					this.m_nSubLane = (SubLane)Enum.Parse(typeof(SubLane), value);
				}
			}
		}

		[XmlAttribute(AttributeName = "station", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Station
		{
			get
			{
				return this.m_strStation;
			}
			set
			{
				this.m_strStation = value;
			}
		}

		[XmlAttribute(AttributeName = "machineID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string MachineID
		{
			get
			{
				return this.m_strMachineId;
			}
			set
			{
				this.m_strMachineId = value;
			}
		}

		[XmlAttribute(AttributeName = "boardID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BoardID
		{
			get
			{
				return this.m_strBoardId;
			}
			set
			{
				this.m_strBoardId = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "dateBegin", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __DateBegin
		{
			get
			{
				return DateTimeHelper.DateToXMLString(this.m_DateBegin);
			}
			set
			{
				this.m_DateBegin = DateTimeHelper.XMLStringToDate(value);
			}
		}

		[XmlIgnore]
		public DateTime DateBegin
		{
			get
			{
				return this.m_DateBegin;
			}
			set
			{
				this.m_DateBegin = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "dateComplete", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __DateComplete
		{
			get
			{
				string result;
				if (!this.m_DateComplete.HasValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_DateComplete.Value);
				}
				return result;
			}
			set
			{
				if (value == null)
				{
					this.m_DateComplete = null;
				}
				else
				{
					this.m_DateComplete = new DateTime?(DateTimeHelper.XMLStringToDate(value));
				}
			}
		}

		[XmlIgnore]
		public DateTime? DateComplete
		{
			get
			{
				return this.m_DateComplete;
			}
			set
			{
				this.m_DateComplete = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "dateCorrelationBegin", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __DateCorrelationBegin
		{
			get
			{
				string result;
				if (!this.m_DateCorrelationBegin.HasValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_DateCorrelationBegin.Value);
				}
				return result;
			}
			set
			{
				if (value == null)
				{
					this.m_DateCorrelationBegin = null;
				}
				else
				{
					this.m_DateCorrelationBegin = new DateTime?(DateTimeHelper.XMLStringToDate(value));
				}
			}
		}

		[XmlIgnore]
		public DateTime? DateCorrelationBegin
		{
			get
			{
				return this.m_DateCorrelationBegin;
			}
			set
			{
				this.m_DateCorrelationBegin = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "dateCorrelationEnd", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __DateCorrelationEnd
		{
			get
			{
				string result;
				if (!this.m_DateCorrelationEnd.HasValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_DateCorrelationEnd.Value);
				}
				return result;
			}
			set
			{
				if (value == null)
				{
					this.m_DateCorrelationEnd = null;
				}
				else
				{
					this.m_DateCorrelationEnd = new DateTime?(DateTimeHelper.XMLStringToDate(value));
				}
			}
		}

		[XmlIgnore]
		public DateTime? DateCorrelationEnd
		{
			get
			{
				return this.m_DateCorrelationEnd;
			}
			set
			{
				this.m_DateCorrelationEnd = value;
			}
		}

		[XmlAttribute(AttributeName = "errorLabel", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int ErrorLabel
		{
			get
			{
				return this.m_nErrorLevel;
			}
			set
			{
				this.m_nErrorLevel = value;
			}
		}

		[XmlIgnore]
		public ErrorCodes ErrorCodes
		{
			get
			{
				ErrorCodes errorCodes;
				if (this.m_ErrorCodes == null)
				{
					this.m_ErrorCodes = new ErrorCodes();
					errorCodes = this.m_ErrorCodes;
				}
				else
				{
					errorCodes = this.m_ErrorCodes;
				}
				return errorCodes;
			}
			set
			{
				this.m_ErrorCodes = value;
			}
		}

		[XmlElement(ElementName = "errors", Form = XmlSchemaForm.Qualified)]
		public ErrorCodes __ErrorCodes
		{
			get
			{
				ErrorCodes result;
				if (this.m_ErrorCodes != null && this.m_ErrorCodes.ErrorCodesList.Count == 0)
				{
					result = null;
				}
				else
				{
					result = this.m_ErrorCodes;
				}
				return result;
			}
			set
			{
				this.m_ErrorCodes = value;
			}
		}

		[XmlElement(Type = typeof(List<Job>), ElementName = "jobs", Form = XmlSchemaForm.Qualified)]
		public List<Job> Jobs
		{
			get
			{
				List<Job> result;
				if (this.m_bSerialize && (this.m_Jobs == null || this.m_Jobs.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_Jobs == null)
					{
						this.m_Jobs = new List<Job>();
					}
					result = this.m_Jobs;
				}
				return result;
			}
			set
			{
				this.m_Jobs = value;
			}
		}

		[XmlElement(Type = typeof(List<Panel>), ElementName = "panels", Form = XmlSchemaForm.Qualified)]
		public List<Panel> Panels
		{
			get
			{
				List<Panel> result;
				if (this.m_bSerialize && (this.m_Panels == null || this.m_Panels.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_Panels == null)
					{
						this.m_Panels = new List<Panel>();
					}
					result = this.m_Panels;
				}
				return result;
			}
			set
			{
				this.m_Panels = value;
			}
		}

		[XmlElement(Type = typeof(List<ComponentType>), ElementName = "componentTypes", Form = XmlSchemaForm.Qualified)]
		public List<ComponentType> ComponentTypes
		{
			get
			{
				List<ComponentType> result;
				if (this.m_bSerialize && (this.m_ComponentTypes == null || this.m_ComponentTypes.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_ComponentTypes == null)
					{
						this.m_ComponentTypes = new List<ComponentType>();
					}
					result = this.m_ComponentTypes;
				}
				return result;
			}
			set
			{
				this.m_ComponentTypes = value;
			}
		}

		[XmlElement(Type = typeof(List<Location>), ElementName = "locations", Form = XmlSchemaForm.Qualified)]
		public List<Location> Locations
		{
			get
			{
				List<Location> result;
				if (this.m_bSerialize && (this.m_Locations == null || this.m_Locations.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_Locations == null)
					{
						this.m_Locations = new List<Location>();
					}
					result = this.m_Locations;
				}
				return result;
			}
			set
			{
				this.m_Locations = value;
			}
		}

		[XmlElement(Type = typeof(List<PackagingUnit>), ElementName = "packagingUnits", Form = XmlSchemaForm.Qualified)]
		public List<PackagingUnit> PackagingUnits
		{
			get
			{
				List<PackagingUnit> result;
				if (this.m_bSerialize && (this.m_PackagingUnits == null || this.m_PackagingUnits.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_PackagingUnits == null)
					{
						this.m_PackagingUnits = new List<PackagingUnit>();
					}
					result = this.m_PackagingUnits;
				}
				return result;
			}
			set
			{
				this.m_PackagingUnits = value;
			}
		}

		[XmlElement(Type = typeof(List<Consumption>), ElementName = "consumptions", Form = XmlSchemaForm.Qualified)]
		public List<Consumption> Consumptions
		{
			get
			{
				List<Consumption> result;
				if (this.m_bSerialize)
				{
					if (this.m_SerializeType == TraceabilityData.SerializeType.ITRACE || this.m_Consumptions == null || this.m_Consumptions.Count == 0)
					{
						result = null;
						return result;
					}
				}
				if (this.m_Consumptions == null)
				{
					this.m_Consumptions = new List<Consumption>();
				}
				result = this.m_Consumptions;
				return result;
			}
			set
			{
				this.m_Consumptions = value;
			}
		}

		[XmlElement(Type = typeof(List<SpliceEvent>), ElementName = "spliceEvents", Form = XmlSchemaForm.Qualified)]
		public List<SpliceEvent> SpliceEvents
		{
			get
			{
				List<SpliceEvent> result;
				if (this.m_bSerialize && (this.m_SpliceEvents == null || this.m_SpliceEvents.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_SpliceEvents == null)
					{
						this.m_SpliceEvents = new List<SpliceEvent>();
					}
					result = this.m_SpliceEvents;
				}
				return result;
			}
			set
			{
				this.m_SpliceEvents = value;
			}
		}

		public TraceabilityData()
		{
			this.m_strVersion = TraceabilityData.TRACEABILITY_VERSION;
			this.m_nBaseType = 0;
			this.m_nLane = Lane.Unknown;
			this.m_nSubLane = SubLane.None;
			this.m_nErrorLevel = 0;
		}

		public static string Serialize(TraceabilityData td, TraceabilityData.SerializeType mode)
		{
			string result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceabilityData));
				using (StringWriter stringWriter = new StringWriter())
				{
					using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
					{
						XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
						xmlSerializerNamespaces.Add("", "");
						td.m_bSerialize = true;
						td.m_SerializeType = mode;
						xmlSerializer.Serialize(xmlWriter, td, xmlSerializerNamespaces);
						td.m_bSerialize = false;
						string text = stringWriter.ToString();
						text = text.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\"?>");
						result = text;
					}
				}
			}
			catch (Exception)
			{
				td.m_bSerialize = false;
				throw;
			}
			finally
			{
				td.m_bSerialize = false;
			}
			return result;
		}

		public string Serialize(TraceabilityData.SerializeType mode)
		{
			return TraceabilityData.Serialize(this, mode);
		}

		public static TraceabilityData Deserialize(string xmlData)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceabilityData));
			TraceabilityData result;
			using (StringReader stringReader = new StringReader(xmlData))
			{
				using (XmlReader xmlReader = new XmlTextReader(stringReader))
				{
					result = (TraceabilityData)xmlSerializer.Deserialize(xmlReader);
				}
			}
			return result;
		}

		public static bool IsValidFromStation(TraceabilityData data, out string errorTxt)
		{
			errorTxt = string.Empty;
			bool result;
			if (string.IsNullOrEmpty(data.Line))
			{
				errorTxt = "Attribute \"Line\" is null or empty";
				result = false;
			}
			else if (string.IsNullOrEmpty(data.Station))
			{
				errorTxt = "Attribute \"Station\" is null or empty";
				result = false;
			}
			else if (data.Jobs.Count != 1)
			{
				errorTxt = "Missing Recipe information";
				result = false;
			}
			else
			{
				DateTime arg_6E_0 = data.DateBegin;
				if (data.DateBegin == DateTime.MinValue)
				{
					errorTxt = "Missing Date Begin2";
					result = false;
				}
				else if (!data.DateComplete.HasValue || data.DateComplete == DateTime.MinValue)
				{
					errorTxt = "Missing Date Complete2";
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		public bool IsValidFromStation(out string errorTxt)
		{
			return TraceabilityData.IsValidFromStation(this, out errorTxt);
		}

		public Location GetLocation(int Loc, string TableId, string Station)
		{
			Location result;
			if (this.m_Locations == null)
			{
				result = null;
			}
			else
			{
				foreach (Location current in this.Locations)
				{
					if (current.IsLocation(Loc, TableId, Station))
					{
						result = current;
						return result;
					}
				}
				result = null;
			}
			return result;
		}

		public void AddLocationSorted(Location loc)
		{
			int num = 0;
			foreach (Location current in this.Locations)
			{
				if (current.Loc > loc.Loc)
				{
					this.Locations.Insert(num, loc);
					return;
				}
				num++;
			}
			this.Locations.Add(loc);
		}

		public bool HasLocation(int locId, string tableId, string station)
		{
			return null != this.GetLocation(locId, tableId, station);
		}

		public void AddError(ErrorStruct errorStruct)
		{
			if (errorStruct != null)
			{
				this.ErrorCodes.ErrorCodesList.Add(errorStruct);
				this.ErrorLabel |= (int)errorStruct.ErrorLevel;
			}
		}

		public void AddReason(string reason, string source, int errorListIndex)
		{
			if (errorListIndex >= this.ErrorCodes.ErrorCodesList.Count)
			{
				throw new IndexOutOfRangeException("The index {0} was out of range. There are {1} errors in the error structure at the moment");
			}
			ErrorStruct errorStruct = this.ErrorCodes.ErrorCodesList[errorListIndex];
			errorStruct.ErrorReasons.Add(new ReasonStruct
			{
				Reason = reason,
				Source = source
			});
		}

		public void AddErrors(List<ErrorStruct> errorStruct)
		{
			if (errorStruct != null)
			{
				foreach (ErrorStruct current in errorStruct)
				{
					this.ErrorCodes.ErrorCodesList.Add(current);
					this.ErrorLabel |= (int)current.ErrorLevel;
				}
			}
		}

		public void AddError(ErrorLevel errorLevel, string reason, string source)
		{
			ErrorStruct errorStruct = new ErrorStruct();
			errorStruct.ErrorLevel = errorLevel;
			errorStruct.ErrorReasons.Add(new ReasonStruct
			{
				Reason = reason,
				Source = source
			});
			this.ErrorCodes.ErrorCodesList.Add(errorStruct);
			this.ErrorLabel |= (int)errorLevel;
		}

		public bool IsEqualHeader(TraceabilityData td2, bool ignoreErrorLabel, bool ignoreEndDate, out string errorText)
		{
			errorText = string.Empty;
			bool result;
			if (this.Accuracy != td2.Accuracy)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Accuracy", this.Accuracy, td2.Accuracy);
				result = false;
			}
			else if (this.BaseType != td2.BaseType)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("BaseType", this.BaseType, td2.BaseType);
				result = false;
			}
			else if (this.BoardID != td2.BoardID)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("BoardID", this.BoardID, td2.BoardID);
				result = false;
			}
			else if (!DateTimeHelper.CompareDateTimes(this.DateBegin, td2.DateBegin))
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("DateBegin", this.DateBegin, td2.DateBegin);
				result = false;
			}
			else
			{
				if (!ignoreEndDate)
				{
					if (!DateTimeHelper.CompareDateTimesNullable(this.DateComplete, td2.DateComplete))
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("DateComplete", this.DateComplete, td2.DateComplete);
						result = false;
						return result;
					}
				}
				if (!DateTimeHelper.CompareDateTimesNullable(this.DateCorrelationBegin, td2.DateCorrelationBegin))
				{
					errorText = TraceabilityDataComparer.CompareAttributeText("DateCorrelationBegin", this.DateCorrelationBegin, td2.DateCorrelationBegin);
					result = false;
				}
				else if (!DateTimeHelper.CompareDateTimesNullable(this.DateCorrelationEnd, td2.DateCorrelationEnd))
				{
					errorText = TraceabilityDataComparer.CompareAttributeText("DateCorrelationEnd", this.DateCorrelationEnd, td2.DateCorrelationEnd);
					result = false;
				}
				else
				{
					if (!ignoreErrorLabel)
					{
						if (this.ErrorLabel != td2.ErrorLabel)
						{
							errorText = TraceabilityDataComparer.CompareAttributeText("ErrorLabel", this.ErrorLabel, td2.ErrorLabel);
							result = false;
							return result;
						}
					}
					if (this.Lane != td2.Lane)
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("Lane", this.Lane, td2.Lane);
						result = false;
					}
					else if (this.SubLane != td2.SubLane)
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("SubLane", this.SubLane, td2.SubLane);
						result = false;
					}
					else if (this.Line != td2.Line)
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("Line", this.Line, td2.Line);
						result = false;
					}
					else if (this.MachineID != td2.MachineID)
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("MachineID", this.MachineID, td2.MachineID);
						result = false;
					}
					else if (this.Station != td2.Station)
					{
						errorText = TraceabilityDataComparer.CompareAttributeText("Station", this.Station, td2.Station);
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		public override string ToString()
		{
			return string.Format("TraceData BoardId={0}, BaseType={1}, Accuracy={2}, Line={3}, Lane={4}, SubLane={5}, DateBegin={6}, DateComplete={7}, Station={8}, MachineId={9}, ErrorLabel={10}", new object[]
			{
				this.BoardID,
				this.BaseType.ToString(),
				this.Accuracy.ToString(),
				this.Line,
				this.Lane.ToString(),
				this.SubLane.ToString(),
				this.DateBegin.ToString(),
				(!this.DateComplete.HasValue) ? "" : this.DateComplete.Value.ToString(),
				this.Station ?? "",
				this.MachineID ?? "",
				this.ErrorLabel.ToString()
			});
		}
	}
}
