using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a troubleshooter category
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterCategory#REST-TroubleshooterCategory-Response
	/// </remarks>
	/// </summary>
	[XmlType("troubleshootercategory")]
	public class TroubleshooterCategory
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("staffid")]
		public int StaffId { get; set; }

		[XmlElement("staffname")]
		public string StaffName { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("categorytype")]
		public TroubleshooterCategoryType CategoryType { get; set; }

		[XmlElement("displayorder")]
		public int DisplayOrder { get; set; }

		[XmlElement("views")]
		public int Views { get; set; }

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
	}
}
