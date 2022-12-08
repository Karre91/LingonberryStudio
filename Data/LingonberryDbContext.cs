using LingonberryStudio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LingonberryStudio.Data
{
    public class LingonberryDbContext : DbContext
    {
        public LingonberryDbContext(DbContextOptions<LingonberryDbContext> options) : base(options)
        {

        }

        public DbSet<Advert> Adverts { get; set; }

    }
}

