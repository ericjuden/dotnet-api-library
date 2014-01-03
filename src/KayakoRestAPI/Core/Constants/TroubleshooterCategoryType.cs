using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TroubleshooterCategoryType
	{
		[XmlEnum("1")]
		Global,

		[XmlEnum("2")]
		Public,

		[XmlEnum("3")]
		Private
	}
}
