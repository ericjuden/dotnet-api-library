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

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description="A set of tests testing Api methods around Ticket Types")]
	public class TicketTypeTests : UnitTestBase
	{
        [Test]
		public void GetAllTicketTypes()
		{
			TicketTypeCollection ticketTypes = TestSetup.KayakoApiService.Tickets.GetTicketTypes();

            Assert.IsNotNull(ticketTypes, "No ticket types were returned");
            Assert.IsNotEmpty(ticketTypes, "No ticket types were returned");
		}

		[Test]
		public void GetTicketType()
		{
			TicketTypeCollection ticketTypes = TestSetup.KayakoApiService.Tickets.GetTicketTypes();

            Assert.IsNotNull(ticketTypes, "No ticket types were returned");
			Assert.IsNotEmpty(ticketTypes, "No ticket types were returned");

			TicketType randomTicketTypeToGet = ticketTypes[new Random().Next(ticketTypes.Count)];

			Trace.WriteLine("GetTicketType using ticket type id: " + randomTicketTypeToGet.Id);

			TicketType ticketType = TestSetup.KayakoApiService.Tickets.GetTicketType(randomTicketTypeToGet.Id);

			CompareTicketTypes(ticketType, randomTicketTypeToGet);
		}

        private void CompareTicketTypes(TicketType one, TicketType two)
        {
            Assert.AreEqual(one.DepartmentId, two.DepartmentId);
			Assert.AreEqual(one.DisplayIcon, two.DisplayIcon);
			Assert.AreEqual(one.DisplayOrder, two.DisplayOrder);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.Title, two.Title);
			Assert.AreEqual(one.Type, two.Type);
			Assert.AreEqual(one.UserGroupId, two.UserGroupId);
			Assert.AreEqual(one.UserVisibilityCustom, two.UserVisibilityCustom);

			AssertObjectXmlEqual<TicketType>(one, two);
        }
	}
}
