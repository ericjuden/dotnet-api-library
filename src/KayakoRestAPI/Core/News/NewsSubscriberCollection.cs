using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a list of news subscriber within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsSubscriber#REST-NewsSubscriber-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("newssubscribers")]
	public class NewsSubscriberCollection : List<NewsSubscriber>
	{
		/// <summary>
        /// Create a list of news categories.
        /// </summary>
		public NewsSubscriberCollection()
        {
        }
	}
}
