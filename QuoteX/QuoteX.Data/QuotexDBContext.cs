using Microsoft.EntityFrameworkCore;
using Quotex.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteX.Data
{
    public class QuotexDBContext : DbContext
    {
        public QuotexDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User {Id = 1, Username = "admin", Password = "adminPassword", Role = "Admin", Quotes = null }
                );
        }
    }
}
