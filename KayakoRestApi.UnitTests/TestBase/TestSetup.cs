using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KayakoRestApi;
using KayakoRestApi.Net;

namespace KayakoRestApi.UnitTests
{
	public static class TestSetup
	{
		public static string ApiKey
		{
			get
			{
				return "94364841-7542-9e94-d59c-f420554d9a9d";
			}
		}

		public static string SecretKey
		{
			get
			{
				return "ZjM5OTAzN2YtYjcxNy1jZWQ0LTIxMGEtNGViNzQzNTNhZjAxY2Y3OGVkMmUtN2RmNi05MTQ0LTI5YjctYmM0M2E1OWNlMmU5";
			}
		}

		public static string ApiUrl
		{
			get
			{
				return "http://apiupdates.kayako.com/api/";
			}
		}

		public static KayakoClient KayakoApiService
		{
			get
			{
				return new KayakoClient(ApiKey, SecretKey, ApiUrl, ApiRequestType.Url);
			}
		}
	}
}
