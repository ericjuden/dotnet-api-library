using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Represents a ticket note
	/// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+TicketType#REST-TicketType-Response
	/// </remarks>
	/// </summary>
    [XmlType("tickettype")]
    public class TicketType
    {
        /// <summary>
		/// The unique numeric identifier of the ticket type
		/// </summary>
		[XmlElement("id")]
		public int Id { get; set; }

		/// <summary>
		/// The title of the ticket type
		/// </summary>
        [XmlElement("title")]
		public string Title { get; set; }

		/// <summary>
		/// The display order of the ticket type
		/// </summary>
        [XmlElement("displayorder")]
        public int DisplayOrder { get; set; }

		/// <summary>
		/// The department id of the ticket type
		/// </summary>
        [XmlElement("departmentid")]
        public int DepartmentId { get; set; }

		/// <summary>
		/// The display icon for the ticket type
		/// </summary>
        [XmlElement("displayicon")]
        public string DisplayIcon { get; set; }

		/// <summary>
		/// The type for the ticket type ('public' or 'private')
		/// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

		/// <summary>
		/// The user visibility custom of the ticket type
		/// </summary>
        [XmlElement("uservisibilitycustom")]
        public int UserVisibilityCustom { get; set; }

		/// <summary>
		/// The user group Id for the ticket type
		/// </summary>
        [XmlElement("usergroupid")]
        public int UserGroupId { get; set; }
    }
}
