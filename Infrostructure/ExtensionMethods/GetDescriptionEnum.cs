using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Infrostructure.Exeption;

namespace Infrostructure.ExtensionMethods
{
    public static class GetDescriptionEnum
    {
        public static string GetDescription(this Enum stateEnum)
        {
            FieldInfo fieldinfo = stateEnum.GetType().GetField(stateEnum.ToString());
            AttributeForDescription[] attributes = (AttributeForDescription[])fieldinfo.GetCustomAttributes(typeof(AttributeForDescription), false);

            if (attributes.Length > 0)
                return attributes[0].Description;

            throw new NotFoundDescriptionExeption();
        }
    }

}
