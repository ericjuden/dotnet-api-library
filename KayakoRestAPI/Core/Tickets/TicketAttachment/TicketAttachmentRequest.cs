using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Tickets
{
    public class TicketAttachmentRequest : RequestBaseObject
    {
        /// <summary>
        /// The unique numeric identifier of the ticket
        /// </summary>
        [RequiredField]
        [ResponseProperty("TicketId")]
        public int TicketId { get; set; }

        /// <summary>
        /// The unique numeric identifier of the ticket post
        /// </summary>
        [RequiredField]
        [ResponseProperty("TicketPostId")]
        public int TicketPostId { get; set; }

        /// <summary>
        /// The file name for the attachment 
        /// </summary>
        [RequiredField]
        [ResponseProperty("FileName")]
        public string FileName { get; set; }

        /// <summary>
        /// The BASE64 encoded attachment contents
        /// </summary>
        [RequiredField]
        [ResponseProperty("Contents")]
        public string Contents { get; set; }

        public static TicketAttachmentRequest FromResponseData(TicketAttachment responseData)
        {
            return TicketAttachmentRequest.FromResponseType<TicketAttachment, TicketAttachmentRequest>(responseData);
        }

        public static TicketAttachment ToResponseData(TicketAttachmentRequest requestData)
        {
            return TicketAttachmentRequest.ToResponseType<TicketAttachmentRequest, TicketAttachment>(requestData);
        }
    }
}
