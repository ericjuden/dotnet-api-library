using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    [XmlRoot("attachments")]
    public class TicketAttachmentCollection : List<TicketAttachment>
    {
        public TicketAttachmentCollection()
        {
        }
    }
}
