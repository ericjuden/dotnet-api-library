using System;
using System.Globalization;
using System.Linq;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsControllerTests
	{
		private INewsController _newsController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;
		private NewsCategoryCollection _responseNewsCategoryCollection;
		private NewsItemCollection _responseNewsItemCollection;
		private NewsSubscriberCollection _responseNewsSubscriberCollection;

		[SetUp]
		public void Setup()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();
			_newsController = new NewsController(_kayakoApiRequest.Object);

			_responseNewsCategoryCollection = new NewsCategoryCollection
				{
					new NewsCategory(),
					new NewsCategory()
				};

			_responseNewsItemCollection = new NewsItemCollection
				{
					new NewsItem(),
					new NewsItem()
				};

			_responseNewsSubscriberCollection = new NewsSubscriberCollection
				{
					new NewsSubscriber(),
					new NewsSubscriber(),
					new NewsSubscriber()
				};
		}

		#region News Category Tests

		[Test]
		public void GetNewsCategories()
		{
			string apiMethod = "/News/Category";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsCategoryCollection>(apiMethod)).Returns(_responseNewsCategoryCollection);

			var newsCategories = _newsController.GetNewsCategories();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsCategoryCollection>(apiMethod), Times.Once());

			Assert.That(newsCategories, Is.EqualTo(_responseNewsCategoryCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetNewsCategory(int newsCategoryId)
		{
			string apiMethod = string.Format("/News/Category/{0}", newsCategoryId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsCategoryCollection>(apiMethod)).Returns(_responseNewsCategoryCollection);

			var newsCategory = _newsController.GetNewsCategory(newsCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsCategoryCollection>(apiMethod), Times.Once());

			Assert.That(newsCategory, Is.EqualTo(_responseNewsCategoryCollection.First()));
		}

		[Test]
		public void CreateNewsCategory()
		{
			var newsCategoryRequest = new NewsCategoryRequest
				{
					Title = "TitleCategory",
					VisibilityType = NewsCategoryVisibilityType.Private
				};

			string apiMethod = "/News/Category";
			string parameters = "title=TitleCategory&visibilitytype=private";

			_kayakoApiRequest.Setup(x => x.ExecutePost<NewsCategoryCollection>(apiMethod, parameters)).Returns(_responseNewsCategoryCollection);

			var newsCategory = _newsController.CreateNewsCategory(newsCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<NewsCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsCategory, Is.EqualTo(_responseNewsCategoryCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateNewsCategory()
		{
			var newsCategoryRequest = new NewsCategoryRequest
			{
				Id = 1,
				Title = "TitleCategory",
				VisibilityType = NewsCategoryVisibilityType.Private
			};

			string apiMethod = string.Format("/News/Category/{0}", newsCategoryRequest.Id);
			string parameters = "title=TitleCategory&visibilitytype=private";

			_kayakoApiRequest.Setup(x => x.ExecutePut<NewsCategoryCollection>(apiMethod, parameters)).Returns(_responseNewsCategoryCollection);

			var newsCategory = _newsController.UpdateNewsCategory(newsCategoryRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<NewsCategoryCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsCategory, Is.EqualTo(_responseNewsCategoryCollection.FirstOrDefault()));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteNewsCategory(int newsCategoryId)
		{
			string apiMethod = string.Format("/News/Category/{0}", newsCategoryId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteSuccess = _newsController.DeleteNewsCategory(newsCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.IsTrue(deleteSuccess);
		}

		#endregion

		#region News Item Tests

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetNewsItemsByCategoryId(int newsCategoryId)
		{
			string apiMethod = string.Format("/News/NewsItem/ListAll/{0}", newsCategoryId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsItemCollection>(apiMethod)).Returns(_responseNewsItemCollection);

			var newsItems = _newsController.GetNewsItems(newsCategoryId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsItemCollection>(apiMethod), Times.Once());

			Assert.That(newsItems, Is.EqualTo(_responseNewsItemCollection));
		}

		[Test]
		public void GetNewsItems()
		{
			string apiMethod = "/News/NewsItem";
			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsItemCollection>(apiMethod)).Returns(_responseNewsItemCollection);

			var newsItems = _newsController.GetNewsItems();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsItemCollection>(apiMethod), Times.Once());

			Assert.That(newsItems, Is.EqualTo(_responseNewsItemCollection));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetNewsItem(int newsItemId)
		{
			string apiMethod = string.Format("/News/NewsItem/{0}", newsItemId);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsItemCollection>(apiMethod)).Returns(_responseNewsItemCollection);

			var newsItem = _newsController.GetNewsItem(newsItemId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsItemCollection>(apiMethod), Times.Once());

			Assert.That(newsItem, Is.EqualTo(_responseNewsItemCollection.FirstOrDefault()));
		}

		[Test]
		public void CreateNewsItem()
		{
			string apiMethod = "/News/NewsItem";
			string parameters = @"subject=Subject&contents=Contents&staffid=1&newstype=3&newsstatus=1&fromname=FromName&email=email@domain.com&customemailsubject=CustomEmailSubject&sendemail=0&allowcomments=1&uservisibilitycustom=1&usergroupidlist=1,2&staffvisibilitycustom=1&staffgroupidlist=1,2&expiry=12/31/2015&newscategoryidlist=1";

			var newsItemRequest = new NewsItemRequest
				{
					Subject = "Subject",
					Contents = "Contents",
					StaffId = 1,
					NewsItemType = NewsItemType.Private,
					NewsItemStatus = NewsItemStatus.Draft,
					FromName = "FromName",
					Email = "email@domain.com",
					CustomEmailSubject = "CustomEmailSubject",
					SendEmail = false,
					AllowComments = true,
					UserVisibilityCustom = true,
					UserGroupIdList = new[] {1, 2},
					StaffVisibilityCustom = true,
					StaffGroupIdList = new[] {1, 2},
					Expiry = new UnixDateTime(DateTime.Parse("31/12/2015 15:30:00", CultureInfo.CreateSpecificCulture("en-GB"))),
					Categories = new[] {1}
				};

			_kayakoApiRequest.Setup(x => x.ExecutePost<NewsItemCollection>(apiMethod, parameters)).Returns(_responseNewsItemCollection);

			var newsItem = _newsController.CreateNewsItem(newsItemRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<NewsItemCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsItem, Is.EqualTo(_responseNewsItemCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateNewsItem()
		{
			var newsItemRequest = new NewsItemRequest
			{
				Id = 1,
				Subject = "Subject",
				Contents = "Contents",
				StaffId = 1,
				NewsItemType = NewsItemType.Private,
				NewsItemStatus = NewsItemStatus.Draft,
				FromName = "FromName",
				Email = "email@domain.com",
				CustomEmailSubject = "CustomEmailSubject",
				SendEmail = false,
				AllowComments = true,
				UserVisibilityCustom = true,
				UserGroupIdList = new[] { 1, 2 },
				StaffVisibilityCustom = true,
				StaffGroupIdList = new[] { 1, 2 },
				Expiry = new UnixDateTime(DateTime.Parse("31/12/2015 15:30:00", CultureInfo.CreateSpecificCulture("en-GB"))),
				Categories = new[] { 1 }
			};

			string apiMethod = string.Format("/News/NewsItem/{0}", newsItemRequest.Id);
			string parameters = @"subject=Subject&contents=Contents&editedstaffid=1&newsstatus=1&fromname=FromName&email=email@domain.com&customemailsubject=CustomEmailSubject&sendemail=0&allowcomments=1&uservisibilitycustom=1&usergroupidlist=1,2&staffvisibilitycustom=1&staffgroupidlist=1,2&expiry=12/31/2015&newscategoryidlist=1";

			_kayakoApiRequest.Setup(x => x.ExecutePut<NewsItemCollection>(apiMethod, parameters)).Returns(_responseNewsItemCollection);

			var newsItem = _newsController.UpdateNewsItem(newsItemRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<NewsItemCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsItem, Is.EqualTo(_responseNewsItemCollection.FirstOrDefault()));
		}

		[TestCase(1, true)]
		[TestCase(2, false)]
		[TestCase(3, true)]
		public void DeleteNewsItem(int newsItemId, bool success)
		{
			string apiMethod = string.Format("/News/NewsItem/{0}", newsItemId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(success);

			var deleteSuccess = _newsController.DeleteNewsItem(newsItemId);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.That(deleteSuccess, Is.EqualTo(success));
		}

		#endregion

		#region News Subscriber Tests

		[Test]
		public void GetNewsSubscribers()
		{
			string apiMethod = "/News/Subscriber";

			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsSubscriberCollection>(apiMethod)).Returns(_responseNewsSubscriberCollection);

			var newsSubscribers = _newsController.GetNewsSubscribers();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsSubscriberCollection>(apiMethod), Times.Once());
			Assert.That(newsSubscribers, Is.EqualTo(_responseNewsSubscriberCollection));
		}

		[TestCase(1)]
		public void GetNewsSubscriber(int newsSubscriberId)
		{
			string apiMethod = string.Format("/News/Subscriber/{0}", newsSubscriberId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<NewsSubscriberCollection>(apiMethod)).Returns(_responseNewsSubscriberCollection);

			var newsSubscriber = _newsController.GetNewsSubscriber(newsSubscriberId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<NewsSubscriberCollection>(apiMethod), Times.Once());
			Assert.That(newsSubscriber, Is.EqualTo(_responseNewsSubscriberCollection.FirstOrDefault()));
		}

		[Test]
		public void CreateNewsSubscriber()
		{
			var apiMethod = "/News/Subscriber";
			var parameters = "email=email@domain.com&isvalidated=1";

			var newsSubscriberRequest = new NewsSubscriberRequest
				{
					Email = "email@domain.com",
					IsValidated = true
				};

			_kayakoApiRequest.Setup(x => x.ExecutePost<NewsSubscriberCollection>(apiMethod, parameters)).Returns(_responseNewsSubscriberCollection);

			var newsSubscriber = _newsController.CreateNewsSubscriber(newsSubscriberRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePost<NewsSubscriberCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsSubscriber, Is.EqualTo(_responseNewsSubscriberCollection.FirstOrDefault()));
		}

		[Test]
		public void UpdateNewsSubscriber()
		{
			var newsSubscriberRequest = new NewsSubscriberRequest
			{
				Id = 1,
				Email = "email@domain.com",
			};

			const string apiMethod = "/News/Subscriber/1";
			const string parameters = "email=email@domain.com";

			_kayakoApiRequest.Setup(x => x.ExecutePut<NewsSubscriberCollection>(apiMethod, parameters)).Returns(_responseNewsSubscriberCollection);

			var newsSubscriber = _newsController.UpdateNewsSubscriber(newsSubscriberRequest);

			_kayakoApiRequest.Verify(x => x.ExecutePut<NewsSubscriberCollection>(apiMethod, parameters), Times.Once());
			Assert.That(newsSubscriber, Is.EqualTo(_responseNewsSubscriberCollection.FirstOrDefault()));
		}

		[TestCase(1, true)]
		[TestCase(2, false)]
		[TestCase(3, true)]
		public void DeleteNewsSubscriber(int newsSubscriberId, bool success)
		{
			var apiMethod = string.Format("/News/Subscriber/{0}", newsSubscriberId);

			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(success);

			var deleteResult = _newsController.DeleteNewsSubscriber(newsSubscriberId);

			Assert.That(deleteResult, Is.EqualTo(success));
		}

		#endregion
	}
}
