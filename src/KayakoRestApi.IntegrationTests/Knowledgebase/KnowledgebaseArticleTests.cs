using System;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseArticleTests : UnitTestBase
	{
		[Test]
		public void GetAllKnowledgebaseArticles()
		{
			KnowledgebaseArticleCollection knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles, "No knowledgebase articles were returned");
			Assert.IsNotEmpty(knowledgebaseArticles, "No knowledgebase articles were returned");
		}

		[Test]
		public void GetKnowledgebaseArticle()
		{
			KnowledgebaseArticleCollection knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles, "No knowledgebase articles were returned");
			Assert.IsNotEmpty(knowledgebaseArticles, "No knowledgebase articles were returned");

			KnowledgebaseArticle knowledgebaseArticleToGet = knowledgebaseArticles[new Random().Next(knowledgebaseArticles.Count)];

			Trace.WriteLine("GetKnowledgebaseArticle using knowledgebase article id: " + knowledgebaseArticleToGet.Id);

			KnowledgebaseArticle knowledgebaseArticle = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticle(knowledgebaseArticleToGet.Id);

			AssertObjectXmlEqual(knowledgebaseArticle, knowledgebaseArticleToGet);
		}

		[Test]
		public void CreateUpdateDeleteKnowledgebaseArticle()
		{
			KnowledgebaseArticleRequest knowledgebaseArticleRequest = new KnowledgebaseArticleRequest
			{
				Subject = "subject",
				Contents = "Contents",
				CreatorId = 1,
				ArticleStatus = KnowledgebaseArticleStatus.Published,
				IsFeatured = true,
				AllowComments = true,
				CategoryIds = new [] { 1 }
			};

			var knowledgebaseArticle = TestSetup.KayakoApiService.Knowledgebase.CreateKnowledgebaseArticle(knowledgebaseArticleRequest);

			Assert.IsNotNull(knowledgebaseArticle);
			Assert.That(knowledgebaseArticle.Subject, Is.EqualTo(knowledgebaseArticleRequest.Subject));
			Assert.That(knowledgebaseArticle.Contents, Is.EqualTo(knowledgebaseArticleRequest.Contents));
			Assert.That(knowledgebaseArticle.CreatorId, Is.EqualTo(knowledgebaseArticleRequest.CreatorId));
			Assert.That(knowledgebaseArticle.ArticleStatus, Is.EqualTo(knowledgebaseArticleRequest.ArticleStatus));
			Assert.That(knowledgebaseArticle.IsFeatured, Is.EqualTo(knowledgebaseArticleRequest.IsFeatured));
			Assert.That(knowledgebaseArticle.AllowComments, Is.EqualTo(knowledgebaseArticleRequest.AllowComments));
			Assert.That(knowledgebaseArticle.Categories, Is.EqualTo(knowledgebaseArticleRequest.CategoryIds));

			knowledgebaseArticleRequest.Id = knowledgebaseArticle.Id;
			knowledgebaseArticleRequest.EditedStaffId = 1;
			knowledgebaseArticleRequest.Subject += "_Subject";
			knowledgebaseArticleRequest.AllowComments = false;

			knowledgebaseArticle = TestSetup.KayakoApiService.Knowledgebase.UpdateKnowledgebaseArticle(knowledgebaseArticleRequest);

			Assert.IsNotNull(knowledgebaseArticle);
			Assert.That(knowledgebaseArticle.Subject, Is.EqualTo(knowledgebaseArticleRequest.Subject));
			Assert.That(knowledgebaseArticle.AllowComments, Is.EqualTo(knowledgebaseArticleRequest.AllowComments));

			var deleteResult = TestSetup.KayakoApiService.Knowledgebase.DeleteKnowledgebaseArticle(knowledgebaseArticleRequest.Id);
			Assert.IsTrue(deleteResult);
		}
	}
}
