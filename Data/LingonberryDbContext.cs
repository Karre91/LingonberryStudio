using Microsoft.EntityFrameworkCore;
using LingonberryStudio.Data.Entities;

namespace LingonberryStudio.Data
{
    public class LingonberryDbContext : DbContext
    {
        public LingonberryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
    }
}
