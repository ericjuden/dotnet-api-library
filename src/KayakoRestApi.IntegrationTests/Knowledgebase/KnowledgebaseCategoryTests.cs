using System;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseCategoryTests : UnitTestBase
	{
		[Test]
		public void GetAllKnowledgebaseCategories()
		{
			KnowledgebaseCategoryCollection knowledgebaseCategories = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseCategories();

			Assert.IsNotNull(knowledgebaseCategories, "No knowledgebase categories were returned");
			Assert.IsNotEmpty(knowledgebaseCategories, "No knowledgebase categories were returned");
		}

		[Test]
		public void GetKnowledgebaseCategory()
		{
			KnowledgebaseCategoryCollection knowledgebaseCategories = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseCategories();

			Assert.IsNotNull(knowledgebaseCategories, "No knowledgebase categories were returned");
			Assert.IsNotEmpty(knowledgebaseCategories, "No knowledgebase categories were returned");

			KnowledgebaseCategory knowledgebaseCategoryToGet = knowledgebaseCategories[new Random().Next(knowledgebaseCategories.Count)];

			Trace.WriteLine("GetKnowledgebaseCategory using knowledgebase category id: " + knowledgebaseCategoryToGet.Id);

			KnowledgebaseCategory knowledgebaseCategory = TestSetup.KayakoApiService.Knowledgebase.GetKnowledgebaseCategory(knowledgebaseCategoryToGet.Id);

			AssertObjectXmlEqual(knowledgebaseCategory, knowledgebaseCategoryToGet);
		}

		[Test]
		public void CreateUpdateDeleteKnowledgebaseCategory()
		{
			KnowledgebaseCategoryRequest knowledgebaseCategoryRequest = new KnowledgebaseCategoryRequest
			{
				Title = "Title",
				CategoryType = KnowledgebaseCategoryType.Global,
				ParentCategoryId = 1,
				DisplayOrder = 4,
				ArticleSortOrder = KnowledgebaseCategoryArticleSortOrder.SortCreationDate,
				AllowComments = true,
				AllowRating = false,
				IsPublished = true,
				UserVisibilityCustom = false,
				StaffVisibilityCustom = false,
				StaffId = 1
			};

			var knowledgebaseCategory = TestSetup.KayakoApiService.Knowledgebase.CreateKnowledgebaseCategory(knowledgebaseCategoryRequest);

			Assert.IsNotNull(knowledgebaseCategory);
			Assert.That(knowledgebaseCategory.Title, Is.EqualTo(knowledgebaseCategoryRequest.Title));
			Assert.That(knowledgebaseCategory.CategoryType, Is.EqualTo(knowledgebaseCategoryRequest.CategoryType));
			Assert.That(knowledgebaseCategory.ParentKnowledgebaseCategoryId, Is.EqualTo(knowledgebaseCategoryRequest.ParentCategoryId));
			Assert.That(knowledgebaseCategory.DisplayOrder, Is.EqualTo(knowledgebaseCategoryRequest.DisplayOrder));
			Assert.That(knowledgebaseCategory.AllowComments, Is.EqualTo(knowledgebaseCategoryRequest.AllowComments));
			Assert.That(knowledgebaseCategory.AllowRating, Is.EqualTo(knowledgebaseCategoryRequest.AllowRating));
			Assert.That(knowledgebaseCategory.IsPublished, Is.EqualTo(knowledgebaseCategoryRequest.IsPublished));
			Assert.That(knowledgebaseCategory.UserVisibilityCustom, Is.EqualTo(knowledgebaseCategoryRequest.UserVisibilityCustom));
			Assert.That(knowledgebaseCategory.StaffVisibilityCustom, Is.EqualTo(knowledgebaseCategoryRequest.StaffVisibilityCustom));
			Assert.That(knowledgebaseCategory.StaffId, Is.EqualTo(knowledgebaseCategoryRequest.StaffId));

			knowledgebaseCategoryRequest.Id = knowledgebaseCategory.Id;
			knowledgebaseCategoryRequest.Title += "_Title";
			knowledgebaseCategoryRequest.DisplayOrder = 32;

			knowledgebaseCategory = TestSetup.KayakoApiService.Knowledgebase.UpdateKnowledgebaseCategory(knowledgebaseCategoryRequest);

			Assert.IsNotNull(knowledgebaseCategory);
			Assert.That(knowledgebaseCategory.Title, Is.EqualTo(knowledgebaseCategoryRequest.Title));
			Assert.That(knowledgebaseCategory.DisplayOrder, Is.EqualTo(knowledgebaseCategoryRequest.DisplayOrder));

			var deleteResult = TestSetup.KayakoApiService.Knowledgebase.DeleteKnowledgebaseCategory(knowledgebaseCategoryRequest.Id);
			Assert.IsTrue(deleteResult);
		}
	}
}
