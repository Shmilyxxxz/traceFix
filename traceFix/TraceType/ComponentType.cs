using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), XmlType(TypeName = "componentType")]
	[Serializable]
	public class ComponentType
	{
		[XmlIgnore]
		private string m_strID;

		[XmlIgnore]
		private string m_strName;

		[XmlIgnore]
		private string m_strPackForm;

		[XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Id
		{
			get
			{
				return this.m_strID;
			}
			set
			{
				this.m_strID = value;
			}
		}

		[XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified, DataType = "string")]
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

		public override string ToString()
		{
			string result;
			if (string.IsNullOrEmpty(this.m_strName))
			{
				result = "<unknown component type>";
			}
			else
			{
				result = this.m_strName;
			}
			return result;
		}
	}
}
