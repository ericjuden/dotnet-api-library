using KayakoRestApi.Core.Constants;
using KayakoRestApi.Data;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Users
{
	public class UserRequest : RequestBaseObject
	{
		/// <summary>
		/// Gets a value indicating the Id of the user
		/// </summary>
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		/// <summary>
		/// The full name of User
		/// </summary>
		[RequiredField]
		[ResponseProperty("FullName")]
		public string FullName { get; set; }

		/// <summary>
		/// The User Group Id to assign to this User
		/// </summary>
		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("GroupId")]
		public int GroupId { get; set; }

		/// <summary>
		/// The email addresses for the User
		/// </summary>
		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("EmailAddresses")]
		public string[] EmailAddresses { get; set; }

		/// <summary>
		/// The User Organization Id
		/// </summary>
		[ResponseProperty("OrganizationId")]
		public KNullable<int> OrganizationId { get; set; }

		/// <summary>
		/// The User Salutation, available options are: Mr., Ms., Mrs., Dr.
		/// </summary>
		[ResponseProperty("Salutation")]
		public UserSalutation Salutation { get; set; }

		/// <summary>
		/// The User Designation/Title
		/// </summary>
		[ResponseProperty("Designation")]
		public string Designation { get; set; }

		/// <summary>
		/// The phone number for the user
		/// </summary>
		[ResponseProperty("Phone")]
		public string Phone { get; set; }

		/// <summary>
		/// Indicates whether the user is enabled/disabled
		/// </summary>
		[ResponseProperty("IsEnabled")]
		public bool IsEnabled { get; set; }

		/// <summary>
		/// The User Role, available options are: user, manager. Default: user
		/// </summary>
		[ResponseProperty("Role")]
		public UserRole Role { get; set; }

		/// <summary>
		/// The Time Zone the user resides in
		/// </summary>
		[ResponseProperty("TimeZone")]
		public string TimeZone { get; set; }

		/// <summary>
		/// Indciates whether daylight savings is enabled/disabled
		/// </summary>
		[ResponseProperty("EnableDst")]
		public bool EnableDst { get; set; }

		/// <summary>
		/// The SLA Plan Id to assign to the user 
		/// </summary>
		[ResponseProperty("SlaPlanId")]
		public int? SlaPlanId { get; set; }

		/// <summary>
		/// The SLA Plan Expiry, 0 = never expires
		/// </summary>
		[ResponseProperty("SlaPlanExpiry")]
		public long? SlaPlanExpiry { get; set; }

		/// <summary>
		/// The User Expiry, 0 = never expires 
		/// </summary>
		[ResponseProperty("Expiry")]
		public long? Expiry { get; set; }

		public static UserRequest FromResponseData(User responseData)
		{
			return UserRequest.FromResponseType<User, UserRequest>(responseData);
		}

		public static User ToResponseData(UserRequest requestData)
		{
			return UserRequest.ToResponseType<UserRequest, User>(requestData);
		}
	}
}
