using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Users
{
	public class UserOrganizationRequest : RequestBaseObject
	{
		/// <summary>
		/// The unique numeric identifier of the user organization
		/// </summary>
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		/// <summary>
		/// The name of the user organization
		/// </summary>
		[RequiredField]
		[ResponseProperty("Name")]
		public string Name { get; set; }

		/// <summary>
		/// The type of user organization ('restricted' or 'shared')
		/// </summary>
		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("OrganizationType")]
		public UserOrganizationType OrganizationType { get; set; }

		/// <summary>
		/// The address of the user organisation
		/// </summary>
		[ResponseProperty("Address")]
		public string Address { get; set; }

		/// <summary>
		/// The City of the user organisation
		/// </summary>
		[ResponseProperty("City")]
		public string City { get; set; }

		/// <summary>
		/// The state of the user organisation
		/// </summary>
		[ResponseProperty("State")]
		public string State { get; set; }

		/// <summary>
		/// The postal code of the user organisation
		/// </summary>
		[ResponseProperty("PostalCode")]
		public string PostalCode { get; set; }

		/// <summary>
		/// The country of the user organisation
		/// </summary>
		[ResponseProperty("Country")]
		public string Country { get; set; }

		/// <summary>
		/// The phone number of the user organisation
		/// </summary>
		[ResponseProperty("Phone")]
		public string Phone { get; set; }

		/// <summary>
		/// The fax number for the user organisation
		/// </summary>
		[ResponseProperty("Fax")]
		public string Fax { get; set; }

		/// <summary>
		/// The website of the user organisation
		/// </summary>
		[ResponseProperty("Website")]		
		public string Website { get; set; }

		/// <summary>
		/// The SLA Plan Id to link with this user organization
		/// </summary>
		[ResponseProperty("SlaPlanId")]
		public int? SlaPlanId { get; set; }

		/// <summary>
		/// The UNIX timestamp by which to ignore the SLA Plan, 0 = never expires
		/// </summary>
		[ResponseProperty("SlaPlanExpiry")]
		public long? SlaPlanExpiry { get; set; }

		public static UserOrganizationRequest FromResponseData(UserOrganization responseData)
		{
			return UserOrganizationRequest.FromResponseType<UserOrganization, UserOrganizationRequest>(responseData);
		}

		public static UserOrganization ToResponseData(UserOrganizationRequest requestData)
		{
			return UserOrganizationRequest.ToResponseType<UserOrganizationRequest, UserOrganization>(requestData);
		}
	}
}
