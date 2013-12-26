using System;
using System.Diagnostics;
using NUnit.Framework;
using KayakoRestApi.Core;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Departments;
using System.Linq;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Posts")]
	public class TicketNoteTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketNotes()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			TicketNoteCollection notes = TestSetup.KayakoApiService.Tickets.GetTicketNotes(randomTicket.Id);

			//Assert.IsNotNull(notes, "No ticket notes were returned for ticket id " + randomTicket.Id);
			//Assert.IsNotEmpty(notes, "No ticket notes were returned for ticket id " + randomTicket.Id);
		}

		[Test]
		public void GetTicketNote()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			TicketNoteCollection notes = TestSetup.KayakoApiService.Tickets.GetTicketNotes(randomTicket.Id);

			Assert.IsNotNull(notes, "No ticket notes were returned for ticket id " + randomTicket.Id);
			Assert.IsNotEmpty(notes, "No ticket notes were returned for ticket id " + randomTicket.Id);

			TicketNote randomTicketNoteToGet = notes[new Random().Next(notes.Count)];

			Trace.WriteLine("GetTicketNote using ticket note id: " + randomTicketNoteToGet.Id);

			TicketNote ticketNote = TestSetup.KayakoApiService.Tickets.GetTicketNote(randomTicket.Id, randomTicketNoteToGet.Id);

			CompareTicketNote(ticketNote, randomTicketNoteToGet);
		}

		[Test(Description = "Tests creating and deleting ticket posts")]
		public void CreateDeleteTicketPosts()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			StaffUserCollection staff = TestSetup.KayakoApiService.Staff.GetStaffUsers();
			StaffUser randomStaffUser = staff[new Random().Next(staff.Count)];
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());
			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			string contents = "This will be the contents";

            TicketNoteRequest request = new TicketNoteRequest()
            {
                TicketId = randomTicket.Id,
                Content = contents,
                StaffId = randomStaffUser.Id,
                ForStaffId = randomStaffUser.Id,
                NoteColor = NoteColor.Purple
            };

			TicketNote createdNote = TestSetup.KayakoApiService.Tickets.AddTicketNote(request);

			Assert.IsNotNull(createdNote);
			Assert.AreEqual(createdNote.Content, contents);
			Assert.AreEqual(createdNote.ForStaffId, randomStaffUser.Id);
			//Assert.AreEqual(createdNote.CreatorStaffId, randomStaffUser.Id);
			Assert.AreEqual(createdNote.NoteColor, NoteColor.Purple);
			Assert.AreEqual(createdNote.TicketId, randomTicket.Id);

			bool success = TestSetup.KayakoApiService.Tickets.DeleteTicketNote(randomTicket.Id, createdNote.Id);

			Assert.IsTrue(success);
		}

		public static void CompareTicketNote(TicketNote one, TicketNote two)
		{
			Assert.AreEqual(one.Content, two.Content);
			Assert.AreEqual(one.CreationDate, two.CreationDate);
			Assert.AreEqual(one.CreatorStaffId, two.CreatorStaffId);
			Assert.AreEqual(one.CreatorStaffName, two.CreatorStaffName);
			Assert.AreEqual(one.ForStaffId, two.ForStaffId);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.NoteColor, two.NoteColor);
			Assert.AreEqual(one.TicketId, two.TicketId);
			Assert.AreEqual(one.Type, two.Type);

			AssertObjectXmlEqual<TicketNote>(one, two);
		}
	}
}
