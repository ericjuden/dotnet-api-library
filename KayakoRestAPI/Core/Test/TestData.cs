using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KayakoRestApi.Core.Test
{
	[Serializable]
	public class TestData
	{
		private string _data { get; set; }

		public TestData()
		{
		}

		public TestData(string data)
		{
			_data = data;
		}

		public static implicit operator string(TestData testData)
		{
			return testData.Data;
		}

		public override string ToString()
		{
			return _data;
		}

		public string Data
		{
			get
			{
				return _data;
			}
		}
	}
}
