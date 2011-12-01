using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Core;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description="A set of tests testing Api methods around Ticket Time Tracks")]
	public class TicketTimeTrackTests : UnitTestBase
	{
		private TicketTimeTrack TestData
		{
			get
			{
				DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
				TimeSpan diff = DateTime.Now - origin;

				Ticket ticket = TestSetup.KayakoApiService.Tickets.GetTickets(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })[0];

				Assert.IsNotNull(ticket);

				TicketTimeTrack ticketTimeTrack = new TicketTimeTrack();

				ticketTimeTrack.TicketId = ticket.Id;
				ticketTimeTrack.BillDate = Math.Floor(diff.TotalSeconds).ToString();
				ticketTimeTrack.Contents = "Test Contents";
				ticketTimeTrack.CreatorStaffId = 1;
				ticketTimeTrack.TimeBillable = 5000;
				ticketTimeTrack.TimeWorked = 6000;
				ticketTimeTrack.WorkerStaffId = 1;
				ticketTimeTrack.WorkDate = Math.Floor(diff.TotalSeconds).ToString();
				ticketTimeTrack.NoteColor = NoteColor.Green;

				return ticketTimeTrack;
			}
		}

        [Test]
		public void GetTicketTimeTracks()
		{
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

			TicketTimeTrackCollection ticketTimeTracks = null;
			foreach (Ticket t in tickets)
			{
				ticketTimeTracks = TestSetup.KayakoApiService.Tickets.GetTicketTimeTracks(t.Id);

				if (ticketTimeTracks.Count > 0)
				{
					break;
				}
			}

            Assert.IsNotNull(tickets, "No ticket time tracks were returned");
			Assert.IsNotEmpty(tickets, "No ticket time tracks returned");
		}

		[Test]
		public void GetTicketTimeTrack()
		{
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(new int[] { 1, 2 });

			Assert.IsNotNull(tickets, "No tickets were returned");
			Assert.IsNotEmpty(tickets, "No tickets were returned");

			TicketTimeTrackCollection ticketTimeTracks = null;
			foreach (Ticket t in tickets)
			{
				ticketTimeTracks = TestSetup.KayakoApiService.Tickets.GetTicketTimeTracks(t.Id);

				if (ticketTimeTracks.Count > 0)
				{
					break;
				}
			}

            Assert.IsNotNull(ticketTimeTracks, "No ticket time tracks were returned");
			Assert.IsNotEmpty(ticketTimeTracks, "No ticket time tracks were returned");

			TicketTimeTrack randomTicketTimeTrackToGet = ticketTimeTracks[new Random().Next(ticketTimeTracks.Count)];

			Trace.WriteLine("GetTicketType using ticket time tracks id: " + randomTicketTimeTrackToGet.Id);

			TicketTimeTrack ticketTimeTrack = TestSetup.KayakoApiService.Tickets.GetTicketTimeTrack(randomTicketTimeTrackToGet.TicketId, randomTicketTimeTrackToGet.Id);

			CompareTicketTimeTracks(ticketTimeTrack, randomTicketTimeTrackToGet);
		}

		[Test(Description = "Tests creating, updating and deleting Ticket Time Tracks")]
		public void CreateUpdateDeleteTimeTracks()
		{
			TicketTimeTrack dummyData = TestData;

            TicketTimeTrackRequest request = TicketTimeTrackRequest.FromResponseData(dummyData);

			TicketTimeTrack createdTicketTimeTrack = TestSetup.KayakoApiService.Tickets.AddTicketTimeTrackingNote(request);

			Assert.IsNotNull(createdTicketTimeTrack);
			dummyData.Id = createdTicketTimeTrack.Id;
			dummyData.CreatorStaffName = createdTicketTimeTrack.CreatorStaffName;
			dummyData.WorkerStaffName = createdTicketTimeTrack.WorkerStaffName;

			CompareTicketTimeTracks(dummyData, createdTicketTimeTrack);

			bool success = TestSetup.KayakoApiService.Tickets.DeleteTicketTimeTrackingNote(createdTicketTimeTrack.TicketId, createdTicketTimeTrack.Id);

			Assert.IsTrue(success);
		}

		private void CompareTicketTimeTracks(TicketTimeTrack one, TicketTimeTrack two)
        {
            Assert.AreEqual(one.BillDate, two.BillDate);
			Assert.AreEqual(one.Contents, two.Contents);
			Assert.AreEqual(one.CreatorStaffId, two.CreatorStaffId);
			Assert.AreEqual(one.CreatorStaffName, two.CreatorStaffName);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.NoteColor, two.NoteColor);
			Assert.AreEqual(one.TicketId, two.TicketId);
			Assert.AreEqual(one.TimeBillable, two.TimeBillable);
			Assert.AreEqual(one.TimeWorked, two.TimeWorked);
			Assert.AreEqual(one.WorkDate, two.WorkDate);
			Assert.AreEqual(one.WorkerStaffId, two.WorkerStaffId);
			Assert.AreEqual(one.WorkerStaffName, two.WorkerStaffName);

			AssertObjectXmlEqual<TicketTimeTrack>(one, two);
        }
	}
}
