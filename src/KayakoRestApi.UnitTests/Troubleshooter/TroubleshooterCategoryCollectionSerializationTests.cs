using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterCategoryCollectionSerializationTests
	{
		[Test]
		public void TroubleshooterCategoryCollectionDeserialization()
		{
			var troubleshooterCategoryCollection = new TroubleshooterCategoryCollection
				{
					new TroubleshooterCategory
						{
							Id = 1,
							StaffId = 0,
							StaffName = "",
							Title = "General",
							Description = "",
							CategoryType = TroubleshooterCategoryType.Global,
							DisplayOrder = 1,
							Views = 22,
							UserVisibilityCustom = false,
							UserGroupIdList = new int[0],
							StaffVisibilityCustom = false,
							StaffGroupIdList = new int[0]
						},
					new TroubleshooterCategory
						{
							Id = 2,
							StaffId = 1,
							StaffName = "",
							Title = "New",
							Description = "",
							CategoryType = TroubleshooterCategoryType.Public,
							DisplayOrder = 1,
							Views = 22,
							UserVisibilityCustom = true,
							UserGroupIdList = new [] { 1, 2 },
							StaffVisibilityCustom = true,
							StaffGroupIdList = new [] { 1, 3}
						}
				};

			var expectedTroubleshooterCategoryCollection = XmlDataUtility.ReadFromFile<TroubleshooterCategoryCollection>("TestData/TroubleshooterCategoryCollection.xml");

			AssertUtility.ObjectsEqual(expectedTroubleshooterCategoryCollection, troubleshooterCategoryCollection);
		}
	}
}
