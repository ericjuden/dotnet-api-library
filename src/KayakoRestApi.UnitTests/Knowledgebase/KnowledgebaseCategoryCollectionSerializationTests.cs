using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseCategoryCollectionSerializationTests
	{
		[Test]
		public void KnowledgebaseCategoryCollectionDeserialization()
		{
			var knowledgebaseCategoryCollection = new KnowledgebaseCategoryCollection
				{
					new KnowledgebaseCategory
						{
							Id = 70,
							ParentKnowledgebaseCategoryId = 0,
							StaffId = 1,
							Title = "category title",
							TotalArticles = 1,
							CategoryType = KnowledgebaseCategoryType.Private,
							DisplayOrder = 6,
							AllowComments = true,
							UserVisibilityCustom = false,
							UserGroupIdList = new [] { 1 },
							StaffVisibilityCustom = false,
							StaffGroupIdList = new [] { 1 },
							AllowRating = true,
							IsPublished = true
						},
					new KnowledgebaseCategory
						{
							Id = 79,
							ParentKnowledgebaseCategoryId = 0,
							StaffId = 1,
							Title = "The next one",
							TotalArticles = 6,
							CategoryType = KnowledgebaseCategoryType.Private,
							DisplayOrder = 7,
							AllowComments = true,
							UserVisibilityCustom = false,
							UserGroupIdList = new [] { 1 },
							StaffVisibilityCustom = false,
							StaffGroupIdList = new [] { 1 },
							AllowRating = true,
							IsPublished = true
						}
				};

			var expectedKnowledgebaseCategoryCollection = XmlDataUtility.ReadFromFile<KnowledgebaseCategoryCollection>("TestData/KnowledgebaseCategoryCollection.xml");

			AssertUtility.ObjectsEqual(expectedKnowledgebaseCategoryCollection, knowledgebaseCategoryCollection);
		}
	}
}
