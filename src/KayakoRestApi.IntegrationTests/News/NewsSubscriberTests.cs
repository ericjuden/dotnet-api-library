using System;
using System.Diagnostics;
using KayakoRestApi.Core.News;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.News
{
	[TestFixture]
	public class NewsSubscriberTests : UnitTestBase
	{
		[Test]
		public void GetNewsSubscribers()
		{
			var newsSubscribers = TestSetup.KayakoApiService.News.GetNewsSubscribers();

			Assert.IsNotNull(newsSubscribers);
			Assert.IsNotEmpty(newsSubscribers);
		}

		[Test]
		public void GetNewsSubscriberById()
		{
			var newsSubscribers = TestSetup.KayakoApiService.News.GetNewsSubscribers();

			Assert.IsNotNull(newsSubscribers, "No news subscribers were returned");
			Assert.IsNotEmpty(newsSubscribers, "No news subscribers were returned");

			NewsSubscriber newsSubscriberToGet = newsSubscribers[new Random().Next(newsSubscribers.Count)];
			Trace.WriteLine("GetNewsSubscriber using news subscriber id: " + newsSubscriberToGet.Id);

			NewsSubscriber newsSubscriber = TestSetup.KayakoApiService.News.GetNewsSubscriber(newsSubscriberToGet.Id);

			AssertObjectXmlEqual(newsSubscriber, newsSubscriberToGet);
		}

		[Test]
		public void CreateUpdateDeleteNewsSubscriber()
		{
			var newsSubscriberRequest = new NewsSubscriberRequest
			{
				Email = "integrationtest@dotnetapi.com",
				IsValidated = false
			};

			var newsSubscriber = TestSetup.KayakoApiService.News.CreateNewsSubscriber(newsSubscriberRequest);

			Assert.IsNotNull(newsSubscriber);
			Assert.That(newsSubscriber.Email, Is.EqualTo(newsSubscriberRequest.Email));
			Assert.That(newsSubscriber.IsValidated, Is.EqualTo(newsSubscriberRequest.IsValidated));

			newsSubscriberRequest = NewsSubscriberRequest.FromResponseData(newsSubscriber);
			newsSubscriberRequest.Email = "updated_integrationtest@dotnetapi.com";

			newsSubscriber = TestSetup.KayakoApiService.News.UpdateNewsSubscriber(newsSubscriberRequest);

			Assert.IsNotNull(newsSubscriber);
			Assert.That(newsSubscriber.Email, Is.EqualTo(newsSubscriberRequest.Email));
			Assert.That(newsSubscriber.IsValidated, Is.EqualTo(newsSubscriberRequest.IsValidated));

			var deleteSuccess = TestSetup.KayakoApiService.News.DeleteNewsSubscriber(newsSubscriber.Id);

			Assert.IsTrue(deleteSuccess);
		}
	}
}
