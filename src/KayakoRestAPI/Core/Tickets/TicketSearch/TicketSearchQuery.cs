using System;
using System.Collections.Generic;
using System.Text;
using KayakoRestApi.Text;
using System.Reflection;

namespace KayakoRestApi.Core.Tickets
{
    /// <summary>
    /// Object to build up a search query which will search tickets
    /// <remarks>http://wiki.kayako.com/display/DEV/REST+-+TicketSearch#REST-TicketSearch-PostVariables</remarks>
    /// </summary>
    public class TicketSearchQuery
    {
        public string Query { get; set; }

		private List<TicketSearchField> _searchFields { get; set; }
		public List<TicketSearchField> SearchFields
		{
			get
			{
				return _searchFields;
			}
			set
			{
				_searchFields = value;
			}
		}

        /// <summary>
        /// Initialises the ticket search query with the query data
        /// </summary>
        public TicketSearchQuery(string query)
        {
            Query = query;
            _searchFields = new List<TicketSearchField>();
        }

        /// <summary>
        /// Initialises the ticket search query with the query data
        /// </summary>
        public TicketSearchQuery(string query, TicketSearchField[] searchFields)
        {
            Query = query;
            _searchFields = new List<TicketSearchField>(searchFields);
        }

        /// <summary>
        /// Populates the post parameters to send to Kayako Api service
        /// </summary>
        /// <returns></returns>
        internal RequestBodyBuilder GetRequestBodyParameters()
        {
            RequestBodyBuilder parameters = new RequestBodyBuilder();
            parameters.AppendRequestData("query", Query);

            FieldInfo[] props = typeof(TicketSearchField).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo p in props)
            {
                if (_searchFields.Contains((TicketSearchField)p.GetValue(typeof(TicketSearchField))))
                {
                    RequestParameterNameAttribute[] att = (RequestParameterNameAttribute[])p.GetCustomAttributes(typeof(RequestParameterNameAttribute), false);

                    if(att != null)
                    {
                        parameters.AppendRequestData(att[0].RequestName, 1);   
                    }
                }
            }


            return parameters;
        }

        /// <summary>
        /// Add a search field to be included in the search
        /// </summary>
        /// <param name="searchField"></param>
        public void AddSearchField(TicketSearchField searchField)
        {
            _searchFields.Add(searchField);
        }
    }

    /// <summary>
    /// Enum representing the various search fields available
    /// </summary>
    public enum TicketSearchField
    {
        [RequestParameterName("ticketid")]
        TicketId,

        [RequestParameterName("contents")]
        Contents,

        [RequestParameterName("author")]
        Author,

        [RequestParameterName("email")]
        EmailAddress,

        [RequestParameterName("creatoremail")]
        CreatorEmailAddress,

        [RequestParameterName("fullname")]
        FullName,

        [RequestParameterName("notes")]
        Notes,

        [RequestParameterName("usergroup")]
        UserGroup,

        [RequestParameterName("userorganization")]
        UserOrganization,

        [RequestParameterName("user")]
        User,

        [RequestParameterName("tags")]
        Tags
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class RequestParameterNameAttribute : Attribute
    {
        public string RequestName { get; set; }

        public RequestParameterNameAttribute(string requestname)
        {
            RequestName = requestname;
        }
    }
}
