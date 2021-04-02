using Newtonsoft.Json;
using Schedulaaa2021_1._0.Models;
using System;
using System.IO;

namespace Schedulaaa2021_1._0
{
    public class FileOps
    {
        static string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\config.json";

        public static Config readConfig()
        {
            try
            {
                string fileData = File.ReadAllText(filepath);
                return JsonConvert.DeserializeObject<Config>(fileData);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static  bool configFileExists()
        {
            return File.Exists(filepath);
        }
    }
}
