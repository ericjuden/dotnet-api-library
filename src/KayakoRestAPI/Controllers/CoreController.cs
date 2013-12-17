using System;
using System.Collections.Generic;
using System.Text;
using KayakoRestApi.Controllers;
using System.Net;
using KayakoRestApi.Net;
using KayakoRestApi.Data;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Test
{
	public sealed class CoreController : BaseController
	{
		internal CoreController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
		}

		internal CoreController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
			: base(apiKey, secretKey, apiUrl, proxy, requestType)
		{
		}

		#region Api Methods

		/// <summary>
		/// Test a GET list request
		/// </summary>
		public string GetListTest()
		{
			return _connector.ExecuteGet<TestData>(ApiBaseMethods.CoreTest);
		}

		/// <summary>
		/// Test a GET request
		/// </summary>
		public string GetTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return _connector.ExecuteGet<TestData>(apiMethod);
		}

		/// <summary>
		/// Test a POST request
		/// </summary>
		public string PostTest()
		{
			return _connector.ExecutePost<TestData>(ApiBaseMethods.CoreTest, "");
		}

		/// <summary>
		/// Test a PUT request
		/// </summary>
		public string PutTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return _connector.ExecutePut<TestData>(apiMethod, "");
		}

		/// <summary>
		/// Test a DELETE request
		/// </summary>
		public bool DeleteTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion
	}
}
