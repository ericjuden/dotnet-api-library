using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a Ticket Count object
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+TicketCount
    /// </remarks>
    [XmlType("ticketcount")]
    public class TicketCount
    {
        /// <summary>
        /// Ticket Count grouped by Department
        /// </summary>
        [XmlArray("departments")]
        [XmlArrayItem("department")]
        public DepartmentSummary[] Departments { get; set; }

        /// <summary>
        /// Ticket Count grouped by Status
        /// </summary>
        [XmlArray("statuses")]
        [XmlArrayItem("ticketstatus")]
        public TicketCountStatus[] TicketStatuses { get; set; }

        /// <summary>
        /// Ticket Count grouped by Owner Staff
        /// </summary>
        [XmlArray("owners")]
        [XmlArrayItem("ownerstaff")]
        public OwnerStaff[] OwnerStaff { get; set; }

        /// <summary>
        /// Unassigned Ticket Count grouped by Department
        /// </summary>
        [XmlArray("unassigned")]
        [XmlArrayItem("department")]
        public UnassignedDepartment[] UnassignedTickets { get; set; }
    }
}
