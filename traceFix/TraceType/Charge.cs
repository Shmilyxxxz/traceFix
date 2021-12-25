using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "Charge")]
	[Serializable]
	public class Charge
	{
		[XmlIgnore]
		private int m_nID;

		[XmlIgnore]
		private string m_strComp;

		[XmlIgnore]
		private string m_strBarc1;

		[XmlIgnore]
		private string m_strBarc2;

		[XmlIgnore]
		private string m_strBarc3;

		[XmlIgnore]
		private string m_strBarc4;

		[XmlIgnore]
		private string m_strBarc5;

		[XmlIgnore]
		private string m_strBarc6;

		[XmlIgnore]
		private int m_nContSize;

		[XmlIgnore]
		private string m_strPackForm;

		[XmlIgnore]
		private string m_tableID;

		[XmlIgnore]
		private string m_strOperator;

		[XmlIgnore]
		private int m_nLoc;

		[XmlIgnore]
		private int m_nTrack;

		[XmlIgnore]
		private int m_nDiv;

		[XmlIgnore]
		private int m_nMTCId;

		[XmlIgnore]
		private int m_nMTCLoc;

		[XmlIgnore]
		private int m_nMTCTower;

		[XmlIgnore]
		private int m_nMTCTray;

		[XmlIgnore]
		private int m_nMTCDiv;

		[XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int ID
		{
			get
			{
				return this.m_nID;
			}
			set
			{
				this.m_nID = value;
			}
		}

		[XmlAttribute(AttributeName = "comp", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Comp
		{
			get
			{
				return this.m_strComp;
			}
			set
			{
				this.m_strComp = value;
			}
		}

		[XmlAttribute(AttributeName = "barc1", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc1
		{
			get
			{
				return this.m_strBarc1;
			}
			set
			{
				this.m_strBarc1 = value;
			}
		}

		[XmlAttribute(AttributeName = "barc2", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc2
		{
			get
			{
				return this.m_strBarc2;
			}
			set
			{
				this.m_strBarc2 = value;
			}
		}

		[XmlAttribute(AttributeName = "barc3", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc3
		{
			get
			{
				return this.m_strBarc3;
			}
			set
			{
				this.m_strBarc3 = value;
			}
		}

		[XmlAttribute(AttributeName = "barc4", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc4
		{
			get
			{
				return this.m_strBarc4;
			}
			set
			{
				this.m_strBarc4 = value;
			}
		}

		[XmlAttribute(AttributeName = "barc5", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc5
		{
			get
			{
				return this.m_strBarc5;
			}
			set
			{
				this.m_strBarc5 = value;
			}
		}

		[XmlAttribute(AttributeName = "barc6", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Barc6
		{
			get
			{
				return this.m_strBarc6;
			}
			set
			{
				this.m_strBarc6 = value;
			}
		}

		[XmlAttribute(AttributeName = "contSize", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int ContSize
		{
			get
			{
				return this.m_nContSize;
			}
			set
			{
				this.m_nContSize = value;
			}
		}

		[XmlAttribute(AttributeName = "packForm", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string PackForm
		{
			get
			{
				return this.m_strPackForm;
			}
			set
			{
				this.m_strPackForm = value;
			}
		}

		[XmlAttribute(AttributeName = "tableID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string TableID
		{
			get
			{
				return this.m_tableID;
			}
			set
			{
				this.m_tableID = value;
			}
		}

		[XmlAttribute(AttributeName = "operator", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Operator
		{
			get
			{
				return this.m_strOperator;
			}
			set
			{
				this.m_strOperator = value;
			}
		}

		[XmlAttribute(AttributeName = "loc", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Loc
		{
			get
			{
				return this.m_nLoc;
			}
			set
			{
				this.m_nLoc = value;
			}
		}

		[XmlAttribute(AttributeName = "track", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Track
		{
			get
			{
				return this.m_nTrack;
			}
			set
			{
				this.m_nTrack = value;
			}
		}

		[XmlAttribute(AttributeName = "div", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Div
		{
			get
			{
				return this.m_nDiv;
			}
			set
			{
				this.m_nDiv = value;
			}
		}

		[XmlAttribute(AttributeName = "MTCid", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int MTCId
		{
			get
			{
				return this.m_nMTCId;
			}
			set
			{
				this.m_nMTCId = value;
			}
		}

		[XmlAttribute(AttributeName = "MTCloc", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int MTCLoc
		{
			get
			{
				return this.m_nMTCLoc;
			}
			set
			{
				this.m_nMTCLoc = value;
			}
		}

		[XmlAttribute(AttributeName = "MTCtower", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int MTCTower
		{
			get
			{
				return this.m_nMTCTower;
			}
			set
			{
				this.m_nMTCTower = value;
			}
		}

		[XmlAttribute(AttributeName = "MTCtray", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int MTCTray
		{
			get
			{
				return this.m_nMTCTray;
			}
			set
			{
				this.m_nMTCTray = value;
			}
		}

		[XmlAttribute(AttributeName = "MTCdiv", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int MTCDiv
		{
			get
			{
				return this.m_nMTCDiv;
			}
			set
			{
				this.m_nMTCDiv = value;
			}
		}
	}
}
