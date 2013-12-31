using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a news item comment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsComment#REST-NewsComment-Response
	/// </remarks>
	/// </summary>
	[XmlType("newsitemcomment")]
	public class NewsItemComment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("newsitemid")]
		public int NewsItemId { get; set; }

		[XmlElement("creatortype")]
		public NewsItemCommentCreatorType CreatorType { get; set; }

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
		public NewsItemCommentStatus CommentStatus { get; set; }

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
