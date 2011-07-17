using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Definition of a list of ticket posts
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketPost
    /// </remarks>
    /// </summary>
    [XmlRoot("posts")]
    public class TicketPostCollection : List<TicketPost>
    {
        /// <summary>
        /// Create a list of ticket posts.
        /// </summary>
        public TicketPostCollection()
        {
        }
    }
}
