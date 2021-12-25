using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), XmlType(TypeName = "job")]
	[Serializable]
	public class Job
	{
		[XmlIgnore]
		private string m_strRecipe;

		[XmlIgnore]
		private string m_strSetup;

		[XmlIgnore]
		private string m_strOrderId;

		[XmlIgnore]
		private string m_strBoardName;

		[XmlIgnore]
		private BoardSide m_nBoardSide;

		[XmlAttribute(AttributeName = "recipe", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Recipe
		{
			get
			{
				return this.m_strRecipe;
			}
			set
			{
				this.m_strRecipe = value;
			}
		}

		[XmlAttribute(AttributeName = "setup", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Setup
		{
			get
			{
				return this.m_strSetup;
			}
			set
			{
				this.m_strSetup = value;
			}
		}

		[XmlAttribute(AttributeName = "orderID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string OrderID
		{
			get
			{
				return this.m_strOrderId;
			}
			set
			{
				this.m_strOrderId = value;
			}
		}

		[XmlAttribute(AttributeName = "boardName", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BoardName
		{
			get
			{
				return this.m_strBoardName;
			}
			set
			{
				this.m_strBoardName = value;
			}
		}

		[XmlIgnore]
		public BoardSide BoardSide
		{
			get
			{
				return this.m_nBoardSide;
			}
			set
			{
				this.m_nBoardSide = value;
			}
		}

		[XmlAttribute(AttributeName = "boardSide", Form = XmlSchemaForm.Qualified)]
		public string __BoardSide
		{
			get
			{
				string result;
				if (this.m_nBoardSide == BoardSide.Unknown)
				{
					result = null;
				}
				else
				{
					result = this.m_nBoardSide.ToString();
				}
				return result;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.m_nBoardSide = BoardSide.Unknown;
				}
				else
				{
					this.m_nBoardSide = (BoardSide)Enum.Parse(typeof(BoardSide), value);
				}
			}
		}

		public Job()
		{
			this.m_nBoardSide = BoardSide.Unknown;
		}

		public override string ToString()
		{
			string result;
			if (string.IsNullOrEmpty(this.m_strRecipe))
			{
				result = "<unknown job>";
			}
			else
			{
				result = string.Format("Recipe: {0} Setup: {1}", this.m_strRecipe, this.m_strSetup);
			}
			return result;
		}

		public bool IsEqual(Job right)
		{
			return this.BoardName == right.BoardName && this.BoardSide == right.BoardSide && this.OrderID == right.OrderID && this.Recipe == right.Recipe && this.Setup == right.Setup;
		}

		public override bool Equals(object obj)
		{
			return this.IsEqual((Job)obj);
		}

	    protected bool Equals(Job other)
	    {
	        return string.Equals(m_strRecipe, other.m_strRecipe) && string.Equals(m_strSetup, other.m_strSetup) && string.Equals(m_strOrderId, other.m_strOrderId) && string.Equals(m_strBoardName, other.m_strBoardName) && m_nBoardSide == other.m_nBoardSide;
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            var hashCode = (m_strRecipe != null ? m_strRecipe.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (m_strSetup != null ? m_strSetup.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (m_strOrderId != null ? m_strOrderId.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (m_strBoardName != null ? m_strBoardName.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (int) m_nBoardSide;
	            return hashCode;
	        }
	    }
	}
}
