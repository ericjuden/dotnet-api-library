using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Tickets
{
    public class TicketNoteRequest : RequestBaseObject
    {
        /// <summary>
        /// The unique numeric identifer of the ticket
        /// </summary>
        [RequiredField]
        [ResponseProperty("TicketId")]
        public int TicketId { get; set; }

        /// <summary>
        /// The ticket note contents 
        /// </summary>
        [RequiredField]
        [ResponseProperty("Content")]
        public string Content { get; set; }

        /// <summary>
        /// The Staff Id, if the ticket is to be created as a staff.
        /// </summary>
        [EitherField("FullName")]
        [ResponseProperty("CreatorStaffId")]
        public int? StaffId { get; set; }

        /// <summary>
        /// The FullName, if the ticket is to be created without providing a staff user. Example: System messages, Alerts etc.
        /// </summary>
        [EitherField("CreatorStaffId")]
        public string FullName { get; set; }

        /// <summary>
        /// The staff Id the note is viewable by
        /// </summary>
        [ResponseProperty("ForStaffId")]
        public int? ForStaffId { get; set; }

        /// <summary>
        /// The Note Color, for more information see http://wiki.kayako.com/display/DEV/Mobile+-+Constants
        /// </summary>
        [OptionalField]
        [ResponseProperty("NoteColor")]
        public NoteColor NoteColor { get; set; }

        public static TicketNoteRequest FromResponseData(TicketNote responseData)
        {
            return TicketNoteRequest.FromResponseType<TicketNote, TicketNoteRequest>(responseData);
        }

        public static TicketNote ToResponseData(TicketNoteRequest requestData)
        {
            return TicketNoteRequest.ToResponseType<TicketNoteRequest, TicketNote>(requestData);
        }
    }
}
