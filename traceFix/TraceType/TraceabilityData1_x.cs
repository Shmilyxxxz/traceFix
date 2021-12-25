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
	public class TraceabilityData1_x
	{
		protected bool m_bSerialize = false;

		[XmlIgnore]
		private string m_strVersion;

		[XmlIgnore]
		private string m_strLine;

		[XmlIgnore]
		private string m_strStation;

		[XmlIgnore]
		private string m_strJob;

		[XmlIgnore]
		private string m_strBoardID;

		[XmlIgnore]
		private string m_strBoardName;

		[XmlIgnore]
		private DateTime m_DateBegin;

		[XmlIgnore]
		private DateTime? m_DateComplete = null;

		[XmlIgnore]
		private int m_nErrorLevel;

		[XmlIgnore]
		private string m_strSetup;

		[XmlIgnore]
		private List<Panel1_1> m_Panels = null;

		[XmlIgnore]
		private List<Charge> m_Charges = null;

		[XmlIgnore]
		private List<SpliceEvent2_1> m_SpliceEvents = null;

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

		[XmlAttribute(AttributeName = "job", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Job
		{
			get
			{
				return this.m_strJob;
			}
			set
			{
				this.m_strJob = value;
			}
		}

		[XmlAttribute(AttributeName = "boardID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BoardID
		{
			get
			{
				return this.m_strBoardID;
			}
			set
			{
				this.m_strBoardID = value;
			}
		}

		[XmlAttribute(AttributeName = "boardName", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BoardName
		{
			get
			{
				return this.m_strBoardName;
			}
			set
			{
				this.m_strBoardName = value;
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
				this.m_DateBegin = DateTimeHelper.XMLStringToDateWithoutTimeZone(value);
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
					this.m_DateComplete = new DateTime?(DateTimeHelper.XMLStringToDateWithoutTimeZone(value));
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

		[XmlAttribute(AttributeName = "errorLabel", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int ErrorLevel
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

		[XmlAttribute(AttributeName = "setup", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Setup
		{
			get
			{
				return this.m_strSetup;
			}
			set
			{
				this.m_strSetup = value;
			}
		}

		[XmlElement(ElementName = "panel", Type = typeof(Panel1_1))]
		public List<Panel1_1> Panels
		{
			get
			{
				return this.m_Panels;
			}
			set
			{
				this.m_Panels = value;
			}
		}

		[XmlElement(ElementName = "charge", Type = typeof(Charge))]
		public List<Charge> Charges
		{
			get
			{
				return this.m_Charges;
			}
			set
			{
				this.m_Charges = value;
			}
		}

		[XmlElement(Type = typeof(SpliceEvent2_1), ElementName = "spliceEvents")]
		public List<SpliceEvent2_1> SpliceEvents
		{
			get
			{
				List<SpliceEvent2_1> result;
				if (this.m_bSerialize && (this.m_SpliceEvents == null || this.m_SpliceEvents.Count == 0))
				{
					result = null;
				}
				else
				{
					if (this.m_SpliceEvents == null)
					{
						this.m_SpliceEvents = new List<SpliceEvent2_1>();
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

		public TraceabilityData1_x()
		{
			this.m_strVersion = "1.x";
			this.m_nErrorLevel = 0;
		}

		public static string Serialize(TraceabilityData1_x td)
		{
			string result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceabilityData1_x));
				using (StringWriter stringWriter = new StringWriter())
				{
					using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
					{
						td.m_bSerialize = true;
						xmlSerializer.Serialize(xmlWriter, td);
						td.m_bSerialize = false;
						string text = stringWriter.ToString();
						text = text.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\"?>");
						text = text.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
						result = text;
					}
				}
			}
			catch (Exception)
			{
				td.m_bSerialize = false;
				throw;
			}
			return result;
		}

		public string Serialize()
		{
			return TraceabilityData1_x.Serialize(this);
		}

		public static TraceabilityData1_x Deserialize(string xmlData)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceabilityData1_x));
			TraceabilityData1_x result;
			using (StringReader stringReader = new StringReader(xmlData))
			{
				using (XmlReader xmlReader = new XmlTextReader(stringReader))
				{
					result = (TraceabilityData1_x)xmlSerializer.Deserialize(xmlReader);
				}
			}
			return result;
		}
	}
}
