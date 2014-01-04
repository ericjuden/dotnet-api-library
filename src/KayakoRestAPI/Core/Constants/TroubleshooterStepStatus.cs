using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TroubleshooterStepStatus
	{
		[XmlEnum("1")]
		Published,

		[XmlEnum("2")]
		Draft
	}
}
