//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLD.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        public DbSet<LymphSite> LymphSites { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Circumference> Circumferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding LymphSite database
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 1, Name = "Head", MaxMeasuringPoints = 8, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 2, Name = "Right Arm", MaxMeasuringPoints = 30, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 3, Name = "Trunk", MaxMeasuringPoints = 20, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 4, Name = "Left Arm", MaxMeasuringPoints = 30, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 5, Name = "Groin", MaxMeasuringPoints = 8, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 6, Name = "Right Leg", MaxMeasuringPoints = 40, IsAffected = false });
            modelBuilder.Entity<LymphSite>().HasData(new LymphSite { Id = 7, Name = "Left Leg", MaxMeasuringPoints = 40, IsAffected = false });


            //seeding a development user
            //modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "test@test.com", Password = "password" });
        }
    }
}
