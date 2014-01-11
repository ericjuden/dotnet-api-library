using System.Collections.Generic;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Tickets
{
	[TestFixture]
	public class TicketCustomFieldCollectionSerializationTests
	{
		[Test]
		public void TicketCustomFieldCollectionDeserialization()
		{
			var ticketcustomFields = new TicketCustomFields
				{
					FieldGroups = new List<TicketCustomFieldGroup>
						{
							new TicketCustomFieldGroup
								{
									Id = 4,
									Title = "Test Ticket",
									Fields = new []
										{
											new TicketCustomField
											{
												Id = 2,
												Type = TicketCustomFieldType.Text,
												Name = "ab32ds122",
												Title = "Test",
												FieldContent = "Test Plaintext Field"
											},
											new TicketCustomField
											{
												Id = 3,
												Type = TicketCustomFieldType.LinkedSelectFields,
												Name = "fd923nds2",
												Title = "Linked Select",
												FieldContent = "Product > Fusion"
											},
											new TicketCustomField
											{
												Id = 4,
												Type = TicketCustomFieldType.MultiSelect,
												Name = "mcz923nxa",
												Title = "Multiple",
												FieldContent = "Value1, Value2"
											},
											new TicketCustomField
											{
												Id = 5,
												Type = TicketCustomFieldType.Date,
												Name = "z13nc8923",
												Title = "Date",
												FieldContent = "05/24/2011"
											},
											new TicketCustomField
											{
												Id = 6,
												Type = TicketCustomFieldType.File,
												FileName = "report.txt",
												Name = "mds923nx92",
												Title = "File",
												FieldContent = "VTFkSlJsUXRNVE01TURvZ1EzVnpkRzl0SUVacFpXeGtjeUJwYmlCVWFXTnJaWFFnVm1sbGQzTUtDbE5YU1VaVUxURXpPVEU2SUZCMVlteHBZeTlRY21sMllYUmxJRlpwYzJsaWFXeHBkSGtnVkc5bloyeGxJR2x1SUZWelpYSXZWWE5sY2lCUGNtZGhibWw2WVhScGIyNGdRM1Z6ZEc5dElFWnBaV3hrSUVkeWIzVndjd29L"
											}
										}
								}
						}
				};

			var expectedTicketCustomFields = XmlDataUtility.ReadFromFile<TicketCustomFields>("TestData/TicketCustomFields.xml");

			AssertUtility.ObjectsEqual(expectedTicketCustomFields, ticketcustomFields);
		}
	}
}
