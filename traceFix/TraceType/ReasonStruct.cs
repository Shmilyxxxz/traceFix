using System;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[Serializable]
	public class ReasonStruct
	{
		[XmlIgnore]
		private string m_strReason;

		[XmlIgnore]
		private string m_strSource;

		[XmlAttribute(AttributeName = "source")]
		public string Source
		{
			get
			{
				return this.m_strSource;
			}
			set
			{
				this.m_strSource = value;
			}
		}

		[XmlAttribute(AttributeName = "reason")]
		public string Reason
		{
			get
			{
				return this.m_strReason;
			}
			set
			{
				this.m_strReason = value;
			}
		}

		public ReasonStruct()
		{
			this.Source = string.Empty;
			this.Reason = string.Empty;
		}
	}
}
