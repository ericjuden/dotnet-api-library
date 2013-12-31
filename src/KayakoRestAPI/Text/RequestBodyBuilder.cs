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

		internal void AppendRequestDataNonEmptyString(string key, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}

			AppendRequestData(key, value);
		}

		internal void AppendRequestDataNonNegativeInt(string key, int value)
		{
			if (value <= 0)
			{
				return;
			}

			AppendRequestData(key, value);
		}

		internal void AppendRequestDataBool(string key, bool? value)
		{
			if (value == null)
			{
				return;
			}

			AppendRequestDataBool(key, value.Value);
		}

		internal void AppendRequestDataBool(string key, bool value)
		{
			int requestValue = value ? 1 : 0;

			AppendRequestData(key, requestValue);
		}

		internal void AppendRequestDataArrayCommaSeparated<T>(string key, IEnumerable<T> values)
		{
			if (values == null)
			{
				return;
			}

			StringBuilder sb = new StringBuilder();
			foreach (object value in values)
			{
				if (!string.IsNullOrEmpty(sb.ToString()))
				{
					sb.Append(",");
				}

				sb.Append(value.ToString());
			}

			if (!string.IsNullOrEmpty(sb.ToString()))
			{
				AppendRequestData(key, sb.ToString());
			}
		}

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
