using System;
using System.Diagnostics;
using System.Linq;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.News
{
	[TestFixture]
	public class NewsItemCommentTests : UnitTestBase
	{
		[Test]
		public void GetNewsItemComments()
		{
			var newsItemComments = TestSetup.KayakoApiService.News.GetNewsItemComments(1);

			Assert.IsNotNull(newsItemComments);
			Assert.IsNotEmpty(newsItemComments);
		}

		[Test]
		public void GetNewsItemComment()
		{
			var newsItemComments = TestSetup.KayakoApiService.News.GetNewsItemComments(1);

			Assert.IsNotNull(newsItemComments);
			Assert.IsNotEmpty(newsItemComments);

			NewsItemComment newsItemCommentToGet = newsItemComments[new Random().Next(newsItemComments.Count)];
			Trace.WriteLine("GetNewsItemComment using news item comment id: " + newsItemCommentToGet.Id);

			NewsItemComment newsItemComment = TestSetup.KayakoApiService.News.GetNewsItemComment(newsItemCommentToGet.Id);

			AssertObjectXmlEqual(newsItemComment, newsItemCommentToGet);
		}

		[Test]
		public void CreateUpdateDeleteNewsSubscriber()
		{
			var users = TestSetup.KayakoApiService.Users.GetUsers();

			Assert.IsNotNull(users);
			Assert.IsNotEmpty(users);

			var newsItemCommentRequest = new NewsItemCommentRequest
			{
				NewsItemId = 1,
				Contents = "Contents of a comment",
				CreatorType = NewsItemCommentCreatorType.User,
				CreatorId = users.FirstOrDefault().Id
			};

			var newsItemComment = TestSetup.KayakoApiService.News.CreateNewsItemComment(newsItemCommentRequest);

			Assert.IsNotNull(newsItemComment);
			Assert.That(newsItemComment.NewsItemId, Is.EqualTo(newsItemCommentRequest.NewsItemId));
			Assert.That(newsItemComment.Contents, Is.EqualTo(newsItemCommentRequest.Contents));
			Assert.That(newsItemComment.CreatorType, Is.EqualTo(newsItemCommentRequest.CreatorType));
			Assert.That(newsItemComment.CreatorId, Is.EqualTo(newsItemCommentRequest.CreatorId));
			
			var deleteSuccess = TestSetup.KayakoApiService.News.DeleteNewsItemComment(newsItemComment.Id);

			Assert.IsTrue(deleteSuccess);
		}
	}
}
