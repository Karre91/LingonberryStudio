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

                if (context.Ads.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ads.AddRange(
                    new Ad()
                    {
                        Category = "HaveStudio,",
                        Area = "CF64 4NJ",
                        Price = 100
                    },
                    new Ad()
                    {
                        Category = "SearchingForStudio,",
                        Area = "CF64 5KL",
                        Price = 200
                    }                    
                    );

                if (context.Ads.Any())
                {
                    return;   // DB has been seeded
                }


                context.SaveChanges();
            }
        }
    }
}
