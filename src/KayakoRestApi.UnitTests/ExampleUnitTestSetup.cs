using System.Diagnostics;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Departments;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests
{
	[TestFixture]
	public class ExampleUnitTestSetup
	{
		private Mock<IKayakoClient> _kayakoClient;
		private Mock<ICoreController> _coreController;
		private Mock<ICustomFieldController> _customFieldController;
		private Mock<IDepartmentController> _departmentController;
		private Mock<IKnowledgebaseController> _knowledgebaseController;
		private Mock<INewsController> _newsController;
		private Mock<IStaffController> _staffController;
		private Mock<ITicketController> _ticketController;
		private Mock<ITroubleshooterController> _troubleshooterController;
		private Mock<IUserController> _userController;

		[SetUp]
		public void Setup()
		{
			_coreController = new Mock<ICoreController>();
			_customFieldController = new Mock<ICustomFieldController>();
			_departmentController = new Mock<IDepartmentController>();
			_knowledgebaseController = new Mock<IKnowledgebaseController>();
			_newsController = new Mock<INewsController>();
			_staffController = new Mock<IStaffController>();
			_ticketController = new Mock<ITicketController>();
			_troubleshooterController = new Mock<ITroubleshooterController>();
			_userController = new Mock<IUserController>();

			_kayakoClient = new Mock<IKayakoClient>();
			_kayakoClient.Setup(x => x.Core).Returns(_coreController.Object);
			_kayakoClient.Setup(x => x.CustomFields).Returns(_customFieldController.Object);
			_kayakoClient.Setup(x => x.Departments).Returns(_departmentController.Object);
			_kayakoClient.Setup(x => x.Knowledgebase).Returns(_knowledgebaseController.Object);
			_kayakoClient.Setup(x => x.News).Returns(_newsController.Object);
			_kayakoClient.Setup(x => x.Staff).Returns(_staffController.Object);
			_kayakoClient.Setup(x => x.Tickets).Returns(_ticketController.Object);
			_kayakoClient.Setup(x => x.Troubleshooter).Returns(_troubleshooterController.Object);
			_kayakoClient.Setup(x => x.Users).Returns(_userController.Object);
		}

		[Test]
		public void ListDepartments()
		{
			var departmentCollection = new DepartmentCollection
				{
					new Department {Title = "Department 1"},
					new Department {Title = "Department 2"},
					new Department {Title = "Department 3"}
				};

			_departmentController.Setup(x => x.GetDepartments()).Returns(departmentCollection);

			var departments = _kayakoClient.Object.Departments.GetDepartments();

			Assert.That(departments, Is.EqualTo(departmentCollection));

			foreach (var department in departments)
			{
				Trace.WriteLine(department.Title);
			}
		}
	}
}
