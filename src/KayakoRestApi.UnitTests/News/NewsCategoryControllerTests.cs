using System.Linq;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using KayakoRestApi.Net;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsCategoryControllerTests
	{
		private INewsController _newsController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;
		private NewsCategoryCollection _responseNewsCategoryCollection;
		private NewsItemCollection _responseNewsItemCollection;

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

		#endregion
	}
}
