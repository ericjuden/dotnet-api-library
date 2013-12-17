using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Represents a ticket and notes associated with that ticket
    /// <remarks>
    /// see : http://wiki.kayako.com/display/DEV/REST+-+Ticket#REST-Ticket-Response
    /// </remarks>
    /// </summary>
    [XmlType("ticket")]
    public class Ticket
    {
        /// <summary>
        /// The unique numeric identifier of the ticket
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// The identifier of the flag type
        /// </summary>
        [XmlAttribute("flagtype")]
        public int FlagType { get; set; }

        /// <summary>
        /// The ticket display Id
        /// </summary>
        [XmlElement("displayid")]
        public string DisplayId { get; set; }

        /// <summary>
        /// The Id of the department the ticket is associated with
        /// </summary>
        [XmlElement("departmentid")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// The Id representing the status of the ticket
        /// </summary>
        [XmlElement("statusid")]
        public int StatusId { get; set; }

        /// <summary>
        /// The Id representing the priority of the ticket
        /// </summary>
        [XmlElement("priorityid")]
        public int PriorityId { get; set; }

        /// <summary>
        /// The Id representing the type of ticket
        /// </summary>
        [XmlElement("typeid")]
        public int TypeId { get; set; }

        /// <summary>
        /// The Id of user who created the ticket
        /// </summary>
        [XmlElement("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets a value indicating the organization of the ticket creator
        /// </summary>
        [XmlElement("userorganization")]
        public string UserOrganization { get; set; }

        /// <summary>
        /// The Id of the user organization of the ticket creator
        /// </summary>
		[XmlElement("userorganizationid")]
		public KNullable<int> UserOrganizationId { get; set; }

        /// <summary>
        /// The Id of the staff member who owns the ticket
        /// </summary>
        [XmlElement("ownerstaffid")]
        public int OwnerStaffId { get; set; }

        /// <summary>
        /// The name of the staff member who owns the ticket
        /// </summary>
        [XmlElement("ownerstaffname")]
        public string OwnerStaffName { get; set; }

        /// <summary>
        /// The full name of the ticket creator
        /// </summary>
        [XmlElement("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// The email address of the ticket creator
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// The date of the last reply to the ticket
        /// </summary>
        [XmlElement("lastreplier")]
        public string LastReplier { get; set; }
        
        /// <summary>
        /// The subject of the ticket
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The creation time of the ticket
        /// </summary>
        [XmlElement("creationtime")]
        public long CreationTime { get; set; }

        /// <summary>
        /// The last activity on the ticket
        /// </summary>
        [XmlElement("lastactivity")]
        public long LastActivity { get; set; }

        /// <summary>
        /// The last reply to the ticket
        /// </summary>
        [XmlElement("laststaffreply")]
		public long LastStaffReply { get; set; }

        /// <summary>
        /// The last user reply to the ticket
        /// </summary>
        [XmlElement("lastuserreply")]
		public long LastUserReply { get; set; }

        /// <summary>
        /// The SLA PLan Id
        /// </summary>
        [XmlElement("slaplanid")]
        public string SlaPlanId { get; set; }

        /// <summary>
        /// The time when the next reply is due
        /// </summary>
        [XmlElement("nextreplydue")]
		public long NextReplyDue { get; set; }

        /// <summary>
        /// The time when the resolution is due
        /// /// </summary>
        [XmlElement("resolutiondue")]
		public long ResolutionDue { get; set; }

        /// <summary>
        /// The number of replies to this ticket
        /// /// </summary>
        [XmlElement("replies")]
        public int Replies { get; set; }

        /// <summary>
        /// The IP address the ticket was created with
        /// /// </summary>
        [XmlElement("ipaddress")]
        public string IPAddress { get; set; }

        /// <summary>
        /// The Id of the creator
        /// </summary>
        [XmlElement("creator")]
        public int Creator { get; set; }

        /// <summary>
        /// The Id of the mode used to create the ticket
        /// </summary>
        [XmlElement("creationmode")]
        public int CreationMode { get; set; }

        /// <summary>
        /// The Id of the creation type
        /// </summary>
        [XmlElement("creationtype")]
        public int CreationType { get; set; }

        /// <summary>
        /// Indicates whether the ticket has been escalated
        /// </summary>
        [XmlElement("isescalated")]
        public string IsEscalated { get; set; }

        /// <summary>
        /// The rule used to escalate the ticket
        /// </summary>
        [XmlElement("escalationruleid")]
        public int EscalationRuleId { get; set; }

		/// <summary>
		/// The template group ID of the ticket
		/// </summary>
		[XmlElement("templategroupid")]
		public int TemplateGroupId { get; set; }

        /// <summary>
        /// A list of tags associated with ticket
        /// </summary>
        [XmlElement("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// The details of the ticket watcher
        /// </summary>
        [XmlElement("watcher")]
        public TicketWatcher Watcher { get; set; }

        /// <summary>
        /// The details of the ticket workflow
        /// </summary>
        [XmlElement("workflow")]
        public TicketWorkflow Workflow { get; set; }

        /// <summary>
        /// List of notes associated with ticket
        /// </summary>
        [XmlElement("note")]
        public TicketNoteCollection Notes { get; set; }

        /// <summary>
        /// List of Posts associated with ticket
        /// </summary>
        [XmlArray("posts")]
        [XmlArrayItem("post")]
		public TicketPostCollection Posts { get; set; }
    }
}
