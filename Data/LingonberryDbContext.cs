﻿using LingonberryStudio.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LingonberryStudio.Data
{
    public class LingonberryDbContext : DbContext
    {
        public LingonberryDbContext(DbContextOptions<LingonberryDbContext> options) : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Facilitie> Facilities { get; set; }
        public DbSet<DatesAndTime> DatesAndTimes { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Measurement> Measurements { get; set; }


    }
}

