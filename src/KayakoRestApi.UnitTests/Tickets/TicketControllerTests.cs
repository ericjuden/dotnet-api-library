using System;
using System.Linq;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Net;
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
	}
}
