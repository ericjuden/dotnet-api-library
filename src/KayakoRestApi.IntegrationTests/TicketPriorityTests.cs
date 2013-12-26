using System;
using System.Diagnostics;
using NUnit.Framework;
using KayakoRestApi.Core;
using KayakoRestApi.Core.Tickets;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Priorities")]
	public class TicketPriorityTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketPriorities()
		{
			TicketPriorityCollection ticketPriorities = TestSetup.KayakoApiService.Tickets.GetTicketPriorities();

			Assert.IsNotNull(ticketPriorities, "No ticket priorities were returned");
			Assert.IsNotEmpty(ticketPriorities, "No ticket priorities were returned");
		}

		[Test]
		public void GetTicketPriority()
		{
			TicketPriorityCollection ticketPriorities = TestSetup.KayakoApiService.Tickets.GetTicketPriorities();

			Assert.IsNotNull(ticketPriorities, "No ticket priorities were returned");
			Assert.IsNotEmpty(ticketPriorities, "No ticket priorities were returned");

			TicketPriority randomTicketPriorityToGet = ticketPriorities[new Random().Next(ticketPriorities.Count)];

			Trace.WriteLine("GetTicketPriority using ticket priority id: " + randomTicketPriorityToGet.Id);

			TicketPriority ticketPriority = TestSetup.KayakoApiService.Tickets.GetTicketPriority(randomTicketPriorityToGet.Id);

			CompareTicketPriorities(ticketPriority, randomTicketPriorityToGet);
		}

		private void CompareTicketPriorities(TicketPriority one, TicketPriority two)
        {
            Assert.AreEqual(one.BgColorCode, two.BgColorCode);
			Assert.AreEqual(one.DisplayIcon, two.DisplayIcon);
			Assert.AreEqual(one.DisplayOrder, two.DisplayOrder);
			Assert.AreEqual(one.FrColorCode, two.FrColorCode);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.Title, two.Title);
			Assert.AreEqual(one.Type, two.Type);
			Assert.AreEqual(one.UserGroupId, two.UserGroupId);
			Assert.AreEqual(one.UserVisibilityCustom, two.UserVisibilityCustom);

			AssertObjectXmlEqual<TicketPriority>(one, two);
        }
	}
}
