using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using KayakoRestApi.Core.News;
using KayakoRestApi.Net;

namespace KayakoRestApi.Controllers
{
	public interface INewsController
	{
		NewsCategoryCollection GetNewsCategories();

		NewsCategory GetNewsCategory(int newsCategoryId);
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

		#region News Category Methods

		public NewsCategoryCollection GetNewsCategories()
		{
			return Connector.ExecuteGet<NewsCategoryCollection>("/News/Category");
		}

		public NewsCategory GetNewsCategory(int newsCategoryId)
		{
			string apiMethod = String.Format("/News/Category/{0}", newsCategoryId);

			NewsCategoryCollection newsCategories = Connector.ExecuteGet<NewsCategoryCollection>(apiMethod);

			if (newsCategories != null && newsCategories.Count > 0)
			{
				return newsCategories[0];
			}

			return null;
		}

		#endregion
	}
}
