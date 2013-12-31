using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using KayakoRestApi.Data;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Data
{
	[TestFixture]
	public class UnixDateTimeTests
	{
		private const long UnixTime = 1388497944;
		private readonly DateTime _dateTime = DateTime.Parse("31/12/2013 13:52:24", CultureInfo.GetCultureInfo("en-GB"));


		[Test]
		public void EmptyConstructorTest()
		{
			var unixDateTime = new UnixDateTime();

			Assert.That(unixDateTime.UnixTimeStamp, Is.EqualTo(0));
			Assert.That(unixDateTime.DateTime, Is.EqualTo(DateTime.MinValue));
		}

		[Test]
		public void DateTimeConstructorTest()
		{
			var unixDateTime = new UnixDateTime(_dateTime);

			Assert.That(unixDateTime.UnixTimeStamp, Is.EqualTo(UnixTime));
			Assert.That(unixDateTime.DateTime, Is.EqualTo(_dateTime));
		}

		[Test]
		public void UnixTimeConstructorTest()
		{
			var unixDateTime = new UnixDateTime(UnixTime);

			Assert.That(unixDateTime.UnixTimeStamp, Is.EqualTo(UnixTime));
			Assert.That(unixDateTime.DateTime, Is.EqualTo(_dateTime));
		}

		[Test]
		public void SerializationTest()
		{
			var unixDateTime = new UnixDateTime(UnixTime);

			XmlSerializer serializer = new XmlSerializer(typeof(UnixDateTime));

			StringBuilder xml = new StringBuilder();

			using(StringWriter sw = new StringWriter(xml))
			{
				serializer.Serialize(sw, unixDateTime);
			}

			string expectedXml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<UnixDateTime>1388497944</UnixDateTime>";

			Assert.That(xml.ToString(), Is.EqualTo(expectedXml));
		}

		[Test]
		public void DeserializationTest()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(UnixDateTime));

			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<UnixDateTime>1388497944</UnixDateTime>";

			using (var sr = new StringReader(xml))
			{
				var unixDateTime = (UnixDateTime)serializer.Deserialize(sr);

				Assert.That(unixDateTime.DateTime, Is.EqualTo(_dateTime));
				Assert.That(unixDateTime.UnixTimeStamp, Is.EqualTo(UnixTime));
			}
		}
	}
}
