using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Dominio.Attributes;

namespace RM.Precificacao.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attributes = 
                fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attributes.Length > 0 ? attributes[0].StringValue : null;
        }
    }
}