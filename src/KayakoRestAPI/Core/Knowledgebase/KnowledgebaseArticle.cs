using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a knowledgebase article
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseArticle#REST-KnowledgebaseArticle-Response
	/// </remarks>
	/// </summary>
	[XmlType("kbarticle")]
	public class KnowledgebaseArticle
	{
		[XmlElement("kbarticleid")]
		public int Id { get; set; }

		[XmlElement("contents")]
		public string Contents { get; set; }

		[XmlElement("contentstext")]
		public string ContentsText { get; set; }

		[XmlArray("categories")]
		[XmlArrayItem("categoryid")]
		public int[] Categories { get; set; }

		[XmlElement("creator")]
		public int Creator { get; set; }

		[XmlElement("creatorid")]
		public int CreatorId { get; set; }

		[XmlElement("author")]
		public string Author { get; set; }

		[XmlElement("email")]
		public string Email { get; set; }

		[XmlElement("subject")]
		public string Subject { get; set; }

		[XmlElement("isedited")]
		public bool IsEdited { get; set; }

		[XmlElement("editeddateline")]
		public UnixDateTime EditedDateLine { get; set; }

		[XmlElement("editedstaffid")]
		public int EditedStaffId { get; set; }

		[XmlElement("views")]
		public int Views { get; set; }

		[XmlElement("isfeatured")]
		public bool IsFeatured { get; set; }

		[XmlElement("allowcomments")]
		public bool AllowComments { get; set; }

		[XmlElement("totalcomments")]
		public int TotalComments { get; set; }

		[XmlElement("hasattachments")]
		public bool HasAttachments { get; set; }

		[XmlArray("attachments")]
		[XmlArrayItem("attachment")]
		public KnowledgebaseArticleAttachment[] Attachments { get; set; }

		[XmlElement("dateline")]
		public UnixDateTime DateLine { get; set; }

		[XmlElement("articlestatus")]
		public KnowledgebaseArticleStatus ArticleStatus { get; set; }

		[XmlElement("articlerating")]
		public int ArticleRating { get; set; }

		[XmlElement("ratinghits")]
		public int RatingHits { get; set; }

		[XmlElement("ratingcount")]
		public int RatingCount { get; set; }
	}
}
