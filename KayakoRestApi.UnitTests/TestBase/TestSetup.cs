using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KayakoRestApi;

namespace KayakoRestApi.UnitTests
{
	public static class TestSetup
	{
		public static string ApiKey
		{
			get
			{
				return "d00bb661-765a-cbf4-1daf-168188cfc544";
			}
		}

		public static string SecretKey
		{
			get
			{
				return "YjdiMjI1N2UtNDg4NS1kOGI0LWMxZmItYzFmMTZjMjAwYTIxNGJhMTBiZTYtNjE1NS05NTA0LWQxNjMtYmExOGEyMzcyYjhl";
			}
		}

		public static string ApiUrl
		{
			get
			{
				return "http://contracting.kayako.com/api/index.php";
			}
		}

		public static KayakoClient KayakoApiService
		{
			get
			{
				return new KayakoClient(ApiKey, SecretKey, ApiUrl);
			}
		}
	}
}
