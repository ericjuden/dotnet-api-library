using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum NewsCategoryVisibilityType
	{
		[XmlEnum(Name = "public")]
		Public,

		[XmlEnum(Name = "private")]
		Private
	}
}
