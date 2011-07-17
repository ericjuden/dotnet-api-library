using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Represents a ticket priority
	/// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+TicketPriority#REST-TicketPriority-Response
	/// </remarks>
	/// </summary>
    [XmlType("ticketpriority")]
    public class TicketPriority
    {
		/// <summary>
		/// The unique numeric identifier of the ticket priority
		/// </summary>
        [XmlElement("id")]
        public int Id { get; set;}

		/// <summary>
		/// The title of the ticket priority
		/// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

		/// <summary>
		/// The display order of the ticket priority
		/// </summary>
        [XmlElement("displayorder")]
        public int DisplayOrder { get; set; }

		/// <summary>
		/// The foreground listing color of the ticket priority
		/// </summary>
        [XmlElement("frcolorcode")]
        public string FrColorCode { get; set; }

		/// <summary>
		/// The background listing color of the ticket priority
		/// </summary>
        [XmlElement("bgcolorcode")]
        public string BgColorCode { get; set; }

		/// <summary>
		/// The display icon of the ticket priority
		/// </summary>
        [XmlElement("displayicon")]
        public string DisplayIcon { get; set; }

		/// <summary>
		/// The type of the ticket priority ('public' or 'private')
		/// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

		/// <summary>
		/// Custom setting for the user visibility
		/// </summary>
        [XmlElement("uservisibilitycustom")]
        public int UserVisibilityCustom { get; set; }

		/// <summary>
		/// The user group Id associated to ticket priority
		/// </summary>
        [XmlElement("usergroupid")]
        public int UserGroupId { get; set; }
    }
}
