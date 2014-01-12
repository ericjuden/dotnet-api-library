using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a troubleshooter step
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterStep#REST-TroubleshooterStep-Response
	/// </remarks>
	/// </summary>
	[XmlType("troubleshooterstep")]
	public class TroubleshooterStep
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("categoryid")]
		public int CategoryId { get; set; }

		[XmlElement("staffid")]
		public int StaffId { get; set; }

		[XmlElement("staffname")]
		public string StaffName { get; set; }

		[XmlElement("subject")]
		public string Subject { get; set; }

		[XmlElement("edited")]
		public bool Edited { get; set; }

		[XmlElement("editedstaffid")]
		public int EditedStaffId { get; set; }

		[XmlElement("editedstaffname")]
		public string EditedStaffName { get; set; }

		[XmlElement("displayorder")]
		public int DisplayOrder { get; set; }

		[XmlElement("views")]
		public int Views { get; set; }

		[XmlElement("allowcomments")]
		public bool AllowComments { get; set; }

		[XmlElement("hasattachments")]
		public bool HasAttachments { get; set; }

		[XmlArray("attachments")]
		[XmlArrayItem("attachment")]
		public TroubleshooterStepAttachment[] Attachments { get; set; }

		[XmlArray("parentsteps")]
		[XmlArrayItem("id")]
		public int[] ParentSteps { get; set; }

		[XmlArray("childsteps")]
		[XmlArrayItem("id")]
		public int[] ChildSteps { get; set; }

		[XmlElement("redirecttickets")]
		public bool RedirectTickets { get; set; }

		[XmlElement("ticketsubject")]
		public string TicketSubject { get; set; }

		[XmlElement("redirectdepartmentid")]
		public int RedirectDepartmentId { get; set; }

		[XmlElement("tickettypeid")]
		public int TicketTypeId { get; set; }

		[XmlElement("priorityid")]
		public int TicketPriorityId { get; set; }

		[XmlElement("contents")]
		public string Contents { get; set; }
	}
}
