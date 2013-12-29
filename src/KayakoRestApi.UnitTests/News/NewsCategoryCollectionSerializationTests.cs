using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsCategoryCollectionSerializationTests
	{
		[Test]
		public void NewsCategoryCollectionDeserialization()
		{
			var newsCategoryCollection = new NewsCategoryCollection
				{
					new NewsCategory
						{
							Id = 1,
							Title = "First",
							NewsItemCount = 14,
							VisibilityType = NewsCategoryVisibilityType.Public
						},
					new NewsCategory
						{
							Id = 2,
							Title = "Second",
							NewsItemCount = 14,
							VisibilityType = NewsCategoryVisibilityType.Private
						}
				};

			var expectedNewsCategoryCollection = XmlDataUtility.ReadFromFile<NewsCategoryCollection>("TestData/NewsCategoryCollection.xml");

			AssertUtility.ObjectsEqual(expectedNewsCategoryCollection, newsCategoryCollection);
		}
	}
}
