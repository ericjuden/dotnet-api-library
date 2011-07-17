using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Tickets
{
    [XmlRoot("customfields")]
    public class TicketCustomFields
    {
        [XmlElement("group")]
        public List<TicketCustomFieldGroup> FieldGroups { get; set; }

        public TicketCustomFields()
        {
            FieldGroups = new List<TicketCustomFieldGroup>();
        }
    }
}
