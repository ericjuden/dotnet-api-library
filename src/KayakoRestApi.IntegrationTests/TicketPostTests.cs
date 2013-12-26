using System;
using System.Diagnostics;
using NUnit.Framework;
using KayakoRestApi.Core;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Departments;
using System.Linq;
using KayakoRestApi.Core.Staff;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Posts")]
	public class TicketPostTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketPosts()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			TicketPostCollection ticketPosts = TestSetup.KayakoApiService.Tickets.GetTicketPosts(randomTicket.Id);

			Assert.IsNotNull(ticketPosts, "No ticket posts were returned for ticket id " + randomTicket.Id);
			Assert.IsNotEmpty(ticketPosts, "No ticket posts were returned for ticket id " + randomTicket.Id);
		}

		[Test]
		public void GetTicketPost()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			TicketPostCollection ticketPosts = TestSetup.KayakoApiService.Tickets.GetTicketPosts(randomTicket.Id);

			Assert.IsNotNull(ticketPosts, "No ticket posts were returned for ticket id " + randomTicket.Id);
			Assert.IsNotEmpty(ticketPosts, "No ticket posts were returned for ticket id " + randomTicket.Id);

			TicketPost randomTicketPostToGet = ticketPosts[new Random().Next(ticketPosts.Count)];

			Trace.WriteLine("GetTicketPost using ticket post id: " + randomTicketPostToGet.Id);

			TicketPost ticketPriority = TestSetup.KayakoApiService.Tickets.GetTicketPost(randomTicket.Id, randomTicketPostToGet.Id);

			CompareTicketPost(ticketPriority, randomTicketPostToGet);
		}

		[Test(Description = "Tests creating and deleting ticket posts")]
		public void CreateDeleteTicketPosts()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			StaffUserCollection staff = TestSetup.KayakoApiService.Staff.GetStaffUsers();
			StaffUser randomStaffUser = staff[new Random().Next(staff.Count)];
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			string subject = "New Post Subject";
			string contents = "This will be the contents";

            TicketPostRequest request = new TicketPostRequest()
            {
                TicketId = randomTicket.Id,
                Subject = subject,
                Contents = contents,
                StaffId = randomStaffUser.Id
            };

			TicketPost createdPost = TestSetup.KayakoApiService.Tickets.AddTicketPost(request);

			Assert.IsNotNull(createdPost);
			Assert.AreEqual(createdPost.StaffId, randomStaffUser.Id);
			//Assert.AreEqual(createdPost.Contents, String.Format("{0}\n{1}", contents, randomStaffUser.Signature));

			//Subject?

			bool success = TestSetup.KayakoApiService.Tickets.DeleteTicketPost(randomTicket.Id, createdPost.Id);

			Assert.IsTrue(success);
		}

		public static void CompareTicketPost(TicketPost one, TicketPost two)
		{
			Assert.AreEqual(one.Contents, two.Contents);
			Assert.AreEqual(one.Creator, two.Creator);
			Assert.AreEqual(one.Dateline, two.Dateline);
			Assert.AreEqual(one.Email, two.Email);
			Assert.AreEqual(one.EmailTo, two.EmailTo);
			Assert.AreEqual(one.FullName, two.FullName);
			Assert.AreEqual(one.HasAttachments, two.HasAttachments);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.IPAddress, two.IPAddress);
			Assert.AreEqual(one.IsEmailed, two.IsEmailed);
			Assert.AreEqual(one.IsHtml, two.IsHtml);
			Assert.AreEqual(one.IsSurveyComment, two.IsSurveyComment);
			Assert.AreEqual(one.IsThirdParty, two.IsThirdParty);
			Assert.AreEqual(one.StaffId, two.StaffId);
			Assert.AreEqual(one.UserId, two.UserId);

			AssertObjectXmlEqual<TicketPost>(one, two);
		}
	}
}
