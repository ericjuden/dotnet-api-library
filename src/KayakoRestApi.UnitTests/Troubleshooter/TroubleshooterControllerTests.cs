using System.Linq;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.Net;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterControllerTests
	{
		private ITroubleshooterController _troubleshooterController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;
		private TroubleshooterCategoryCollection _responseTroubleshooterCategoryCollection;
		private TroubleshooterStepCollection _responseTroubleshooterStepCollection;
		private TroubleshooterCommentCollection _responseTroubleshooterCommentCollection;

		[SetUp]
		public void Setup()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();
			_troubleshooterController = new TroubleshooterController(_kayakoApiRequest.Object);

			_responseTroubleshooterCategoryCollection = new TroubleshooterCategoryCollection
				{
					new TroubleshooterCategory(),
					new TroubleshooterCategory()
				};

			_responseTroubleshooterStepCollection = new TroubleshooterStepCollection
				{
					new TroubleshooterStep(),
					new TroubleshooterStep()
				};

			_responseTroubleshooterCommentCollection = new TroubleshooterCommentCollection
				{
					new TroubleshooterComment(),
					new TroubleshooterComment()
				};
		}

		#region Troubleshooter Categories Tests

		[Test]
		public void GetTroubleshooterCategories()
		{
			const string apiMethod = "/Troubleshooter/Category";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterCategoryCollection>(apiMethod)).Returns(_responseTroubleshooterCategoryCollection);

			var troubleshooterCategories = _troubleshooterController.GetTroubleshooterCategories();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterCategoryCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterCategories, Is.EqualTo(_responseTroubleshooterCategoryCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetTroubleshooterCategory(int troubleshooterCategoryId)
		{
			var apiMethod = string.Format("/Troubleshooter/Category/{0}", troubleshooterCategoryId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterCategoryCollection>(apiMethod)).Returns(_responseTroubleshooterCategoryCollection);

			var troubleshooterCategory = _troubleshooterController.GetTroubleshooterCategory(troubleshooterCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterCategoryCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterCategory, Is.EqualTo(_responseTroubleshooterCategoryCollection.First()));
		}

		[Test]
		public void CreateTroubleshooterCategory()
		{
			var troubleshooterCategoryRequest = new TroubleshooterCategoryRequest
			{
				Title = "TitleCategory",
				CategoryType = TroubleshooterCategoryType.Private,
				StaffId = 2,
				DisplayOrder = 1,
				Description = "Description",
				UserVisibilityCustom = true,
				UserGroupIdList = new [] { 1, 2, 3 },
				StaffVisibilityCustom = true,
				StaffGroupIdList = new [] { 3, 4, 5}
			};

			const string apiMethod = "/Troubleshooter/Category";
			const string parameters = "title=TitleCategory&categorytype=3&staffid=2&displayorder=1&description=Description&uservisibilitycustom=1&usergroupidlist=1,2,3&staffvisibilitycustom=1&staffgroupidlist=3,4,5";

			_kayakoApiRequest.Setup(x => x.ExecutePost<TroubleshooterCategoryCollection>(apiMethod, parameters)).Returns(_responseTroubleshooterCategoryCollection);

			var troubleshooterCategory = _troubleshooterController.CreateTroubleshooterCategory(troubleshooterCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<TroubleshooterCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(troubleshooterCategory, Is.EqualTo(_responseTroubleshooterCategoryCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateTroubleshooterCategory()
		{
			var troubleshooterCategoryRequest = new TroubleshooterCategoryRequest
			{
				Title = "TitleCategory",
				CategoryType = TroubleshooterCategoryType.Public,
				DisplayOrder = 1,
				Description = "Description",
				UserVisibilityCustom = true,
				UserGroupIdList = new[] { 1, 2, 3 },
				StaffVisibilityCustom = true,
				StaffGroupIdList = new[] { 3, 4, 5 }
			};

			var apiMethod = string.Format("/Troubleshooter/Category/{0}", troubleshooterCategoryRequest.Id);
			const string parameters = "title=TitleCategory&categorytype=2&displayorder=1&description=Description&uservisibilitycustom=1&usergroupidlist=1,2,3&staffvisibilitycustom=1&staffgroupidlist=3,4,5";

			_kayakoApiRequest.Setup(x => x.ExecutePut<TroubleshooterCategoryCollection>(apiMethod, parameters)).Returns(_responseTroubleshooterCategoryCollection);

			var troubleshooterCategory = _troubleshooterController.UpdateTroubleshooterCategory(troubleshooterCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<TroubleshooterCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(troubleshooterCategory, Is.EqualTo(_responseTroubleshooterCategoryCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteTroubleshooterCategory(int troubleshooterCategoryId)
		{
			string apiMethod = string.Format("/Troubleshooter/Category/{0}", troubleshooterCategoryId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _troubleshooterController.DeleteTroubleshooterCategory(troubleshooterCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.IsTrue(deleteSuccess);
		}

		#endregion

		#region Troubleshooter Step Methods

		[Test]
		public void GetTroubleshooterSteps()
		{
			const string apiMethod = "/Troubleshooter/Step";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterStepCollection>(apiMethod)).Returns(_responseTroubleshooterStepCollection);

			var troubleshooterSteps = _troubleshooterController.GetTroubleshooterSteps();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterStepCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterSteps, Is.EqualTo(_responseTroubleshooterStepCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetTroubleshooterStep(int troubleshooterStepId)
		{
			var apiMethod = string.Format("/Troubleshooter/Step/{0}", troubleshooterStepId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterStepCollection>(apiMethod)).Returns(_responseTroubleshooterStepCollection);

			var troubleshooterStep = _troubleshooterController.GetTroubleshooterStep(troubleshooterStepId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterStepCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterStep, Is.EqualTo(_responseTroubleshooterStepCollection.First()));
		}

		[Test]
		public void CreateTroubleshooterStep()
		{
			var troubleshooterStepRequest = new TroubleshooterStepRequest
			{
				CategoryId = TroubleshooterCategoryType.Private,
				Subject = "Subject",
				Contents = "Contents",
				StaffId = 3,
				DisplayOrder = 15,
				AllowComments = true,
				EnableTicketRedirection = false,
				RedirectDepartmentId = 4,
				TicketTypeId = 4,
				TicketPriorityId = 2,
				TicketSubject = "Ticket Subject",
				StepStatus = TroubleshooterStepStatus.Published,
				ParentStepIdList = new [] { 1, 2, 3 }
			};

			const string apiMethod = "/Troubleshooter/Step";
			const string parameters = "categoryid=3&subject=Subject&contents=Contents&staffid=3&displayorder=15&allowcomments=1&enableticketredirection=0&redirectdepartmentid=4&tickettypeid=4&ticketpriorityid=2&ticketsubject=Ticket Subject&stepstatus=1&parentstepidlist=1,2,3";

			_kayakoApiRequest.Setup(x => x.ExecutePost<TroubleshooterStepCollection>(apiMethod, parameters)).Returns(_responseTroubleshooterStepCollection);

			var troubleshooterStep = _troubleshooterController.CreateTroubleshooterStep(troubleshooterStepRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<TroubleshooterStepCollection>(apiMethod, parameters), Times.Once());
			Assert.That(troubleshooterStep, Is.EqualTo(_responseTroubleshooterStepCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateTroubleshooterStep()
		{
			var troubleshooterStepRequest = new TroubleshooterStepRequest
			{
				StaffId = 3,
				Subject = "Subject",
				Contents = "Contents",
				DisplayOrder = 4,
				AllowComments = true,
				EnableTicketRedirection = false,
				RedirectDepartmentId = 3,
				TicketTypeId = 1,
				TicketPriorityId = 3,
				TicketSubject = "Ticket Subject",
				StepStatus = TroubleshooterStepStatus.Published,
				ParentStepIdList = new [] { 1, 3, 5 }
			};

			var apiMethod = string.Format("/Troubleshooter/Step/{0}", troubleshooterStepRequest.Id);
			const string parameters = "subject=Subject&contents=Contents&editedstaffid=3&displayorder=4&allowcomments=1&enableticketredirection=0&redirectdepartmentid=3&tickettypeid=1&ticketpriorityid=3&ticketsubject=Ticket Subject&stepstatus=1&parentstepidlist=1,3,5";

			_kayakoApiRequest.Setup(x => x.ExecutePut<TroubleshooterStepCollection>(apiMethod, parameters)).Returns(_responseTroubleshooterStepCollection);

			var troubleshooterStep = _troubleshooterController.UpdateTroubleshooterStep(troubleshooterStepRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<TroubleshooterStepCollection>(apiMethod, parameters), Times.Once());
			Assert.That(troubleshooterStep, Is.EqualTo(_responseTroubleshooterStepCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteTroubleshooterStep(int troubleshooterStepId)
		{
			string apiMethod = string.Format("/Troubleshooter/Step/{0}", troubleshooterStepId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _troubleshooterController.DeleteTroubleshooterStep(troubleshooterStepId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.IsTrue(deleteSuccess);
		}

		#endregion

		#region Troubleshooter Comment Methods

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetTroubleshooterComments(int troubleshooterStepId)
		{
			string apiMethod = string.Format("/Troubleshooter/Comment/ListAll/{0}", troubleshooterStepId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterCommentCollection>(apiMethod)).Returns(_responseTroubleshooterCommentCollection);

			var troubleshooterComments = _troubleshooterController.GetTroubleshooterComments(troubleshooterStepId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterCommentCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterComments, Is.EqualTo(_responseTroubleshooterCommentCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetTroubleshooterComment(int troubleshooterCommentId)
		{
			var apiMethod = string.Format("/Troubleshooter/Comment/{0}", troubleshooterCommentId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TroubleshooterCommentCollection>(apiMethod)).Returns(_responseTroubleshooterCommentCollection);

			var troubleshooterComment = _troubleshooterController.GetTroubleshooterComment(troubleshooterCommentId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TroubleshooterCommentCollection>(apiMethod), Times.Once());

			Assert.That(troubleshooterComment, Is.EqualTo(_responseTroubleshooterCommentCollection.First()));
		}

		[Test]
		public void CreateTroubleshooterComment()
		{
			var troubleshooterCommentRequest = new TroubleshooterCommentRequest
			{
				TroubleshooterStepId = 1,
				Contents = "Contents",
				CreatorType = TroubleshooterCommentCreatorType.User,
				CreatorId = 1,
				FullName = "FullName",
				Email = "email@domain.com",
				ParentCommentId = 3
			};

			const string apiMethod = "/Troubleshooter/Comment";
			const string parameters = "troubleshooterstepid=1&contents=Contents&creatortype=2&creatorid=1&fullname=FullName&email=email@domain.com&parentcommentid=3";

			_kayakoApiRequest.Setup(x => x.ExecutePost<TroubleshooterCommentCollection>(apiMethod, parameters)).Returns(_responseTroubleshooterCommentCollection);

			var troubleshooterComment = _troubleshooterController.CreateTroubleshooterComment(troubleshooterCommentRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<TroubleshooterCommentCollection>(apiMethod, parameters), Times.Once());
			Assert.That(troubleshooterComment, Is.EqualTo(_responseTroubleshooterCommentCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteTroubleshooterComment(int troubleshooterCommentId)
		{
			string apiMethod = string.Format("/Troubleshooter/Comment/{0}", troubleshooterCommentId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _troubleshooterController.DeleteTroubleshooterComment(troubleshooterCommentId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.IsTrue(deleteSuccess);
		}

		#endregion
	}
}
