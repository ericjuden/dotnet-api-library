using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents unassigned ticket count by department
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+TicketCount
    /// </remarks>
    [XmlType("department", Namespace="TicketCount/Unassigned/Department")]
    public class UnassignedDepartment
    {
        /// <summary>
        /// The unique numeric identifier of the department 
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

        /// <summary>
        /// The total unresolved items
        /// </summary>
        [XmlAttribute("totalunresolveditems")]
        public int TotalUnresolvedItems { get; set; }
    }
}
