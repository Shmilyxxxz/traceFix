using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "id")]
	[Serializable]
	public class PanelId
	{
		[XmlIgnore]
		private List<PanelRefDes> m_RefDes = null;

		[XmlIgnore]
		private string m_strRef;

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlElement(Type = typeof(PanelRefDes), ElementName = "RefDes", Form = XmlSchemaForm.Qualified)]
		public List<PanelRefDes> IDs
		{
			get
			{
				if (this.m_RefDes == null)
				{
					this.m_RefDes = new List<PanelRefDes>();
				}
				return this.m_RefDes;
			}
			set
			{
				this.m_RefDes = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "ref", Form = XmlSchemaForm.Unqualified, DataType = "IDREFS")]
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
