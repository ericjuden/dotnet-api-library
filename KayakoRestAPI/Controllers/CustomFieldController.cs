using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using KayakoRestApi.Core.CustomFields;

namespace KayakoRestApi.Controllers
{
	public sealed class CustomFieldController : BaseController
	{
		internal CustomFieldController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
		}

		#region Api Methods

		/// <summary>
		/// Retrieve a list of a custom fields.
		/// </summary>
		public CustomFieldCollection GetCustomFields()
		{
			string apiMethod = "/Base/CustomField";

			return _connector.ExecuteGet<CustomFieldCollection>(apiMethod);
		}

		/// <summary>
		/// Retrieve the list of custom field options
		/// </summary>
		public CustomFieldOptionCollection GetCustomFieldOptions(int customFieldId)
		{
			string apiMethod = String.Format("/Base/CustomField/ListOptions/{0}", customFieldId);

			return _connector.ExecuteGet<CustomFieldOptionCollection>(apiMethod);
		}

		#endregion
	}
}
