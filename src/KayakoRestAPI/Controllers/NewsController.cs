using System;
using System.Net;
using KayakoRestApi.Core.News;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.RequestBase;
using KayakoRestApi.Text;

namespace KayakoRestApi.Controllers
{
	public interface INewsController
	{
		NewsCategoryCollection GetNewsCategories();

		NewsCategory GetNewsCategory(int newsCategoryId);

		NewsCategory CreateNewsCategory(NewsCategoryRequest newsCategoryRequest);

		NewsCategory UpdateNewsCategory(NewsCategoryRequest newsCategoryRequest);

		bool DeleteNewsCategory(int newsCategoryId);
	}

	public sealed class NewsController : BaseController, INewsController
	{
		internal NewsController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
        }

		internal NewsController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
			: base(apiKey, secretKey, apiUrl, proxy, requestType)
		{
		}

		internal NewsController(IKayakoApiRequest kayakoApiRequest) 
			: base(kayakoApiRequest)
		{
		}

		private const string NewsCategoryBaseUrl = "/News/Category";

		#region News Category Methods

		public NewsCategoryCollection GetNewsCategories()
		{
			return Connector.ExecuteGet<NewsCategoryCollection>(NewsCategoryBaseUrl);
		}

		public NewsCategory GetNewsCategory(int newsCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", NewsCategoryBaseUrl, newsCategoryId);

			NewsCategoryCollection newsCategories = Connector.ExecuteGet<NewsCategoryCollection>(apiMethod);

			if (newsCategories != null && newsCategories.Count > 0)
			{
				return newsCategories[0];
			}

			return null;
		}

		public NewsCategory CreateNewsCategory(NewsCategoryRequest newsCategoryRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(newsCategoryRequest, RequestTypes.Create);

			NewsCategoryCollection newsCategories = Connector.ExecutePost<NewsCategoryCollection>(NewsCategoryBaseUrl, parameters.ToString());

			if (newsCategories != null && newsCategories.Count > 0)
			{
				return newsCategories[0];
			}

			return null;
		}

		public NewsCategory UpdateNewsCategory(NewsCategoryRequest newsCategoryRequest)
		{
			string apiMethod = String.Format("{0}/{1}", NewsCategoryBaseUrl, newsCategoryRequest.Id);
			RequestBodyBuilder parameters = PopulateRequestParameters(newsCategoryRequest, RequestTypes.Update);

			NewsCategoryCollection newsCategories = Connector.ExecutePut<NewsCategoryCollection>(apiMethod, parameters.ToString());

			if (newsCategories != null && newsCategories.Count > 0)
			{
				return newsCategories[0];
			}

			return null;
		}

		public bool DeleteNewsCategory(int newsCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", NewsCategoryBaseUrl, newsCategoryId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private static RequestBodyBuilder PopulateRequestParameters(NewsCategoryRequest newsCategory, RequestTypes requestType)
		{
			newsCategory.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

			if (!String.IsNullOrEmpty(newsCategory.Title))
			{
				parameters.AppendRequestData("title", newsCategory.Title);
			}

			parameters.AppendRequestData("visibilitytype", EnumUtility.ToApiString(newsCategory.VisibilityType));

			return parameters;
		}

		#endregion
	}
}
