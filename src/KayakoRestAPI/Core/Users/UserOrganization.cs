using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Data;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Users
{
    /// <summary>
    /// Represents a User Organization
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+UserOrganization#REST-UserOrganization-Response
    /// </remarks>
    /// </summary>
	[XmlType("userorganization")]
    public class UserOrganization
    {
        /// <summary>
        /// The unique numeric identifier of the user organization
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the user organization
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of user organization ('restricted' or 'shared')
        /// </summary>
        [XmlElement("organizationtype")]
		public UserOrganizationType OrganizationType { get; set; }

        /// <summary>
        /// The address of the user organisation
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// The City of the user organisation
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// The state of the user organisation
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// The postal code of the user organisation
        /// </summary>
        [XmlElement("postalcode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country of the user organisation
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// The phone number of the user organisation
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The fax number for the user organisation
        /// </summary>
        [XmlElement("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// The website of the user organisation
        /// </summary>
        [XmlElement("website")]
        public string Website { get; set; }

        /// <summary>
        /// The date line of the user organisation
        /// </summary>
        [XmlElement("dateline")]
        public long Dateline { get; set; }

        /// <summary>
        /// The last time the user organisation was updated
        /// </summary>
		[XmlElement("lastupdate")]
        public long LastUpdated { get; set; }

        /// <summary>
        /// The SLA Plan Id to link with this user organization
        /// </summary>
		[XmlElement("slaplanid")]
        public int SlaPlanId { get; set; }

        /// <summary>
        /// The UNIX timestamp by which to ignore the SLA Plan, 0 = never expires
        /// </summary>
		[XmlElement("slaplanexpiry")]
        public long SlaPlanExpiry { get; set; }
    }
}
