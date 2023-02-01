namespace LingonberryStudio.Data
{
    using LingonberryStudio.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class LingonberryDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LingonberryDbContext(DbContextOptions<LingonberryDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }

        public DbSet<Amenity> AmenityTypes { get; set; }

        public DbSet<TimeFrame> TimeFrames { get; set; }

        public DbSet<WorkPlace> WorkPlace { get; set; }
    }
}

