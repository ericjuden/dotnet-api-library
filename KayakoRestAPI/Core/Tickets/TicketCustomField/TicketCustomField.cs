using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.Core.Tickets
{
    [XmlRoot("field")]
    public class TicketCustomField
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

		[XmlAttribute("type")]
		public TicketCustomFieldType Type { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("filename")]
        public string FileName { get; set; }

        [XmlText]
        public string FieldContent { get; set; }
    }
}
