using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Staff
{
	public class StaffUserRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField]
		[ResponseProperty("FirstName")]
		public string FirstName { get; set; }

		[RequiredField]
		[ResponseProperty("LastName")]
		public string LastName { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("UserName")]
		public string UserName { get; set; }

		[RequiredField(RequestTypes.Create)]
		public string Password { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("GroupId")]
		public int GroupId { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Email")]
		public string Email { get; set; }

		[OptionalField]
		[ResponseProperty("Designation")]
		public string Designation { get; set; }

		[OptionalField]
		[ResponseProperty("MobileNumber")]
		public string MobileNumber { get; set; }

		[OptionalField]
		[ResponseProperty("Signature")]
		public string Signature { get; set; }

		[OptionalField]
		[ResponseProperty("IsEnabled")]
		public bool IsEnabled { get; set; }

		[OptionalField]
		[ResponseProperty("Greeting")]
		public string Greeting { get; set; }

		[OptionalField]
		[ResponseProperty("TimeZone")]
		public string TimeZone { get; set; }

		[OptionalField]
		[ResponseProperty("EnableDst")]
		public bool EnableDst { get; set; }

		public static StaffUserRequest FromResponseData(StaffUser responseData)
		{
			return StaffUserRequest.FromResponseType<StaffUser, StaffUserRequest>(responseData);
		}

		public static StaffUser ToResponseData(StaffUserRequest requestData)
		{
			return StaffUserRequest.ToResponseType<StaffUserRequest, StaffUser>(requestData);
		}
	}
}
