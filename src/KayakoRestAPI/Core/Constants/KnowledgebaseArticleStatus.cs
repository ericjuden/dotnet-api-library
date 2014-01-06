using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum KnowledgebaseArticleStatus
	{
		[XmlEnum(Name = "1")]
		Published,

		[XmlEnum(Name = "2")]
		Draft
	}
}
