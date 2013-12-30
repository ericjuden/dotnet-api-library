using System;
using System.Xml;
using System.Xml.Serialization;
using KayakoRestApi.Utilities;

namespace KayakoRestApi.Data
{
	public class UnixDateTime : IXmlSerializable
	{
		private long _unixDateTime = 0;

		public UnixDateTime()
		{
		}

		public UnixDateTime(long epochDateTime)
		{
			_unixDateTime = epochDateTime;
		}

		[XmlIgnore]
		public long EpochValue
		{
			get { return _unixDateTime; }
			set { _unixDateTime = value; }
		}

		[XmlIgnore]
		public DateTime DateTime
		{
			get { return _unixDateTime != 0 ? UnixTimeUtility.FromUnixTime(_unixDateTime) : DateTime.MinValue; }
		}

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			reader.MoveToContent();

			if (!reader.IsEmptyElement)
			{
				string value = reader.ReadElementContentAsString();

				if (long.TryParse(value, out _unixDateTime))
				{
					return;
				}
			}

			_unixDateTime = 0;
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteString(_unixDateTime.ToString());
		}
	}
}

