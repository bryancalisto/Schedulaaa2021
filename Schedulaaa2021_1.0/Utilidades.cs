using Schedulaaa2021_1._0.Models;
using System;

namespace Schedulaaa2021_1._0
{
    public class Utilidades
    {
        public static void  updateConfig(ref Config config)
        {
            if (!FileOps.configFileExists())
            {
                Toast.show("ARCHIVO DE CONFIGURACIÓN NO ENCONTRADO");
                Environment.Exit(-1);
            }

            config = FileOps.readConfig();

            if (config == null)
            {
                Toast.show("ERROR AL LEER ARCHIVO DE CONFIGURACIÓN");
                Environment.Exit(-2);
            }
        }
    }
}
