using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RM.Precificacao.Dominio.Attributes
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
