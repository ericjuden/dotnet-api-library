using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.News
{
	public class NewsItemCommentRequest : RequestBaseObject
	{
		[RequiredField]
		[ResponseProperty("NewsItemId")]
		public int NewsItemId { get; set; }

		[RequiredField]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		[RequiredField]
		[ResponseProperty("CreatorType")]
		public NewsItemCommentCreatorType CreatorType { get; set; }

		[OptionalField]
		[ResponseProperty("CreatorId")]
		public int? CreatorId { get; set; }

		[OptionalField]
		[ResponseProperty("FullName")]
		public string FullName { get; set; }

		[OptionalField]
		[ResponseProperty("Email")]
		public string Email { get; set; }

		[OptionalField]
		[ResponseProperty("ParentCommentId")]
		public int? ParentCommentId { get; set; }

		public static NewsItemCommentRequest FromResponseData(NewsItemComment responseData)
		{
			return FromResponseType<NewsItemComment, NewsItemCommentRequest>(responseData);
		}

		public static NewsItemComment ToResponseData(NewsItemCommentRequest requestData)
		{
			return ToResponseType<NewsItemCommentRequest, NewsItemComment>(requestData);
		}
	}
}
