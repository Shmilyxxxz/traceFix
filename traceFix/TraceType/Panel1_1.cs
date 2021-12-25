using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "panel")]
	[Serializable]
	public class Panel1_1
	{
		[XmlIgnore]
		private List<int> m_Ids;

		[XmlIgnore]
		private string m_strName;

		[XmlIgnore]
		private string m_strPanelId;

		[XmlIgnore]
		private bool m_bOmit;

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlElement(Type = typeof(int), ElementName = "id")]
		public List<int> IDs
		{
			get
			{
				if (this.m_Ids == null)
				{
					this.m_Ids = new List<int>();
				}
				return this.m_Ids;
			}
			set
			{
				this.m_Ids = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string PanelName
		{
			get
			{
				return this.m_strName;
			}
			set
			{
				this.m_strName = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "panelID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string PanelID
		{
			get
			{
				return this.m_strPanelId;
			}
			set
			{
				this.m_strPanelId = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "omit", Form = XmlSchemaForm.Unqualified, DataType = "boolean")]
		public bool Omit
		{
			get
			{
				return this.m_bOmit;
			}
			set
			{
				this.m_bOmit = value;
			}
		}

		public override string ToString()
		{
			string result;
			if (string.IsNullOrEmpty(this.m_strName))
			{
				result = "<unknown panel>";
			}
			else
			{
				string text = this.PanelName + " (";
				if (this.m_Ids == null)
				{
					text += "0";
				}
				else
				{
					text += this.m_Ids.Count;
				}
				text += " Charges)";
				result = text;
			}
			return result;
		}
	}
}
