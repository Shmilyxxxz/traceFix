using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Serializable]
	public class ErrorCodes
	{
		[XmlIgnore]
		private List<ErrorStruct> m_ErrorCodesList;

		[XmlElement(ElementName = "error", Form = XmlSchemaForm.Qualified)]
		public List<ErrorStruct> ErrorCodesList
		{
			get
			{
				return this.m_ErrorCodesList;
			}
			set
			{
				this.m_ErrorCodesList = value;
			}
		}

		public ErrorCodes()
		{
			this.m_ErrorCodesList = new List<ErrorStruct>();
		}

		public static ErrorCodes CreateErrorCode(ErrorLevel errorLevel, string reason, string source)
		{
			ErrorCodes errorCodes = new ErrorCodes();
			ErrorStruct errorStruct = new ErrorStruct();
			errorStruct.ErrorLevel = errorLevel;
			errorStruct.ErrorReasons.Add(new ReasonStruct
			{
				Reason = reason,
				Source = source
			});
			errorCodes.ErrorCodesList.Add(errorStruct);
			return errorCodes;
		}
	}
}
