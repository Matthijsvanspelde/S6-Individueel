using Assetservice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assetservice.Data
{
    public static class AssetMockDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                SeedDate(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }

        private static void SeedDate(AppDbContext context, bool isProduction) 
        {
            if (isProduction)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }                
            }
        }
    }
}
