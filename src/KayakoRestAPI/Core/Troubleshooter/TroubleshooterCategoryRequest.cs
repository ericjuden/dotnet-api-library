using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Troubleshooter
{
	public class TroubleshooterCategoryRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Title")]
		public string Title { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("CategoryType")]
		public TroubleshooterCategoryType CategoryType { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("StaffId")]
		public int StaffId { get; set; }

		[OptionalField]
		[ResponseProperty("DisplayOrder")]
		public int? DisplayOrder { get; set; }

		[OptionalField]
		[ResponseProperty("Description")]
		public string Description { get; set; }

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

		public static TroubleshooterCategoryRequest FromResponseData(TroubleshooterCategory responseData)
		{
			return FromResponseType<TroubleshooterCategory, TroubleshooterCategoryRequest>(responseData);
		}

		public static TroubleshooterCategory ToResponseData(TroubleshooterCategoryRequest requestData)
		{
			return ToResponseType<TroubleshooterCategoryRequest, TroubleshooterCategory>(requestData);
		}
	}
}
