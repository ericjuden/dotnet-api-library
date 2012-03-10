using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Core.Departments;

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

		[Test]
		public void UpdateTicketCustomFields()
		{
			DepartmentCollection depts = TestSetup.KayakoApiService.Departments.GetDepartments();
			TicketCollection tickets = TestSetup.KayakoApiService.Tickets.GetTickets(depts.Select(d => d.Id).ToArray());

			int idToUse = -1;

			foreach (Ticket ticket in tickets)
			{
				TicketCustomFields ticketCustomFields = TestSetup.KayakoApiService.Tickets.GetTicketCustomFields(ticket.Id);

				if (ticketCustomFields.FieldGroups.Count > 0)
				{
					if (ticketCustomFields.FieldGroups.Where(tcf => tcf.Fields.Length > 0 && tcf.Fields.Any(a => a.Type == Core.Constants.TicketCustomFieldType.Text || a.Type == Core.Constants.TicketCustomFieldType.TextArea)).Any())
					{
						idToUse = ticket.Id;
						break;
					}
				}
			}

			if (idToUse != -1)
			{
				TicketCustomFields ticketCustomFields = TestSetup.KayakoApiService.Tickets.GetTicketCustomFields(idToUse);

				TicketCustomFieldGroup group = ticketCustomFields.FieldGroups.FirstOrDefault(customField => customField.Fields.Length > 0);
				TicketCustomField field = group.Fields.FirstOrDefault(type => type.Type == Core.Constants.TicketCustomFieldType.Text || type.Type == Core.Constants.TicketCustomFieldType.TextArea);
				field.FieldContent = String.Format("This was updated at : {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));

				TicketCustomFields updatedTicketCustomFields = TestSetup.KayakoApiService.Tickets.UpdateTicketCustomFields(idToUse, ticketCustomFields);

				TicketCustomFieldGroup updatedGroup = updatedTicketCustomFields.FieldGroups.FirstOrDefault(customField => customField.Fields.Length > 0);
				TicketCustomField updatedField = updatedGroup.Fields.FirstOrDefault(type => type.Type == Core.Constants.TicketCustomFieldType.Text || type.Type == Core.Constants.TicketCustomFieldType.TextArea);

				Assert.AreEqual(field.FieldContent, updatedField.FieldContent);
			}
			else
			{
				throw new Exception("Could not find any tickets with any text/text area custom fields.");
			}
		}
	}
}
