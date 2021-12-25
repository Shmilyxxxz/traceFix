using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "ref")]
	[Serializable]
	public class PanelId2_1
	{
		[XmlIgnore]
		private List<string> m_RefDes;

		[XmlIgnore]
		private string m_strRef;

		[XmlElement(ElementName = "RefDes", Type = typeof(string))]
		public List<string> IDs
		{
			get
			{
				if (this.m_RefDes == null)
				{
					this.m_RefDes = new List<string>();
				}
				return this.m_RefDes;
			}
			set
			{
				this.m_RefDes = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified, DataType = "IDREFS")]
		public string Ref
		{
			get
			{
				return this.m_strRef;
			}
			set
			{
				this.m_strRef = value;
			}
		}

		public override string ToString()
		{
			string result;
			if (string.IsNullOrEmpty(this.m_strRef))
			{
				result = "<unknown id>";
			}
			else
			{
				string text = "Charge " + this.m_strRef + " (";
				if (this.m_RefDes == null)
				{
					text += "0";
				}
				else
				{
					text += this.m_RefDes.Count;
				}
				text += " RefDes)";
				result = text;
			}
			return result;
		}
	}
}
