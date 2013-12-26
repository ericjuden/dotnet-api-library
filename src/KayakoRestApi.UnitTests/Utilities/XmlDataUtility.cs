using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace KayakoRestApi.UnitTests.Utilities
{
	public class XmlDataUtility
	{
		public static T ReadFromFile<T>(string filePath)
		{
			return DeserializeObject<T>(filePath);
		}

		private static T DeserializeObject<T>(string filePah)
		{
			var xmlFile = Path.Combine(Directory.GetCurrentDirectory(), filePah);

			XmlSerializer serializer = new XmlSerializer(typeof(T));

			using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
			{
				using (XmlTextReader xtr = new XmlTextReader(fs))
				{
					return (T)serializer.Deserialize(xtr);
				}
			}
		}
	}
}
