using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests
{
	public class UnitTestBase
	{
		public void OutputMessage<T>(string preMessage, T dataToOutput)
		{
			string serializedObject = SerializeObject<T>(dataToOutput);

			OutputMessage(String.Format("{0}{1}{2}", preMessage, Environment.NewLine, serializedObject));
		}

		public void OutputMessage(string message)
		{
			Console.WriteLine(message);
		}

		public static void AssertObjectXmlEqual<T>(T expected, T actual)
		{
			string expectedXml = SerializeObject<T>(expected);
			string actualXml = SerializeObject<T>(actual);

			Assert.AreEqual(expectedXml, actualXml);
		}

		private static string SerializeObject<T>(T serializeObject)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			StringBuilder sb = new StringBuilder();

			using (StringWriter sw = new StringWriter(sb))
			{
				serializer.Serialize(sw, (T)serializeObject);
			}

			return sb.ToString();
		}
	}
}
