using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a list of news item comments within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsComment#REST-NewsComment-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("newsitemcomments")]
	public class NewsItemCommentCollection : List<NewsItemComment>
	{
		/// <summary>
        /// Create a list of news item comments.
        /// </summary>
		public NewsItemCommentCollection()
        {
        }
	}
}
