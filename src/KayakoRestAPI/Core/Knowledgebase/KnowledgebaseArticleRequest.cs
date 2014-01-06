using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Knowledgebase
{
	public class KnowledgebaseArticleRequest : RequestBaseObject
	{
		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("Id")]
		public int Id { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Subject")]
		public string Subject { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		[RequiredField(RequestTypes.Create)]
		[ResponseProperty("CreatorId")]
		public int? CreatorId { get; set; }

		[OptionalField]
		[ResponseProperty("ArticleStatus")]
		public KnowledgebaseArticleStatus? ArticleStatus { get; set; }

		[OptionalField]
		[ResponseProperty("IsFeatured")]
		public bool? IsFeatured { get; set; }

		[OptionalField]
		[ResponseProperty("AllowComments")]
		public bool? AllowComments { get; set; }

		[OptionalField]
		[ResponseProperty("CategoryId")]
		public int[] CategoryIds { get; set; }

		[RequiredField(RequestTypes.Update)]
		[ResponseProperty("EditedStaffId")]
		public int? EditedStaffId { get; set; }

		public static KnowledgebaseArticleRequest FromResponseData(KnowledgebaseArticle responseData)
		{
			return FromResponseType<KnowledgebaseArticle, KnowledgebaseArticleRequest>(responseData);
		}

		public static KnowledgebaseArticle ToResponseData(KnowledgebaseArticleRequest requestData)
		{
			return ToResponseType<KnowledgebaseArticleRequest, KnowledgebaseArticle>(requestData);
		}
	}
}
