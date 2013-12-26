using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using KayakoRestApi;
using KayakoRestApi.Core.Departments;

namespace KayakoTestApplication
{
    /// <summary>
    /// A number of example uses of the .Net Api for Kayako
    /// </summary>
    public class Program
    {
		const string Api_KEY = "94364841-7542-9e94-d59c-f420554d9a9d";
		const string SECRET_KEY = "ZjM5OTAzN2YtYjcxNy1jZWQ0LTIxMGEtNGViNzQzNTNhZjAxY2Y3OGVkMmUtN2RmNi05MTQ0LTI5YjctYmM0M2E1OWNlMmU5";
		const string Api_URL = @"http://apiupdates.kayako.com/api/"; //Note: No trailing ?

        static void Main(string[] args)
        {
			KayakoClient client = new KayakoClient(Api_KEY, SECRET_KEY, Api_URL);

			DepartmentCollection departments = client.Departments.GetDepartments();

			OutputData<DepartmentCollection>("Departments: ", departments);

            Console.ReadLine();
        }

        static T DeserializeObject<T>(string xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    return (T)serializer.Deserialize(xtr);
                }
            }
        }

		static void OutputData<T>(string prefix, object o)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			StringBuilder sb = new StringBuilder();

			using (StringWriter sw = new StringWriter(sb))
			{
				serializer.Serialize(sw, o);
			}

            Console.WriteLine(prefix + Environment.NewLine);
            Console.WriteLine(sb.ToString());
		}
	}
}
