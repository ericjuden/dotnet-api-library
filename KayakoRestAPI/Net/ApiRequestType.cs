using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.Net
{
	public enum ApiRequestType
	{
		/// <summary>
		/// Interact with the API with the whole request as the URL
		/// <example>e.g. https://example.domain.com/api/Module/Controller/Action&amp;parameterA=valueA&amp;parameterB=valueB&amp;parameterC=valueC</example>
		/// </summary>
		Url,

		/// <summary>
		/// Interact with the API with the method request as a querystring (e=....)
		/// <example>e.g. https://example.domain.com/api/?e=/Module/Controller/Action&amp;parameterA=valueA&amp;parameterB=valueB&amp;parameterC=valueC</example>
		/// </summary>
		QueryString
	}
}
