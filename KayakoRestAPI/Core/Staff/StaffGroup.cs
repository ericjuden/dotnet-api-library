using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Staff
{
    /// <summary>
    /// Represents a staff group.
    /// </summary>
    /// <remarks>
    /// see: http://wiki.kayako.com/display/DEV/REST+-+StaffGroup#REST-StaffGroup-Response
    /// </remarks>
    [XmlType("staffgroup")]
    public class StaffGroup
    {
        /// <summary>
        /// The numeric identifier of the staff group
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// The title of the staff group
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Toggles whether or not this group is has admin privileges
        /// </summary>
        [XmlElement("isadmin")]
        public bool IsAdmin { get; set; }
    }
}
