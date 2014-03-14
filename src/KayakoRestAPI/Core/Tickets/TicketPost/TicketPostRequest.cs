using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Tickets
{
    public class TicketPostRequest : RequestBaseObject
    {
        /// <summary>
        /// The unique numeric identifier of the ticket.
        /// </summary>
        [RequiredField]
        public int TicketId { get; set; }

        /// <summary>
        /// The ticket post subject 
        /// </summary>
        [RequiredField]
        public string Subject { get; set; }

        /// <summary>
        /// The ticket post contents 
        /// </summary>
        [RequiredField]
        public string Contents { get; set; }

        /// <summary>
        /// The User Id, if the ticket post is to be created as a user
        /// </summary>
        [EitherField("StaffId")]
        public int? UserId { get; set; }

        /// <summary>
        /// The Staff Id, if the ticket post is to be created as a staff 
        /// </summary>
        [EitherField("UserId")]
        public int? StaffId { get; set; }

		/// <summary>
		/// IsPrivate, if the ticket post is for staff to view only
		/// </summary>
		[RequiredField]
		public bool IsPrivate { get; set; }

        public static TicketPostRequest FromResponseData(TicketPost responseData)
        {
            return TicketPostRequest.FromResponseType<TicketPost, TicketPostRequest>(responseData);
        }

        public static TicketPost ToResponseData(TicketPostRequest requestData)
        {
            return TicketPostRequest.ToResponseType<TicketPostRequest, TicketPost>(requestData);
        }
    }
}
