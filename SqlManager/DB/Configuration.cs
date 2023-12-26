using DrukarniaTests.SqlManager.Models;
using Microsoft.Extensions.Configuration;

namespace DrukarniaTests.SqlManager.DB
{
    internal class Configuration
    {
        private static readonly string FileName = Path.GetFullPath(@"..//..//..//prop.json");
        private static readonly IConfigurationRoot Config;

        static Configuration()
        {
            Config = ReadFromJsonFile(FileName);
        }

        private static IConfigurationRoot ReadFromJsonFile(string fileName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(fileName);

            return builder.Build();
        }

        public static DatabaseConString GetSqlModel()
        {
            return Config.Get<DatabaseConString>();
        }

    }
}
