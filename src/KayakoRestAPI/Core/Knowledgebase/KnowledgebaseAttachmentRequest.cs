using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Knowledgebase
{
	public class KnowledgebaseAttachmentRequest : RequestBaseObject
	{
		[RequiredField]
		[ResponseProperty("KnowledgebaseArticleId")]
		public int KnowledgebaseArticleId { get; set; }

		[RequiredField]
		[ResponseProperty("FileName")]
		public string FileName { get; set; }

		[RequiredField]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		public static KnowledgebaseAttachmentRequest FromResponseData(KnowledgebaseAttachment responseData)
		{
			return FromResponseType<KnowledgebaseAttachment, KnowledgebaseAttachmentRequest>(responseData);
		}

		public static KnowledgebaseAttachment ToResponseData(KnowledgebaseAttachmentRequest requestData)
		{
			return ToResponseType<KnowledgebaseAttachmentRequest, KnowledgebaseAttachment>(requestData);
		}
	}
}
