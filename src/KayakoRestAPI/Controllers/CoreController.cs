using System;
using System.Net;
using KayakoRestApi.Core.Test;
using KayakoRestApi.Net;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Controllers
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
			return Connector.ExecuteGet<TestData>(ApiBaseMethods.CoreTest);
		}

		/// <summary>
		/// Test a GET request
		/// </summary>
		public string GetTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return Connector.ExecuteGet<TestData>(apiMethod);
		}

		/// <summary>
		/// Test a POST request
		/// </summary>
		public string PostTest()
		{
			return Connector.ExecutePost<TestData>(ApiBaseMethods.CoreTest, "");
		}

		/// <summary>
		/// Test a PUT request
		/// </summary>
		public string PutTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return Connector.ExecutePut<TestData>(apiMethod, "");
		}

		/// <summary>
		/// Test a DELETE request
		/// </summary>
		public bool DeleteTest(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);

			return Connector.ExecuteDelete(apiMethod);
		}

		#endregion
	}
}
