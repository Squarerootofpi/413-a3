using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace _413assignment3.Models
{
    public class SeedDatabase
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Les Mis",
                        Category = "Drama",
                        Year = 1999,
                        Director = "Joe Schmo",
                        Rating = "G",
                        Edited = true,
                        Notes = "Great movie!",
                        LentTo = "Myself # awesome..."
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
