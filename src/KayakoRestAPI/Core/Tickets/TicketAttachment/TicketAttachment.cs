using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
	/// <summary>
	/// Represents a ticket attachment
	/// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment#REST-TicketAttachment-Response
	/// </remarks>
	/// </summary>
    [XmlType("attachment")]
    public class TicketAttachment
    {
		/// <summary>
		/// The unique numeric identifier of the attachment
		/// </summary>
        [XmlElement("id")]
        public int Id { get; set;}

		/// <summary>
		/// The unique numeric identifier of the ticket
		/// </summary>
        [XmlElement("ticketid")]
        public int TicketId { get; set;}

		/// <summary>
		/// The unique numeric identifier of the ticket post
		/// </summary>
        [XmlElement("ticketpostid")]
        public int TicketPostId { get; set;}

		/// <summary>
		/// The file name for the attachment 
		/// </summary>
        [XmlElement("filename")]
        public string FileName { get; set;}

		/// <summary>
		/// The size of the ticket attachment 
		/// </summary>
        [XmlElement("filesize")]
        public int FileSize { get; set;}

		/// <summary>
		/// The type of file of the ticket attachment
		/// </summary>
        [XmlElement("filetype")]
        public string FileType { get; set;}

		/// <summary>
		/// The date of the ticket attachment
		/// </summary>
        [XmlElement("dateline")]
        public string Dateline { get; set;}

		/// <summary>
		/// The BASE64 encoded attachment contents
		/// </summary>
		[XmlElement("contents")]
		public string Contents { get; set; }
    }
}
