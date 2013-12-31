using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.News
{
	public class NewsSubscriberRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField]
		[ResponseProperty("Email")]
		public string Email { get; set; }

		[OptionalField]
		[ResponseProperty("IsValidated")]
		public bool? IsValidated { get; set; }

		public static NewsSubscriberRequest FromResponseData(NewsSubscriber responseData)
		{
			return FromResponseType<NewsSubscriber, NewsSubscriberRequest>(responseData);
		}

		public static NewsSubscriber ToResponseData(NewsSubscriberRequest requestData)
		{
			return ToResponseType<NewsSubscriberRequest, NewsSubscriber>(requestData);
		}
	}
}
