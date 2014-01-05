using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum KnowledgebaseCategoryArticleSortOrder
	{
		[XmlEnum(Name = "1")]
		Inherit,

		[XmlEnum(Name = "2")]
		SortTitle,

		[XmlEnum(Name = "3")]
		SortRating,

		[XmlEnum(Name = "4")]
		SortCreationDate,

		[XmlEnum(Name = "5")]
		SortDisplayOrder
	}
}
