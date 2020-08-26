using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)  {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        ProductId = 1,
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Price = 275,
                        Category = "Watersports"
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "LifeJacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "Corner Flags",
                        Description = "Give your field a proffesional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        ProductId = 5,
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        ProductId = 6,
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        ProductId = 7,
                        Name = "Unsteadly Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        ProductId = 8,
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        ProductId = 9,
                        Name = "Bling-Bling Board",
                        Description = "Gold-plated, diamond-stuffed King",
                        Category = "Chess",
                        Price = 1200
                    }
                );

        }
    }
}
