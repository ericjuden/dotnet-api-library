using System;
using System.Collections.Generic;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Departments;
using NUnit.Framework;
using KayakoRestApi.Core.CustomFields;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Cusom Fields")]
	public class CustomFieldTests : UnitTestBase
	{
        [Test]
		public void GetCustomFields()
		{
			CustomFieldCollection customFields = TestSetup.KayakoApiService.CustomFields.GetCustomFields();

			Assert.IsNotNull(customFields, "No custom fields were returned");
			Assert.IsNotEmpty(customFields, "No custom fields were returned");
		}

		[Test]
		public void GetCustomFieldOptions()
		{
			CustomFieldCollection customFields = TestSetup.KayakoApiService.CustomFields.GetCustomFields();

			Assert.IsNotNull(customFields, "No custom fields were returned");
			Assert.IsNotEmpty(customFields, "No custom fields were returned");

			int idToUse = -1;
			foreach (CustomField customField in customFields)
			{
				CustomFieldOptionCollection customFieldOptions = TestSetup.KayakoApiService.CustomFields.GetCustomFieldOptions(customField.CustomFieldId);
				if (customFieldOptions.Count > 0)
				{
					idToUse = customField.CustomFieldId;
					break;
				}
			}

			if (idToUse != -1)
			{
				CustomFieldOptionCollection customFieldOptions = TestSetup.KayakoApiService.CustomFields.GetCustomFieldOptions(idToUse);

				Assert.IsNotNull(customFieldOptions, "No custom fields were returned");
				Assert.IsNotEmpty(customFieldOptions, "No custom fields were returned");
			}
			else
			{
				throw new Exception("No custom field options found");
			}
		}
	}
}
