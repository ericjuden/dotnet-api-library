using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Knowledgebase
{
	public class KnowledgebaseCommentRequest : RequestBaseObject
	{
		[RequiredField]
		[ResponseProperty("KnowledgebaseArticleId")]
		public int KnowledgebaseArticleId { get; set; }

		[RequiredField]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		[RequiredField]
		[ResponseProperty("CreatorType")]
		public KnowledgebaseCommentCreatorType CreatorType { get; set; }
		
		[EitherField("FullName")]
		[ResponseProperty("CreatorId")]
		public int? CreatorId { get; set; }

		[EitherField("CreatorId")]
		[ResponseProperty("FullName")]
		public string FullName { get; set; }

		[OptionalField]
		[ResponseProperty("Email")]
		public string Email { get; set; }

		[OptionalField]
		[ResponseProperty("ParentCommentId")]
		public int? ParentCommentId { get; set; }

		public static KnowledgebaseCommentRequest FromResponseData(KnowledgebaseComment responseData)
		{
			return FromResponseType<KnowledgebaseComment, KnowledgebaseCommentRequest>(responseData);
		}

		public static KnowledgebaseComment ToResponseData(KnowledgebaseCommentRequest requestData)
		{
			return ToResponseType<KnowledgebaseCommentRequest, KnowledgebaseComment>(requestData);
		}
	}
}
