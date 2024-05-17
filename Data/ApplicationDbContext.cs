using Microsoft.EntityFrameworkCore;
using NoahStener_KodprovLIA.Models.Entities;
using System;

namespace NoahStener_KodprovLIA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarIssue> CarIssues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Regnummer ska vara unikt för varje bil
            modelBuilder.Entity<Car>().HasIndex(c => c.RegNumber).IsUnique();



            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarID = 1,
                RegNumber = "ABC543",
                Model = "Volvo"
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarID = 2,
                RegNumber = "BBB123",
                Model = "Saab"
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarID = 3,
                RegNumber = "CCC741",
                Model = "Kia"
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarID = 4,
                RegNumber = "DAB092",
                Model = "Volvo"
            });

            modelBuilder.Entity<CarIssue>().HasData(new CarIssue
            {
                CarIssueID = 200,
                Description = "Motorfel",
                IssueReported = new DateTime(2024, 05, 08),
                CarID = 1,
            });

            modelBuilder.Entity<CarIssue>().HasData(new CarIssue
            {
                CarIssueID = 201,
                Description = "Fel med växellåda",
                IssueReported = new DateTime(2024, 05, 08),
                CarID = 3,
            });

            modelBuilder.Entity<CarIssue>().HasData(new CarIssue
            {
                CarIssueID = 202,
                Description = "Punktering",
                IssueReported = new DateTime(2024, 05, 08),
                CarID = 2,
            });

            modelBuilder.Entity<CarIssue>().HasData(new CarIssue
            {
                CarIssueID = 203,
                Description = "Elektroniskt problem",
                IssueReported = new DateTime(2024, 05, 08),
                CarID = 1,
            });
        }
    }
}
