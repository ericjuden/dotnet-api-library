using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Troubleshooter
{
	public class TroubleshooterStepRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[ResponseProperty("CategoryId")]
		[RequiredField(RequestTypes.Create)]
		public TroubleshooterCategoryType CategoryId { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Subject")]
		public string Subject { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		[RequiredField]
		[ResponseProperty("StaffId")]
		public int StaffId { get; set; }

		[ResponseProperty("DisplayOrder")]
		public int? DisplayOrder { get; set; }

		[ResponseProperty("AllowComments")]
		public bool? AllowComments { get; set; }

		[ResponseProperty("RedirectTickets")]
		public bool? EnableTicketRedirection { get; set; }

		[ResponseProperty("RedirectDepartmentId")]
		public int? RedirectDepartmentId { get; set; }

		[ResponseProperty("TicketTypeId")]
		public int? TicketTypeId { get; set; }

		[ResponseProperty("TicketPriorityId")]
		public int? TicketPriorityId { get; set; }

		[ResponseProperty("TicketSubject")]
		public string TicketSubject { get; set; }

		public TroubleshooterStepStatus? StepStatus { get; set; }

		[ResponseProperty("ParentSteps")]
		public int[] ParentStepIdList { get; set; }

		public static TroubleshooterStepRequest FromResponseData(TroubleshooterStep responseData)
		{
			return FromResponseType<TroubleshooterStep, TroubleshooterStepRequest>(responseData);
		}

		public static TroubleshooterStep ToResponseData(TroubleshooterStepRequest requestData)
		{
			return ToResponseType<TroubleshooterStepRequest, TroubleshooterStep>(requestData);
		}
	}
}
