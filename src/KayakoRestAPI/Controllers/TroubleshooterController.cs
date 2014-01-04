using System;
using System.Net;
using KayakoRestApi.Core.News;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.RequestBase;
using KayakoRestApi.Text;

namespace KayakoRestApi.Controllers
{
	public interface ITroubleshooterController
	{
		TroubleshooterCategoryCollection GetTroubleshooterCategories();

		TroubleshooterCategory GetTroubleshooterCategory(int troubleshooterCategoryId);

		TroubleshooterCategory CreateTroubleshooterCategory(TroubleshooterCategoryRequest troubleshooterCategoryRequest);

		TroubleshooterCategory UpdateTroubleshooterCategory(TroubleshooterCategoryRequest troubleshooterCategoryRequest);

		bool DeleteTroubleshooterCategory(int troubleshooterCategoryId);

		TroubleshooterStepCollection GetTroubleshooterSteps();

		TroubleshooterStep GetTroubleshooterStep(int troubleshooterStepId);

		//TroubleshooterStep CreateTroubleshooterStep(TroubleshooterCategoryRequest troubleshooterStepRequest);

		//TroubleshooterStep UpdateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest);

		bool DeleteTroubleshooterStep(int troubleshooterStepId);
	}

	public sealed class TroubleshooterController : BaseController, ITroubleshooterController
	{
		internal TroubleshooterController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
        }

		internal TroubleshooterController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
			: base(apiKey, secretKey, apiUrl, proxy, requestType)
		{
		}

		internal TroubleshooterController(IKayakoApiRequest kayakoApiRequest) 
			: base(kayakoApiRequest)
		{
		}

		private const string TroubleshooterCategoryBaseUrl = "/Troubleshooter/Category";
		private const string TroubleshooterStepBaseUrl = "/Troubleshooter/Step";

		#region Troubleshooter Category Methods

		public TroubleshooterCategoryCollection GetTroubleshooterCategories()
		{
			return Connector.ExecuteGet<TroubleshooterCategoryCollection>(TroubleshooterCategoryBaseUrl);
		}

		public TroubleshooterCategory GetTroubleshooterCategory(int troubleshooterCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterCategoryBaseUrl, troubleshooterCategoryId);

			TroubleshooterCategoryCollection troubleshooterCategories = Connector.ExecuteGet<TroubleshooterCategoryCollection>(apiMethod);

			if (troubleshooterCategories != null && troubleshooterCategories.Count > 0)
			{
				return troubleshooterCategories[0];
			}

			return null;
		}

		public TroubleshooterCategory CreateTroubleshooterCategory(TroubleshooterCategoryRequest troubleshooterCategoryRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterCategoryRequest, RequestTypes.Create);

			TroubleshooterCategoryCollection troubleshooterCategories = Connector.ExecutePost<TroubleshooterCategoryCollection>(TroubleshooterCategoryBaseUrl, parameters.ToString());

			if (troubleshooterCategories != null && troubleshooterCategories.Count > 0)
			{
				return troubleshooterCategories[0];
			}

			return null;
		}

		public TroubleshooterCategory UpdateTroubleshooterCategory(TroubleshooterCategoryRequest troubleshooterCategoryRequest)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterCategoryBaseUrl, troubleshooterCategoryRequest.Id);
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterCategoryRequest, RequestTypes.Update);

			TroubleshooterCategoryCollection troubleshooterCategories = Connector.ExecutePut<TroubleshooterCategoryCollection>(apiMethod, parameters.ToString());

			if (troubleshooterCategories != null && troubleshooterCategories.Count > 0)
			{
				return troubleshooterCategories[0];
			}

			return null;
		}

		public bool DeleteTroubleshooterCategory(int troubleshooterCategoryId)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterCategoryBaseUrl, troubleshooterCategoryId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(TroubleshooterCategoryRequest troubleshooterCategoryRequest, RequestTypes requestType)
		{
			troubleshooterCategoryRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonEmptyString("title", troubleshooterCategoryRequest.Title);
			parameters.AppendRequestData("categorytype", EnumUtility.ToApiString(troubleshooterCategoryRequest.CategoryType));

			if (requestType == RequestTypes.Create)
			{
				parameters.AppendRequestDataNonNegativeInt("staffid", troubleshooterCategoryRequest.StaffId);
			}

			if (troubleshooterCategoryRequest.DisplayOrder.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("displayorder", troubleshooterCategoryRequest.DisplayOrder.Value);
			}

			parameters.AppendRequestDataNonEmptyString("description", troubleshooterCategoryRequest.Description);
			parameters.AppendRequestDataBool("uservisibilitycustom", troubleshooterCategoryRequest.UserVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("usergroupidlist", troubleshooterCategoryRequest.UserGroupIdList);
			parameters.AppendRequestDataBool("staffvisibilitycustom", troubleshooterCategoryRequest.StaffVisibilityCustom);
			parameters.AppendRequestDataArrayCommaSeparated("staffgroupidlist", troubleshooterCategoryRequest.StaffGroupIdList);

			return parameters;
		}

		#endregion

		#region Troubleshooter Step Methods

		public TroubleshooterStepCollection GetTroubleshooterSteps()
		{
			return Connector.ExecuteGet<TroubleshooterStepCollection>(TroubleshooterStepBaseUrl);
		}

		public TroubleshooterStep GetTroubleshooterStep(int troubleshooterStepId)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterStepBaseUrl, troubleshooterStepId);

			TroubleshooterStepCollection troubleshooterSteps = Connector.ExecuteGet<TroubleshooterStepCollection>(apiMethod);

			if (troubleshooterSteps != null && troubleshooterSteps.Count > 0)
			{
				return troubleshooterSteps[0];
			}

			return null;
		}

		//public TroubleshooterStep CreateTroubleshooterStep(TroubleshooterCategoryRequest troubleshooterStepRequest)
		//{
			
		//}

		//public TroubleshooterStep UpdateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest)
		//{
			
		//}

		public bool DeleteTroubleshooterStep(int troubleshooterStepId)
		{
			string apiMethod = string.Format("{0}/{1}", TroubleshooterStepBaseUrl, troubleshooterStepId);

			return Connector.ExecuteDelete(apiMethod);
		}

		#endregion
	}
}
