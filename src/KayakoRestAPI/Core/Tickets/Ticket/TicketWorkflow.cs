using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Representing the workflow element of a ticket
	/// <remarks>
	/// see http://wiki.kayako.com/display/DEV/REST+-+Ticket#REST-Ticket-Response
	/// </remarks>
	/// </summary>
    [Serializable]
    public class TicketWorkflow
    {
		/// <summary>
		/// The unique numeric identifier of the workflow
		/// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

		/// <summary>
		/// The title of the workflow
		/// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
