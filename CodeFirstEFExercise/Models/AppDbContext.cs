using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstEFExercise.Models {
    public class AppDbContext : DbContext{

        /// <summary>
        /// All models must appear in the DbContext
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }

        public AppDbContext() {}


        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options){ }

        /// <summary>
        /// Contains method to configure connection and tools for DbContext and to create database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var connStr = @"server=localhost\sqlexpress;database=SalesDb28;trusted_connection=true;";
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        /// <summary>
        /// Fluent-Api goes here
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Product>(e => {
                e.Property("Code").HasMaxLength(8).IsRequired();
                e.HasIndex("Code").IsUnique();
            });
        }
    }
}
