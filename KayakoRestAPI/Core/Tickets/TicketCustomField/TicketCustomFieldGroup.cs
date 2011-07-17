using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    [XmlRoot("group")]
    public class TicketCustomFieldGroup
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("field")]
        public TicketCustomField[] Fields { get; set; }
    }
}
