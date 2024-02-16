namespace Marathon.Server
{
    //using Azure.Extensions.AspNetCore.Configuration.Secrets;
    //using Azure.Identity;
    //using Azure.Security.KeyVault.Secrets;
    using Marathon.Server.Azure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            KeyVaultManager keyVaultManager = new KeyVaultManager();

            Debug.WriteLine(keyVaultManager.GetSecret("Databaza"));
         
            

        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                });
    }
}
