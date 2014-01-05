using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a knowledgebase category
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseCategory#REST-KnowledgebaseCategory-Response
	/// </remarks>
	/// </summary>
	[XmlType("kbcategory")]
	public class KnowledgebaseCategory
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("parentkbcategoryid")]
		public int ParentKnowledgebaseCategoryId { get; set; }

		[XmlElement("staffid")]
		public int StaffId { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("totalarticles")]
		public int TotalArticles { get; set; }

		[XmlElement("categorytype")]
		public KnowledgebaseCategoryType CategoryType { get; set; }

		[XmlElement("displayorder")]
		public int DisplayOrder { get; set; }

		[XmlElement("allowcomments")]
		public bool AllowComments { get; set; }

		[XmlElement("uservisibilitycustom")]
		public bool UserVisibilityCustom { get; set; }

		[XmlArray("usergroupidlist")]
		[XmlArrayItem("usergroupid")]
		public int[] UserGroupIdList { get; set; }

		[XmlElement("staffvisibilitycustom")]
		public bool StaffVisibilityCustom { get; set; }

		[XmlArray("staffgroupidlist")]
		[XmlArrayItem("staffgroupid")]
		public int[] StaffGroupIdList { get; set; }

		[XmlElement("allowrating")]
		public bool AllowRating { get; set; }

		[XmlElement("ispublished")]
		public bool IsPublished { get; set; }
	}
}
