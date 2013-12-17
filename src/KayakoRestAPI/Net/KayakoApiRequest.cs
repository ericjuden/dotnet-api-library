using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using KayakoRestApi.Core;
using System.Web;
using KayakoRestApi.Net;
using KayakoRestApi.Core.Test;

namespace KayakoRestApi.Net
{
    [Serializable]
    internal class KayakoApiRequest
    {
		private ApiRequestType _requestType;
        private string _apiKey;
        private string _secretKey;
        private string _apiUrl;
		private IWebProxy _proxy;
        private string _signature;
        private string _encodedSignature;
        private string _salt;
        
        internal KayakoApiRequest(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
            _apiUrl = apiUrl;
			_proxy = proxy;
			_requestType = requestType;

            ComputeSaltAndSignature();
        }

        private void ComputeSaltAndSignature()
        {
            // Generate a new globally unique identifier for the salt
            string salt = Guid.NewGuid().ToString();
            _salt = salt;

            // Initialize the keyed hash object using the secret key as the key
            HMACSHA256 hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));

            // Computes the signature by hashing the salt with the secret key as the key
            byte[] signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(salt));

            // Base 64 Encode
            _signature = Convert.ToBase64String(signature);

            // URLEncode
            _encodedSignature = HttpUtility.UrlEncode(_signature);
        }

        #region Api Connection Methods

        #region Execute Put/Post/Delete/Get

        /// <summary>
        /// Generic method for extracting data via PUSH.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl">URL to request data.</param>
        /// <param name="parameters">Parameters to post.</param>
        /// <returns>TTarget result of the extraction</returns>
        internal TTarget ExecutePut<TTarget>(string apiMethod, string parameters) where TTarget : class, new()
        {
            return ExecuteCall<TTarget>(apiMethod, parameters, HttpMethod.PUT);
        }

        /// <summary>
        /// Generic method for extracting data via POST.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="apiMethod">URL to request data.</param>
        /// <param name="parameters">Parameters to post.</param>
        /// <returns>TTarget result of the extraction</returns>
        internal TTarget ExecutePost<TTarget>(string apiMethod, string parameters) where TTarget : class, new()
        {
            return ExecuteCall<TTarget>(apiMethod, parameters, HttpMethod.POST);
        }

        /// <summary>
        /// Generic method for extracting data.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl">URL to request data.</param>
        /// <returns>TTarget result of the extraction</returns>
        internal TTarget ExecuteGet<TTarget>(string apiMethod) where TTarget : class, new()
        {
            return ExecuteCall<TTarget>(apiMethod, "", HttpMethod.GET);
        }

        #endregion

		private string GetRequestUrl(string apiMethod)
		{
			string requestUrl = "";

			if (_requestType == ApiRequestType.QueryString)
			{
				requestUrl = String.Format("{0}?e={1}", _apiUrl, apiMethod);
			}
			else
			{
				requestUrl = String.Format("{0}{1}", _apiUrl, apiMethod);
			}

			return requestUrl;
		}

        /// <summary>
        /// Generic method for extracting data via DELETE.
        /// </summary>
        /// <param name="apiMethod">URL to request data</param>
        /// <returns>The success of the delete</returns>
        internal bool ExecuteDelete(string apiMethod)
        {
			string requestUrl = GetRequestUrl(apiMethod);
			requestUrl = AppendSecurityCredentials(requestUrl, HttpMethod.DELETE);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
			request.Method = "DELETE";

			if (_proxy != null)
			{
				request.Proxy = _proxy;
			}

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                string s = sr.ReadToEnd();

                throw new InvalidOperationException(s, ex);
            }

            return false;
        }

		private string AppendSecurityCredentials(string inputString, HttpMethod httpMethod)
		{
			string signature = _signature;

			if (httpMethod == HttpMethod.GET)
			{
				signature = _encodedSignature;
			}

			return String.Format("{0}&apikey={1}&salt={2}&signature={3}", inputString, _apiKey, _salt, signature);
		}

        #region Execute Requests to Api

        private TTarget ExecuteCall<TTarget>(string apiMethod, string parameters, HttpMethod httpMethod) where TTarget : class, new()
        {
			string requestUrl = GetRequestUrl(apiMethod);
			
            if (httpMethod == HttpMethod.GET)
            {
                requestUrl = AppendSecurityCredentials(requestUrl, httpMethod);
            }

            WebRequest request = WebRequest.Create(requestUrl);
            request.Method = httpMethod.ToString();

			if (_proxy != null)
			{
				request.Proxy = _proxy;
			}

            if (httpMethod != HttpMethod.GET)
            {
                request.ContentType = "application/x-www-form-urlencoded";

				parameters = AppendSecurityCredentials(parameters, httpMethod);

                byte[] bytes = Encoding.UTF8.GetBytes(parameters);

                request.ContentLength = bytes.Length;

                using (Stream os = request.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                }
            }

            return (TTarget)ProcessWebRequest<TTarget>(request);
        }

        private TTarget ProcessWebRequest<TTarget>(WebRequest request) where TTarget : class, new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TTarget));
                using (HttpWebResponse webResponse = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string streamContents = sr.ReadToEnd();

						if (typeof(TTarget) == typeof(TestData))
						{
							return (TTarget)(object)new TestData(streamContents);
						}
						else
						{
							using (StringReader serializerStream = new StringReader(streamContents))
							{
								TTarget responseData = (TTarget)serializer.Deserialize(serializerStream);
								return responseData;
							}
						}
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string streamContents = reader.ReadToEnd();

                    throw new InvalidOperationException(streamContents, ex.InnerException);
                }
            }
        }

        #endregion

        #endregion
    }
}
