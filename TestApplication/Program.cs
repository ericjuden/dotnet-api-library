using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using KayakoRestApi;
using KayakoRestApi.Core.Users;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Controllers;
using KayakoRestApi.UnitTests;
using KayakoRestApi.Net;
using KayakoRestApi.Utilities;
using KayakoRestApi.Core.Departments;
using KayakoRestApi.RequestBase;
using KayakoRestApi.Core.Staff;
using KayakoRestApi.Core.Tickets;
using KayakoRestApi.Data;

namespace KayakoTestApplication
{
    /// <summary>
    /// A number of example uses of the .Net Api for Kayako
    /// </summary>
    public class Program
    {
		const string Api_KEY = "d00bb661-765a-cbf4-1daf-168188cfc544";
		const string SECRET_KEY = "YjdiMjI1N2UtNDg4NS1kOGI0LWMxZmItYzFmMTZjMjAwYTIxNGJhMTBiZTYtNjE1NS05NTA0LWQxNjMtYmExOGEyMzcyYjhl";
		const string Api_URL = @"http://contracting.kayako.com/api/index.php"; //Note: No trailing ?

        static void Main(string[] args)
        {
			KayakoClient client = new KayakoClient(Api_KEY, SECRET_KEY, Api_URL);

			//Define the search query
			string query = "firstname";
			TicketSearchField[] searchFields = new TicketSearchField[] { TicketSearchField.FullName, TicketSearchField.EmailAddress };

			TicketSearchQuery searchQuery = new TicketSearchQuery(query, searchFields);

			//Add areas the ticket search should look in
			searchQuery.AddSearchField(TicketSearchField.Author);
			searchQuery.AddSearchField(TicketSearchField.CreatorEmailAddress);
			searchQuery.AddSearchField(TicketSearchField.EmailAddress);
			searchQuery.AddSearchField(TicketSearchField.FullName);

			//Get the tickets matching the search criteria
			TicketCollection matchingTickets = client.Tickets.SearchTickets(searchQuery);

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
