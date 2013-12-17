using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Represents a ticket status
	/// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+TicketStatus#REST-TicketStatus-Response
	/// </remarks>
	/// </summary>
    [XmlType("ticketstatus")]
    public class TicketStatus
    {
        /// <summary>
        /// The unique identifer of the ticket status
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
		/// The title of the ticket status
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
		/// The display order of the ticket status
        /// </summary>
        [XmlElement("displayorder")]
        public int DisplayOrder { get; set; }

        /// <summary>
		/// The identifer for the department of the ticket status
        /// </summary>
        [XmlElement("departmentid")]
        public int DepartmentId { get; set; }

        /// <summary>
		/// The display icon for the ticket status
        /// </summary>
        [XmlElement("displayicon")]
        public string DisplayIcon { get; set; }

        /// <summary>
        /// Type of the ticket status ('public' or 'private')
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ticket status is displayed in the main list
        /// </summary>
        [XmlElement("displayinmainlist")]
        public bool DisplayInMainList { get; set; }

        /// <summary>
        /// Indicates whether the ticket status is marked as resolved
        /// </summary>
        [XmlElement("markasresolved")]
        public bool MarkAsResolved { get; set; }

        /// <summary>
        /// Indicates whether the total ticket count for this ticket status will be displayed in the filter tickets tree
        /// </summary>
        [XmlElement("displaycount")]
        public bool DisplayCount { get; set; }

        /// <summary>
        /// The status color associated with this status
        /// </summary>
        [XmlElement("statuscolor")]
        public string StatusColor { get; set; }

        /// <summary>
        /// The ticket status background color
        /// </summary>
        [XmlElement("statusbgcolor")]
        public string StatusBgColor { get; set; }

        /// <summary>
        /// Value representing the reset due time
        /// </summary>
        [XmlElement("resetduetime")]
        public string ResetDueTime { get; set; }

        /// <summary>
        /// Indicates if the ticket triggers a survery email
        /// </summary>
        [XmlElement("triggersurvey")]
        public bool TriggerSurvey { get; set; }

        /// <summary>
        /// The staff visibility custom
        /// </summary>
        [XmlElement("staffvisibilitycustom")]
        public int StaffVisibilityCustom { get; set; }

        /// <summary>
        /// The staff group Id
        /// </summary>
        [XmlElement("staffgroupid")]
        public int StaffGroupId { get; set; }
    }
}
