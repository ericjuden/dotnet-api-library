using System;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Net;
using KayakoRestApi.RequestBase;
using KayakoRestApi.Text;

namespace KayakoRestApi.Controllers
{
	/// <summary>
	/// Provides access to Staff API Methods
	/// </summary>
    public sealed class StaffController : BaseController
    {
        internal StaffController(string apiKey, string secretKey, string apiUrl)
            : base(apiKey, secretKey, apiUrl)
        {
        }

        #region Api Methods

		#region Staff Methos

		/// <summary>
        /// Retrieve a list of all staff users in the help desk.
        /// </summary>
        /// <returns>The staff</returns>
        public StaffUserCollection GetStaffUsers()
        {
            string apiMethod = "/Base/Staff/";

            return _connector.ExecuteGet<StaffUserCollection>(apiMethod);
        }

        /// <summary>
        /// Retrieve a staff identified by <paramref name="staffId"/>
        /// </summary>
        /// <param name="staffId">The numeric identifier of the staff.</param>
        /// <returns>The staff user.</returns>
        public StaffUser GetStaffUser(int staffId)
        {
            string apiMethod = String.Format("/Base/Staff/{0}", staffId);

            StaffUserCollection users = _connector.ExecuteGet<StaffUserCollection>(apiMethod);

            if (users != null && users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Update the staff identified by <paramref name="staffUser"/>
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+Staff#REST-Staff-PUT%2FBase%2FStaff%2F%24id%24
        /// </remarks>
        /// <param name="staffUser">User to updated</param>
        /// <returns>Updated user.</returns>
        public StaffUser UpdateStaffUser(StaffUserRequest staffUser)
        {
            string apiMethod = String.Format("/Base/Staff/{0}", staffUser.Id);

            RequestBodyBuilder parameters = PopulateRequestParameters(staffUser, RequestTypes.Update);

            StaffUserCollection users = _connector.ExecutePut<StaffUserCollection>(apiMethod, parameters.ToString());

            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Create a new Staff record
        /// </summary>
        /// <param name="staffUser">Data representing the new staff</param>
        /// <param name="password">The staff password </param>
        /// <returns></returns>
        public StaffUser CreateStaffUser(StaffUserRequest staffUser)
        {
            string apiMethod = "/Base/Staff/";

            RequestBodyBuilder parameters = PopulateRequestParameters(staffUser, RequestTypes.Create);

            StaffUserCollection staff = _connector.ExecutePost<StaffUserCollection>(apiMethod, parameters.ToString());

            if (staff != null && staff.Count > 0)
            {
                return staff[0];
            }

            return null;
        }

        /// <summary>
        /// Delete the staff identified by <paramref name="staffId"/>.
        /// </summary>
        /// <param name="staffId">The numeric identifier of the staff.</param>
        /// <returns>True if staff removed, false otherwise.</returns>
        public bool DeleteStaffUser(int staffId)
        {
            string apiMethod = String.Format("/Base/Staff/{0}", staffId);

			return _connector.ExecuteDelete(apiMethod);
        }

		#endregion

		#region Staff Group Methods

		/// <summary>
		/// Retrieve a list of all staff user groups in the help desk.
		/// </summary>
		/// <returns>List of staff groups</returns>
		public StaffGroupCollection GetStaffGroups()
		{
            string apiMethod = "/Base/StaffGroup/";

			return _connector.ExecuteGet<StaffGroupCollection>(apiMethod);
		}

		/// <summary>
		/// Retrieve a staff group identified by <paramref name="groupId"/>.
		/// </summary>
		/// <param name="groupId">The numeric identifier of the staff group.</param>
		/// <returns>The staff group</returns>
		public StaffGroup GetStaffGroup(int groupId)
		{
            string apiMethod = String.Format("/Base/StaffGroup/{0}/", groupId);

			StaffGroupCollection grps = _connector.ExecuteGet<StaffGroupCollection>(apiMethod);

			if (grps != null && grps.Count > 0)
			{
				return grps[0];
			}

			return null;
		}

        /// <summary>
        /// Create a staff group
        /// </summary>
        /// <param name="staffGroup">Data representing the staff group to create</param>
        /// <returns>Data representing the staff group created</returns>
		public StaffGroup CreateStaffGroup(StaffGroupRequest staffGroup)
		{
            string apiMethod = "/Base/StaffGroup";

			RequestBodyBuilder parameters = PopulateRequestParameters(staffGroup, RequestTypes.Create);

			StaffGroupCollection staffGroups = _connector.ExecutePost<StaffGroupCollection>(apiMethod, parameters.ToString());

			if (staffGroups != null && staffGroups.Count > 0)
			{
				return staffGroups[0];
			}

			return null;
		}

        /// <summary>
        /// Update the staff group identified by its internal identifer
        /// </summary>
        /// <param name="staffGroup">Data representing the staff group to update. Staff Group Id and Title must be supplied</param>
        /// <returns></returns>
		public StaffGroup UpdateStaffGroup(StaffGroupRequest staffGroup)
		{
            string apiMethod = String.Format("/Base/StaffGroup/{0}", staffGroup.Id);

			RequestBodyBuilder parameters = PopulateRequestParameters(staffGroup, RequestTypes.Update);

			StaffGroupCollection staffGroups = _connector.ExecutePut<StaffGroupCollection>(apiMethod, parameters.ToString());

			if (staffGroups != null && staffGroups.Count > 0)
			{
				return staffGroups[0];
			}

			return null;
		}

        /// <summary>
        /// Delete the staff group identified by its internal identifier
        /// </summary>
        /// <param name="staffGroupId">The Id of the Staff Group to delete</param>
        /// <returns>The success of the deletion</returns>
		public bool DeleteStaffGroup(int staffGroupId)
		{
			string apiMethod = String.Format("/Base/StaffGroup/{0}", staffGroupId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#endregion

		#region Request Parameter Builders

		private static RequestBodyBuilder PopulateRequestParameters(StaffUserRequest staffUser, RequestTypes requestType)
        {
			staffUser.EnsureValidData(requestType);

            RequestBodyBuilder parameters = new RequestBodyBuilder();

            if (!String.IsNullOrEmpty(staffUser.FirstName))
            {
                parameters.AppendRequestData("firstname", staffUser.FirstName);
            }

            if (!String.IsNullOrEmpty(staffUser.LastName))
            {
                parameters.AppendRequestData("lastname", staffUser.LastName);
            }

            if (!String.IsNullOrEmpty(staffUser.UserName))
            {
                parameters.AppendRequestData("username", staffUser.UserName);
            }

			if (!String.IsNullOrEmpty(staffUser.Password))
            {
				parameters.AppendRequestData("password", staffUser.Password);
            }

            if (staffUser.GroupId > 0)
            {
                parameters.AppendRequestData("staffgroupid", staffUser.GroupId);
            }

            if (!String.IsNullOrEmpty(staffUser.Email))
            {
                parameters.AppendRequestData("email", staffUser.Email);
            }

            if (!String.IsNullOrEmpty(staffUser.Designation))
            {
                parameters.AppendRequestData("designation", staffUser.Designation);
            }

            if (!String.IsNullOrEmpty(staffUser.MobileNumber))
            {
                parameters.AppendRequestData("mobilenumber", staffUser.MobileNumber);
            }

            parameters.AppendRequestData("isenabled", Convert.ToInt32(staffUser.IsEnabled));

            if (!String.IsNullOrEmpty(staffUser.Greeting))
            {
                parameters.AppendRequestData("greeting", staffUser.Greeting);
            }

            if (!String.IsNullOrEmpty(staffUser.Signature))
            {
                parameters.AppendRequestData("signature", staffUser.Signature);
            }

            if (!String.IsNullOrEmpty(staffUser.TimeZone))
            {
                parameters.AppendRequestData("timezone", staffUser.TimeZone);
            }

            parameters.AppendRequestData("enabledst", Convert.ToInt32(staffUser.EnableDst));

            return parameters;
        }

		private static RequestBodyBuilder PopulateRequestParameters(StaffGroupRequest staffGroup, RequestTypes requestType)
		{
            staffGroup.EnsureValidData(requestType);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

			if (!String.IsNullOrEmpty(staffGroup.Title))
			{
				parameters.AppendRequestData("title", staffGroup.Title);
			}

			parameters.AppendRequestData("isadmin", Convert.ToInt32(staffGroup.IsAdmin));

			return parameters;
		}

		#endregion
	}
}
