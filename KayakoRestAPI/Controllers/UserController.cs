using System;
using KayakoRestApi.Core.Users;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.Text;
using KayakoRestApi.RequestBase;
using System.Net;

namespace KayakoRestApi.Controllers
{
	/// <summary>
	/// Provides access to User API Methods
	/// </summary>
    public sealed class UserController : BaseController
    {
        internal UserController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
        }

		internal UserController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
			: base(apiKey, secretKey, apiUrl, proxy, requestType)
		{
		}

        #region Api Methods

		#region User Methods

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item
        /// fetch limit is reached (by default this is 1000).
        /// </summary>
		public UserCollection GetUsers()
        {
            return GetUsers(0, 1000);
        }

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item
        /// fetch limit is reached (by default this is 1000).
        /// </summary>
        public UserCollection GetUsers(int filter)
        {
            return GetUsers(filter, 1000);
        }

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item
        /// fetch limit is reached (by default this is 1000).
        /// </summary>
        public UserCollection GetUsers(int filter, int max)
        {
            string apiMethod = String.Format("/Base/User/Filter/{0}/{1}", filter, max);

            return _connector.ExecuteGet<UserCollection>(apiMethod);
        }

        /// <summary>
        /// Retrieve the user identified by their unique indentifier
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            string apiMethod = String.Format("/Base/User/{0}", userId);

            UserCollection users = _connector.ExecuteGet<UserCollection>(apiMethod);

            if (users != null && users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Create a new User record
        /// </summary>
        public User CreateUser(UserRequest user, string password, bool sendWelcomeEmail)
        {
            string apiMethod = "/Base/User/";

            RequestBodyBuilder parameters = PopulateRequestParameters(user, RequestTypes.Create);

            if (!String.IsNullOrEmpty(password))
            {
                parameters.AppendRequestData("password", password);
            }

            parameters.AppendRequestData("sendwelcomeemail", Convert.ToInt32(sendWelcomeEmail));

            UserCollection users = _connector.ExecutePost<UserCollection>(apiMethod, parameters.ToString());

            if (users != null && users.Count > 0)
            {
                return users[0];
            }

            return null;
        }

        /// <summary>
        /// Update the user identified by their unique identifier.
        /// </summary>
        public User UpdateUser(UserRequest user)
        {
            string apiMethod = String.Format("/Base/User/{0}", user.Id);

            RequestBodyBuilder parameters = PopulateRequestParameters(user, RequestTypes.Update);

            UserCollection users = _connector.ExecutePut<UserCollection>(apiMethod, parameters.ToString());

            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Delete the user identified by its unique identifier
        /// </summary>
        public bool DeleteUser(int userId)
        {
            string url = String.Format("/Base/User/{0}", userId);

            return _connector.ExecuteDelete(url);
        }

		#endregion

		#region User Group Methods

        /// <summary>
        /// Retrieve a list of all user groups in the help desk.
        /// </summary>
		public UserGroupCollection GetUserGroups()
		{
			string apiMethod = "/Base/UserGroup/";

			return _connector.ExecuteGet<UserGroupCollection>(apiMethod);
		}

        /// <summary>
        /// Retrieve the user group identified by user group identifier.
        /// </summary>
		public UserGroup GetUserGroup(int userGroupId)
		{
			string apiMethod = String.Format("/Base/UserGroup/{0}", userGroupId);

			UserGroupCollection userGroups = _connector.ExecuteGet<UserGroupCollection>(apiMethod);

			if (userGroups != null && userGroups.Count > 0)
			{
				return userGroups[0];
			}

			return null;
		}

        /// <summary>
        /// Retrieve the user group identified by its unique identifier
        /// </summary>
        public UserGroup CreateUserGroup(UserGroupRequest userGroup)
		{
            string apiMethod = "/Base/UserGroup/";

			RequestBodyBuilder parameters = PopulateRequestParameters(userGroup, RequestTypes.Create);

			UserGroupCollection userGroups = _connector.ExecutePost<UserGroupCollection>(apiMethod, parameters.ToString());

			if (userGroups != null && userGroups.Count > 0)
			{
				return userGroups[0];
			}

			return null;
		}

        /// <summary>
        /// Update the user group identified by its unique identifier
        /// </summary>
		public UserGroup UpdateUserGroup(UserGroupRequest userGroup)
		{
			string apiMethod = String.Format("/Base/UserGroup/{0}", userGroup.Id);

            RequestBodyBuilder parameters = PopulateRequestParameters(userGroup, RequestTypes.Create);

			UserGroupCollection userGroups = _connector.ExecutePut<UserGroupCollection>(apiMethod, parameters.ToString());

			if (userGroups.Count > 0)
			{
				return userGroups[0];
			}
			return null;
		}

        /// <summary>
        /// Delete the user group identified by its unique identifier
        /// </summary>
		public bool DeleteUserGroup(int userGroupId)
		{
			string apiMethod = String.Format("/Base/UserGroup/{0}", userGroupId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#region User Organization Methods

		/// <summary>
		/// Retrieve a list of all organizations in the help desk
		/// </summary>
		/// <returns>TicketPosts</returns>
		public UserOrganizationCollection GetUserOrganizations()
		{
            string apiMethod = "/Base/UserOrganization/";

			UserOrganizationCollection orgs = _connector.ExecuteGet<UserOrganizationCollection>(apiMethod);

			return orgs;
		}

		/// <summary>
		/// Retrieve a list of all organizations in the help desk
		/// </summary>
		/// <returns>TicketPosts</returns>
		public UserOrganization GetUserOrganization(int id)
		{
            string apiMethod = String.Format("/Base/UserOrganization/{0}", id);

			UserOrganizationCollection orgs = _connector.ExecuteGet<UserOrganizationCollection>(apiMethod);

			if (orgs != null && orgs.Count > 0)
			{
				return orgs[0];
			}

			return null;
		}

		/// <summary>
		/// Create a new user organization record
		/// </summary>
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+UserOrganization#REST-UserOrganization-POST%2FBase%2FUserOrganization
		/// </remarks>
		/// <param name="org">Organisation to create</param>
		/// <returns>Added organisation.</returns>
		public UserOrganization CreateUserOrganization(UserOrganizationRequest org)
		{
			string apiMethod = "/Base/UserOrganization";

			RequestBodyBuilder parameters = PopulateRequestParameters(org, RequestTypes.Create);

			UserOrganizationCollection orgs = _connector.ExecutePost<UserOrganizationCollection>(apiMethod, parameters.ToString());

			if (orgs.Count > 0)
			{
				return orgs[0];
			}
			return null;
		}

        /// <summary>
        /// Update the user organization identified by its unique identifier
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
		public UserOrganization UpdateUserOrganization(UserOrganizationRequest org)
		{
			string apiMethod = String.Format("/Base/UserOrganization/{0}", org.Id);

			RequestBodyBuilder parameters = PopulateRequestParameters(org, RequestTypes.Update);

			UserOrganizationCollection orgs = _connector.ExecutePut<UserOrganizationCollection>(apiMethod, parameters.ToString());

			if (orgs != null && orgs.Count > 0)
			{
				return orgs[0];
			}

			return null;
		}

		public bool DeleteUserOrganization(int id)
		{
			string apiMethod = String.Format("/Base/UserOrganization/{0}", id);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#endregion

		#region Request Parameter Builders

		private static RequestBodyBuilder PopulateRequestParameters(UserRequest user, RequestTypes requestType)
        {
			user.EnsureValidData(requestType);

            RequestBodyBuilder parameters = new RequestBodyBuilder();

            if (!String.IsNullOrEmpty(user.FullName))
            {
                parameters.AppendRequestData("fullname", user.FullName);
            }

            if (user.GroupId > 0)
            {
                parameters.AppendRequestData("usergroupid", user.GroupId);
            }

            if (user.EmailAddresses != null && user.EmailAddresses.Length > 0)
            {
                parameters.AppendRequestDataArray<string>("email[]", user.EmailAddresses);
            }

			if (user.OrganizationId != null && user.OrganizationId.HasValue && user.OrganizationId.Value > 0)
            {
                parameters.AppendRequestData("userorganizationid", user.OrganizationId.Value);
            }

            parameters.AppendRequestData("salutation", EnumUtility.ToApiString(user.Salutation));

            if(!String.IsNullOrEmpty(user.Designation))
            {
                parameters.AppendRequestData("designation", user.Designation);
            }

            if(!String.IsNullOrEmpty(user.Phone))
            {
                parameters.AppendRequestData("phone", user.Phone);
            }

            parameters.AppendRequestData("isenabled", Convert.ToInt32(user.IsEnabled));

			parameters.AppendRequestData("userrole", EnumUtility.ToApiString(user.Role));

            if(!String.IsNullOrEmpty(user.TimeZone))
            {
                parameters.AppendRequestData("timezone", user.TimeZone);
            }
            
            parameters.AppendRequestData("enabledst", Convert.ToInt32(user.EnableDst));

			if (user.SlaPlanId != null)
			{
				parameters.AppendRequestData("slaplanid", user.SlaPlanId);
			}

			if (user.SlaPlanExpiry != null)
			{
				parameters.AppendRequestData("slaplanexpiry", user.SlaPlanExpiry);
			}

			if (user.Expiry != null)
			{
				parameters.AppendRequestData("userexpiry", user.Expiry);
			}

            return parameters;
		}

		private static RequestBodyBuilder PopulateRequestParameters(UserGroupRequest userGroup, RequestTypes requestType)
		{
            userGroup.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

			if (!String.IsNullOrEmpty(userGroup.Title))
			{
				parameters.AppendRequestData("title", userGroup.Title);
			}

			parameters.AppendRequestData("grouptype", EnumUtility.ToApiString(userGroup.GroupType));

			//parameters.AppendRequestData("ismaster", Convert.ToInt32(userGroup.Ismaster));

			return parameters;
		}

		private static RequestBodyBuilder PopulateRequestParameters(UserOrganizationRequest org, RequestTypes requestType)
		{
			org.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

			parameters.AppendRequestData("name", org.Name);
			parameters.AppendRequestData("organizationtype", EnumUtility.ToApiString(org.OrganizationType));

			if (!String.IsNullOrEmpty(org.Address))
			{
				parameters.AppendRequestData("address", org.Address);
			}

			if (!String.IsNullOrEmpty(org.City))
			{
			parameters.AppendRequestData("city", org.City);
			}

			if (!String.IsNullOrEmpty(org.State))
			{
			parameters.AppendRequestData("state", org.State);
			}

			if (!String.IsNullOrEmpty(org.PostalCode))
			{
			parameters.AppendRequestData("postalcode", org.PostalCode);
			}

			if (!String.IsNullOrEmpty(org.Country))
			{
			parameters.AppendRequestData("country", org.Country);
			}

			if (!String.IsNullOrEmpty(org.Phone))
			{
			parameters.AppendRequestData("phone", org.Phone);
			}

			if (!String.IsNullOrEmpty(org.Fax))
			{
			parameters.AppendRequestData("fax", org.Fax);
			}

			if (!String.IsNullOrEmpty(org.Website))
			{
			parameters.AppendRequestData("website", org.Website);
			}

			if (org.SlaPlanId != null)
			{
			parameters.AppendRequestData("slaplanid", org.SlaPlanId);
			}

			if (org.SlaPlanExpiry != null)
			{
			parameters.AppendRequestData("slaplanexpiry", org.SlaPlanExpiry);
			}

			return parameters;
		}

		#endregion
	}
}
