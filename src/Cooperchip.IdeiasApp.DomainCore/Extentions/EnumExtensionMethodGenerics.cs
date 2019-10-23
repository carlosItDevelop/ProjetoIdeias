using System;
using System.Linq;
using System.Reflection;

namespace Cooperchip.IdeiasApp.DomainCore.Extentions
{
    public static class EnumExtensionMethodGenerics
    {
        // Todo: Altere a assinatura do método e o parâmetro de entrada para usar o parâmetro de tipo T
        public static string GetDescription(this Enum _enum) 
        {
            Type genericEnumType = _enum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(_enum.ToString());
            if ((memberInfo.Length <= 0)) return _enum.ToString();

            var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs.ElementAt(0)).Description : _enum.ToString();
        }
    }


    //public static class GenericExtensionMethodDiscription
    //{
    //    public static string GetDescription(this Enum _enum)
    //    {
    //        Type genericEnumType = _enum.GetType();
    //        MemberInfo[] memberInfo = genericEnumType.GetMember(_enum.ToString());
    //        if ((memberInfo.Length <= 0)) return _enum.ToString();

    //        var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

    //        return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs.ElementAt(0)).Description : _enum.ToString();
    //    }
    //}

}