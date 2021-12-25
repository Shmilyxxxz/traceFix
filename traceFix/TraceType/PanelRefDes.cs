using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "RefDes")]
	[Serializable]
	public class PanelRefDes
	{
		[XmlIgnore]
		private string m_strName;

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Name
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

		public override string ToString()
		{
			string result;
			if (string.IsNullOrEmpty(this.m_strName))
			{
				result = "<unknown refdes>";
			}
			else
			{
				result = this.Name;
			}
			return result;
		}
	}
}
