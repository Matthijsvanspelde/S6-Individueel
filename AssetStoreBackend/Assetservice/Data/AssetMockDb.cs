using Assetservice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assetservice.Data
{
    public static class AssetMockDb
    {
        public static void PrepPopulation(IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                SeedDate(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedDate(AppDbContext context) 
        {
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
