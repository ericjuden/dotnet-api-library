using System;
using System.Diagnostics;
using KayakoRestApi.Core.News;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.News
{
	[TestFixture(Description = "A set of tests testing Api methods around News Categories")]
	public class NewsCategoryTests : UnitTestBase
	{
		[Test]
		public void GetAllNewsCategories()
		{
			NewsCategoryCollection newsCategories = TestSetup.KayakoApiService.News.GetNewsCategories();

			Assert.IsNotNull(newsCategories, "No news categories were returned");
			Assert.IsNotEmpty(newsCategories, "No news categories were returned");
		}

		[Test]
		public void GetNewsCategory()
		{
			NewsCategoryCollection newsCategories = TestSetup.KayakoApiService.News.GetNewsCategories();

			Assert.IsNotNull(newsCategories, "No news categories were returned");
			Assert.IsNotEmpty(newsCategories, "No news categories were returned");

			NewsCategory newsCategoryToGet = newsCategories[new Random().Next(newsCategories.Count)];

			Trace.WriteLine("GetNewsCategory using news category id: " + newsCategoryToGet.Id);

			NewsCategory dept = TestSetup.KayakoApiService.News.GetNewsCategory(newsCategoryToGet.Id);

			AssertObjectXmlEqual(dept, newsCategoryToGet);
		}
	}
}
