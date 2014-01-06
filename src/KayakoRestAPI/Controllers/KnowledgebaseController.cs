using System;
using System.Net;
using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.RequestBase;
using KayakoRestApi.Text;

namespace KayakoRestApi.Controllers
{
	public interface IKnowledgebaseController
	{
		KnowledgebaseCategoryCollection GetKnowledgebaseCategories();

		KnowledgebaseCategoryCollection GetKnowledgebaseCategories(int count, int start);

		KnowledgebaseCategory GetKnowledgebaseCategory(int knowledgebaseCategoryId);

		KnowledgebaseCategory CreateKnowledgebaseCategory(KnowledgebaseCategoryRequest knowledgebaseCategoryRequest);

		KnowledgebaseCategory UpdateKnowledgebaseCategory(KnowledgebaseCategoryRequest knowledgebaseCategoryRequest);

		bool DeleteKnowledgebaseCategory(int knowledgebaseCategoryId);

		KnowledgebaseArticleCollection GetKnowledgebaseArticles();

		KnowledgebaseArticleCollection GetKnowledgebaseArticles(int count, int start);

		KnowledgebaseArticle GetKnowledgebaseArticle(int knowledgebaseArticleId);

		KnowledgebaseArticle CreateKnowledgebaseArticle(KnowledgebaseArticleRequest knowledgebaseArticleRequest);

		KnowledgebaseArticle UpdateKnowledgebaseArticle(KnowledgebaseArticleRequest knowledgebaseArticleRequest);

		bool DeleteKnowledgebaseArticle(int knowledgebaseArticleId);
	}

	public sealed class KnowledgebaseController : BaseController, IKnowledgebaseController
	{
		internal KnowledgebaseController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
        }

		internal KnowledgebaseController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
			: base(apiKey, secretKey, apiUrl, proxy, requestType)
		{
		}

		internal KnowledgebaseController(IKayakoApiRequest kayakoApiRequest) 
			: base(kayakoApiRequest)
		{
		}

		private const string KnowledgebaseCategoryBaseUrl = "/Knowledgebase/Category";
		private const string KnowledgebaseArticleBaseUrl = "/Knowledgebase/Article";

		#region Knowledgebase Category Methods

		public KnowledgebaseCategoryCollection GetKnowledgebaseCategories()
		{
			return GetKnowledgebaseCategories(-1, -1);
		}

		public KnowledgebaseCategoryCollection GetKnowledgebaseCategories(int count, int start)
		{
			string apiMethod = string.Format("{0}/ListAll/{1}/{2}", KnowledgebaseCategoryBaseUrl, count, start);

			return Connector.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod);
		}

		public KnowledgebaseCategory GetKnowledgebaseCategory(int knowledgebaseCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseCategoryBaseUrl, knowledgebaseCategoryId);

			KnowledgebaseCategoryCollection knowledgebaseCategories = Connector.ExecuteGet<KnowledgebaseCategoryCollection>(apiMethod);

			if (knowledgebaseCategories != null && knowledgebaseCategories.Count > 0)
			{
				return knowledgebaseCategories[0];
			}

			return null;
		}

		public KnowledgebaseCategory CreateKnowledgebaseCategory(KnowledgebaseCategoryRequest knowledgebaseCategoryRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(knowledgebaseCategoryRequest, RequestTypes.Create);

			KnowledgebaseCategoryCollection knowledgebaseCategories = Connector.ExecutePost<KnowledgebaseCategoryCollection>(KnowledgebaseCategoryBaseUrl, parameters.ToString());

			if (knowledgebaseCategories != null && knowledgebaseCategories.Count > 0)
			{
				return knowledgebaseCategories[0];
			}

			return null;
		}

		public KnowledgebaseCategory UpdateKnowledgebaseCategory(KnowledgebaseCategoryRequest knowledgebaseCategoryRequest)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseCategoryBaseUrl, knowledgebaseCategoryRequest.Id);
			RequestBodyBuilder parameters = PopulateRequestParameters(knowledgebaseCategoryRequest, RequestTypes.Update);

			KnowledgebaseCategoryCollection knowledgebaseCategories = Connector.ExecutePut<KnowledgebaseCategoryCollection>(apiMethod, parameters.ToString());

			if (knowledgebaseCategories != null && knowledgebaseCategories.Count > 0)
			{
				return knowledgebaseCategories[0];
			}

			return null;
		}

		public bool DeleteKnowledgebaseCategory(int knowledgebaseCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseCategoryBaseUrl, knowledgebaseCategoryId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(KnowledgebaseCategoryRequest knowledgebaseCategoryRequest, RequestTypes requestType)
		{
			knowledgebaseCategoryRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonEmptyString("title", knowledgebaseCategoryRequest.Title);

			if (knowledgebaseCategoryRequest.CategoryType.HasValue)
			{
				parameters.AppendRequestData("categorytype",
				                             EnumUtility.ToApiString(knowledgebaseCategoryRequest.CategoryType.Value));
			}

			if (knowledgebaseCategoryRequest.ParentCategoryId.HasValue)
			{
				parameters.AppendRequestData("parentcategoryid", knowledgebaseCategoryRequest.ParentCategoryId.Value);
			}

			if (knowledgebaseCategoryRequest.DisplayOrder.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("displayorder", knowledgebaseCategoryRequest.DisplayOrder.Value);
			}

			if (knowledgebaseCategoryRequest.ArticleSortOrder.HasValue)
			{
				parameters.AppendRequestData("articlesortorder",
				                             EnumUtility.ToApiString(knowledgebaseCategoryRequest.ArticleSortOrder.Value));
			}

			parameters.AppendRequestDataBool("allowcomments", knowledgebaseCategoryRequest.AllowComments);
			parameters.AppendRequestDataBool("allowrating", knowledgebaseCategoryRequest.AllowRating);
			parameters.AppendRequestDataBool("ispublished", knowledgebaseCategoryRequest.IsPublished);
			parameters.AppendRequestDataBool("uservisibilitycustom", knowledgebaseCategoryRequest.UserVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("usergroupidlist", knowledgebaseCategoryRequest.UserGroupIdList);
			parameters.AppendRequestDataBool("staffvisibilitycustom", knowledgebaseCategoryRequest.StaffVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("staffgroupidlist", knowledgebaseCategoryRequest.StaffGroupIdList);

			if (requestType == RequestTypes.Create && knowledgebaseCategoryRequest.StaffId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("staffid", knowledgebaseCategoryRequest.StaffId.Value);
			}

			return parameters;
		}

		#endregion

		#region Knowledgebase Article Methods

		public KnowledgebaseArticleCollection GetKnowledgebaseArticles()
		{
			return Connector.ExecuteGet<KnowledgebaseArticleCollection>(KnowledgebaseArticleBaseUrl);
		}

		public KnowledgebaseArticleCollection GetKnowledgebaseArticles(int count, int start)
		{
			string apiMethod = string.Format("{0}/ListAll/{1}/{2}", KnowledgebaseArticleBaseUrl, count, start);

			return Connector.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod);
		}

		public KnowledgebaseArticle GetKnowledgebaseArticle(int knowledgebaseArticleId)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseArticleBaseUrl, knowledgebaseArticleId);

			KnowledgebaseArticleCollection knowledgebaseArticles = Connector.ExecuteGet<KnowledgebaseArticleCollection>(apiMethod);

			if (knowledgebaseArticles != null && knowledgebaseArticles.Count > 0)
			{
				return knowledgebaseArticles[0];
			}

			return null;
		}

		public KnowledgebaseArticle CreateKnowledgebaseArticle(KnowledgebaseArticleRequest knowledgebaseArticleRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(knowledgebaseArticleRequest, RequestTypes.Create);

			KnowledgebaseArticleCollection knowledgebaseArticles = Connector.ExecutePost<KnowledgebaseArticleCollection>(KnowledgebaseArticleBaseUrl, parameters.ToString());

			if (knowledgebaseArticles != null && knowledgebaseArticles.Count > 0)
			{
				return knowledgebaseArticles[0];
			}

			return null;
		}

		public KnowledgebaseArticle UpdateKnowledgebaseArticle(KnowledgebaseArticleRequest knowledgebaseArticleRequest)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseArticleBaseUrl, knowledgebaseArticleRequest.Id);
			RequestBodyBuilder parameters = PopulateRequestParameters(knowledgebaseArticleRequest, RequestTypes.Update);

			KnowledgebaseArticleCollection knowledgebaseArticles = Connector.ExecutePut<KnowledgebaseArticleCollection>(apiMethod, parameters.ToString());

			if (knowledgebaseArticles != null && knowledgebaseArticles.Count > 0)
			{
				return knowledgebaseArticles[0];
			}

			return null;
		}

		public bool DeleteKnowledgebaseArticle(int knowledgebaseArticleId)
		{
			string apiMethod = String.Format("{0}/{1}", KnowledgebaseArticleBaseUrl, knowledgebaseArticleId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(KnowledgebaseArticleRequest knowledgebaseArticleRequest, RequestTypes requestType)
		{
			knowledgebaseArticleRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonEmptyString("subject", knowledgebaseArticleRequest.Subject);
			parameters.AppendRequestDataNonEmptyString("contents", knowledgebaseArticleRequest.Contents);

			if (requestType == RequestTypes.Create && knowledgebaseArticleRequest.CreatorId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("creatorid", knowledgebaseArticleRequest.CreatorId.Value);
			}

			if (knowledgebaseArticleRequest.ArticleStatus.HasValue)
			{
				parameters.AppendRequestData("articlestatus", EnumUtility.ToApiString(knowledgebaseArticleRequest.ArticleStatus.Value));
			}

			parameters.AppendRequestDataBool("isfeatured", knowledgebaseArticleRequest.IsFeatured);
			parameters.AppendRequestDataBool("allowcomments", knowledgebaseArticleRequest.AllowComments);
			parameters.AppendRequestDataArrayCommaSeparated("categoryid", knowledgebaseArticleRequest.CategoryIds);

			if (requestType == RequestTypes.Update && knowledgebaseArticleRequest.EditedStaffId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("editedstaffid", knowledgebaseArticleRequest.EditedStaffId.Value);
			}

			return parameters;
		}

		#endregion
	}
}
