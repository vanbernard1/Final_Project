using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection; //Add required using directives to seed data
using Final_Project.Models;

namespace Final_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); //Call SeedData from Main
            using (var scope = host.Services.CreateScope())
            {
            var services = scope.ServiceProvider;
            try
            {
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
            
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured seeding the DB.");
           }
    }

            host.Run();
}
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
