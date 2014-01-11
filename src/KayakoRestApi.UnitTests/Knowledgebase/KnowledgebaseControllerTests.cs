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
		private KnowledgebaseArticleCollection _responseKnowledgebaseArticleCollection;
		private KnowledgebaseCommentCollection _responseKnowledgebaseCommentCollection;
		private KnowledgebaseAttachmentCollection _responseKnowledgebaseAttachmentCollection;

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

			_responseKnowledgebaseArticleCollection = new KnowledgebaseArticleCollection
				{
					new KnowledgebaseArticle(),
					new KnowledgebaseArticle()
				};

			_responseKnowledgebaseCommentCollection = new KnowledgebaseCommentCollection
				{
					new KnowledgebaseComment(),
					new KnowledgebaseComment()
				};

			_responseKnowledgebaseAttachmentCollection = new KnowledgebaseAttachmentCollection
				{
					new KnowledgebaseAttachment(),
					new KnowledgebaseAttachment()
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

		#region Knoweldgebase Article Methods

		[TestCase(1,1)]
		[TestCase(1, 3)]
		public void GetKnowledgebaseArticlesPaging(int count, int start)
		{
			string apiMethod = string.Format("/Knowledgebase/Article/ListAll/{0}/{1}", count, start);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod)).Returns(_responseKnowledgebaseArticleCollection);

			var knowledgebaseArticles = _knowledgebaseController.GetKnowledgebaseArticles(count, start);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseArticles, Is.EqualTo(_responseKnowledgebaseArticleCollection));
		}

		[Test]
		public void GetKnowledgebaseArticles()
		{
			const string apiMethod = "/Knowledgebase/Article";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod)).Returns(_responseKnowledgebaseArticleCollection);

			var knowledgebaseArticles = _knowledgebaseController.GetKnowledgebaseArticles();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseArticles, Is.EqualTo(_responseKnowledgebaseArticleCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetKnowledgebaseArticle(int knowledgebaseArticleId)
		{
			string apiMethod = string.Format("/Knowledgebase/Article/{0}", knowledgebaseArticleId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod)).Returns(_responseKnowledgebaseArticleCollection);

			var knowledgebaseArticle = _knowledgebaseController.GetKnowledgebaseArticle(knowledgebaseArticleId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseArticle, Is.EqualTo(_responseKnowledgebaseArticleCollection.FirstOrDefault()));
		}

		[Test]
		public void CreateKnowledgebaseArticle()
		{
			var knowledgebaseArticleRequest = new KnowledgebaseArticleRequest
			{
				CreatorId = 3,
				Subject = "Subject",
				Contents = "Contents",
				ArticleStatus = KnowledgebaseArticleStatus.Published,
				IsFeatured = false,
				AllowComments = true,
				CategoryIds = new [] { 1 }
			};

			const string apiMethod = "/Knowledgebase/Article";
			const string parameters = "subject=Subject&contents=Contents&creatorid=3&articlestatus=1&isfeatured=0&allowcomments=1&categoryid=1";

			_kayakoApiRequest.Setup(x => x.ExecutePost<KnowledgebaseArticleCollection>(apiMethod, parameters)).Returns(_responseKnowledgebaseArticleCollection);

			var knowledgebaseArticle = _knowledgebaseController.CreateKnowledgebaseArticle(knowledgebaseArticleRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<KnowledgebaseArticleCollection>(apiMethod, parameters), Times.Once());
			Assert.That(knowledgebaseArticle, Is.EqualTo(_responseKnowledgebaseArticleCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateKnowledgebaseArticle()
		{
			var knowledgebaseArticleRequest = new KnowledgebaseArticleRequest
			{
				Id = 1,
				EditedStaffId = 3,
				Subject = "Subject",
				Contents = "Contents",
				ArticleStatus = KnowledgebaseArticleStatus.Published,
				IsFeatured = false,
				AllowComments = true,
				CategoryIds = new [] { 1, 2, 3 }
			};

			string apiMethod = string.Format("/Knowledgebase/Article/{0}", knowledgebaseArticleRequest.Id);
			const string parameters = "subject=Subject&contents=Contents&articlestatus=1&isfeatured=0&allowcomments=1&categoryid=1,2,3&editedstaffid=3";

			_kayakoApiRequest.Setup(x => x.ExecutePut<KnowledgebaseArticleCollection>(apiMethod, parameters)).Returns(_responseKnowledgebaseArticleCollection);

			var knowledgebaseArticle = _knowledgebaseController.UpdateKnowledgebaseArticle(knowledgebaseArticleRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<KnowledgebaseArticleCollection>(apiMethod, parameters), Times.Once());
			Assert.That(knowledgebaseArticle, Is.EqualTo(_responseKnowledgebaseArticleCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteKnowledgebaseArticle(int knowledgebaseArticleId)
		{
			string apiMethod = string.Format("/Knowledgebase/Article/{0}", knowledgebaseArticleId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _knowledgebaseController.DeleteKnowledgebaseArticle(knowledgebaseArticleId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());

			Assert.IsTrue(deleteSuccess);
		}

		#endregion

		#region Knowledgebase Comment Methods
		
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetKnowledgebaseCommentsForArticle(int articleId)
		{
			string apiMethod = String.Format("/Knowledgebase/Comment/ListAll/{0}", articleId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseCommentCollection>(apiMethod)).Returns(_responseKnowledgebaseCommentCollection);

			var knowledgebaseComments = _knowledgebaseController.GetKnowledgebaseComments(articleId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseCommentCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseComments, Is.EqualTo(_responseKnowledgebaseCommentCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetKnowledgebaseCommentById(int commentId)
		{
			string apiMethod = String.Format("/Knowledgebase/Comment/{0}", commentId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<KnowledgebaseCommentCollection>(apiMethod)).Returns(_responseKnowledgebaseCommentCollection);

			var knowledgebaseComment = _knowledgebaseController.GetKnowledgebaseComment(commentId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<KnowledgebaseCommentCollection>(apiMethod), Times.Once());

			Assert.That(knowledgebaseComment, Is.EqualTo(_responseKnowledgebaseCommentCollection.First()));
		}

		[Test]
		public void CreateKnowledgebaseComment()
		{
			var knowledgebaseCommentRequest = new KnowledgebaseCommentRequest
				{
					KnowledgebaseArticleId = 1,
					Contents = "Contents",
					CreatorType = KnowledgebaseCommentCreatorType.User,
					CreatorId = 3,
					Email = "email@domain.com",
					ParentCommentId = 1
				};

			const string apiMethod = "/Knowledgebase/Comment";
			const string parameters = "knowledgebasearticleid=1&contents=Contents&creatortype=2&creatorid=3&email=email@domain.com&parentcommentid=1";

			_kayakoApiRequest.Setup(x => x.ExecutePost<KnowledgebaseCommentCollection>(apiMethod, parameters)).Returns(_responseKnowledgebaseCommentCollection);

			var knowledgebaseComment = _knowledgebaseController.CreateKnowledgebaseComment(knowledgebaseCommentRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<KnowledgebaseCommentCollection>(apiMethod, parameters), Times.Once());
			Assert.That(knowledgebaseComment, Is.EqualTo(_responseKnowledgebaseCommentCollection.First()));
		}

		[TestCase(1, true)]
		[TestCase(2, false)]
		[TestCase(3, true)]
		public void DeleteKnowledgebaseComment(int commentId, bool success)
		{
			string apiMethod = string.Format("/Knowledgebase/Comment/{0}", commentId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(success);

			var deleteSuccess = _knowledgebaseController.DeleteKnowledgebaseComment(commentId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod));

			Assert.That(deleteSuccess, Is.EqualTo(success));
		}

		#endregion

		#region Knowledgebase Attachment Methods

		#endregion
	}
}
