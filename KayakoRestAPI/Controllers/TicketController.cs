using System;
using System.Text;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Data;
using KayakoRestApi.Net;
using KayakoRestApi.Text;
using KayakoRestApi.RequestBase;
using System.Net;

namespace KayakoRestApi.Controllers
{
	/// <summary>
	/// Provides access to Ticket API Methods
	/// </summary>
    public sealed class TicketController : BaseController
    {
        internal TicketController(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
            : base(apiKey, secretKey, apiUrl, proxy)
        {
        }

        #region Ticket Api Methods

        /// <summary>
        /// Retrieve a filtered list of tickets from the help desk.
        /// </summary>
        /// <param name="departmentIds">Filter the tickets by the specified department id(s)</param>
        public TicketCollection GetTickets(int[] departmentIds)
        {
            return GetTickets(departmentIds, null, null, null);
        }

        /// <summary>
        /// Retrieve a filtered list of tickets from the help desk.
        /// </summary>
        /// <param name="departmentIds">Filter the tickets by the specified department id(s)</param>
        /// <param name="ticketStatusIds">Filter the tickets by the specified ticket status id(s). Pass null or empty array for no filter</param>
        /// <param name="ownerStaffIds">Filter the tickets by the specified owner staff id(s). Pass null or empty array for no filter</param>
        /// <param name="userIds">Filter the tickets by the specified user id(s). Pass null or empty array for no filter</param>
        /// <returns></returns>
        public TicketCollection GetTickets(int[] departmentIds, int[] ticketStatusIds, int[] ownerStaffIds, int[] userIds)
        {
            string deptIdParameter = JoinIntParameters(departmentIds);
            string ticketStatusIdParameter = JoinIntParameters(ticketStatusIds);
            string ownerStaffIdParameter = JoinIntParameters(ownerStaffIds);
            string userIdParameter = JoinIntParameters(userIds);

			string apiMethod = String.Format("/Tickets/Ticket/ListAll/{0}/{1}/{2}/{3}", 
                deptIdParameter,
                ticketStatusIdParameter,
                ownerStaffIdParameter,
                userIdParameter);

            TicketCollection tickets = _connector.ExecuteGet<TicketCollection>(apiMethod);

            return tickets;
        }

        /// <summary>
        /// Retrieve the ticket identified by <paramref name="ticketId"/>.
        /// </summary>
        /// <param name="ticketId">The unique numeric identifier of the ticket</param>
        /// <returns>The ticket!</returns>
        public Ticket GetTicket(int ticketId)
        {
			return GetTicketRequest(ticketId.ToString());
        }

		/// <summary>
		/// Retrieve the ticket identified by <paramref name="ticketId"/>.
		/// </summary>
		/// <param name="ticketId">The ticket mask Id (e.g. ABC-123-4567).</param>
		/// <returns>The ticket!</returns>
		public Ticket GetTicket(string displayId)
		{
			return GetTicketRequest(displayId);
		}

		private Ticket GetTicketRequest(string id)
		{
			string apiMethod = String.Format("/Tickets/Ticket/{0}/", id);

			TicketCollection tickets = _connector.ExecuteGet<TicketCollection>(apiMethod);

			if (tickets.Count > 0)
			{
				return tickets[0];
			}

			return null;
		}

        public Ticket CreateTicket(TicketRequest ticketRequest)
        {
			string apiMethod = "/Tickets/Ticket";

            ticketRequest.EnsureValidData(RequestTypes.Create);

            RequestBodyBuilder parameters = new RequestBodyBuilder();

            parameters.AppendRequestData("subject", ticketRequest.Subject);
            parameters.AppendRequestData("fullname", ticketRequest.FullName);
            parameters.AppendRequestData("email", ticketRequest.Email);
            parameters.AppendRequestData("contents", ticketRequest.Contents);
            parameters.AppendRequestData("departmentid", ticketRequest.DepartmentId);
            parameters.AppendRequestData("ticketstatusid", ticketRequest.TicketStatusId);
            parameters.AppendRequestData("ticketpriorityid", ticketRequest.TicketPriorityId);
            parameters.AppendRequestData("tickettypeid", ticketRequest.TicketTypeId);

            if (ticketRequest.AutoUserId != null)
            {
                parameters.AppendRequestData("autouserid", Convert.ToInt32(ticketRequest.AutoUserId));
            }
            else if (ticketRequest.UserId != null)
            {
                parameters.AppendRequestData("userid", ticketRequest.UserId);
            }
            else if (ticketRequest.StaffId != null)
            {
                parameters.AppendRequestData("staffid", ticketRequest.StaffId);
            }

            if (ticketRequest.OwnerStaffId != null)
            {
                parameters.AppendRequestData("ownerstaffid", ticketRequest.OwnerStaffId);
            }

			if (ticketRequest.CreationType != null)
			{
				parameters.AppendRequestData("type", EnumUtility.ToApiString(ticketRequest.CreationType));
			}

            TicketCollection tickets = _connector.ExecutePost<TicketCollection>(apiMethod, parameters.ToString());

            if (tickets.Count > 0)
            {
                return tickets[0];
            }

            return null;
        }

		public Ticket UpdateTicket(TicketRequest request)
        {
			request.EnsureValidData(RequestTypes.Update);

            RequestBodyBuilder parameters = new RequestBodyBuilder();

			if (!String.IsNullOrEmpty(request.Subject))
            {
				parameters.AppendRequestData("subject", request.Subject);
            }

			if (!String.IsNullOrEmpty(request.FullName))
            {
				parameters.AppendRequestData("fullname", request.FullName);
            }

			if (!String.IsNullOrEmpty(request.Email))
            {
				parameters.AppendRequestData("email", request.Email);
            }

			if (request.DepartmentId != null)
            {
				parameters.AppendRequestData("departmentid", request.DepartmentId);
            }

			if (request.TicketStatusId != null)
            {
				parameters.AppendRequestData("ticketstatusid", request.TicketStatusId);
            }

			if (request.TicketPriorityId != null)
            {
				parameters.AppendRequestData("ticketpriorityid", request.TicketPriorityId);
            }

			if (request.TicketTypeId != null)
            {
				parameters.AppendRequestData("tickettypeid", request.TicketTypeId);
            }

			if (request.OwnerStaffId != null)
            {
				parameters.AppendRequestData("ownerstaffid", request.OwnerStaffId);
            }

			if (request.UserId != null)
            {
				parameters.AppendRequestData("userid", request.UserId);
            }

			string apiMethod = String.Format("/Tickets/Ticket/{0}", request.Id);

            TicketCollection tickets = _connector.ExecutePut<TicketCollection>(apiMethod, parameters.ToString());

            if (tickets != null && tickets.Count > 0)
            {
                return tickets[0];
            }

            return null;
        }

        public bool DeleteTicket(int ticketId)
        {
			string apiMethod = String.Format("/Tickets/Ticket/{0}", ticketId);

            return _connector.ExecuteDelete(apiMethod);
        }

        #endregion

        #region Ticket Count Api Methods

        /// <summary>
        /// Retrieve a list of counts for different departments, ticket status'es, owners etc.
        /// </summary>
        public TicketCount GetTicketCounts()
        {
            string apiMethod = "/Tickets/TicketCount/";
            
            TicketCount ticketCount = _connector.ExecuteGet<TicketCount>(apiMethod);

            return ticketCount;
        }

        #endregion

		#region Ticket Priority Methods

		/// <summary>
		/// Retrieve a list of all ticket statues in the help desk.
		/// </summary>
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus
		/// </remarks>
		/// <returns>The ticket statuses</returns>
		public TicketPriorityCollection GetTicketPriorities()
		{
			string apiMethod = "/Tickets/TicketPriority/";

			return _connector.ExecuteGet<TicketPriorityCollection>(apiMethod);
		}

		/// <summary>
		/// Retrieve the ticket status identified by <paramref name="priorityId"/>.
		/// </summary>
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus#REST-TicketStatus-GET%2FTickets%2FTicketStatus%2F%24id%24
		/// </remarks>
		/// <param name="priorityId">The unique numeric identifier of the ticket status.</param>
		/// <returns>The ticket status</returns>
		public TicketPriority GetTicketPriority(int priorityId)
		{
			string apiMethod = String.Format("/Tickets/TicketPriority/{0}", priorityId);

			TicketPriorityCollection priorities = _connector.ExecuteGet<TicketPriorityCollection>(apiMethod);

			if (priorities != null && priorities.Count > 0)
			{
				return priorities[0];
			}
			return null;
		}

		#endregion

        #region Ticket Search Methods

        /// <summary>
        /// Run a search on tickets. You can combine the search factors to make the span multiple areas.
        /// For example, to search the full name, contents and email you can send the arguments as:
        /// query=John&amp;fullname=1&amp;email=1&amp;contents=1
        /// </summary>
        public TicketCollection SearchTickets(TicketSearchQuery query)
        {
            if (String.IsNullOrEmpty(query.Query))
            {
                throw new ArgumentException("A search query must be provided");
            }

            string apiMethod = "/Tickets/TicketSearch";

            RequestBodyBuilder parameters = query.GetRequestBodyParameters();

            TicketCollection tickets = _connector.ExecutePost<TicketCollection>(apiMethod, parameters.ToString());

            return tickets;
        }

        #endregion

		#region Ticket Status Methods

		/// <summary>
		/// Retrieve a list of all ticket statues in the help desk.
		/// </summary>
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus
		/// </remarks>
		/// <returns>The ticket statuses</returns>
		public TicketStatusCollection GetTicketStatuses()
		{
			string apiMethod = "/Tickets/TicketStatus/";

			return _connector.ExecuteGet<TicketStatusCollection>(apiMethod);
		}

		/// <summary>
		/// Retrieve the ticket status identified by <paramref name="statusId"/>.
		/// </summary>
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus#REST-TicketStatus-GET%2FTickets%2FTicketStatus%2F%24id%24
		/// </remarks>
		/// <param name="statusId">The unique numeric identifier of the ticket status.</param>
		/// <returns>The ticket status</returns>
		public TicketStatus GetTicketStatus(int statusId)
		{
			string apiMethod = String.Format("/Tickets/TicketStatus/{0}", statusId);

			TicketStatusCollection statuses = _connector.ExecuteGet<TicketStatusCollection>(apiMethod);

			if (statuses != null && statuses.Count > 0)
			{
				return statuses[0];
			}
			return null;
		}

		#endregion

		#region Ticket Time Track Methods

		/// <summary>
		/// Retrieve a list of a ticket's time track notes.
		/// </summary>
		public TicketTimeTrackCollection GetTicketTimeTracks(int ticketId)
		{
			string apiMethod = String.Format("/Tickets/TicketTimeTrack/ListAll/{0}", ticketId);

			TicketTimeTrackCollection ticketTimeTracks = _connector.ExecuteGet<TicketTimeTrackCollection>(apiMethod);

			return ticketTimeTracks;
		}

		/// <summary>
		/// Retrieve a ticket's time track note
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket</param>
		/// <param name="timeTrackNoteId">The unique numeric identifier of the ticket time tracking note</param>
		public TicketTimeTrack GetTicketTimeTrack(int ticketId, int timeTrackNoteId)
		{
			string apiMethod = String.Format("/Tickets/TicketTimeTrack/{0}/{1}", ticketId, timeTrackNoteId);

			TicketTimeTrackCollection ticketTimeTracks = _connector.ExecuteGet<TicketTimeTrackCollection>(apiMethod);

			if (ticketTimeTracks != null && ticketTimeTracks.Count > 0)
			{
				return ticketTimeTracks[0];
			}

			return null;
		}

		/// <summary>
		/// Add a new time tracking note to a ticket
		/// </summary>
		public TicketTimeTrack AddTicketTimeTrackingNote(TicketTimeTrackRequest request)
		{
            request.EnsureValidData(RequestTypes.Create);

			string apiMethod = "/Tickets/TicketTimeTrack";

			RequestBodyBuilder parameters = new RequestBodyBuilder();
            parameters.AppendRequestData("ticketid", request.TicketId);
            parameters.AppendRequestData("contents", request.Contents);
            parameters.AppendRequestData("staffid", request.StaffId);
            parameters.AppendRequestData("worktimeline", request.WorkTimeline);
            parameters.AppendRequestData("billtimeline", request.BillTimeline);
            parameters.AppendRequestData("timespent", request.TimeSpent);
            parameters.AppendRequestData("timebillable", request.TimeBillable);

            if (request.WorkerStaffId != null)
			{
                parameters.AppendRequestData("workerstaffid", request.WorkerStaffId);
			}

            if (request.NoteColor != null)
			{
                parameters.AppendRequestData("notecolor", EnumUtility.ToApiString(request.NoteColor));
			}

			TicketTimeTrackCollection ticketTimeTracks = _connector.ExecutePost<TicketTimeTrackCollection>(apiMethod, parameters.ToString());

			if (ticketTimeTracks != null && ticketTimeTracks.Count > 0)
			{
				return ticketTimeTracks[0];
			}

			return null;
		}

		/// <summary>
		/// Delete the ticket time tracking note identified by identifier linked to the ticket identifier
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket</param>
		/// <param name="timeTrackNoteId">The unique numeric identifier of the ticket time tracking note</param>
		public bool DeleteTicketTimeTrackingNote(int ticketId, int timeTrackNoteId)
		{
			string apiMethod = String.Format("/Tickets/TicketTimeTrack/{0}/{1}", ticketId, timeTrackNoteId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#region Ticket Type Methods

		public TicketTypeCollection GetTicketTypes()
		{
			string apiMethod = "/Tickets/TicketType/";

			return _connector.ExecuteGet<TicketTypeCollection>(apiMethod);
		}

		public TicketType GetTicketType(int ticketTypeId)
		{
			string apiMethod = String.Format("/Tickets/TicketType/{0}", ticketTypeId);

			TicketTypeCollection ticketTypes = _connector.ExecuteGet<TicketTypeCollection>(apiMethod);

			if (ticketTypes != null && ticketTypes.Count > 0)
			{
				return ticketTypes[0];
			}

			return null;
		}

		#endregion

		#region Ticket Posts Methods

		/// <summary>
		/// Retrieve a list of all the ticket posts that belong to a ticket given ticket's id.
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket.</param>
		/// <returns>TicketPosts</returns>
		public TicketPostCollection GetTicketPosts(int ticketId)
		{
			string apiMethod = String.Format("/Tickets/TicketPost/ListAll/{0}", ticketId);

			TicketPostCollection posts = _connector.ExecuteGet<TicketPostCollection>(apiMethod);

			return posts;
		}

		/// <summary>
		/// Retrieve the post identified by <paramref name="postId"/> that belong to the ticket identified by <paramref name="ticketId"/>.
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket.</param>
		/// <param name="postId">The unique numeric identifier of the ticket post.</param>
		/// <returns>The ticket post</returns>
		public TicketPost GetTicketPost(int ticketId, int postId)
		{
			string apiMethod = String.Format("/Tickets/TicketPost/{0}/{1}", ticketId, postId);

			TicketPostCollection posts = _connector.ExecuteGet<TicketPostCollection>(apiMethod);

			if (posts.Count > 0)
			{
				return posts[0];
			}

			return null;
		}

        /// <summary>
		/// Add a new post to an existing ticket.. Only <paramref name="userid"/> or <paramref name="staffid"/> should be set.
		/// <remarks>
		/// See - http://wiki.kayako.com/display/DEV/REST+-+TicketPost#REST-TicketPost-POST%2FTickets%2FTicketPost
		/// </remarks>
		/// </summary>
		/// <param name="ticketid">The unique numeric identifier of the ticket</param>
		/// <param name="subject">The ticket post subject.</param>
		/// <param name="contents">The ticket post contents</param>
		/// <param name="userid">The User Id, if the ticket post is to be created as a user</param>
		/// <param name="staffid">The Staff Id, if the ticket post is to be created as a staff.</param>
		/// <returns></returns>
		public TicketPost AddTicketPost(TicketPostRequest request)
		{
            string apiMethod = "/Tickets/TicketPost";

            request.EnsureValidData(RequestTypes.Create);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

            parameters.AppendRequestData("ticketid", request.TicketId);
            parameters.AppendRequestData("subject", request.Subject);
            parameters.AppendRequestData("contents", request.Contents);

            if (request.UserId == null && request.StaffId == null)
			{
				throw new ArgumentException("Neither UserId nor StaffId are set, one of these fields are required field and cannot be null.");
			}

            if (request.UserId != null && request.StaffId != null)
			{
				throw new ArgumentException("UserId are StaffId are both set, only one of these fields must be set.");
			}

            if (request.UserId != null)
			{
                parameters.AppendRequestData("userid", request.UserId.Value);
			}

            if (request.StaffId != null)
			{
                parameters.AppendRequestData("staffid", request.StaffId.Value);
			}

			TicketPostCollection posts = _connector.ExecutePost<TicketPostCollection>(apiMethod, parameters.ToString());

			if (posts.Count > 0)
			{
				return posts[0];
			}

			return null;
		}

		public bool DeleteTicketPost(int ticketId, int ticketPostId)
		{
			string apiMethod = String.Format("/Tickets/TicketPost/{0}/{1}", ticketId, ticketPostId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#region Ticket Attachments Methods

		public TicketAttachmentCollection GetTicketAttachments(int ticketId)
		{
            string apiMethod = String.Format("/Tickets/TicketAttachment/ListAll/{0}", ticketId);

			return _connector.ExecuteGet<TicketAttachmentCollection>(apiMethod);
		}

		public TicketAttachment GetTicketAttachment(int ticketId, int attachmentId)
		{
            string apiMethod = String.Format("/Tickets/TicketAttachment/{0}/{1}", ticketId, attachmentId);

			TicketAttachmentCollection attachments = _connector.ExecuteGet<TicketAttachmentCollection>(apiMethod);

			if (attachments != null && attachments.Count > 0)
			{
				return attachments[0];
			}

			return null;
		}

		/// <summary>
		/// Add an attachment to a ticket post.
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket</param>
		/// <param name="ticketPostId">The unique numeric identifier of the ticket post</param>
		/// <param name="fileName">The file name for the attachment </param>
		/// <param name="contents">The BASE64 encoded attachment contents</param>
		public TicketAttachment AddTicketAttachment(TicketAttachmentRequest request)
		{
            string apiMethod = "/Tickets/TicketAttachment";

            request.EnsureValidData(RequestTypes.Create);

			RequestBodyBuilder parameters = new RequestBodyBuilder();
			parameters.AppendRequestData("ticketid", request.TicketId);
            parameters.AppendRequestData("ticketpostid", request.TicketPostId);
            parameters.AppendRequestData("filename", request.FileName);
            parameters.AppendRequestData("contents", request.Contents);

			TicketAttachmentCollection attachments = _connector.ExecutePost<TicketAttachmentCollection>(apiMethod, parameters.ToString());

			if (attachments != null && attachments.Count > 0)
			{
				return attachments[0];
			}

			return null;
		}

		public bool DeleteTicketAttachment(int ticketId, int attachmentId)
		{
            string apiMethod = String.Format("/Tickets/TicketAttachment/{0}/{1}", ticketId, attachmentId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#region Ticket Note Methods

		/// <summary>
		/// Retrieve a list of a ticket's notes.
		/// </summary>
		/// <remarks>
		/// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-GET%2FTickets%2FTicketNote%2FListAll%2F%24ticketid%24
		/// </remarks>
		/// <param name="ticketId">The unique numeric identifier of the ticket.</param>
		/// <returns>Ticket notes.</returns>
		public TicketNoteCollection GetTicketNotes(int ticketId)
		{
            string apiMethod = String.Format("/Tickets/TicketNote/ListAll/{0}", ticketId);

			return _connector.ExecuteGet<TicketNoteCollection>(apiMethod);
		}

		/// <summary>
		/// Retrieve the note identified by <paramref name="noteId"/> that belongs to a ticket identified by <paramref name="ticketId"/>.
		/// </summary>
		/// <param name="ticketId">The unique numeric identifier of the ticket.</param>
		/// <param name="noteId">The unique numeric identifier of the ticket note.</param>
		/// <returns>List of ticket notes</returns>
		public TicketNote GetTicketNote(int ticketId, int noteId)
		{
            string apiMethod = String.Format("/Tickets/TicketNote/{0}/{1}/", ticketId, noteId);

			TicketNoteCollection notes = _connector.ExecuteGet<TicketNoteCollection>(apiMethod);

			if (notes != null && notes.Count > 0)
			{
				return notes[0];
			}
			return null;
		}

        ///// <summary>
        ///// Add a new note to a ticket.
        ///// </summary>
        ///// <remarks>
        ///// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-POST%2FTickets%2FTicketNote</remarks>
        ///// <returns>The added ticket note.</returns>
        public TicketNote AddTicketNote(TicketNoteRequest request)
        {
            string apiMethod = "/Tickets/TicketNote";

            request.EnsureValidData(RequestTypes.Create);

			RequestBodyBuilder parameters = new RequestBodyBuilder();

            parameters.AppendRequestData("ticketid", request.TicketId);
            parameters.AppendRequestData("contents", request.Content);
            parameters.AppendRequestData("notecolor", (int)request.NoteColor);

            if (request.FullName == null && request.StaffId == null)
			{
				throw new ArgumentException("Neither FullName nor StaffId are set, one of these fields are required field and cannot be null.");
			}

            if (request.FullName != null && request.StaffId != null)
			{
				throw new ArgumentException("FullName are StaffId are both set, only one of these fields must be set.");
			}

            if (request.FullName != null)
			{
                parameters.AppendRequestData("fullname", request.FullName);
			}

            if (request.StaffId != null)
			{
                parameters.AppendRequestData("staffid", request.StaffId.Value);
			}

            if (request.ForStaffId != null)
			{
                parameters.AppendRequestData("forstaffid", request.ForStaffId.Value);
			}

			TicketNoteCollection notes = _connector.ExecutePost<TicketNoteCollection>(apiMethod, parameters.ToString());

			if (notes.Count > 0)
			{
				return notes[0];
			}

			return null;
		}

		public bool DeleteTicketNote(int ticketId, int noteId)
		{
            string apiMethod = String.Format("/Tickets/TicketNote/{0}/{1}", ticketId, noteId);

			return _connector.ExecuteDelete(apiMethod);
		}

		#endregion

		#region Ticket Custom Fields Methods

		/// <summary>
		/// Retrieve a list of a ticket's custom fields.
		/// </summary>
		public TicketCustomFields GetTicketCustomFields(int ticketId)
		{
			string apiMethod = String.Format("/Tickets/TicketCustomField/{0}", ticketId);

			return _connector.ExecuteGet<TicketCustomFields>(apiMethod);
		}

		/// <summary>
		/// Update the custom field values for a ticket. Please note all custom fields for the ticket must be sent through with
		/// their values.
		/// </summary>
		public TicketCustomFields UpdateTicketCustomFields(int ticketId, TicketCustomFields customFields)
		{
			string apiMethod = String.Format("/Tickets/TicketCustomField/{0}", ticketId);

			StringBuilder sb = new StringBuilder();
			foreach(TicketCustomFieldGroup group in customFields.FieldGroups)
			{
				foreach(TicketCustomField field in group.Fields)
				{
					sb.AppendFormat("{0}={1}", field.FieldContent);
				}
			}

			return _connector.ExecutePost<TicketCustomFields>(apiMethod, sb.ToString());
		}

		#endregion

		private string JoinIntParameters(int[] values)
        {
            if(values != null && values.Length > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach(int val in values)
                {
                    if(!String.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append(",");
                    }

                    sb.Append(val);
                }

                return sb.ToString();
            }

            return "-1";
        }
    }
}
