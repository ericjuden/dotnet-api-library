using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a knowledgebase comment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseComment#REST-KnowledgebaseComment-GET%2FKnowledgebase%2FComment%2FListAll%2F%24kbarticleid%24
	/// </remarks>
	/// </summary>
	[XmlType("kbarticlecomment")]
	public class KnowledgebaseComment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("kbarticleid")]
		public int KnowledgebaseArticleId { get; set; }

		[XmlElement("creatortype")]
		public KnowledgebaseCommentCreatorType CreatorType { get; set; }

		[XmlElement("creatorid")]
		public int CreatorId { get; set; }

		[XmlElement("fullname")]
		public string FullName { get; set; }

		[XmlElement("email")]
		public string Email { get; set; }

		[XmlElement("ipaddress")]
		public string IpAddress { get; set; }

		[XmlElement("dateline")]
		public UnixDateTime DateLine { get; set; }

		[XmlElement("parentcommentid")]
		public int ParentCommentId { get; set; }

		[XmlElement("commentstatus")]
		public KnowledgebaseCommentStatus CommentStatus { get; set; }

		[XmlElement("useragent")]
		public string UserAgent { get; set; }

		[XmlElement("referrer")]
		public string Referrer { get; set; }

		[XmlElement("parenturl")]
		public string ParentUrl { get; set; }

		[XmlElement("contents")]
		public string Contents { get; set; }
	}
}
