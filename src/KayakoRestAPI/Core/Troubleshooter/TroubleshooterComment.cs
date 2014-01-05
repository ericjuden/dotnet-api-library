using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a troubleshooter comment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterComment#REST-TroubleshooterComment-Response
	/// </remarks>
	/// </summary>
	[XmlType("troubleshooterstepcomment")]
	public class TroubleshooterComment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("troubleshooterstepid")]
		public int TroubleshooterStepId { get; set; }

		[XmlElement("creatortype")]
		public TroubleshooterCommentCreatorType CreatorType { get; set; }

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
		public TroubleshooterCommentStatus CommentStatus { get; set; }

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
