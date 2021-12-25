using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "spliceEvent")]
	[Serializable]
	public class SpliceEvent
	{
		[XmlIgnore]
		private int m_nLoc;

		[XmlIgnore]
		private int m_nTrack;

		[XmlIgnore]
		private int m_nDiv;

		[XmlIgnore]
		private int m_nCount;

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "loc", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Loc
		{
			get
			{
				return this.m_nLoc;
			}
			set
			{
				this.m_nLoc = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "track", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Track
		{
			get
			{
				return this.m_nTrack;
			}
			set
			{
				this.m_nTrack = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "div", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Div
		{
			get
			{
				return this.m_nDiv;
			}
			set
			{
				this.m_nDiv = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "count", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int Count
		{
			get
			{
				return this.m_nCount;
			}
			set
			{
				this.m_nCount = value;
			}
		}

		public SpliceEvent()
		{
			this.m_nLoc = 0;
			this.m_nTrack = 0;
			this.m_nDiv = 0;
			this.m_nCount = 0;
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"SpliceEvent Loc=",
				this.m_nLoc,
				" Track=",
				this.m_nTrack,
				" Div=",
				this.m_nDiv
			});
		}
	}
}
