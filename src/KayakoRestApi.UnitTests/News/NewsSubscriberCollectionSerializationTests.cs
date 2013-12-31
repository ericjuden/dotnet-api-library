using KayakoRestApi.Core.News;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsSubscriberCollectionSerializationTests
	{
		[Test]
		public void NewsSubscirberCollectionDeserialization()
		{
			var newsSubscriberCollection = new NewsSubscriberCollection
				{
					new NewsSubscriber
						{
							Id = 1,
							TGroupId = 1,
							UserId = 0,
							Email = "john.doe@kayako.com",
							IsValidated = false,
							UserGroupId = 1
						},
					new NewsSubscriber
						{
							Id = 2,
							TGroupId = 1,
							UserId = 0,
							Email = "rohan.sharma@kayako.com",
							IsValidated = true,
							UserGroupId = 1
						},
					new NewsSubscriber
						{
							Id = 3,
							TGroupId = 1,
							UserId = 0,
							Email = "email@domain.com",
							IsValidated = false,
							UserGroupId = 1
						}
				};

			var expectedNewsSubscriberCollection = XmlDataUtility.ReadFromFile<NewsSubscriberCollection>("TestData/NewsSubscriberCollection.xml");

			AssertUtility.ObjectsEqual(expectedNewsSubscriberCollection, newsSubscriberCollection);
		}
	}
}
