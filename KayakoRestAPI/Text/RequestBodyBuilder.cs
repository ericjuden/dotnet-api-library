using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.Text
{
    internal class RequestBodyBuilder
    {
        private StringBuilder _sb;

        internal RequestBodyBuilder()
        {
            _sb = new StringBuilder();
        }

        internal RequestBodyBuilder(string value)
        {
            _sb = new StringBuilder(value);
        }

        internal void AppendRequestData(string key, object value)
        {
            if (!String.IsNullOrEmpty(_sb.ToString()))
            {
                _sb.Append("&");
            }

            _sb.AppendFormat("{0}={1}", key, value);
        }

        internal void AppendRequestDataArray<T>(string key, IEnumerable<T> values)
        {
            foreach(object value in values)
            {
                if (!String.IsNullOrEmpty(_sb.ToString()))
                {
                    _sb.Append("&");
                }

                _sb.AppendFormat("{0}={1}", key, value);
            }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
