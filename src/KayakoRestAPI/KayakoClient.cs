using System.Net;
using KayakoRestApi.Controllers;
using KayakoRestApi.Net;

namespace KayakoRestApi
{
	public interface IKayakoClient
	{
		ICoreController Core { get; }

		ICustomFieldController CustomFields { get; }

		IDepartmentController Departments { get; }

		INewsController News { get; }

		IStaffController Staff { get; }

		ITicketController Tickets { get; }

		IUserController Users { get; }
	}

    /// <summary>
    /// This service allows the interaction with the Kayako REST Api.
    /// </summary>
    /// <remarks>
    /// See - http://wiki.kayako.com/display/DEV/REST+Api
    /// </remarks>
    public class KayakoClient : IKayakoClient
	{
		#region Private Properties

		private readonly ICoreController _coreController;
		private readonly ICustomFieldController _customFields;
		private readonly IDepartmentController _departments;
		private readonly INewsController _news;
		private readonly IStaffController _staff;
		private readonly ITicketController _tickets;
		private readonly IUserController _users;

		#endregion

		#region Public Properies

		/// <summary>
		/// Provides access to Core API Methods
		/// </summary>
		public ICoreController Core
		{
			get { return _coreController; }
		}

		/// <summary>
		/// Provides access to Custom Field API Methods
		/// </summary>
		public ICustomFieldController CustomFields
		{
			get { return _customFields; }
		}

		/// <summary>
		/// Provides access to Deparment API Methods
		/// </summary>
		public IDepartmentController Departments
		{ 
			get { return _departments; }
		}

		/// <summary>
		/// Provides access to News API Methods
		/// </summary>
		public INewsController News
		{
			get { return _news; }
		}

		/// <summary>
		/// Provides access to Staff API Methods
		/// </summary>
		public IStaffController Staff
		{
			get { return _staff; }
		}

		/// <summary>
		/// Provides access to Ticket API Methods
		/// </summary>
		public ITicketController Tickets
		{
			get { return _tickets; }
		}

		/// <summary>
		/// Provides access to User API Methods
		/// </summary>
		public IUserController Users
		{
			get { return _users; }
		}

		#endregion

		/// <summary>
        /// Initializes a new instance of the KayakoRestApi.KayakoService class.
        /// </summary>
        /// <param name="apiKey">Api Key.</param>
        /// <param name="secretKey">Secret Api Key.</param>
        /// <param name="apiUrl">URL of Kayako REST Api</param>
        public KayakoClient(string apiKey, string secretKey, string apiUrl)
        {
			_coreController = new CoreController(apiKey, secretKey, apiUrl, null);
			_customFields = new CustomFieldController(apiKey, secretKey, apiUrl, null);
			_departments = new DepartmentController(apiKey, secretKey, apiUrl, null);
			_news = new NewsController(apiKey, secretKey, apiUrl, null);
			_staff = new StaffController(apiKey, secretKey, apiUrl, null);
			_tickets = new TicketController(apiKey, secretKey, apiUrl, null);
			_users = new UserController(apiKey, secretKey, apiUrl, null);
        }

		/// <summary>
		/// Initializes a new instance of the KayakoRestApi.KayakoService class.
		/// </summary>
		/// <param name="apiKey">Api Key.</param>
		/// <param name="secretKey">Secret Api Key.</param>
		/// <param name="apiUrl">URL of Kayako REST Api</param>
		/// <param name="requestType">Determines how the request URL is formed</param>
		public KayakoClient(string apiKey, string secretKey, string apiUrl, ApiRequestType requestType)
		{
			_coreController = new CoreController(apiKey, secretKey, apiUrl, null, requestType);
			_customFields = new CustomFieldController(apiKey, secretKey, apiUrl, null, requestType);
			_departments = new DepartmentController(apiKey, secretKey, apiUrl, null, requestType);
			_news = new NewsController(apiKey, secretKey, apiUrl, null, requestType);
			_staff = new StaffController(apiKey, secretKey, apiUrl, null, requestType);
			_tickets = new TicketController(apiKey, secretKey, apiUrl, null, requestType);
			_users = new UserController(apiKey, secretKey, apiUrl, null, requestType);
		}

		/// <summary>
		/// Initializes a new instance of the KayakoRestApi.KayakoService class.
		/// </summary>
		/// <param name="apiKey">Api Key.</param>
		/// <param name="secretKey">Secret Api Key.</param>
		/// <param name="apiUrl">URL of Kayako REST Api</param>
		/// <param name="proxy">An IWebProxy object representing any proxy details required for internet connection</param>
		public KayakoClient(string apiKey, string secretKey, string apiUrl, IWebProxy proxy)
		{
			_coreController = new CoreController(apiKey, secretKey, apiUrl, proxy);
			_customFields = new CustomFieldController(apiKey, secretKey, apiUrl, proxy);
			_departments = new DepartmentController(apiKey, secretKey, apiUrl, proxy);
			_news = new NewsController(apiKey, secretKey, apiUrl, proxy);
			_staff = new StaffController(apiKey, secretKey, apiUrl, proxy);
			_tickets = new TicketController(apiKey, secretKey, apiUrl, proxy);
			_users = new UserController(apiKey, secretKey, apiUrl, proxy);
		}

		/// <summary>
		/// Initializes a new instance of the KayakoRestApi.KayakoService class.
		/// </summary>
		/// <param name="apiKey">Api Key.</param>
		/// <param name="secretKey">Secret Api Key.</param>
		/// <param name="apiUrl">URL of Kayako REST Api</param>
		/// <param name="requestType">Determines how the request URL is formed</param>
		public KayakoClient(string apiKey, string secretKey, string apiUrl, IWebProxy proxy, ApiRequestType requestType)
		{
			_coreController = new CoreController(apiKey, secretKey, apiUrl, proxy, requestType);
			_customFields = new CustomFieldController(apiKey, secretKey, apiUrl, proxy, requestType);
			_departments = new DepartmentController(apiKey, secretKey, apiUrl, proxy, requestType);
			_news = new NewsController(apiKey, secretKey, apiUrl, proxy, requestType);
			_staff = new StaffController(apiKey, secretKey, apiUrl, proxy, requestType);
			_tickets = new TicketController(apiKey, secretKey, apiUrl, proxy, requestType);
			_users = new UserController(apiKey, secretKey, apiUrl, proxy, requestType);
		}
    }
}
