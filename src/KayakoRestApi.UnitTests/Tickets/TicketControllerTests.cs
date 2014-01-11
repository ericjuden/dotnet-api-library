using System;
using System.Collections.Generic;
using System.Linq;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Net;
using KayakoRestApi.UnitTests.Utilities;
using Moq;
using NUnit.Framework;
using KayakoRestApi.Controllers;

namespace KayakoRestApi.UnitTests.Tickets
{
	[TestFixture]
	public class TicketControllerTests
	{
		private ITicketController _ticketController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;

		private TicketCollection _responseTicketCollection;
		private TicketRequest _createTicketRequestRequiredFields;
		private string _createTicketRequiredFieldsParameters;
		private TicketCustomFields _responseTicketCustomFields;

		[SetUp]
		public void Setup()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();

			_ticketController = new TicketController(_kayakoApiRequest.Object);

			_responseTicketCollection = new TicketCollection
				{
					new Ticket()
				};

			_createTicketRequestRequiredFields = new TicketRequest
				{
					Subject = "Subject",
					FullName = "Fullname",
					Email = "email@email.com",
					Contents = "Contents",
					DepartmentId = 1,
					TicketStatusId = 2,
					TicketPriorityId = 3,
					TicketTypeId = 4
				};

			_createTicketRequiredFieldsParameters = "subject=Subject&fullname=Fullname&email=email@email.com&contents=Contents&departmentid=1&ticketstatusid=2&ticketpriorityid=3&tickettypeid=4";

			_responseTicketCustomFields = new TicketCustomFields
				{
					FieldGroups = new List<TicketCustomFieldGroup>
						{
							new TicketCustomFieldGroup
								{
									Id = 1,
									Title = "Title",
									Fields = new[]
										{
											new TicketCustomField
												{
													Type = TicketCustomFieldType.Text,
													Name = "FieldName1",
													FieldContent = "content1"
												},
											new TicketCustomField
												{
													Type = TicketCustomFieldType.Text,
													Name = "FieldName2",
													FieldContent = "content2"
												}
										}
								}
						}
				};
		}

		#region Update Ticket

		[Test]
		public void UpdateTicket()
		{
			var ticketRequest = new TicketRequest
				{
					Id = 39,
					Subject = "Subject",
					FullName = "Fullname",
					Email = "email@email.com",
					DepartmentId = 1,
					TicketStatusId = 2,
					TicketPriorityId = 3,
					TicketTypeId = 4,
					OwnerStaffId = 5,
					UserId = 6,
					TemplateGroupId = 7
				};

			string parameters = "subject=Subject&fullname=Fullname&email=email@email.com&departmentid=1&ticketstatusid=2&ticketpriorityid=3&tickettypeid=4&ownerstaffid=5&userid=6&templategroup=7";

			UpdateTicketRequest(parameters, ticketRequest);
		}

		[Test]
		public void UpdateTicket_TemplateGroupId()
		{
			var ticketRequest = new TicketRequest
				{
					Id = 39,
					TemplateGroupId = 1
				};

			const string parameters = "templategroup=1";

			UpdateTicketRequest(parameters, ticketRequest);
		}

		[Test]
		public void UpdateTicket_TemplateGroupName()
		{
			var ticketRequest = new TicketRequest
			{
				Id = 39,
				TemplateGroupName = "templatename"
			};

			const string parameters = "templategroup=templatename";

			UpdateTicketRequest(parameters, ticketRequest);
		}

		private void UpdateTicketRequest(string parameters, TicketRequest ticketRequest)
		{
			string apiMethod = String.Format("/Tickets/Ticket/{0}", ticketRequest.Id);

			_kayakoApiRequest.Setup(x => x.ExecutePut<TicketCollection>(apiMethod, parameters)).Returns(_responseTicketCollection);

			Ticket ticket = _ticketController.UpdateTicket(ticketRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<TicketCollection>(apiMethod, parameters), Times.Once());

			Assert.That(ticket, Is.EqualTo(_responseTicketCollection.FirstOrDefault()));
		}

		#endregion

		#region Create Ticket

		[Test]
		public void CreateTicket()
		{
			_createTicketRequestRequiredFields.AutoUserId = true;

			string parameters = string.Format("{0}&autouserid=1", _createTicketRequiredFieldsParameters);

			CreateTicketRequest(parameters, _createTicketRequestRequiredFields);
		}

		[Test]
		public void CreateTicket_TemplateGroupId()
		{
			_createTicketRequestRequiredFields.TemplateGroupId = 1;

			string parameters = string.Format("{0}&templategroup=1", _createTicketRequiredFieldsParameters);

			CreateTicketRequest(parameters, _createTicketRequestRequiredFields);
		}

		[Test]
		public void CreateTicket_TemplateGroupName()
		{
			_createTicketRequestRequiredFields.TemplateGroupName = "templatename";

			string parameters = string.Format("{0}&templategroup=templatename", _createTicketRequiredFieldsParameters);

			CreateTicketRequest(parameters, _createTicketRequestRequiredFields);
		}

		private void CreateTicketRequest(string parameters, TicketRequest ticketRequest)
		{
			string apiMethod = "/Tickets/Ticket";

			_kayakoApiRequest.Setup(x => x.ExecutePost<TicketCollection>(apiMethod, parameters)).Returns(_responseTicketCollection);

			Ticket ticket = _ticketController.CreateTicket(ticketRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<TicketCollection>(apiMethod, parameters), Times.Once());

			Assert.That(ticket, Is.EqualTo(_responseTicketCollection.FirstOrDefault()));
		}

		#endregion

		#region Ticket Custom Field Methods

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetTicketCustomFields(int ticketId)
		{
			var apiMethod = string.Format("/Tickets/TicketCustomField/{0}", ticketId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<TicketCustomFields>(apiMethod)).Returns(_responseTicketCustomFields);

			var ticketCustomFields = _ticketController.GetTicketCustomFields(ticketId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TicketCustomFields>(apiMethod), Times.Once());
			AssertUtility.ObjectsEqual(ticketCustomFields, _responseTicketCustomFields);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void UpdateTicketCustomField(int ticketId)
		{
			var apiMethod = string.Format("/Tickets/TicketCustomField/{0}", ticketId);
			const string parameters = "FieldName1=content1&FieldName2=content2";

			_kayakoApiRequest.Setup(x => x.ExecutePost<TicketCustomFields>(apiMethod, parameters)).Returns(_responseTicketCustomFields);

			var ticketCustomFields = _ticketController.UpdateTicketCustomFields(ticketId, _responseTicketCustomFields);

			_kayakoApiRequest.Verify(x => x.ExecutePost<TicketCustomFields>(apiMethod, parameters), Times.Once());
			AssertUtility.ObjectsEqual(ticketCustomFields, _responseTicketCustomFields);
		}

		#endregion
	}
}
