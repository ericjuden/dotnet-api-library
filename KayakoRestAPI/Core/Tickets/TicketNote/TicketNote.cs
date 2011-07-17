using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a ticket note
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-Response
    /// </remarks>
    /// </summary>
    [XmlType("note")]
    public class TicketNote
    {
		/// <summary>
		/// The unique numeric identifier of the note
		/// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

		/// <summary>
		/// The unique numeric identifer of the ticket
		/// </summary>
		[XmlAttribute("ticketid")]
		public int TicketId { get; set; }

        /// <summary>
        /// The type of ticket note
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
		/// The Note Color, for more information see http://wiki.kayako.com/display/DEV/Mobile+-+Constants
        /// </summary>
        [XmlAttribute("notecolor")]
        public NoteColor NoteColor { get; set; }

        /// <summary>
		/// The Staff Id, if the ticket is to be created as a staff.
        /// </summary>
        [XmlAttribute("creatorstaffid")]
        public int CreatorStaffId { get; set; }

        /// <summary>
        /// The staff Id the note is viewable by
        /// </summary>
        [XmlAttribute("forstaffid")]
        public int ForStaffId { get; set; }

        /// <summary>
		/// The fullname of the staff user if the ticket is to be created without providing a staff id. Example: System messages, Alerts etc.
        /// </summary>
        [XmlAttribute("creatorstaffname")]
        public string CreatorStaffName { get; set; }

        /// <summary>
        /// Gets or sets value indicating the creation date of the note
        /// </summary>
        [XmlAttribute("creationdate")]
        public int CreationDate { get; set; }

        /// <summary>
		/// The ticket note contents 
        /// </summary>
        [XmlText]
        public string Content { get; set; }
    }
}
