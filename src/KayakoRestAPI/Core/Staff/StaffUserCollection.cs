using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Staff;

namespace KayakoRestApi.Core.Staff
{
    /// <summary>
    /// Definition of a list of staff.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Staff
    /// </remarks>
    /// </summary>
    [XmlRoot("staffusers")]
    public class StaffUserCollection : List<StaffUser>
    {
        /// <summary>
        /// Create a list of staff.
        /// </summary>
        public StaffUserCollection()
        {
        }
    }
}
