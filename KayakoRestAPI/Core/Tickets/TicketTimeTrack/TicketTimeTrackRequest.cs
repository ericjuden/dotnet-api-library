using KayakoRestApi.Core.Constants;
using KayakoRestApi.RequestBase;

namespace KayakoRestApi.Core.Tickets
{
    public class TicketTimeTrackRequest : RequestBaseObject
    {
        /// <summary>
        /// The unique numeric identifier of the ticket
        /// </summary>
        [RequiredField]
        [ResponseProperty("TicketId")]
        public int TicketId { get; set; }

        /// <summary>
        /// The ticket time tracking note contents
        /// </summary>
        [RequiredField]
        [ResponseProperty("Contents")]
        public string Contents { get; set; }
        
        /// <summary>
        /// The ticket time tracking creator staff identifier
        /// </summary>
        [RequiredField]
        [ResponseProperty("CreatorStaffId")]
        public int StaffId { get; set; }

        /// <summary>
        /// The UNIX timestamp which specifies when the work was executed
        /// </summary>
        [RequiredField]
        [ResponseProperty("WorkDate")]
        public string WorkTimeline { get; set; }
        
        /// <summary>
        /// The UNIX timestamp which specifies when to bill the user
        /// </summary>
        [RequiredField]
        [ResponseProperty("BillDate")]
        public string BillTimeline { get; set; }

        /// <summary>
        /// The time spent (in seconds).
        /// </summary>
        [RequiredField]
        [ResponseProperty("TimeWorked")]
        public int TimeSpent { get; set; }

        /// <summary>
        /// The time billable (in seconds).
        /// </summary>
        [RequiredField]
        [ResponseProperty("TimeBillable")]
        public int TimeBillable { get; set; }

        /// <summary>
        /// The staff identifier of the worker. If not specified, the staff user creating this entry will be considered as the worker.
        /// </summary>
        [ResponseProperty("WorkerStaffId")]
        public int? WorkerStaffId { get; set; }

        /// <summary>
        /// The Note Color, for more information see note colors
        /// </summary>
        [ResponseProperty("NoteColor")]
        public NoteColor? NoteColor { get; set; }
        
        public static TicketTimeTrackRequest FromResponseData(TicketTimeTrack responseData)
        {
            return TicketTimeTrackRequest.FromResponseType<TicketTimeTrack, TicketTimeTrackRequest>(responseData);
        }

        public static TicketTimeTrack ToResponseData(TicketTimeTrackRequest requestData)
        {
            return TicketTimeTrackRequest.ToResponseType<TicketTimeTrackRequest, TicketTimeTrack>(requestData);
        }
    }
}
