using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.News
{
	public class NewsCategoryRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField]
		[ResponseProperty("Title")]
		public string Title { get; set; }

		[RequiredField]
		[ResponseProperty("VisibilityType")]
		public NewsCategoryVisibilityType VisibilityType { get; set; }

		public static NewsCategoryRequest FromResponseData(NewsCategory responseData)
		{
			return FromResponseType<NewsCategory, NewsCategoryRequest>(responseData);
		}

		public static NewsCategory ToResponseData(NewsCategoryRequest requestData)
		{
			return ToResponseType<NewsCategoryRequest, NewsCategory>(requestData);
		}
	}
}
