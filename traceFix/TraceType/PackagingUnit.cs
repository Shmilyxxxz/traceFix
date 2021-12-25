using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ASM.TraceabilityProxy.Service
{
	[EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(ExpandableObjectConverter)), XmlType(TypeName = "packagingUnit")]
	[Serializable]
	public class PackagingUnit
	{
		[XmlIgnore]
		private string m_strId;

		[XmlIgnore]
		private string m_strComponentTypeId;

		[XmlIgnore]
		private string m_strPackagingId;

		[XmlIgnore]
		private string m_strBatchId;

		[XmlIgnore]
		private int? m_BatchQuantity;

		[XmlIgnore]
		private int m_nOriginalQuantity;

		[XmlIgnore]
		private string m_strComponentBarcode;

		[XmlIgnore]
		private string m_strManufacturer;

		[XmlIgnore]
		private string m_strSupplier;

		[XmlIgnore]
		private string m_strSerial;

		[XmlIgnore]
		private string m_strExtra1;

		[XmlIgnore]
		private string m_strExtra2;

		[XmlIgnore]
		private string m_strExtra3;

		[XmlIgnore]
		private DateTime m_ManufactureDate;

		[XmlIgnore]
		private DateTime m_VerifiedDate;

		[XmlIgnore]
		private DateTime m_ExpiryDate;

		[XmlIgnore]
		private string m_strOperator;

		[XmlIgnore]
		private JedecLevel m_MSDLevel;

		[XmlIgnore]
		private DateTime m_MsdOpenDate;

		[XmlIgnore]
		private string m_strComment;

		[XmlIgnore]
		private bool m_bActive;

		[XmlIgnore]
		private int? m_Quantity;

		[XmlIgnore]
		private string m_strBrightnessClass;

		[XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Id
		{
			get
			{
				return this.m_strId;
			}
			set
			{
				this.m_strId = value;
			}
		}

		[XmlAttribute(AttributeName = "componentTypeID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string ComponentTypeId
		{
			get
			{
				return this.m_strComponentTypeId;
			}
			set
			{
				this.m_strComponentTypeId = value;
			}
		}

		[XmlAttribute(AttributeName = "packagingID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string PackagingId
		{
			get
			{
				return this.m_strPackagingId;
			}
			set
			{
				this.m_strPackagingId = value;
			}
		}

		[XmlAttribute(AttributeName = "batchID", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BatchId
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strBatchId))
				{
					result = null;
				}
				else
				{
					result = this.m_strBatchId;
				}
				return result;
			}
			set
			{
				this.m_strBatchId = value;
			}
		}

		[XmlAttribute(AttributeName = "batchQuantity", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __BatchQuantity
		{
			get
			{
				string result;
				if (!this.m_BatchQuantity.HasValue)
				{
					result = null;
				}
				else
				{
					result = this.m_BatchQuantity.ToString();
				}
				return result;
			}
			set
			{
				int value2;
				if (!int.TryParse(value, out value2))
				{
					this.m_BatchQuantity = null;
				}
				else
				{
					this.m_BatchQuantity = new int?(value2);
				}
			}
		}

		[XmlIgnore]
		public int? BatchQuantity
		{
			get
			{
				return this.m_BatchQuantity;
			}
			set
			{
				this.m_BatchQuantity = value;
			}
		}

		[XmlAttribute(AttributeName = "originalQuantity", Form = XmlSchemaForm.Unqualified, DataType = "int")]
		public int OriginalQuantity
		{
			get
			{
				return this.m_nOriginalQuantity;
			}
			set
			{
				this.m_nOriginalQuantity = value;
			}
		}

		[XmlAttribute(AttributeName = "componentBarcode", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string ComponentBarcode
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strComponentBarcode))
				{
					result = null;
				}
				else
				{
					result = this.m_strComponentBarcode;
				}
				return result;
			}
			set
			{
				this.m_strComponentBarcode = value;
			}
		}

		[XmlAttribute(AttributeName = "manufacturer", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Manufacturer
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strManufacturer))
				{
					result = null;
				}
				else
				{
					result = this.m_strManufacturer;
				}
				return result;
			}
			set
			{
				this.m_strManufacturer = value;
			}
		}

		[XmlAttribute(AttributeName = "supplier", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Supplier
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strSupplier))
				{
					result = null;
				}
				else
				{
					result = this.m_strSupplier;
				}
				return result;
			}
			set
			{
				this.m_strSupplier = value;
			}
		}

		[XmlAttribute(AttributeName = "serial", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Serial
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strSerial))
				{
					result = null;
				}
				else
				{
					result = this.m_strSerial;
				}
				return result;
			}
			set
			{
				this.m_strSerial = value;
			}
		}

		[XmlAttribute(AttributeName = "extra1", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Extra1
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strExtra1))
				{
					result = null;
				}
				else
				{
					result = this.m_strExtra1;
				}
				return result;
			}
			set
			{
				this.m_strExtra1 = value;
			}
		}

		[XmlAttribute(AttributeName = "extra2", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Extra2
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strExtra2))
				{
					result = null;
				}
				else
				{
					result = this.m_strExtra2;
				}
				return result;
			}
			set
			{
				this.m_strExtra2 = value;
			}
		}

		[XmlAttribute(AttributeName = "extra3", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Extra3
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strExtra3))
				{
					result = null;
				}
				else
				{
					result = this.m_strExtra3;
				}
				return result;
			}
			set
			{
				this.m_strExtra3 = value;
			}
		}

		[XmlAttribute(AttributeName = "quantity", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __Quantity
		{
			get
			{
				string result;
				if (!this.m_Quantity.HasValue)
				{
					result = null;
				}
				else
				{
					result = this.m_Quantity.ToString();
				}
				return result;
			}
			set
			{
				int value2;
				if (!int.TryParse(value, out value2))
				{
					this.m_Quantity = null;
				}
				else
				{
					this.m_Quantity = new int?(value2);
				}
			}
		}

		[XmlIgnore]
		public int? Quantity
		{
			get
			{
				return this.m_Quantity;
			}
			set
			{
				this.m_Quantity = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "manufactureDate", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __ManufactureDate
		{
			get
			{
				string result;
				if (this.m_ManufactureDate == DateTime.MinValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_ManufactureDate);
				}
				return result;
			}
			set
			{
				this.m_ManufactureDate = DateTimeHelper.XMLStringToDate(value);
			}
		}

		[XmlIgnore]
		public DateTime ManufactureDate
		{
			get
			{
				return this.m_ManufactureDate;
			}
			set
			{
				this.m_ManufactureDate = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "verifiedDate", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __VerifiedDate
		{
			get
			{
				string result;
				if (this.m_VerifiedDate == DateTime.MinValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_VerifiedDate);
				}
				return result;
			}
			set
			{
				this.m_VerifiedDate = DateTimeHelper.XMLStringToDate(value);
			}
		}

		[XmlIgnore]
		public DateTime VerifiedDate
		{
			get
			{
				return this.m_VerifiedDate;
			}
			set
			{
				this.m_VerifiedDate = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "expiryDate", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __ExpiryDate
		{
			get
			{
				string result;
				if (this.m_ExpiryDate == DateTime.MaxValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_ExpiryDate);
				}
				return result;
			}
			set
			{
				this.m_ExpiryDate = DateTimeHelper.XMLStringToDate(value);
			}
		}

		[XmlIgnore]
		public DateTime ExpiryDate
		{
			get
			{
				return this.m_ExpiryDate;
			}
			set
			{
				this.m_ExpiryDate = value;
			}
		}

		[XmlAttribute(AttributeName = "operator", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Operator
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strOperator))
				{
					result = null;
				}
				else
				{
					result = this.m_strOperator;
				}
				return result;
			}
			set
			{
				this.m_strOperator = value;
			}
		}

		[XmlIgnore]
		public JedecLevel MsdLevel
		{
			get
			{
				return this.m_MSDLevel;
			}
			set
			{
				this.m_MSDLevel = value;
			}
		}

		[XmlAttribute(AttributeName = "msdLevel", Form = XmlSchemaForm.Qualified)]
		public string __MsdLevel
		{
			get
			{
				string result;
				if (this.m_MSDLevel == JedecLevel.L0_UNDEFINED || (this.m_MSDLevel == JedecLevel.L1 && this.m_MsdOpenDate == DateTime.MinValue))
				{
					result = null;
				}
				else
				{
					result = this.m_MSDLevel.ToString();
				}
				return result;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.m_MSDLevel = JedecLevel.L0_UNDEFINED;
				}
				else
				{
					this.m_MSDLevel = (JedecLevel)Enum.Parse(typeof(JedecLevel), value.ToUpper());
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), XmlAttribute(AttributeName = "msdOpenDate", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string __MsdOpenDate
		{
			get
			{
				string result;
				if (this.m_MsdOpenDate == DateTime.MinValue)
				{
					result = null;
				}
				else
				{
					result = DateTimeHelper.DateToXMLString(this.m_MsdOpenDate);
				}
				return result;
			}
			set
			{
				this.m_MsdOpenDate = DateTimeHelper.XMLStringToDate(value);
			}
		}

		[XmlIgnore]
		public DateTime MsdOpenDate
		{
			get
			{
				return this.m_MsdOpenDate;
			}
			set
			{
				this.m_MsdOpenDate = value;
			}
		}

		[XmlAttribute(AttributeName = "comment", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string Comment
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strComment))
				{
					result = null;
				}
				else
				{
					result = this.m_strComment;
				}
				return result;
			}
			set
			{
				this.m_strComment = value;
			}
		}

		[XmlAttribute(AttributeName = "active", Form = XmlSchemaForm.Unqualified, DataType = "boolean")]
		public bool Active
		{
			get
			{
				return this.m_bActive;
			}
			set
			{
				this.m_bActive = value;
			}
		}

		[XmlAttribute(AttributeName = "brightnessClass", Form = XmlSchemaForm.Unqualified, DataType = "string")]
		public string BrightnessClass
		{
			get
			{
				string result;
				if (string.IsNullOrEmpty(this.m_strBrightnessClass))
				{
					result = null;
				}
				else
				{
					result = this.m_strBrightnessClass;
				}
				return result;
			}
			set
			{
				this.m_strBrightnessClass = value;
			}
		}

		public PackagingUnit()
		{
			this.m_strPackagingId = string.Empty;
			this.m_VerifiedDate = DateTime.MinValue;
			this.m_ExpiryDate = DateTime.MaxValue;
			this.m_ManufactureDate = DateTime.MinValue;
			this.m_MsdOpenDate = DateTime.MinValue;
			this.m_bActive = true;
		}

		public override string ToString()
		{
			string text = "Id=";
			if (string.IsNullOrEmpty(this.m_strId))
			{
				text += "<undefined>";
			}
			else
			{
				text += this.m_strId;
			}
			return text;
		}

		public bool IsEqual(PackagingUnit pu2, out string errorText)
		{
			errorText = string.Empty;
			bool result;
			if (this.Active != pu2.Active)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Active", this.Active, pu2.Active);
				result = false;
			}
			else if (this.BatchId != pu2.BatchId)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("BatchId", this.BatchId, pu2.BatchId);
				result = false;
			}
			else if (this.BatchQuantity != pu2.BatchQuantity)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("BatchQuantity", this.BatchQuantity, pu2.BatchQuantity);
				result = false;
			}
			else if (this.Comment != pu2.Comment)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Comment", this.Comment, pu2.Comment);
				result = false;
			}
			else if (this.ComponentBarcode != pu2.ComponentBarcode)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("ComponentBarcode", this.ComponentBarcode, pu2.ComponentBarcode);
				result = false;
			}
			else if (!DateTimeHelper.CompareDateTimes(this.ExpiryDate, pu2.ExpiryDate))
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("ExpiryDate", this.ExpiryDate, pu2.ExpiryDate);
				result = false;
			}
			else if (this.Extra1 != pu2.Extra1)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Extra1", this.Extra1, pu2.Extra1);
				result = false;
			}
			else if (this.Extra2 != pu2.Extra2)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Extra2", this.Extra2, pu2.Extra2);
				result = false;
			}
			else if (this.Extra3 != pu2.Extra3)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Extra3", this.Extra3, pu2.Extra3);
				result = false;
			}
			else if (!DateTimeHelper.CompareDateTimes(this.ManufactureDate, pu2.ManufactureDate))
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("ManufactureDate", this.ManufactureDate, pu2.ManufactureDate);
				result = false;
			}
			else if (this.Manufacturer != pu2.Manufacturer)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Manufacturer", this.Manufacturer, pu2.Manufacturer);
				result = false;
			}
			else if (this.MsdLevel != pu2.MsdLevel)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("MsdLevel", this.MsdLevel, pu2.MsdLevel);
				result = false;
			}
			else if (!DateTimeHelper.CompareDateTimes(this.MsdOpenDate, pu2.MsdOpenDate))
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("MsdOpenDate", this.MsdOpenDate, pu2.MsdOpenDate);
				result = false;
			}
			else if (this.Operator != pu2.Operator)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Operator", this.Operator, pu2.Operator);
				result = false;
			}
			else if (this.Quantity != pu2.Quantity)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Quantity", this.Quantity, pu2.Quantity);
				result = false;
			}
			else if (this.OriginalQuantity != pu2.OriginalQuantity)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("OriginalQuantity", this.OriginalQuantity, pu2.OriginalQuantity);
				result = false;
			}
			else if (this.PackagingId != pu2.PackagingId)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("PackagingId", this.PackagingId, pu2.PackagingId);
				result = false;
			}
			else if (this.Serial != pu2.Serial)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Serial", this.Serial, pu2.Serial);
				result = false;
			}
			else if (this.Supplier != pu2.Supplier)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("Supplier", this.Supplier, pu2.Supplier);
				result = false;
			}
			else if (this.BrightnessClass != pu2.BrightnessClass)
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("BrightnessClass", this.BrightnessClass, pu2.BrightnessClass);
				result = false;
			}
			else if (!DateTimeHelper.CompareDateTimes(this.VerifiedDate, pu2.VerifiedDate))
			{
				errorText = TraceabilityDataComparer.CompareAttributeText("VerifiedDate", this.VerifiedDate, pu2.VerifiedDate);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
