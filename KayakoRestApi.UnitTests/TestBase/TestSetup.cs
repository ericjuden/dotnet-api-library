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
				return "2ad89dba-fbf3-dbd4-7985-49d263d6e5b8";
			}
		}

		public static string SecretKey
		{
			get
			{
				return "YWEzOTk1ODctZjdiNy01YTc0LWExYjItNTY4YmM5MjZlNWE2YzNhM2FmMGEtNTI3MC1iMDM0LWYxNTAtMjg4Nzg5OThiM2Ri";
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
