using System;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.CustomFields;
using KayakoRestApi.Net;
using KayakoRestApi.UnitTests.Utilities;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.CustomFields
{
	[TestFixture]
	public class CustomFieldControllerTests
	{
		private ICustomFieldController _customFieldController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;
		private CustomFieldCollection _responseCustomFieldCollection;
		private CustomFieldOptionCollection _responseCustomFieldOptionsCollection;

		[SetUp]
		public void Setup()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();
			_customFieldController = new CustomFieldController(_kayakoApiRequest.Object);
			
			_responseCustomFieldCollection = new CustomFieldCollection
				{
					new CustomField(),
					new CustomField()
				};

			_responseCustomFieldOptionsCollection = new CustomFieldOptionCollection
				{
					new CustomFieldOption(),
					new CustomFieldOption()
				};
		}

		[Test]
		public void GetCustomFields()
		{
			const string apiMethod = "/Base/CustomField";

			_kayakoApiRequest.Setup(x => x.ExecuteGet<CustomFieldCollection>(apiMethod)).Returns(_responseCustomFieldCollection);

			var customFields = _customFieldController.GetCustomFields();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<CustomFieldCollection>(apiMethod), Times.Once());
			AssertUtility.ObjectsEqual(customFields, _responseCustomFieldCollection);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void GetCustomFieldListOptions(int customFieldId)
		{
			var apiMethod = string.Format("/Base/CustomField/ListOptions/{0}", customFieldId);

			_kayakoApiRequest.Setup(x => x.ExecuteGet<CustomFieldOptionCollection>(apiMethod)).Returns(_responseCustomFieldOptionsCollection);

			var customFieldOptions = _customFieldController.GetCustomFieldOptions(customFieldId);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<CustomFieldOptionCollection>(apiMethod), Times.Once());
			AssertUtility.ObjectsEqual(customFieldOptions, _responseCustomFieldOptionsCollection);
		}
	}
}
