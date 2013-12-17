using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Core;
using System.Xml.Serialization;
using System.IO;
using KayakoRestApi.Core.Tickets;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description="A set of tests testing Api methods around Ticket Counts")]
	public class TicketCountTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketCount()
		{
			TicketCount ticketCount = TestSetup.KayakoApiService.Tickets.GetTicketCounts();

			Assert.IsNotNull(ticketCount, "No ticket counts were returned");
			
			OutputMessage<TicketCount>("Ticket Count Result: ", ticketCount);
		}
	}
}
