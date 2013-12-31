using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.News
{
	public class NewsItemRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField]
		[ResponseProperty("Subject")]
		public string Subject { get; set; }

		[RequiredField]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		[RequiredField]
		[ResponseProperty("StaffId")]
		public int StaffId { get; set; }

		[OptionalField]
		[ResponseProperty("NewsItemType")]
		public NewsItemType? NewsItemType { get; set; }

		[OptionalField]
		[ResponseProperty("NewsItemStatus")]
		public NewsItemStatus? NewsItemStatus { get; set; }

		[OptionalField]
		public string FromName { get; set; }

		[OptionalField]
		[ResponseProperty("Email")]
		public string Email { get; set; }

		[OptionalField]
		[ResponseProperty("EmailSubject")]
		public string CustomEmailSubject { get; set; }

		[OptionalField]
		public bool? SendEmail { get; set; }
		
		[OptionalField]
		[ResponseProperty("AllowComments")]
		public bool? AllowComments { get; set; }

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
		[ResponseProperty("Expiry")]
		public UnixDateTime Expiry { get; set; }

		[OptionalField]
		[ResponseProperty("Categories")]
		public int[] Categories { get; set; }

		public static NewsItemRequest FromResponseData(NewsItem responseData)
		{
			return FromResponseType<NewsItem, NewsItemRequest>(responseData);
		}

		public static NewsItem ToResponseData(NewsItemRequest requestData)
		{
			return ToResponseType<NewsItemRequest, NewsItem>(requestData);
		}
	}
}
