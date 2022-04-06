using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using UserService.Models;

namespace UserService.Data
{
    public class UserMockDb
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

            if (!context.Users.Any())
            {
                Console.WriteLine("Seeding data...");

                context.Users.AddRange(
                    new User() { Username = "Matthijs1999", Biography = "My name is Matthijs1999" },
                    new User() { Username = "Pieter2000", Biography = "My name is Pieter2000" },
                    new User() { Username = "Klaas69", Biography = "My name is Klaas69" }
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
