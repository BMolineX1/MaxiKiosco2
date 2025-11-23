using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MaxiKiosco.Utilidades
{
    public static class ConfigKiosco
    {
        // Lee desde App.config y si no existe, usa "RI" por defecto
        public static string EmisorCondIva =>
            ConfigurationManager.AppSettings["EmisorCondIva"] ?? "RI";
    }
}

