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

		TroubleshooterStep CreateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest);

		TroubleshooterStep UpdateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest);

		bool DeleteTroubleshooterStep(int troubleshooterStepId);

		TroubleshooterCommentCollection GetTroubleshooterComments(int troubleshooterStepId);

		TroubleshooterComment GetTroubleshooterComment(int troubleshooterCommentId);

		TroubleshooterComment CreateTroubleshooterComment(TroubleshooterCommentRequest troubleshooterCommentRequest);

		bool DeleteTroubleshooterComment(int troubleshooterCommentId);

		TroubleshooterAttachmentCollection GetTroubleshooterAttachments(int troubleshooterStepId);

		TroubleshooterAttachment GetTroubleshooterAttachment(int troubleshooterStepId, int troubleshooterAttachmentId);

		TroubleshooterAttachment CreateTroubleshooterAttachment(TroubleshooterAttachmentRequest troubleshooterAttachmentRequest);

		bool DeleteTroubleshooterAttachment(int troubleshooterStepId, int troubleshooterAttachmentId);
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
		private const string TroubleshooterCommentBaseUrl = "/Troubleshooter/Comment";
		private const string TroubleshooterAttachmentBaseUrl = "/Troubleshooter/Attachment";

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

		public TroubleshooterStep CreateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterStepRequest, RequestTypes.Create);

			TroubleshooterStepCollection troubleshooterSteps = Connector.ExecutePost<TroubleshooterStepCollection>(TroubleshooterStepBaseUrl, parameters.ToString());

			if (troubleshooterSteps != null && troubleshooterSteps.Count > 0)
			{
				return troubleshooterSteps[0];
			}

			return null;
		}

		public TroubleshooterStep UpdateTroubleshooterStep(TroubleshooterStepRequest troubleshooterStepRequest)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterStepBaseUrl, troubleshooterStepRequest.Id);
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterStepRequest, RequestTypes.Update);

			TroubleshooterStepCollection troubleshooterStep = Connector.ExecutePut<TroubleshooterStepCollection>(apiMethod, parameters.ToString());

			if (troubleshooterStep != null && troubleshooterStep.Count > 0)
			{
				return troubleshooterStep[0];
			}

			return null;
		}

		public bool DeleteTroubleshooterStep(int troubleshooterStepId)
		{
			string apiMethod = string.Format("{0}/{1}", TroubleshooterStepBaseUrl, troubleshooterStepId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(TroubleshooterStepRequest troubleshooterStepRequest, RequestTypes requestType)
		{
			troubleshooterStepRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

			if (requestType == RequestTypes.Create)
			{
				parameters.AppendRequestData("categoryid", EnumUtility.ToApiString(troubleshooterStepRequest.CategoryId));
			}

			parameters.AppendRequestDataNonEmptyString("subject", troubleshooterStepRequest.Subject);
			parameters.AppendRequestDataNonEmptyString("contents", troubleshooterStepRequest.Contents);

			parameters.AppendRequestDataNonNegativeInt(requestType == RequestTypes.Create ? "staffid" : "editedstaffid",
			                                           troubleshooterStepRequest.StaffId);

			if (troubleshooterStepRequest.DisplayOrder.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("displayorder", troubleshooterStepRequest.DisplayOrder.Value);
			}

			parameters.AppendRequestDataBool("allowcomments", troubleshooterStepRequest.AllowComments);
			parameters.AppendRequestDataBool("enableticketredirection", troubleshooterStepRequest.EnableTicketRedirection);

			if (troubleshooterStepRequest.RedirectDepartmentId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("redirectdepartmentid", troubleshooterStepRequest.RedirectDepartmentId.Value);
			}

			if (troubleshooterStepRequest.TicketTypeId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("tickettypeid", troubleshooterStepRequest.TicketTypeId.Value);
			}

			if(troubleshooterStepRequest.TicketPriorityId.HasValue)
			{
				parameters.AppendRequestDataNonNegativeInt("ticketpriorityid", troubleshooterStepRequest.TicketPriorityId.Value);
			}

			parameters.AppendRequestDataNonEmptyString("ticketsubject", troubleshooterStepRequest.TicketSubject);
			
			if (troubleshooterStepRequest.StepStatus.HasValue)
			{
				parameters.AppendRequestData("stepstatus", EnumUtility.ToApiString(troubleshooterStepRequest.StepStatus.Value));
			}

			parameters.AppendRequestDataArrayCommaSeparated("parentstepidlist", troubleshooterStepRequest.ParentStepIdList);

			return parameters;
		}

		#endregion

		#region Troubleshooter Comment Methods

		public TroubleshooterCommentCollection GetTroubleshooterComments(int troubleshooterStepId)
		{
			string apiMethod = string.Format("{0}/ListAll/{1}", TroubleshooterCommentBaseUrl, troubleshooterStepId);

			return Connector.ExecuteGet<TroubleshooterCommentCollection>(apiMethod);
		}

		public TroubleshooterComment GetTroubleshooterComment(int troubleshooterCommentId)
		{
			string apiMethod = String.Format("{0}/{1}", TroubleshooterCommentBaseUrl, troubleshooterCommentId);

			TroubleshooterCommentCollection troubleshooterComments = Connector.ExecuteGet<TroubleshooterCommentCollection>(apiMethod);

			if (troubleshooterComments != null && troubleshooterComments.Count > 0)
			{
				return troubleshooterComments[0];
			}

			return null;
		}

		public TroubleshooterComment CreateTroubleshooterComment(TroubleshooterCommentRequest troubleshooterCommentRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterCommentRequest, RequestTypes.Create);

			TroubleshooterCommentCollection troubleshooterComments = Connector.ExecutePost<TroubleshooterCommentCollection>(TroubleshooterCommentBaseUrl, parameters.ToString());

			if (troubleshooterComments != null && troubleshooterComments.Count > 0)
			{
				return troubleshooterComments[0];
			}

			return null;
		}

		public bool DeleteTroubleshooterComment(int troubleshooterCommentId)
		{
			string apiMethod = string.Format("{0}/{1}", TroubleshooterCommentBaseUrl, troubleshooterCommentId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(TroubleshooterCommentRequest troubleshooterCommentRequest, RequestTypes requestType)
		{
			troubleshooterCommentRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonNegativeInt("troubleshooterstepid", troubleshooterCommentRequest.TroubleshooterStepId);
			parameters.AppendRequestDataNonEmptyString("contents", troubleshooterCommentRequest.Contents);
			parameters.AppendRequestData("creatortype", EnumUtility.ToApiString(troubleshooterCommentRequest.CreatorType));
			parameters.AppendRequestDataNonNegativeInt("creatorid", troubleshooterCommentRequest.CreatorId);
			parameters.AppendRequestDataNonEmptyString("fullname", troubleshooterCommentRequest.FullName);
			parameters.AppendRequestDataNonEmptyString("email", troubleshooterCommentRequest.Email);
			parameters.AppendRequestDataNonNegativeInt("parentcommentid", troubleshooterCommentRequest.ParentCommentId);

			return parameters;
		}

		#endregion

		#region Troubleshooter Attachment Methods

		public TroubleshooterAttachmentCollection GetTroubleshooterAttachments(int troubleshooterStepId)
		{
			string apiMethod = string.Format("{0}/ListAll/{1}", TroubleshooterAttachmentBaseUrl, troubleshooterStepId);

			return Connector.ExecuteGet<TroubleshooterAttachmentCollection>(apiMethod);
		}

		public TroubleshooterAttachment GetTroubleshooterAttachment(int troubleshooterStepId, int troubleshooterAttachmentId)
		{
			string apiMethod = String.Format("{0}/{1}/{2}", TroubleshooterAttachmentBaseUrl, troubleshooterStepId, troubleshooterAttachmentId);

			TroubleshooterAttachmentCollection troubleshooterAttachments = Connector.ExecuteGet<TroubleshooterAttachmentCollection>(apiMethod);

			if (troubleshooterAttachments != null && troubleshooterAttachments.Count > 0)
			{
				return troubleshooterAttachments[0];
			}

			return null;
		}

		public TroubleshooterAttachment CreateTroubleshooterAttachment(TroubleshooterAttachmentRequest troubleshooterAttachmentRequest)
		{
			RequestBodyBuilder parameters = PopulateRequestParameters(troubleshooterAttachmentRequest, RequestTypes.Create);

			TroubleshooterAttachmentCollection troubleshooterAttachments = Connector.ExecutePost<TroubleshooterAttachmentCollection>(TroubleshooterAttachmentBaseUrl, parameters.ToString());

			if (troubleshooterAttachments != null && troubleshooterAttachments.Count > 0)
			{
				return troubleshooterAttachments[0];
			}

			return null;
		}

		public bool DeleteTroubleshooterAttachment(int troubleshooterStepId, int troubleshooterAttachmentId)
		{
			string apiMethod = String.Format("{0}/{1}/{2}", TroubleshooterAttachmentBaseUrl, troubleshooterStepId, troubleshooterAttachmentId);

			return Connector.ExecuteDelete(apiMethod);
		}

		private RequestBodyBuilder PopulateRequestParameters(TroubleshooterAttachmentRequest troubleshooterAttachmentRequest, RequestTypes requestType)
		{
			troubleshooterAttachmentRequest.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestDataNonNegativeInt("troubleshooterstepid", troubleshooterAttachmentRequest.TroubleshooterStepId);
			parameters.AppendRequestDataNonEmptyString("filename", troubleshooterAttachmentRequest.FileName);
			parameters.AppendRequestDataNonEmptyString("contents", troubleshooterAttachmentRequest.Contents);

			return parameters;
		}

		#endregion
	}
}
