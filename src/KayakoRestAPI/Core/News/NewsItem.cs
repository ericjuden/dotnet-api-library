using System;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.News
{
	[XmlType("newsitem")]
	public class NewsItem
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("staffid")]
		public int StaffId { get; set; }

		[XmlElement("newstype")]
		public NewsItemType NewsItemType { get; set; }

		[XmlElement("newsstatus")]
		public NewsItemStatus NewsItemStatus { get; set; }

		[XmlElement("author")]
		public string Author { get; set; }

		[XmlElement("email")]
		public string Email { get; set; }

		[XmlElement("subject")]
		public string Subject { get; set; }

		[XmlElement("emailsubject")]
		public string EmailSubject { get; set; }

		[XmlElement("dateline")]
		public UnixDateTime DateLine { get; set; }

		[XmlElement("expiry")]
		public UnixDateTime Expiry { get; set; }

		[XmlElement("issynced")]
		public bool IsSynced { get; set; }

		[XmlElement("totalcomments")]
		public int TotalComments { get; set; }

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

		[XmlElement("allowcomments")]
		public bool AllowComments { get; set; }

		[XmlElement("contents")]
		public string Contents { get; set; }

		[XmlArray("categories")]
		[XmlArrayItem("categoryid")]
		public int[] Categories { get; set; }
	}
}

