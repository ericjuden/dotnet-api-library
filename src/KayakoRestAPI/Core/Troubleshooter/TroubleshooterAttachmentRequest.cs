using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Troubleshooter
{
	public class TroubleshooterAttachmentRequest : RequestBaseObject
	{
		[RequiredField]
		[ResponseProperty("TroubleshooterStepId")]
		public int TroubleshooterStepId { get; set; }

		[RequiredField]
		[ResponseProperty("FileName")]
		public string FileName { get; set; }

		[RequiredField]
		[ResponseProperty("Contents")]
		public string Contents { get; set; }

		public static TroubleshooterAttachmentRequest FromResponseData(TroubleshooterAttachment responseData)
		{
			return FromResponseType<TroubleshooterAttachment, TroubleshooterAttachmentRequest>(responseData);
		}

		public static TroubleshooterAttachment ToResponseData(TroubleshooterAttachmentRequest requestData)
		{
			return ToResponseType<TroubleshooterAttachmentRequest, TroubleshooterAttachment>(requestData);
		}
	}
}
