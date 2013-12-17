using System;
using System.Diagnostics;
using NUnit.Framework;
using KayakoRestApi.Core;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Departments;
using System.Linq;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Core.Constants;
using System.Text;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Attachments")]
	public class TicketAttachmentTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketAttachments()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			Ticket ticket = TestSetup.KayakoApiService.Tickets.GetTicket(1);

			TicketAttachmentCollection attachments = TestSetup.KayakoApiService.Tickets.GetTicketAttachments(ticket.Id);

			Assert.IsNotNull(attachments, "No ticket attachments were returned for ticket id " + ticket.Id);
			Assert.IsNotEmpty(attachments, "No ticket attachments were returned for ticket id " + ticket.Id);
		}

		[Test]
		public void GetTicketAttachment()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			Ticket ticket = TestSetup.KayakoApiService.Tickets.GetTicket(1);

			TicketAttachmentCollection attachments = TestSetup.KayakoApiService.Tickets.GetTicketAttachments(ticket.Id);

			Assert.IsNotNull(attachments, "No ticket attachments were returned for ticket id " + ticket.Id);
			Assert.IsNotEmpty(attachments, "No ticket attachments were returned for ticket id " + ticket.Id);

			TicketAttachment randomTicketAttachmentToGet = attachments[new Random().Next(attachments.Count)];

			Trace.WriteLine("GetTicketAttachment using ticket attachment id: " + randomTicketAttachmentToGet.Id);

			TicketAttachment ticketNote = TestSetup.KayakoApiService.Tickets.GetTicketAttachment(ticket.Id, randomTicketAttachmentToGet.Id);

			CompareTicketAttachment(ticketNote, randomTicketAttachmentToGet);
		}

		[Test(Description = "Tests creating and deleting ticket attachment")]
		public void CreateDeleteTicketAttachment()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			StaffUserCollection staff = TestSetup.KayakoApiService.Staff.GetStaffUsers();
			StaffUser randomStaffUser = staff[new Random().Next(staff.Count)];
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];
			TicketPostCollection ticketPosts = TestSetup.KayakoApiService.Tickets.GetTicketPosts(randomTicket.Id);
			TicketPost randomPost = ticketPosts[new Random().Next(ticketPosts.Count)];

			string contents = Convert.ToBase64String(Encoding.UTF8.GetBytes("This is the file contents"));

            TicketAttachmentRequest request = new TicketAttachmentRequest()
            {
                TicketId = randomTicket.Id,
                TicketPostId = randomPost.Id,
                FileName = "TheFilename.txt",
                Contents = contents
            };

            TicketAttachment createdAttachment = TestSetup.KayakoApiService.Tickets.AddTicketAttachment(request);

			Assert.AreEqual(createdAttachment.TicketId, randomTicket.Id);
			Assert.AreEqual(createdAttachment.TicketPostId, randomPost.Id);
			Assert.AreEqual(createdAttachment.FileName, "TheFilename.txt");
			//Assert.AreEqual(createdAttachment.Contents, contents);

			bool success = TestSetup.KayakoApiService.Tickets.DeleteTicketAttachment(randomTicket.Id, createdAttachment.Id);

			Assert.IsTrue(success);
		}

		private void CompareTicketAttachment(TicketAttachment one, TicketAttachment two)
		{
			Assert.AreEqual(one.Dateline, two.Dateline);
			Assert.AreEqual(one.FileName, two.FileName);
			Assert.AreEqual(one.FileSize, two.FileSize);
			Assert.AreEqual(one.FileType, two.FileType);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.TicketId, two.TicketId);
			Assert.AreEqual(one.TicketPostId, two.TicketPostId);

			//AssertObjectXmlEqual<TicketAttachment>(one, two);
		}
	}
}
