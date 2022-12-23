using LingonberryStudio.Models;
using LingonberryStudio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LingonberryStudio.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LingonberryDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LingonberryDbContext>>()))
            {

                //    if (context.Adverts.Any())
                //    {
                //        return;   // DB has been seeded
                //    }

                //    context.Adverts.AddRange(
                //        new Advert()
                //        {
                //            Name = "Havve,",
                //            Description = "fin"
                //        },
                //        new Advert()
                //        {
                //            Name = "Havve,",
                //            Description = "ful"
                //        }
                //        );

                //    if (context.Adverts.Any())
                //    {
                //        return;   // DB has been seeded
                //    }


                //    context.SaveChanges();
                //}
            }
        }
    }
}

