using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "consumption")]
	[Serializable]
	public class Consumption
	{
		[XmlIgnore]
		private string m_strPackagingUID;

		[XmlIgnore]
		private short m_nAccessTotal;

		[XmlIgnore]
		private short m_nRejectIdent;

		[XmlIgnore]
		private short m_nRejectVacuum;

		[XmlIgnore]
		private short m_nTrackEmpty;

		[XmlAttribute(AttributeName = "packagingID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string PackagingUID
		{
			get
			{
				return this.m_strPackagingUID;
			}
			set
			{
				this.m_strPackagingUID = value;
			}
		}

		[XmlAttribute(AttributeName = "accessTotal", Form = XmlSchemaForm.Unqualified, DataType = "short")]
		public short AccessTotal
		{
			get
			{
				return this.m_nAccessTotal;
			}
			set
			{
				this.m_nAccessTotal = value;
			}
		}

		[XmlAttribute(AttributeName = "rejectIdent", Form = XmlSchemaForm.Unqualified, DataType = "short")]
		public short RejectIdent
		{
			get
			{
				return this.m_nRejectIdent;
			}
			set
			{
				this.m_nRejectIdent = value;
			}
		}

		[XmlAttribute(AttributeName = "rejectVacuum", Form = XmlSchemaForm.Unqualified, DataType = "short")]
		public short RejectVacuum
		{
			get
			{
				return this.m_nRejectVacuum;
			}
			set
			{
				this.m_nRejectVacuum = value;
			}
		}

		[XmlAttribute(AttributeName = "trackEmpty", Form = XmlSchemaForm.Unqualified, DataType = "short")]
		public short TrackEmpty
		{
			get
			{
				return this.m_nTrackEmpty;
			}
			set
			{
				this.m_nTrackEmpty = value;
			}
		}

		public Consumption()
		{
			this.m_strPackagingUID = string.Empty;
			this.m_nAccessTotal = 0;
			this.m_nRejectIdent = 0;
			this.m_nRejectVacuum = 0;
			this.m_nTrackEmpty = 0;
		}

		public override string ToString()
		{
			return string.Format("PackagingID={0}, AccessTotal={1}, RejectIdent={2}, RejectVacuum={3}, TrackEmpty={4}", new object[]
			{
				this.m_strPackagingUID,
				this.m_nAccessTotal,
				this.m_nRejectIdent,
				this.m_nRejectVacuum,
				this.m_nTrackEmpty
			});
		}
	}
}
