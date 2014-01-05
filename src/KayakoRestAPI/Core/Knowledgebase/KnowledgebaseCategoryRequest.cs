using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Knowledgebase
{
	public class KnowledgebaseCategoryRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField]
		[ResponseProperty("Title")]
		public string Title { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("CategoryType")]
		public KnowledgebaseCategoryType? CategoryType { get; set; }

		[OptionalField]
		[ResponseProperty("ParentKnowledgebaseCategoryId")]
		public int? ParentCategoryId { get; set; }

		[OptionalField]
		[ResponseProperty("DisplayOrder")]
		public int? DisplayOrder { get; set; }

		[OptionalField]
		public KnowledgebaseCategoryArticleSortOrder? ArticleSortOrder { get; set; }

		[OptionalField]
		[ResponseProperty("AllowComments")]
		public bool? AllowComments { get; set; }

		[OptionalField]
		[ResponseProperty("AllowRating")]
		public bool? AllowRating { get; set; }

		[OptionalField]
		[ResponseProperty("IsPublished")]
		public bool? IsPublished { get; set; }

		[OptionalField]
		[ResponseProperty("UserVisibilityCustom")]
		public bool? UserVisibilityCustom { get; set; }

		[OptionalField]
		[ResponseProperty("UserGroupIdList")]
		public int[] UserGroupIdList { get; set; }

		[OptionalField]
		[ResponseProperty("StaffVisibilityCustom")]
		public bool? StaffVisibilityCustom { get; set; }

		[OptionalField]
		[ResponseProperty("StaffGroupIdList")]
		public int[] StaffGroupIdList { get; set; }

		[OptionalField]
		[ResponseProperty("StaffId")]
		public int? StaffId { get; set; }

		public static KnowledgebaseCategoryRequest FromResponseData(KnowledgebaseCategory responseData)
		{
			return FromResponseType<KnowledgebaseCategory, KnowledgebaseCategoryRequest>(responseData);
		}

		public static KnowledgebaseCategory ToResponseData(KnowledgebaseCategoryRequest requestData)
		{
			return ToResponseType<KnowledgebaseCategoryRequest, KnowledgebaseCategory>(requestData);
		}
	}
}
