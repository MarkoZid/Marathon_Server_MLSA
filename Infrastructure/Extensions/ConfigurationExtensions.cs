namespace Marathon.Server.Infrastructure.Extensions
{
    using Humanizer.Configuration;
    using Marathon.Server.Azure;
    using Microsoft.Extensions.Configuration;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public static class ConfigurationExtensions
    {


        public static string GetDefaultConnectionString(this IConfiguration configuration)
            {
            KeyVaultManager keyVaultManager = new KeyVaultManager();


                var db = keyVaultManager.GetSecret("Databaza");

            



                return configuration.GetConnectionString("DefaultConnection");
            }


        public static async Task<string> GetDefaultConnectionStringAsync(this IConfiguration configuration)
        {
            KeyVaultManager keyVaultManager = new KeyVaultManager();

            var db = await keyVaultManager.GetSecretAsync("posledno");

            return db;
        }






        public static string GetDatabaseConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("majkati");

            if (string.IsNullOrEmpty(connectionString))
            {
                
            }

            return connectionString;
        }
    }
}
