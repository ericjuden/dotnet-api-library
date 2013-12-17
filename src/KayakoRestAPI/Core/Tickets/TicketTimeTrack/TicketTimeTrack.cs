using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a ticket time track
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketTimeTrack#REST-TicketTimeTrack-Response
    /// </remarks>
    /// </summary>
    [XmlType("timetrack")]
    public class TicketTimeTrack
    {
        /// <summary>
        /// The unique numeric identifier of the ticket time tracking note
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// The unique numeric identifier representing the ticket id
        /// </summary>
        [XmlAttribute("ticketid")]
        public int TicketId { get; set; }

        /// <summary>
        /// The time spent (in seconds)
        /// </summary>
        [XmlAttribute("timeworked")]
        public int TimeWorked { get; set; }

        /// <summary>
        /// The time billable (in seconds)
        /// </summary>
        [XmlAttribute("timebillable")]
        public int TimeBillable { get; set; }

        /// <summary>
        /// The UNIX timestamp which specifies when to bill the user 
        /// </summary>
		[XmlAttribute("billdate")]
        public string BillDate { get; set; }

        /// <summary>
        /// The UNIX timestamp which specifies when the work was executed
        /// </summary>
		[XmlAttribute("workdate")]
        public string WorkDate { get; set; }

        /// <summary>
        /// The staff identifier of the worker. If not specified, the staff user creating this entry will be considered as the worker
        /// </summary>
        [XmlAttribute("workerstaffid")]
        public int WorkerStaffId { get; set; }

        /// <summary>
        /// The staff name of the worker. If not specified, the staff user creating this entry will be considered as the worker
        /// </summary>
        [XmlAttribute("workerstaffname")]
        public string WorkerStaffName { get; set; }

        /// <summary>
        /// The staff id of the creator
        /// </summary>
        [XmlAttribute("creatorstaffid")]
        public int CreatorStaffId { get; set; }

        /// <summary>
        /// The staff name of the creator
        /// </summary>
        [XmlAttribute("creatorstaffname")]
        public string CreatorStaffName { get; set; }

        /// <summary>
        /// The Note Color
        /// </summary>
        [XmlAttribute("notecolor")]
        public NoteColor NoteColor { get; set; }

        /// <summary>
        /// The contents of the time track item
        /// </summary>
        [XmlText]
        public string Contents { get; set; }
    }
}
