using System;
using System.Diagnostics;
using NUnit.Framework;
using KayakoRestApi.Core.Tickets;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Statuses")]
	public class TicketStatusTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketStatuses()
		{
			TicketStatusCollection ticketStatuses = TestSetup.KayakoApiService.Tickets.GetTicketStatuses();

			Assert.IsNotNull(ticketStatuses, "No ticket statuses were returned");
			Assert.IsNotEmpty(ticketStatuses, "No ticket statuses were returned");
		}

		[Test]
		public void GetTicketType()
		{
			TicketStatusCollection ticketStatuses = TestSetup.KayakoApiService.Tickets.GetTicketStatuses();

            Assert.IsNotNull(ticketStatuses, "No ticket statuses were returned");
			Assert.IsNotEmpty(ticketStatuses, "No ticket statuses were returned");

			TicketStatus randomTicketStatusToGet = ticketStatuses[new Random().Next(ticketStatuses.Count)];

			Trace.WriteLine("GetTicketType using ticket status id: " + randomTicketStatusToGet.Id);

			TicketStatus ticketType = TestSetup.KayakoApiService.Tickets.GetTicketStatus(randomTicketStatusToGet.Id);

			CompareTicketTypes(ticketType, randomTicketStatusToGet);
		}

		private void CompareTicketTypes(TicketStatus one, TicketStatus two)
        {
            Assert.AreEqual(one.DepartmentId, two.DepartmentId);
			Assert.AreEqual(one.DisplayCount, two.DisplayCount);
			Assert.AreEqual(one.DisplayIcon, two.DisplayIcon);
			Assert.AreEqual(one.DisplayInMainList, two.DisplayInMainList);
			Assert.AreEqual(one.DisplayOrder, two.DisplayOrder);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.MarkAsResolved, two.MarkAsResolved);
			Assert.AreEqual(one.ResetDueTime, two.ResetDueTime);
			Assert.AreEqual(one.StaffGroupId, two.StaffGroupId);
			Assert.AreEqual(one.StaffVisibilityCustom, two.StaffVisibilityCustom);
			Assert.AreEqual(one.StatusBgColor, two.StatusBgColor);
			Assert.AreEqual(one.StatusColor, two.StatusColor);
			Assert.AreEqual(one.Title, two.Title);
			Assert.AreEqual(one.TriggerSurvey, two.TriggerSurvey);
			Assert.AreEqual(one.Type, two.Type);

			AssertObjectXmlEqual<TicketStatus>(one, two);
        }
	}
}
