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
	}
}
