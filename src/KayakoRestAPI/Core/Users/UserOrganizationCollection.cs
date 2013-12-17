using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Users
{
    /// <summary>
    /// Definition of a list User Organizations.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+UserOrganization
    /// </remarks>
    /// </summary>
	[XmlRoot("userorganizations")]
    public class UserOrganizationCollection : List<UserOrganization>
    {
        /// <summary>
        /// Create a list of user organisations.
        /// </summary>
        public UserOrganizationCollection()
        {
        }
    }
}
