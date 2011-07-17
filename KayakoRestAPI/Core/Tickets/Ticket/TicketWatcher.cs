using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Representing the watcher element of a ticket
	/// <remarks>
	/// see http://wiki.kayako.com/display/DEV/REST+-+Ticket#REST-Ticket-Response
	/// </remarks>
	/// </summary>
    [Serializable]
    public class TicketWatcher
    {
		/// <summary>
		/// The unique numeric staff id of the watcher
		/// </summary>
        [XmlAttribute("staffid")]
        public int Id { get; set; }

		/// <summary>
		/// The staff name of the watcher
		/// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
