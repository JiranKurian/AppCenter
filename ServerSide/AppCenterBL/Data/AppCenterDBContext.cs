using AppCenterData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCenterData.Data
{
    public class AppCenterDBContext : DbContext
    {
        public DbSet<Login> Login { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Apps> Apps { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<AppHistory> AppHistory { get; set; }
        public DbSet<AppRating> AppRating { get; set; }
        public DbSet<AppUserUpdate> AppUserUpdate { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<FeedbackStatus> FeedbackStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AppCenterDB;Integrated Security=True");
        }
    }
}
