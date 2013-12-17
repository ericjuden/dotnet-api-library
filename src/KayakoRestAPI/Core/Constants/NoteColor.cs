using System;
using System.Xml.Serialization;
namespace KayakoRestApi.Core.Constants
{
    /// <summary>
    /// The following represent the note background colors.
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/Mobile+-+Constants
    /// </remarks>
    public enum NoteColor
    {
		[XmlEnum("1")]
        Yellow = 1,

		[XmlEnum("2")]
        Purple = 2,

		[XmlEnum("3")]
        Blue = 3,

		[XmlEnum("4")]
        Green = 4,

		[XmlEnum("5")]
        Red = 5
    }
}
