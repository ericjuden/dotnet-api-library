using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a Ticket Count department summary
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+TicketCount
    /// </remarks>
    [XmlType("department")]
    public class DepartmentSummary
    {
        /// <summary>
        /// The unique numeric identifier of the department 
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// The time representing the last activity
        /// </summary>
        [XmlElement("totalitems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// The time of the last activity
        /// </summary>
		[XmlElement("lastactivity")]
        public long LastActivity { get; set; }

        /// <summary>
        /// The total unresolved items
        /// </summary>
        [XmlElement("totalunresolveditems")]
        public int TotalUnresolvedItems { get; set; }

        /// <summary>
        /// The summary of ticket status for the department
        /// </summary>
        [XmlElement("ticketstatus")]
        public TicketCountStatus[] TicketStatusSummary { get; set; }

        /// <summary>
        /// The summary of ticket type for the department
        /// </summary>
        [XmlElement("tickettype")]
        public TicketCountType[] TicketTypeSummary { get; set; }

        /// <summary>
        /// The summary of tickets for staff
        /// </summary>
        [XmlElement("ownerstaff")]
        public OwnerStaff[] OwnerStaff { get; set; }
    }
}
