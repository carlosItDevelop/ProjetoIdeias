using System;

namespace Cooperchip.IdeiasApp.DomainCore.Extentions
{
    public static class DataExtention
    {
        public static string ToBrazilianDate (this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy");
        }

        public static string ToBrazilianDateTime(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}