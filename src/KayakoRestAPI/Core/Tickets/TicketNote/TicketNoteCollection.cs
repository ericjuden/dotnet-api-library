using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Definition of a list of ticket notes
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketNote
    /// </remarks>
    /// </summary>
    [XmlRoot("notes")]
    public class TicketNoteCollection : List<TicketNote>
    {
        /// <summary>
        /// Create a list of ticket notes.
        /// </summary>
        public TicketNoteCollection()
        {
        }
    }
}
