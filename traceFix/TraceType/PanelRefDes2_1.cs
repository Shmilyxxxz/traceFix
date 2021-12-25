using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "refdes")]
	[Serializable]
	public class PanelRefDes2_1
	{
		[XmlIgnore]
		private string m_strName;

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlElement(Type = typeof(string), ElementName = "refdes", Form = XmlSchemaForm.Unqualified)]
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
