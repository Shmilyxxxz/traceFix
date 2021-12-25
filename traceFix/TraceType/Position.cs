using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), XmlType(TypeName = "position")]
	[Serializable]
	public class Position
	{
		[XmlIgnore]
		private List<PackagingUnit> m_PackagingUnits;

		[XmlIgnore]
		private int m_nTrack;

		[XmlIgnore]
		private int m_nTower;

		[XmlIgnore]
		private int m_nLevel;

		[XmlIgnore]
		private int m_nDiv;

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

		[XmlIgnore]
		public int Tower
		{
			get
			{
				return this.m_nTower;
			}
			set
			{
				this.m_nTower = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "tower", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __Tower
		{
			get
			{
				string result;
				if (this.m_nTower < 1)
				{
					result = null;
				}
				else
				{
					result = this.m_nTower.ToString();
				}
				return result;
			}
			set
			{
				this.m_nTower = int.Parse(value);
			}
		}

		[XmlIgnore]
		public int Level
		{
			get
			{
				return this.m_nLevel;
			}
			set
			{
				this.m_nLevel = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "level", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __Level
		{
			get
			{
				string result;
				if (this.m_nLevel < 1)
				{
					result = null;
				}
				else
				{
					result = this.m_nLevel.ToString();
				}
				return result;
			}
			set
			{
				this.m_nLevel = int.Parse(value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlElement(Type = typeof(PackagingUnit), ElementName = "packagingUnit", IsNullable = false, Form = XmlSchemaForm.Qualified)]
		public List<PackagingUnit> PackagingUnits
		{
			get
			{
				if (this.m_PackagingUnits == null)
				{
					this.m_PackagingUnits = new List<PackagingUnit>();
				}
				return this.m_PackagingUnits;
			}
			set
			{
				this.m_PackagingUnits = value;
			}
		}

		public Position()
		{
			this.m_nTrack = -1;
			this.m_nTower = -1;
			this.m_nLevel = -1;
			this.m_nDiv = -1;
		}

		public override string ToString()
		{
			string text = string.Format("Position Tr{0} D{1} To{2} Le{3} (", new object[]
			{
				this.m_nTrack,
				this.m_nDiv,
				this.m_nTower,
				this.m_nLevel
			});
			if (this.m_PackagingUnits == null)
			{
				text += "0";
			}
			else
			{
				text += this.m_PackagingUnits.Count;
			}
			return text + " PUs)";
		}

		public bool IsPosition(int pTrack, int pDivision, int pTower, int pLevel)
		{
			return this.Track == pTrack && this.Div == pDivision && this.Tower == pTower && this.Level == pLevel;
		}

		public bool IsEqualPosition(Position right)
		{
			return this.IsPosition(right.Track, right.Div, right.Tower, right.Level);
		}
	}
}
