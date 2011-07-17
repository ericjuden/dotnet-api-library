using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KayakoRestApi.Core.Tickets;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Custom Fields")]
	public class TicketCustomFieldTests : UnitTestBase
	{
		[Test]
		public void GetTicketsCustomFields()
		{
			TicketCustomFields ticketCustomFields = TestSetup.KayakoApiService.Tickets.GetTicketCustomFields(2);

			Assert.IsNotNull(ticketCustomFields.FieldGroups, "No ticket custom fields were returned");
			Assert.IsNotEmpty(ticketCustomFields.FieldGroups, "No ticket custom fields were returned");

			OutputMessage<TicketCustomFields>("Result: ", ticketCustomFields);
		}
	}
}
