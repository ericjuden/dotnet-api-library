using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a ticket post
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketPost
    /// </remarks>
    /// </summary>
    [XmlType("post")]
    [Serializable]
    public class TicketPost
    {
        /// <summary>
		/// The unique numeric identifier of the ticket post
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// The time of the post
        /// </summary>
        [XmlElement("dateline")]
        public int Dateline { get; set; }

        /// <summary>
        /// The User Id of the poster
        /// </summary>
        [XmlElement("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// The Full name of the poster
        /// </summary>
        [XmlElement("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// The email of the poster
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// The email address of the poster
        /// </summary>
        [XmlElement("emailto")]
        public string EmailTo { get; set; }

        /// <summary>
        /// The IP Address of the poster
        /// </summary>
        [XmlElement("ipaddress")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Indicator to whether there is a ticket attachment
        /// </summary>
        [XmlElement("hasattachments")]
        public bool HasAttachments { get; set; }

        /// <summary>
        /// The Id of the ticket creator
        /// </summary>
        [XmlElement("creator")]
        public int Creator { get; set; }

        /// <summary>
        /// The Staff Id assigned to this ticket
        /// </summary>
        [XmlElement("staffid")]
        public int StaffId { get; set; }

        /// <summary>
        /// Value indicating if this post is from a third party.
        /// </summary>
        [XmlElement("isthirdparty")]
        public bool IsThirdParty { get; set; }

        /// <summary>
        /// Value indicating if this post was created from HTML
        /// </summary>
        [XmlElement("ishtml")]
        public bool IsHtml { get; set; }
        
        /// <summary>
        /// Value indicating if this post was created from an email
        /// </summary>
        [XmlElement("isemailed")]
        public bool IsEmailed { get; set; }

        /// <summary>
        /// Value indicating if this post is a survey comment
        /// </summary>
		[XmlElement("issurveycomment")]
        public bool IsSurveyComment { get; set; }

        /// <summary>
        /// The contents of the post.
        /// </summary>
        [XmlElement("contents")]
        public string Contents { get; set; }
    }
}
