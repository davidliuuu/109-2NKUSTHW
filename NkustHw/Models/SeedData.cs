using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesContext>>()))
            {
                // Look for any movies.
                if (context.Iteminfo.Any())
                {
                    return;   // DB has been seeded
                }

                context.Iteminfo.AddRange(
                    new Iteminfo
                    {
                        Title = "Banana",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Fruit",
                        Price = 20,
                        Count = 10
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
