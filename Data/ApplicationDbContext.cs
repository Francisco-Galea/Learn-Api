﻿using Microsoft.EntityFrameworkCore;
using TestApi.Models.Entities;

namespace TestApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {  
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemOrdered> ItemsOrdered { get; set; }
    }
}
