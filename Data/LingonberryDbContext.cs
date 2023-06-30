namespace LingonberryStudio.Data
{
    using LingonberryStudio.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class LingonberryDbContext : DbContext
    {
        public LingonberryDbContext(DbContextOptions<LingonberryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }

        //public DbSet<Amenity> AmenityTypes { get; set; }

        //public DbSet<TimeFrame> TimeFrames { get; set; }

        //public DbSet<WorkPlace> WorkPlace { get; set; }
    }
}