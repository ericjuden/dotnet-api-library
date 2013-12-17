using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Definition of a list of ticket time tracks
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketTimeTrack
    /// </remarks>
    /// </summary>
    [XmlRoot("timetracks")]
    public class TicketTimeTrackCollection : List<TicketTimeTrack>
    {
        /// <summary>
        /// Create a list of ticket time tracks.
        /// </summary>
        public TicketTimeTrackCollection()
        {
        }
    }
}
