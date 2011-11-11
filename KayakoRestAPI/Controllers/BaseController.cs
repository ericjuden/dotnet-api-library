using System;
using System.Collections.Generic;
using System.Text;
using KayakoRestApi.Net;
using System.Security.Cryptography;
using System.Net;

namespace KayakoRestApi.Controllers
{
    public class BaseController
    {
        internal KayakoApiRequest _connector { get; set;}

        internal BaseController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
        {
            _connector = new KayakoApiRequest(apiKey, secretKey, apiUrl, proxy);
        }
    }
}
