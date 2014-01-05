using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum KnowledgebaseCategoryType
	{
		[XmlEnum(Name = "1")]
		Inherit,

		[XmlEnum(Name = "2")]
		Global,

		[XmlEnum(Name = "3")]
		Public,

		[XmlEnum(Name = "4")]
		Private
	}
}
