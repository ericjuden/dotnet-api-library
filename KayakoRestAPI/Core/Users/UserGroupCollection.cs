using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Users
{
    /// <summary>
    /// Definition of a list of user groups.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+UserGroup
    /// </remarks>
    /// </summary>
    [XmlRoot("usergroups")]
    public class UserGroupCollection : List<UserGroup>
    {
        /// <summary>
        /// Create a list of user groups.
        /// </summary>
        public UserGroupCollection()
        {
        }
    }
}
