using System.Linq;
using KayakoRestApi.Controllers;
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
		}

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
	}
}
