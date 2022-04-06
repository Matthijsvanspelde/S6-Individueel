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

            if (!context.Assets.Any())
            {
                Console.WriteLine("Seeding data...");

                context.Assets.AddRange(
                    new Asset() { Title = "ButtonClick.wav", Description = "Sound of a button click."},
                    new Asset() { Title = "Tree.obj", Description = "Tree 3D model." },
                    new Asset() { Title = "Character.png", Description = "Character sprite sheet." }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data.");
            }
        }
    }
}
