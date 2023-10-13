namespace Marathon.Server
{
    using Marathon.Server.Features.Hubs;
    using Marathon.Server.Features.Tokens;
    using Marathon.Server.Infrastructure.Extensions;
    using Marathon.Server.Infrastructure.Extentions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            services
                 .AddDatabase(this.Configuration)
                 .AddIdentity()
                 .AddCorsWithOptions()
                 .AddSignalRWithOptions()
                 .AddRedisEasyCaching()
                 .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                 .AddApplicationServices()
                 .AddSwagger()
                 .AddApiControllers();

            //services.AddMvc(options =>
            //{
             //   options.InputFormatters.Add(new BinaryFormatterInputFormatter());
              //  options.OutputFormatters.Add(new BinaryFormatterOutputFormatter());
            //}); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwaggerUI()
                .UseRouting()
                .UseAuthorization()
                .UseOptionsMiddleware()
                .UseTokenCheckMiddleware()
                .UseCors("CorsPolicy")
                .UseAuthentication()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<UpdatesHub>("/updatesHub");
                    endpoints.MapControllers();
                })
                .ApplyMigrations();
        }



        //public static IServiceCollection AddApplicationServices(this IServiceCollection services)
       // {
         //   services.AddScoped<ITokensService, TokensService>();
            // ... other services

           // return services;
        //}
    }
}
