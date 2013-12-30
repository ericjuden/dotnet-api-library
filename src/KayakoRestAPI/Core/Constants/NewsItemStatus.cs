using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum NewsItemStatus
	{
		[XmlEnum("1")]
		Draft,

		[XmlEnum("2")]
		Published
	}
}
