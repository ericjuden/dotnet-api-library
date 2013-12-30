using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum NewsItemType
	{
		[XmlEnum(Name = "1")]
		Global,

		[XmlEnum(Name = "2")]
		Public,

		[XmlEnum(Name = "3")]
		Private
	}
}
