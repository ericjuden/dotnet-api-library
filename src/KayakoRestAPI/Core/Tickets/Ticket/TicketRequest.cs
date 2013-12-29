using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Tickets
{
    public class TicketRequest : RequestBaseObject
    {
		/// <summary>
		/// The unique numeric identifier of the ticket
		/// </summary>
		[RequiredField(RequestTypes.Update)]
		public int Id { get; set; }

        /// <summary>
        /// The subject of the ticket
        /// </summary>
        [RequiredField(RequestTypes.Create)]
        [ResponseProperty("Subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The full name of the ticket creator
        /// </summary>
        [RequiredField(RequestTypes.Create)]
        [ResponseProperty("FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// The email address of the ticket creator
        /// </summary>
        [RequiredField(RequestTypes.Create)]
        [ResponseProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// The contents of the first ticket post
        /// </summary>
        [RequiredField(RequestTypes.Create)]
        public string Contents { get; set; }

        /// <summary>
        /// The Id of the department the ticket is associated with
        /// </summary>
        [ResponseProperty("DepartmentId")]
        [RequiredField(RequestTypes.Create)]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// The Id representing the status of the ticket
        /// </summary>
        [ResponseProperty("StatusId")]
        [RequiredField(RequestTypes.Create)]
        public int? TicketStatusId { get; set; }

        /// <summary>
        /// The Id representing the priority of the ticket
        /// </summary>
        [ResponseProperty("PriorityId")]
        [RequiredField(RequestTypes.Create)]
        public int? TicketPriorityId { get; set; }

        /// <summary>
        /// The Id representing the type of ticket
        /// </summary>
        [ResponseProperty("TypeId")]
        [RequiredField(RequestTypes.Create)]
        public int? TicketTypeId { get; set; }

        /// <summary>
        /// If dispatched as "1" then the User Id is looked up based on the email address, if none is found, the system ends up creating a new user based on the information supplied.
        /// </summary>
        [EitherFieldAttribute("UserId|StaffId")]
        public bool? AutoUserId { get; set; }

        /// <summary>
        /// The Id of user who created the ticket
        /// </summary>
        [ResponseProperty("UserId")]
        [EitherFieldAttribute("AutoUserId|StaffId")]
        public int? StaffId { get; set; }

        /// <summary>
        /// The Id of staff user who created the ticket
        /// </summary>
        [EitherFieldAttribute("AutoUserId|StaffId")]
        public int? UserId { get; set; }

        /// <summary>
        /// The Id of the staff member who owns the ticket
        /// </summary>
        [OptionalField]
        [ResponseProperty("OwnerStaffId")]
        public int? OwnerStaffId { get; set; }

		[OptionalField]
		[ResponseProperty("TemplateGroupId")]
		public int? TemplateGroupId { get; set; }

		[OptionalField]
		[ResponseProperty("TemplateGroupName")]
		public string TemplateGroupName { get; set; }

        /// <summary>
        /// The Id of the creation type
        /// </summary>
        [OptionalField]
        public Constants.TicketCreationType? CreationType { get; set; }

        public static TicketRequest FromResponseData(Ticket responseData)
        {
            return TicketRequest.FromResponseType<Ticket, TicketRequest>(responseData);
        }

        public static Ticket ToResponseData(TicketRequest requestData)
        {
            return TicketRequest.ToResponseType<TicketRequest, Ticket>(requestData);
        }
    }
}
