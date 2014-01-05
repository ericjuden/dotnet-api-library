using System;
using System.Linq;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Net;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseControllerTests
	{
		private IKnowledgebaseController _knowledgebaseController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;
		private KnowledgebaseCategoryCollection _responseKnowledgebaseCategoryCollection;

		[SetUp]
		public void Setup()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();
			_knowledgebaseController = new KnowledgebaseController(_kayakoApiRequest.Object);

			_responseKnowledgebaseCategoryCollection = new KnowledgebaseCategoryCollection
				{
					new KnowledgebaseCategory(),
					new KnowledgebaseCategory()
				};
		}

		#region Knowledgebase Category Methods

		[Test]
		public void GetKnowledgebaseCategories()
		{
			const string apiMethod = "/Knowledgebase/Category/ListAll/-1/-1";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod)).Returns(_responseKnowledgebaseCategoryCollection);

			var knowledgebaseCategories = _knowledgebaseController.GetKnowledgebaseCategories();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseCategories, Is.EqualTo(_responseKnowledgebaseCategoryCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetKnowledgebaseCategory(int knowledgebaseCategoryId)
		{
			string apiMethod = string.Format("/Knowledgebase/Category/{0}", knowledgebaseCategoryId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod)).Returns(_responseKnowledgebaseCategoryCollection);

			var knowledgebaseCategory = _knowledgebaseController.GetKnowledgebaseCategory(knowledgebaseCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseCategory, Is.EqualTo(_responseKnowledgebaseCategoryCollection.FirstOrDefault()));
		}

		[Test]
		public void CreateKnowledgebaseCategory()
		{
			var knowledgebaseCategoryRequest = new KnowledgebaseCategoryRequest
				{
					Title = "Title",
					CategoryType = KnowledgebaseCategoryType.Inherit,
					ParentCategoryId = 3,
					DisplayOrder = 3,
					ArticleSortOrder = KnowledgebaseCategoryArticleSortOrder.SortCreationDate,
					AllowComments = true,
					AllowRating = false,
					IsPublished = true,
					UserVisibilityCustom = true,
					UserGroupIdList = new[] {1, 2, 3},
					StaffVisibilityCustom = false,
					StaffGroupIdList = new[] {1, 2, 3},
					StaffId = 3
				};

			const string apiMethod = "/Knowledgebase/Category";
			const string parameters = "title=Title&categorytype=4&parentcategoryid=3&displayorder=3&articlesortorder=4&allowcomments=1&allowrating=0&ispublished=1&uservisibilitycustom=1&usergroupidlist=1,2,3&staffvisibilitycustom=0&staffgroupidlist=1,2,3&staffid=3";

			_kayakoApiRequest.Setup(x => x.ExecutePost<KnowledgebaseCategoryCollection>(apiMethod, parameters)).Returns(_responseKnowledgebaseCategoryCollection);

			var knowledgebaseCategory = _knowledgebaseController.CreateKnowledgebaseCategory(knowledgebaseCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<KnowledgebaseCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(knowledgebaseCategory, Is.EqualTo(_responseKnowledgebaseCategoryCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateKnowledgebaseCategory()
		{
			var knowledgebaseCategoryRequest = new KnowledgebaseCategoryRequest
			{
				Id = 3,
				Title = "Title",
				CategoryType = KnowledgebaseCategoryType.Inherit,
				ParentCategoryId = 3,
				DisplayOrder = 3,
				ArticleSortOrder = KnowledgebaseCategoryArticleSortOrder.SortCreationDate,
				AllowComments = true,
				AllowRating = false,
				IsPublished = true,
				UserVisibilityCustom = true,
				UserGroupIdList = new[] { 1, 2, 3 },
				StaffVisibilityCustom = false,
				StaffGroupIdList = new[] { 1, 2, 3 },
			};

			string apiMethod = string.Format("/Knowledgebase/Category/{0}", knowledgebaseCategoryRequest.Id);
			const string parameters = "title=Title&categorytype=4&parentcategoryid=3&displayorder=3&articlesortorder=4&allowcomments=1&allowrating=0&ispublished=1&uservisibilitycustom=1&usergroupidlist=1,2,3&staffvisibilitycustom=0&staffgroupidlist=1,2,3";

			_kayakoApiRequest.Setup(x => x.ExecutePut<KnowledgebaseCategoryCollection>(apiMethod, parameters)).Returns(_responseKnowledgebaseCategoryCollection);

			var knowledgebaseCategory = _knowledgebaseController.UpdateKnowledgebaseCategory(knowledgebaseCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<KnowledgebaseCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(knowledgebaseCategory, Is.EqualTo(_responseKnowledgebaseCategoryCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteKnowledgebaseCategory(int knowledgebaseCategoryId)
		{
			string apiMethod = string.Format("/Knowledgebase/Category/{0}", knowledgebaseCategoryId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _knowledgebaseController.DeleteKnowledgebaseCategory(knowledgebaseCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());

			Assert.IsTrue(deleteSuccess);
		}

		#endregion
	}
}
