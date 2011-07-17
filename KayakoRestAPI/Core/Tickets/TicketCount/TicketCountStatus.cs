using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a Ticket Count grouped by status
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+TicketCount
    /// </remarks>
    [XmlType("ticketstatus")]
    public class TicketCountStatus
    {
        /// <summary>
        /// The unique numeric identifier of the ticket status 
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// The time representing the last activity
        /// </summary>
        [XmlAttribute("lastactivity")]
		public long LastActivity { get; set; }

        /// <summary>
        /// The total number of items
        /// </summary>
        [XmlAttribute("totalitems")]
        public int TotalItems { get; set; }
    }
}
