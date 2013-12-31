using System.Xml.Serialization;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a news category
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsSubscriber
	/// </remarks>
	/// </summary>
	[XmlType("newssubscriber")]
	public class NewsSubscriber
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("tgroupid")]
		public int TGroupId { get; set; }

		[XmlElement("userid")]
		public int UserId { get; set; }

		[XmlElement("email")]
		public string Email { get; set; }

		[XmlElement("isvalidated")]
		public bool IsValidated { get; set; }

		[XmlElement("usergroupid")]
		public int UserGroupId { get; set; }
	}
}
