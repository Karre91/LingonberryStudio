using LingonberryStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace LingonberryStudio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<FormModel> AdvertsDb { get; set; }

    }
}

