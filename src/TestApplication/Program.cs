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
		const string Api_KEY = "8c75489a-45c6-b114-e597-88c5f462ff53";
		const string SECRET_KEY = "NWQ3N2YyMzEtNTYwMi1lMzE0LWQ1OTAtMGM1ZGQyZDdjYmVkZTIyZGVlMTMtZDJiOS01OTk0LTg5ZmMtMjE4MmNjMjZkMmIx";
		const string Api_URL = @"http://jamietestingagain.kayako.com/api/"; //Note: No trailing ?

        static void Main(string[] args)
        {
			KayakoClient client = new KayakoClient(Api_KEY, SECRET_KEY, Api_URL, ApiRequestType.Url);

			try
			{
				Ticket ticket = client.Tickets.GetTicket(39);
				//Successfully returns a ticket object with correct values populated

				TicketRequest ticketReq = TicketRequest.FromResponseData(ticket);
				//Successfully returns a ticket object with correct values populated

				//Our own method that sets some ticket values, e.g. Update the ticket status

				Ticket respTicket = client.Tickets.UpdateTicket(ticketReq);
				//Exception is thrown here.

				OutputData<Ticket>("Ticket: ", respTicket);
			}
			catch (Exception ex)
			{
				//Exception Message: If StaffId has a value, StaffId must be null\r\nParameter name: StaffId
			}

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
