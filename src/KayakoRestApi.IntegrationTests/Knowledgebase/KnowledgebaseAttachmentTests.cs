using System;
using System.Linq;
using System.Text;
using KayakoRestApi.Core.Knowledgebase;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseAttachmentTests : UnitTestBase
	{
		[Test]
		public void GetKnowledgebaseAttachments()
		{
			var knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles);
			Assert.IsNotEmpty(knowledgebaseArticles);

			var knowledgebaseArticleToGet = knowledgebaseArticles.FirstOrDefault();

			Assert.IsNotNull(knowledgebaseArticleToGet);
			Assert.IsNotNull(knowledgebaseArticleToGet.Attachments);
			Assert.IsNotEmpty(knowledgebaseArticleToGet.Attachments);

			var knowledgebaseAttachments = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseAttachments(knowledgebaseArticleToGet.Id);

			Assert.IsNotNull(knowledgebaseAttachments);
			Assert.IsNotEmpty(knowledgebaseAttachments);
			Assert.That(knowledgebaseAttachments.Count, Is.EqualTo(knowledgebaseArticleToGet.Attachments.Length));
		}

		[Test]
		public void GetKnowledgebaseAttachment()
		{
			var knowledgebaseArticles = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseArticles();

			Assert.IsNotNull(knowledgebaseArticles);
			Assert.IsNotEmpty(knowledgebaseArticles);

			var knowledgebaseStepToGet = knowledgebaseArticles.FirstOrDefault();

			Assert.IsNotNull(knowledgebaseStepToGet);
			Assert.IsNotNull(knowledgebaseStepToGet.Attachments);
			Assert.IsNotEmpty(knowledgebaseStepToGet.Attachments);

			var knowledgebaseAttachment = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseAttachment(knowledgebaseStepToGet.Id, knowledgebaseStepToGet.Attachments.FirstOrDefault().Id);

			Assert.IsNotNull(knowledgebaseAttachment);
		}

		[Test]
		public void CreateDeleteTicketAttachment()
		{
			string contents = Convert.ToBase64String(Encoding.UTF8.GetBytes("This is the contents"));

			var knowledgebaseAttachmentRequest = new KnowledgebaseAttachmentRequest
			{
				KnowledgebaseArticleId = 1,
				FileName = "Test.txt",
				Contents = contents
			};

			var knowledgebaseAttachment = TestSetup.KayakoApiService.Knowledgebase.CreateKnowledgebaseAttachment(knowledgebaseAttachmentRequest);

			Assert.IsNotNull(knowledgebaseAttachment);
			Assert.That(knowledgebaseAttachment.KnowledgebaseArticleId, Is.EqualTo(knowledgebaseAttachment.KnowledgebaseArticleId));
			Assert.That(knowledgebaseAttachment.FileName, Is.EqualTo(knowledgebaseAttachment.FileName));
			Assert.That(knowledgebaseAttachment.Contents, Is.EqualTo(contents));

			var deleteSuccess = TestSetup.KayakoApiService.Knowledgebase.DeleteKnowledgebaseAttachment(knowledgebaseAttachment.KnowledgebaseArticleId, knowledgebaseAttachment.Id);

			Assert.IsTrue(deleteSuccess);
		}
	}
}
