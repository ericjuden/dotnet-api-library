using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a list of news categories within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsCategory#REST-NewsCategory-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("newscategories")]
	public class NewsCategoryCollection : List<NewsCategory>
	{
		/// <summary>
        /// Create a list of news categories.
        /// </summary>
		public NewsCategoryCollection()
        {
        }
	}
}
