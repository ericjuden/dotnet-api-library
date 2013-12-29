using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.News
{
	/// <summary>
	/// Represents a news category
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+NewsCategory
	/// </remarks>
	/// </summary>
	[XmlType("newscategory")]
	public class NewsCategory
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("newsitemcount")]
		public int NewsItemCount { get; set; }

		[XmlElement("visibilitytype")]
		public NewsCategoryVisibilityType VisibilityType { get; set; }
	}
}
