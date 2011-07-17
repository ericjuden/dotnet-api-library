using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.RequestBase
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    internal sealed class EitherFieldAttribute : Attribute
    {
        public string[] DependsOn { get; set; }

        /// <param name="dependsOn">Pipe separated list of dependant properties</param>
        public EitherFieldAttribute(string dependsOn)
        {
            DependsOn = dependsOn.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public EitherFieldAttribute(string[] dependsOn)
        {
            DependsOn = dependsOn;
        }
    }
}
