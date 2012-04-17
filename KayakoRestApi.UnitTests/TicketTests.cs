using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi.Core.Departments;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Tickets;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Tickets")]
	public class TicketTests : UnitTestBase
	{
        [Test]
		public void GetAllTickets()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());

			Assert.IsNotNull(tickets, "No tickets were returned");
			Assert.IsNotEmpty(tickets, "No tickets were returned");
		}

		[Test]
		public void GetTicket()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());

			Assert.IsNotNull(tickets, "No tickets were returned");
			Assert.IsNotEmpty(tickets, "No tickets were returned");

			Ticket ticketToGet = tickets[new Random().Next(tickets.Count)];

			Trace.WriteLine("GetTicket using ticket id: " + ticketToGet.Id);

			Ticket ticketById = TestSetup.KayakoApiService.Tickets.GetTicket(ticketToGet.Id);
			Ticket ticketByDisplayId = TestSetup.KayakoApiService.Tickets.GetTicket(ticketToGet.DisplayId);

			//CompareTickets(ticketById, ticketToGet);
			CompareTickets(ticketById, ticketByDisplayId);
			//CompareTickets(ticketByDisplayId, ticketToGet);
		}

		[Test(Description="Tests creating, updating and deleting departments")]
		public void CreateUpdateDeleteTicket()
		{
			string subject = "Ticket Subject";
			string fullname = "Ticket FullName";
			string email = "ticket@email.com";
			string contents = "Contents of the ticket";
			int deptId = 3;
			int statusId = 1;
			int priorityId = 1;
			int typeId = 1;
			int ownerId = 1;
			TicketCreationType type = TicketCreationType.Default;

            TicketRequest request = new TicketRequest()
            {
                Subject = subject,
                FullName = fullname,
                Email = email,
                Contents = contents,
                DepartmentId = deptId,
				TemplateGroupId = 1,
                TicketStatusId = statusId,
                TicketPriorityId = priorityId,
                TicketTypeId = typeId,
                OwnerStaffId = ownerId,
                CreationType = type,
                AutoUserId = true,
            };

			//Ticket createdTicket = TestSetup.KayakoApiService.Tickets.CreateTicket(subject, fullname, email, contents, deptId, statusId, priorityId, typeId, ownerId, type);
            Ticket createdTicket = TestSetup.KayakoApiService.Tickets.CreateTicket(request);

			Assert.IsNotNull(createdTicket);
			Assert.AreEqual(createdTicket.Subject, subject);
			Assert.AreEqual(createdTicket.FullName, fullname);
			Assert.AreEqual(createdTicket.Email, email);
			Assert.AreEqual(createdTicket.DepartmentId, deptId);
			Assert.AreEqual(createdTicket.StatusId, statusId);
			Assert.AreEqual(createdTicket.PriorityId, priorityId);
			Assert.AreEqual(createdTicket.Replies, 0);
			Assert.AreEqual(createdTicket.TypeId, typeId);
			//Assert.AreEqual(createdTicket.OwnerStaffId, ownerId);

			request.Id = createdTicket.Id;
			request.Subject = "Updated " + subject;
			request.FullName = "Updated " + fullname;
			request.Contents = "Updated " + contents;
			request.TemplateGroupId = 1;

			Ticket updatedTicket = TestSetup.KayakoApiService.Tickets.UpdateTicket(request);

			Assert.IsNotNull(updatedTicket);
			//Assert.AreEqual(updatedTicket.Subject, request.Subject);
			//Assert.AreEqual(updatedTicket.FullName, request.FullName);
			//Assert.AreEqual(updatedTicket.Email, request.Email);
			//Assert.AreEqual(updatedTicket.DepartmentId, request.DepartmentId);
			//Assert.AreEqual(updatedTicket.StatusId, request.TicketStatusId);
			//Assert.AreEqual(updatedTicket.PriorityId, request.TicketPriorityId);
			//Assert.AreEqual(updatedTicket.Replies, 0);
			//Assert.AreEqual(updatedTicket.TypeId, request.TicketTypeId);
			//Assert.AreEqual(updatedTicket.OwnerStaffId, request.OwnerStaffId);

			bool success = TestSetup.KayakoApiService.Tickets.DeleteTicket(updatedTicket.Id);

			Assert.IsTrue(success);
		}

        private void CompareTickets(Ticket one, Ticket two)
        {
			Assert.AreEqual(one.CreationMode, two.CreationMode);
			Assert.AreEqual(one.CreationTime, two.CreationTime);
			Assert.AreEqual(one.CreationType, two.CreationType);
			Assert.AreEqual(one.Creator, two.Creator);
			Assert.AreEqual(one.DepartmentId, two.DepartmentId);
			Assert.AreEqual(one.DisplayId, two.DisplayId);
			Assert.AreEqual(one.Email, two.Email);
			Assert.AreEqual(one.EscalationRuleId, two.EscalationRuleId);
			Assert.AreEqual(one.TemplateGroupId, two.TemplateGroupId);
			Assert.AreEqual(one.FlagType, two.FlagType);
			Assert.AreEqual(one.FullName, two.FullName);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.IPAddress, two.IPAddress);
			Assert.AreEqual(one.IsEscalated, two.IsEscalated);
			Assert.AreEqual(one.LastActivity, two.LastActivity);
			Assert.AreEqual(one.LastReplier, two.LastReplier);
			Assert.AreEqual(one.LastStaffReply, two.LastStaffReply);
			Assert.AreEqual(one.LastUserReply, two.LastUserReply);
			Assert.AreEqual(one.NextReplyDue, two.NextReplyDue);

			Assert.AreEqual(one.Posts.Count, two.Posts.Count);
			Assert.AreEqual(one.Notes.Count, two.Notes.Count);

			for (int i = 0; i < one.Notes.Count; i++)
			{
				TicketNoteTests.CompareTicketNote(one.Notes[i], two.Notes[i]);
			}

			Assert.AreEqual(one.OwnerStaffId, two.OwnerStaffId);
			Assert.AreEqual(one.OwnerStaffName, two.OwnerStaffName);

			for (int i = 0; i < one.Posts.Count; i++)
			{
				TicketPostTests.CompareTicketPost(one.Posts[i], two.Posts[i]);
			}

			Assert.AreEqual(one.PriorityId, two.PriorityId);
			Assert.AreEqual(one.Replies, two.Replies);
			Assert.AreEqual(one.ResolutionDue, two.ResolutionDue);
			Assert.AreEqual(one.SlaPlanId, two.SlaPlanId);
			Assert.AreEqual(one.StatusId, two.StatusId);
			Assert.AreEqual(one.Subject, two.Subject);
			Assert.AreEqual(one.Tags, two.Tags);
			Assert.AreEqual(one.TypeId, two.TypeId);
			Assert.AreEqual(one.UserId, two.UserId);
			Assert.AreEqual(one.UserOrganization, two.UserOrganization);
			Assert.AreEqual(one.UserOrganizationId.HasValue, two.UserOrganizationId.HasValue);

			if (one.UserOrganizationId.HasValue)
			{
				Assert.AreEqual(one.UserOrganizationId.Value, two.UserOrganizationId.Value);
			}

			//Assert.AreEqual(one.Watcher, two.Watcher);
			//Assert.AreEqual(one.Workflow, two.Workflow);

			AssertObjectXmlEqual<Ticket>(one, two);
        }
	}
}
