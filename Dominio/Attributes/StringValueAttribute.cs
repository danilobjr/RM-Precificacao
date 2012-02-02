using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Attributes
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }
}
