using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FW_Assessment2.Models;
using Microsoft.EntityFrameworkCore;

namespace FW_Assessment2
{
    public class TrashBagsContext : DbContext
    {
      public TrashBagsContext(DbContextOptions<TrashBagsContext> options)
            : base(options)
        { }

        public DbSet<TrashBag> TrashBags { get; set; }
        public DbSet<Brand> Brands { get; set; }

        // seed database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          System.Diagnostics.Debug.WriteLine("HEREEEEEE");
            modelBuilder.Entity<TrashBag>().HasData(
                new TrashBag { Id = 1, BrandId = 1, Volume = 50, Compostable = false },
                new TrashBag { Id = 2, BrandId = 1, Volume = 30, Compostable = false },
                new TrashBag { Id = 3, BrandId = 1, Volume = 10, Compostable = true },
                new TrashBag { Id = 4, BrandId = 1, Volume = 100, Compostable = false },
                new TrashBag { Id = 5, BrandId = 1, Volume = 1000, Compostable = true }
            );
            
            modelBuilder.Entity<Brand>().HasData(
                new Brand {BrandId=1, Name="Killeen"},
                new Brand {BrandId=2, Name="Tesco" }
            );
        }
    }
}