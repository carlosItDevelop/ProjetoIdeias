using System;
using System.Linq;
using System.Reflection;

namespace Cooperchip.IdeiasApp.DomainCore.Extentions
{
    public static class EnumExtensionMethodAndGenerics
    {
        public static string GetDescription(this Enum _enum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = _enum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(_enum.ToString());
            if ((memberInfo.Length <= 0)) return _enum.ToString();

            var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs.ElementAt(0)).Description : _enum.ToString();
        }
    }
}