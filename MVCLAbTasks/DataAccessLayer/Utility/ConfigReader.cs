using System.Configuration;

namespace DataAccessLayer.Utility
{
    public static class ConfigReader
    {
        public static string EFConnection => ReadConfig("defaultEFConnection");

        private static string ReadConfig(string param)
        {
            return ConfigurationManager.ConnectionStrings[param].ConnectionString;
        }
    }
}
