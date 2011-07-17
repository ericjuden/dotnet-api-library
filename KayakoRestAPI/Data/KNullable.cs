using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace KayakoRestApi.Data
{
	[Serializable]
	public class KNullable<T> : IXmlSerializable
		where T : struct
	{
        private T? _value { get; set; }

        public KNullable()
        {
            _value = new T?();
        }

        public KNullable(T value)
        {
            _value = new T?(value);
        }

        public T Value
        {
            get
            {
                
                return _value.Value;
            }
        }

        public bool HasValue
        {
            get
            {
                return _value.HasValue;
            }
        }

		public static KNullable<T> ToKNullable(T value)
		{
			return new KNullable<T>(value);
		}

        public static implicit operator KNullable<T>(T value)
        {
            return new KNullable<T>(value);
        }

		public static T FromKNullable(KNullable<T> value)
		{
			return value.Value;
		}

        public static explicit operator T(KNullable<T> value)
        {
            return value.Value;
        }

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return _value.Equals(obj);
		}

		#region IXmlSerializable Methods

		public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();

			if (!reader.IsEmptyElement)
			{
				string value = reader.ReadElementContentAsString();

				if (!String.IsNullOrEmpty(value))
				{
					_value = (T)Convert.ChangeType(value, typeof(T));
				}
			}
			else
			{
				_value = new T?();
			}
        }

        public void WriteXml(XmlWriter writer)
        {
			if (_value.HasValue)
            {
				writer.WriteString(_value.Value.ToString());
			}
			else
			{
				writer.WriteString("");
			}
		}

		#endregion
	}
}
