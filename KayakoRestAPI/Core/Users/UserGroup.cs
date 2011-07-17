using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Users
{
    /// <summary>
    /// Represents a user group
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+UserGroup#REST-UserGroup-Response
    /// </remarks>
    [XmlType("usergroup")]
    public class UserGroup
    {
        /// <summary>
        /// The unique numeric identifier of the user group
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// The title of the user group
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// The type of user group ('guest' or 'registered')
        /// </summary>
        [XmlElement("grouptype")]
		public UserGroupType GroupType { get; set; }

        /// <summary>
        /// Indicates whether the user group is a master group
        /// </summary>
        [XmlElement("ismaster")]
        public bool IsMaster { get; set; }
    }
}
