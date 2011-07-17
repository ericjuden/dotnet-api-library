using System;
using System.Collections.Generic;
using System.Text;
using KayakoRestApi.Net;
using System.Security.Cryptography;

namespace KayakoRestApi.Controllers
{
    public class BaseController
    {
        internal KayakoApiRequest _connector { get; set;}

        internal BaseController(string apiKey, string secretKey, string apiUrl)
        {
            _connector = new KayakoApiRequest(apiKey, secretKey, apiUrl);
        }
    }
}
