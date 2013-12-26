using System.Collections.Generic;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Departments
{
	/// <summary>
	/// Represents a department
	/// </summary>
	/// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+Department
	/// </remarks>
	[XmlType("department")]
	public class Department
	{
		/// <summary>
        /// The unique numeric identifier of the department 
		/// </summary>
		[XmlElement("id")]
		public int Id { get; set; }

		/// <summary>
        /// The title of the department
		/// </summary>
		[XmlElement("title")]
		public string Title { get; set; }

		/// <summary>
        /// The accessibility level of the department ('public' or 'private')
		/// </summary>
		[XmlElement("type")]
		public DepartmentType Type { get; set; }

		/// <summary>
        /// The module the department should be associated with ('tickets' or 'livechat')
		/// </summary>
		[XmlElement("module")]
		public DepartmentModule Module { get; set; }

		/// <summary>
        /// A positive integer that the helpdesk will use to sort departments when displaying them (ascending)
		/// </summary>
		[XmlElement("displayorder")]
		public int DisplayOrder { get; set; }

		/// <summary>
        /// A positive integer of the parent department for this department
		/// </summary>
		[XmlElement("parentdepartmentid")]
		public int ParentDepartmentId { get; set; }

		/// <summary>
        /// Controls whether or not to restrict visibility of this department to particular user groups (see usergroupid[])
		/// </summary>
		[XmlElement("uservisibilitycustom")]
		public bool UserVisibilityCustom { get; set; }

		/// <summary>
        /// An array of positive integers identifying the user groups to be assigned to this department
		/// </summary>
		[XmlArray("usergroups")]
		[XmlArrayItem("id")]
		public List<int> UserGroups { get; set; }
	}
}
