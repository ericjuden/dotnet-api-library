using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Departments;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Ticket Statuses")]
	public class TicketSearchTests : UnitTestBase
	{
		[Test]
		public void DoTicketSearch()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			depts.Add(new Department() { Id = 0 });

			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());

			Ticket randomTicket = tickets[new Random().Next(tickets.Count)];

			int expectedSearchAmount = tickets.Where(t => t.Email.Equals(randomTicket.Email, StringComparison.InvariantCultureIgnoreCase)).Count();

			TicketSearchQuery query = new TicketSearchQuery(randomTicket.Email);
			query.AddSearchField(TicketSearchField.EmailAddress);

			TicketCollection queriedTickets = TestSetup.KayakoApiService.Tickets.SearchTickets(query);

			Assert.AreEqual(expectedSearchAmount, queriedTickets.Count);
		}
	}
}
