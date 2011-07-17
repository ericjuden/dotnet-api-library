using System;
using KayakoRestApi.Core.Departments;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.Text;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Controllers
{
	/// <summary>
	/// Provides access to Deparment API Methods
	/// </summary>
    public sealed class DepartmentController : BaseController
	{
        internal DepartmentController(string apiKey, string secretKey, string apiUrl)
            : base(apiKey, secretKey, apiUrl)
        {
        }

        #region Api Methods

        /// <summary>
        /// Retrieve a list of all departments and sub-departments in the help desk.
        /// </summary>
		public DepartmentCollection GetDepartments()
		{
			string apiMethod = "/Base/Department/";

			return _connector.ExecuteGet<DepartmentCollection>(apiMethod);
		}

        /// <summary>
        /// Retrieve the department identified by its internal identifier
        /// </summary>
        /// <param name="id">The unique numeric identifer of the department to retrieve</param>
        /// <returns></returns>
		public Department GetDepartment(int id)
		{
			string apiMethod = String.Format("/Base/Department/{0}", id);

			DepartmentCollection depts = _connector.ExecuteGet<DepartmentCollection>(apiMethod);

			if(depts != null && depts.Count > 0)
			{
				return depts[0];
			}

			return null;
		}

        /// <summary>
        /// Update the department identified by its internal identifier
        /// </summary>
        /// <param name="dept">Data to update the department. Department Id and Title must be supplied</param>
        /// <returns>Department data representing the updated department</returns>
		public Department UpdateDepartment(DepartmentRequest dept)
		{
			string apiMethod = String.Format("/Base/Department/{0}", dept.Id);

            RequestBodyBuilder parameters = PopulateRequestParameters(dept, RequestTypes.Update);

			DepartmentCollection depts = _connector.ExecutePut<DepartmentCollection>(apiMethod, parameters.ToString());

			if (depts != null && depts.Count > 0)
			{
				return depts[0];
			}

			return null;
		}

        /// <summary>
        /// Creates a new department
        /// </summary>
        /// <param name="dept">Department data to create a new department with. Department Title, Module and Type must be supplied</param>
        /// <returns>Department data representing the department created</returns>
		public Department CreateDepartment(DepartmentRequest dept)
		{
			string apiMethod = "/Base/Department/";

            RequestBodyBuilder parameters = PopulateRequestParameters(dept, RequestTypes.Create);

			DepartmentCollection depts = _connector.ExecutePost<DepartmentCollection>(apiMethod, parameters.ToString());

			if (depts != null && depts.Count > 0)
			{
				return depts[0];
			}

			return null;
		}

        /// <summary>
        /// Delete the Department identified by its internal identifier
        /// </summary>
        /// <param name="id">The unique numeric identifer of the department to delete</param>
        /// <returns>The success of the deletion</returns>
		public bool DeleteDepartment(int id)
		{
            string apiMethod = String.Format("/Base/Department/{0}", id);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		private static RequestBodyBuilder PopulateRequestParameters(DepartmentRequest dept, RequestTypes requestType)
        {
			dept.EnsureValidData(requestType);

            RequestBodyBuilder parameters = new RequestBodyBuilder();

            if (!String.IsNullOrEmpty(dept.Title))
            {
                parameters.AppendRequestData("title", dept.Title);
            }

			parameters.AppendRequestData("type", EnumUtility.ToApiString(dept.Type));

			if (requestType == RequestTypes.Create)
			{
				parameters.AppendRequestData("module", EnumUtility.ToApiString(dept.Module));
			}

            if (dept.DisplayOrder > 0)
            {
                parameters.AppendRequestData("displayorder", dept.DisplayOrder);
            }

            if (dept.ParentDepartmentId > 0)
            {
                parameters.AppendRequestData("parentdepartmentid", dept.ParentDepartmentId);
            }

            if(dept.UserVisibilityCustom)
            {
                parameters.AppendRequestData("uservisibilitycustom", 1);
            }
            else
            {
                parameters.AppendRequestData("uservisibilitycustom", 0);
            }

            if (dept.UserGroups != null && dept.UserGroups.Count > 0)
            {
                parameters.AppendRequestDataArray<int>("usergroupid[]", dept.UserGroups);
            }

            return parameters;
        }
	}
}
