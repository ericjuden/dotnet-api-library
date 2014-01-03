using System;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterCategoryTests : UnitTestBase
	{
		[Test]
		public void GetAllTroubleshooterCategories()
		{
			TroubleshooterCategoryCollection troubleshooterCategories = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterCategories();

			Assert.IsNotNull(troubleshooterCategories, "No troubleshooter categories were returned");
			Assert.IsNotEmpty(troubleshooterCategories, "No troubleshooter categories were returned");
		}

		[Test]
		public void GetTroubleshooterCategory()
		{
			TroubleshooterCategoryCollection troubleshooterCategories = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterCategories();

			Assert.IsNotNull(troubleshooterCategories, "No troubleshooter categories were returned");
			Assert.IsNotEmpty(troubleshooterCategories, "No troubleshooter categories were returned");

			TroubleshooterCategory troubleshooterCategoryToGet = troubleshooterCategories[new Random().Next(troubleshooterCategories.Count)];

			Trace.WriteLine("GetTroubleshooterCategory using troubleshooter category id: " + troubleshooterCategoryToGet.Id);

			TroubleshooterCategory troubleshooterCategory = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterCategory(troubleshooterCategoryToGet.Id);

			AssertObjectXmlEqual(troubleshooterCategory, troubleshooterCategoryToGet);
		}

		[Test(Description = "Tests creating, updating and deleting troubleshooter categories")]
		public void CreateUpdateDeleteNewsCategory()
		{
			TroubleshooterCategoryRequest troubleshooterCategoryRequest = new TroubleshooterCategoryRequest
				{
					Title = "Troubleshooter Category Request",
					CategoryType = TroubleshooterCategoryType.Public,
					StaffId = 1,
					DisplayOrder = 5,
					Description = "Description of Troubleshooter Category Request",
					UserVisibilityCustom = false,
					StaffVisibilityCustom = false
				};

			var troubleshooterCategory = TestSetup.KayakoApiService.Troubleshooter.CreateTroubleshooterCategory(troubleshooterCategoryRequest);

			Assert.IsNotNull(troubleshooterCategory);
			Assert.That(troubleshooterCategory.Title, Is.EqualTo(troubleshooterCategoryRequest.Title));
			Assert.That(troubleshooterCategory.CategoryType, Is.EqualTo(troubleshooterCategoryRequest.CategoryType));
			Assert.That(troubleshooterCategory.StaffId, Is.EqualTo(troubleshooterCategoryRequest.StaffId));
			Assert.That(troubleshooterCategory.DisplayOrder, Is.EqualTo(troubleshooterCategoryRequest.DisplayOrder));
			Assert.That(troubleshooterCategory.Description, Is.EqualTo(troubleshooterCategoryRequest.Description));
			Assert.That(troubleshooterCategory.UserVisibilityCustom, Is.EqualTo(troubleshooterCategoryRequest.UserVisibilityCustom));
			Assert.That(troubleshooterCategory.StaffVisibilityCustom, Is.EqualTo(troubleshooterCategoryRequest.StaffVisibilityCustom));

			troubleshooterCategoryRequest.Id = troubleshooterCategory.Id;
			troubleshooterCategoryRequest.Title += "_Title";
			troubleshooterCategoryRequest.Description += "_Updated";

			troubleshooterCategory = TestSetup.KayakoApiService.Troubleshooter.UpdateTroubleshooterCategory(troubleshooterCategoryRequest);

			Assert.IsNotNull(troubleshooterCategory);
			Assert.That(troubleshooterCategory.Title, Is.EqualTo(troubleshooterCategoryRequest.Title));
			Assert.That(troubleshooterCategory.Description, Is.EqualTo(troubleshooterCategoryRequest.Description));

			var deleteResult = TestSetup.KayakoApiService.Troubleshooter.DeleteTroubleshooterCategory(troubleshooterCategoryRequest.Id);
			Assert.IsTrue(deleteResult);
		}
	}
}
