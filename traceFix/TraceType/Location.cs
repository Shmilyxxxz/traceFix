using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), XmlType(TypeName = "location")]
	[Serializable]
	public class Location
	{
		[XmlIgnore]
		private List<Position> m_Positions;

		[XmlIgnore]
		private string m_strTableID = null;

		[XmlIgnore]
		private int m_nLoc;

		[XmlIgnore]
		private string m_strStation = null;

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

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "tableID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string TableID
		{
			get
			{
				return this.m_strTableID;
			}
			set
			{
				if (value == string.Empty)
				{
					this.m_strTableID = null;
				}
				else
				{
					this.m_strTableID = value;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlAttribute(AttributeName = "station", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Station
		{
			get
			{
				return this.m_strStation;
			}
			set
			{
				if (value == string.Empty)
				{
					this.m_strStation = null;
				}
				else
				{
					this.m_strStation = value;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced), XmlElement(Type = typeof(Position), ElementName = "position", IsNullable = false, Form = XmlSchemaForm.Qualified)]
		public List<Position> Positions
		{
			get
			{
				if (this.m_Positions == null)
				{
					this.m_Positions = new List<Position>();
				}
				return this.m_Positions;
			}
			set
			{
				this.m_Positions = value;
			}
		}

		public Location()
		{
			this.m_nLoc = 0;
			this.m_strTableID = string.Empty;
			this.m_strStation = string.Empty;
		}

		public override string ToString()
		{
			string text = string.Format("Location {0} Table {1} Station {2} (", this.m_nLoc, this.m_strTableID, this.m_strStation);
			if (this.m_Positions == null)
			{
				text += "0";
			}
			else
			{
				text += this.m_Positions.Count;
			}
			return text + " Positions)";
		}

		public bool IsLocation(int pLoc, string pTableId, string pStation)
		{
			if (pTableId == string.Empty)
			{
				pTableId = null;
			}
			if (pStation == string.Empty)
			{
				pStation = null;
			}
			bool result;
			if (pTableId != null)
			{
				result = (pTableId == this.TableID && pStation == this.Station && pLoc == this.Loc);
			}
			else
			{
				result = (this.Loc == pLoc && pStation == this.Station);
			}
			return result;
		}

		public bool IsEqualLocation(Location right)
		{
			return this.Loc == right.Loc && this.Station == right.Station;
		}

		public Position GetPosition(int Track, int Div)
		{
			return this.GetPosition(Track, -1, -1, Div);
		}

		public Position GetPosition(int Tower, int Level, int Div)
		{
			return this.GetPosition(-1, Tower, Level, Div);
		}

		public Position GetPosition(int Track, int Tower, int Level, int Div)
		{
			Position result;
			if (this.m_Positions == null)
			{
				result = null;
			}
			else
			{
				foreach (Position current in this.m_Positions)
				{
					if (current.IsPosition(Track, Div, Tower, Level))
					{
						result = current;
						return result;
					}
				}
				result = null;
			}
			return result;
		}

		public void AddPositionSorted(Position pos)
		{
			int num = 0;
			foreach (Position current in this.Positions)
			{
				if (current.Track > pos.Track || (current.Track == pos.Track && current.Div > pos.Div))
				{
					this.Positions.Insert(num, pos);
					return;
				}
				num++;
			}
			this.Positions.Add(pos);
		}
	}
}
