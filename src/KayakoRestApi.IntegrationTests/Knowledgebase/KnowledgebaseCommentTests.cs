using System;
using System.Linq;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseCommentTests : UnitTestBase
	{
		[Test]
		public void GetKnowledgebaseComments()
		{
			var knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles);
			Assert.IsNotEmpty(knowledgebaseArticles);

			var knowledgebaseArticle = knowledgebaseArticles.FirstOrDefault(article => article.TotalComments > 0);

			Assert.IsNotNull(knowledgebaseArticle);

			var knowledgebaseComments = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseComments(knowledgebaseArticle.Id);

			Assert.IsNotNull(knowledgebaseComments);
			Assert.IsNotEmpty(knowledgebaseComments);
		}

		[Test]
		public void GetKnowledgebaseComment()
		{
			var knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles);
			Assert.IsNotEmpty(knowledgebaseArticles);

			var knowledgebaseArticle = knowledgebaseArticles.FirstOrDefault(article => article.TotalComments > 0);

			Assert.IsNotNull(knowledgebaseArticle);

			var knowledgebaseComments = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseComments(knowledgebaseArticle.Id);

			Assert.IsNotNull(knowledgebaseComments);
			Assert.IsNotEmpty(knowledgebaseComments);

			var knowlegebaseComment = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseComment(knowledgebaseComments.First().Id);

			Assert.IsNotNull(knowlegebaseComment);
		}

		[Test]
		public void CreateDeleteKnowledgebaseComment()
		{
			var knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles);
			Assert.IsNotEmpty(knowledgebaseArticles);

			var knowledgebaseCommentRequest = new KnowledgebaseCommentRequest
				{
					KnowledgebaseArticleId = knowledgebaseArticles.FirstOrDefault().Id,
					Contents = "contents",
					Email = "email@domain.com",
					CreatorType = KnowledgebaseCommentCreatorType.User,
					FullName = "Fullname"
				};

			var knowledgebaseComment = TestSetup.KayakoApiService.Knowledgebase.CreateKnowledgebaseComment(knowledgebaseCommentRequest);

			Assert.IsNotNull(knowledgebaseComment);
			Assert.That(knowledgebaseComment.KnowledgebaseArticleId, Is.EqualTo(knowledgebaseCommentRequest.KnowledgebaseArticleId));
			Assert.That(knowledgebaseComment.Contents, Is.EqualTo(knowledgebaseCommentRequest.Contents));
			Assert.That(knowledgebaseComment.Email, Is.EqualTo(knowledgebaseCommentRequest.Email));
			Assert.That(knowledgebaseComment.CreatorType, Is.EqualTo(knowledgebaseCommentRequest.CreatorType));
			Assert.That(knowledgebaseComment.FullName, Is.EqualTo(knowledgebaseCommentRequest.FullName));

			var deleteSuccess = TestSetup.KayakoApiService.Knowledgebase.DeleteKnowledgebaseComment(knowledgebaseComment.Id);

			Assert.IsTrue(deleteSuccess);
		}
	}
}
