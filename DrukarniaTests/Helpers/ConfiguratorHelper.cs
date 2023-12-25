using Microsoft.Extensions.Configuration;
using DrukarniaTests.Models;

namespace DrukarniaTests.Helpers
{
    internal class ConfiguratorHelper
    {
        private static readonly string FileName = Path.GetFullPath(@"..//..//..//settings.json");
        private static readonly IConfigurationRoot Config;

        static ConfiguratorHelper()
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

        public static SqlConnectionModel GetSqlSectionModel()
        {
            return Config.GetSection("dbSection").Get<SqlConnectionModel>();
        }
    }
}
