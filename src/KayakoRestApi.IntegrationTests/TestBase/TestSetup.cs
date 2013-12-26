using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KayakoRestApi;
using KayakoRestApi.Net;

namespace KayakoRestApi.IntegrationTests
{
	public static class TestSetup
	{
		public static string ApiKey
		{
			get
			{
                return ReadTextFile("TestBase/ApiKey.txt");
			}
		}

		public static string SecretKey
		{
			get
			{
                return ReadTextFile("TestBase/SecretKey.txt");
			}
		}

		public static string ApiUrl
		{
			get
			{
				return ReadTextFile("TestBase/ApiUrl.txt");
			}
		}

		public static KayakoClient KayakoApiService
		{
			get
			{
				return new KayakoClient(ApiKey, SecretKey, ApiUrl, ApiRequestType.Url);
			}
		}

        private static string ReadTextFile(string textFilePath)
        {
            using(var fileStream = File.OpenRead(textFilePath))
            {
                using(var streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
	}
}
