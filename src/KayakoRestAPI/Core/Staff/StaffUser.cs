using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Staff
{
    /// <summary>
    /// Represents a helpdesk staff user.
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+Staff#REST-Staff-Response
    /// </remarks>
    [XmlType("staff")]
    public class StaffUser
    {
        /// <summary>
        /// The numeric identifier of the member of staff
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// The staff group Id that the member of staff belongs to
        /// </summary>
        [XmlElement("staffgroupid")]
        public int GroupId { get; set; }

        /// <summary>
        /// The staff member's first name
        /// </summary>
        [XmlElement("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// The staff member's last name
        /// </summary>
        [XmlElement("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// The staff member's full name
        /// </summary>
        [XmlElement("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// The user name the staff user will use to log in
        /// </summary>
        [XmlElement("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The email address of the staff user
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// The staff user's designation/title
        /// </summary>
        [XmlElement("designation")]
        public string Designation { get; set; }

        /// <summary>
        /// The staff user's greeting message
        /// </summary>
        [XmlElement("greeting")]
        public string Greeting { get; set; }

        /// <summary>
        /// The mobile number for the staff user 
        /// </summary>
        [XmlElement("mobilenumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// The signature to append to each reply made by the staff user
        /// </summary>
		[XmlElement("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Enables/Disables the staff user's account
        /// </summary>
        [XmlElement("isenabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The default time zone for the staff user
        /// </summary>
        [XmlElement("timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Toggle the enabling/disabling of automatic DST calculation
        /// </summary>
        [XmlElement("enabledst")]
        public bool EnableDst { get; set; }
    }
}
