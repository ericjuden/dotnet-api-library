using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum CustomFieldFieldType
	{
		[XmlEnum(Name = "1")]
		Text,

		[XmlEnum(Name = "2")]
		TextArea,

		[XmlEnum(Name = "3")]
		Password,

		[XmlEnum(Name = "4")]
		Checkbox,

		[XmlEnum(Name = "5")]
		Radio,

		[XmlEnum(Name = "6")]
		Select,

		[XmlEnum(Name = "7")]
		MultiSelect,

		[XmlEnum(Name = "8")]
		Custom,

		[XmlEnum(Name = "9")]
		LinkedSelectFields,

		[XmlEnum(Name = "1")]
		Date,

		[XmlEnum(Name = "1")]
		File
	}
}
