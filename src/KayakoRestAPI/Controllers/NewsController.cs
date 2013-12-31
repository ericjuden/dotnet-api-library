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

		NewsItemCollection GetNewsItems(int newsItemId);

		NewsItemCollection GetNewsItems();

		NewsItem GetNewsItem(int newsItemId);

		NewsItem CreateNewsItem(NewsItemRequest newsItemRequest);

		NewsItem UpdateNewsItem(NewsItemRequest newsItemRequest);

		bool DeleteNewsItem(int newsItemId);
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
		private const string NewsItemBaseUrl = "/News/NewsItem";

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

		#region News Item Methods

		public NewsItemCollection GetNewsItems(int newsItemId)
		{
			string apiMethod = String.Format("{0}/ListAll/{1}", NewsItemBaseUrl, newsItemId);

			return Connector.ExecuteGet<NewsItemCollection>(apiMethod);
		}

		public NewsItemCollection GetNewsItems()
		{
			return Connector.ExecuteGet<NewsItemCollection>(NewsItemBaseUrl);
		}

		public NewsItem GetNewsItem(int newsItemId)
		{
			string apiMethod = String.Format("{0}/{1}", NewsItemBaseUrl, newsItemId);

			var newsItems = Connector.ExecuteGet<NewsItemCollection>(apiMethod);

			if (newsItems != null && newsItems.Count > 0)
			{
				return newsItems[0];
			}

			return null;
		}

		public NewsItem CreateNewsItem(NewsItemRequest newsItemRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(newsItemRequest, RequestTypes.Create);

			NewsItemCollection newsItems = Connector.ExecutePost<NewsItemCollection>(NewsItemBaseUrl, parameters.ToString());

			if (newsItems != null && newsItems.Count > 0)
			{
				return newsItems[0];
			}

			return null;
		}

		public NewsItem UpdateNewsItem(NewsItemRequest newsItemRequest)
		{
			string apiMethod = string.Format("/News/NewsItem/{0}", newsItemRequest.Id);

			RequestBodyBuilder parameters = PopulateRequestParameters(newsItemRequest, RequestTypes.Update);

			NewsItemCollection newsItems = Connector.ExecutePut<NewsItemCollection>(apiMethod, parameters.ToString());

			if (newsItems != null && newsItems.Count > 0)
			{
				return newsItems[0];
			}

			return null;
		}

		public bool DeleteNewsItem(int newsItemId)
		{
			string apiMethod = string.Format("/News/NewsItem/{0}", newsItemId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private static RequestBodyBuilder PopulateRequestParameters(NewsItemRequest newsItem, RequestTypes requestType)
		{
			newsItem.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonEmptyString("subject", newsItem.Subject);
			parameters.AppendRequestDataNonEmptyString("contents", newsItem.Contents);

			if (requestType == RequestTypes.Create)
			{
				parameters.AppendRequestDataNonNegativeInt("staffid", newsItem.StaffId);
			}
			else
			{
				parameters.AppendRequestDataNonNegativeInt("editedstaffid", newsItem.StaffId);
			}

			if (requestType == RequestTypes.Create)
			{
				parameters.AppendRequestData("newstype", EnumUtility.ToApiString(newsItem.NewsItemType));
			}

			parameters.AppendRequestData("newsstatus", EnumUtility.ToApiString(newsItem.NewsItemStatus));
			parameters.AppendRequestDataNonEmptyString("fromname", newsItem.FromName);
			parameters.AppendRequestDataNonEmptyString("email", newsItem.Email);
			parameters.AppendRequestDataNonEmptyString("customemailsubject", newsItem.CustomEmailSubject);
			parameters.AppendRequestDataBool("sendemail", newsItem.SendEmail);
			parameters.AppendRequestDataBool("allowcomments", newsItem.AllowComments);
			parameters.AppendRequestDataBool("uservisibilitycustom", newsItem.UserVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("usergroupidlist", newsItem.UserGroupIdList);
			parameters.AppendRequestDataBool("staffvisibilitycustom", newsItem.StaffVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("staffgroupidlist", newsItem.StaffGroupIdList);
			parameters.AppendRequestData("expiry", newsItem.Expiry.DateTime.ToString("M/d/yyyy"));
			parameters.AppendRequestDataArrayCommaSeparated("newscategoryidlist", newsItem.Categories);
			
			return parameters;
		}

		#endregion
	}
}
