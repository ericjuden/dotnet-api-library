using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace KayakoRestApi.RequestBase
{
	public abstract class RequestBaseObject
	{
        public bool IsValid(RequestTypes requestType)
        {
            try
            {
                EnsureValidData(requestType);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates the request base object for a request type (create or update)
        /// </summary>
		internal void EnsureValidData(RequestTypes requestType)
		{
			PropertyInfo[] properties = GetType().GetProperties();
            
			foreach (PropertyInfo info in properties)
			{
				RequiredFieldAttribute[] required = (RequiredFieldAttribute[])info.GetCustomAttributes(typeof(RequiredFieldAttribute), false);

				if (required != null && required.Length > 0)
				{
					bool checkValue = required.Length == 0;

					foreach (RequestTypes type in required[0].RequestTypes)
					{
						if (type == requestType)
						{
							checkValue = true;
							break;
						}
					}

					if (checkValue && info.GetValue(this, null) == null)
					{
						throw new ArgumentException(String.Format("{0} - Required field missing", GetType().Name), info.Name);
					}
				}

                EitherFieldAttribute[] eitherField = (EitherFieldAttribute[])info.GetCustomAttributes(typeof(EitherFieldAttribute), false);

                if (eitherField != null && eitherField.Length > 0)
                {
                    if(info.GetValue(this, null) != null)
                    {
                        foreach (string prop in eitherField[0].DependsOn)
                        {
                            PropertyInfo pInfo = GetType().GetProperty(prop);

                            if (pInfo != null)
                            {
                                if (pInfo.GetValue(this, null) != null)
                                {
                                    throw new ArgumentException(String.Format("If {0} has a value, {1} must be null", info.Name, pInfo.Name), info.Name);
                                }
                            }
                        }
                    }
                }
			}
		}
		
        /// <summary>
        /// Converts from an Api response object to a request base object
        /// </summary>
		protected static TTo FromResponseType<TFrom, TTo>(TFrom responseObject) where TTo : RequestBaseObject
		{
			ConstructorInfo ci = typeof(TTo).GetConstructor(new Type[0]);

			TTo output = (TTo)ci.Invoke(new object[0]);

			foreach (PropertyInfo info in typeof(TTo).GetProperties())
			{
				ResponsePropertyAttribute[] responseMatchAtt = (ResponsePropertyAttribute[])info.GetCustomAttributes(typeof(ResponsePropertyAttribute), false);

				if (responseMatchAtt != null && responseMatchAtt.Length > 0)
				{
					PropertyInfo matchingProp = responseObject.GetType().GetProperty(responseMatchAtt[0].RepsonseProperty);

					info.SetValue(output, matchingProp.GetValue(responseObject, null), null);
				}
			}

			return output;
		}

        /// <summary>
        /// Converts from an request base object to an Api response object
        /// </summary>
		protected static TTo ToResponseType<TFrom, TTo>(TFrom requestObject) where TFrom : RequestBaseObject
		{
			ConstructorInfo ci = typeof(TTo).GetConstructor(new Type[0]);

			TTo output = (TTo)ci.Invoke(new object[0]);

			foreach (PropertyInfo info in typeof(TFrom).GetProperties())
			{
				ResponsePropertyAttribute[] responseMatchAtt = (ResponsePropertyAttribute[])info.GetCustomAttributes(typeof(ResponsePropertyAttribute), false);

				if (responseMatchAtt != null && responseMatchAtt.Length > 0)
				{
					PropertyInfo matchingProp = output.GetType().GetProperty(responseMatchAtt[0].RepsonseProperty);

					matchingProp.SetValue(output, info.GetValue(requestObject, null), null);
				}
			}

			return output;
		}
	}
}
