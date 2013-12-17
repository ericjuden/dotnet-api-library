using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KayakoRestApi.Core.Test;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Cusom Fields")]
	public class CoreTests : UnitTestBase
	{
		[Test]
		public void GetList()
		{
			string getList = TestSetup.KayakoApiService.Core.GetListTest();

			OutputMessage(getList);
			Assert.IsNotNullOrEmpty(getList);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Get(int id)
		{
			string get = TestSetup.KayakoApiService.Core.GetTest(id);

			OutputMessage(get);
			Assert.IsNotNullOrEmpty(get);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Put(int id)
		{
			string put = TestSetup.KayakoApiService.Core.PutTest(id);

			OutputMessage(put);
			Assert.IsNotNullOrEmpty(put);
		}

		public void Post()
		{
			string post = TestSetup.KayakoApiService.Core.PostTest();

			OutputMessage(post);
			Assert.IsNotNullOrEmpty(post);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Delete(int id)
		{
			bool res = TestSetup.KayakoApiService.Core.DeleteTest(id);

			Assert.IsTrue(res);
		}
	}
}
