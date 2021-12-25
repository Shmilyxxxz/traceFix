using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[Serializable]
	public class ErrorStruct
	{
		[XmlIgnore]
		private List<ReasonStruct> m_ErrorReasons;

		[XmlIgnore]
		private ErrorLevel m_ErrorLevel;

		[XmlElement(ElementName = "reason", Form = XmlSchemaForm.Qualified)]
		public List<ReasonStruct> ErrorReasons
		{
			get
			{
				return this.m_ErrorReasons;
			}
			set
			{
				this.m_ErrorReasons = value;
			}
		}

		[XmlAttribute(AttributeName = "error", Form = XmlSchemaForm.Qualified)]
		public ErrorLevel ErrorLevel
		{
			get
			{
				return this.m_ErrorLevel;
			}
			set
			{
				this.m_ErrorLevel = value;
			}
		}

		public ErrorStruct()
		{
			this.ErrorReasons = new List<ReasonStruct>();
			this.ErrorLevel = ErrorLevel.DEFAULT_ERROR;
		}

		public static ErrorStruct CreateErrorStruct(ErrorLevel el, string reason, string source)
		{
			return new ErrorStruct
			{
				ErrorLevel = el,
				ErrorReasons = 
				{
					new ReasonStruct
					{
						Reason = reason,
						Source = source
					}
				}
			};
		}
	}
}
