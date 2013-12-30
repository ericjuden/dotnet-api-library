using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsItemCollectionSerializationTests
	{
		[Test]
		public void NewsItemCollectionDeserialization()
		{
			var newsItemCollection = new NewsItemCollection
				{
					new NewsItem
						{
							Id = 41,
							StaffId = 1,
							NewsItemType = NewsItemType.Global,
							NewsItemStatus = NewsItemStatus.Published,
							Author = "Author full name",
							Email = "author@domain.com",
							Subject = "News subject",
							EmailSubject = "",
							DateLine = new UnixDateTime(1338237929),
							Expiry = new UnixDateTime(0),
							IsSynced = false,
							TotalComments = 0,
							UserVisibilityCustom = true,
							UserGroupIdList = new[] { 1,2,3},
							StaffVisibilityCustom = true,
							StaffGroupIdList = new[] { 1,2},
							AllowComments = true,
							Contents = "Test",
							Categories = new [] { 1,2}
						}
				};

			var expectedNewsItemCollection = XmlDataUtility.ReadFromFile<NewsItemCollection>("TestData/NewsItemCollection.xml");

			AssertUtility.ObjectsEqual(expectedNewsItemCollection, newsItemCollection);
		}
	}
}
