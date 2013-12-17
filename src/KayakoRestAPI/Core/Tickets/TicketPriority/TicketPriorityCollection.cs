using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Definition of a list of Ticket Priorities.
    /// 
    /// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+TicketPriority
    /// </remarks>
    /// </summary>
    [XmlRoot("ticketpriorities")]
    public class TicketPriorityCollection : List<TicketPriority>
    {
        /// <summary>
        /// Create a list of ticket priorities.
        /// </summary>
        public TicketPriorityCollection()
        {
        }
    }
}