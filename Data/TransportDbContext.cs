﻿using Microsoft.EntityFrameworkCore;
using UBB_SE_2025_EUROTRUCKERS.Models;

namespace UBB_SE_2025_EUROTRUCKERS.Data
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Truck> trucks { get; set; }
        public DbSet<Delivery> deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones del modelo
            modelBuilder.Entity<Delivery>()
                .HasKey(d => d.delivery_id);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.driver)
                .WithMany()
                .HasForeignKey(d => d.driver_id);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.truck)
                .WithMany()
                .HasForeignKey(d => d.truck_id);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.company)
                .WithMany()
                .HasForeignKey(d => d.company_id);

            modelBuilder.Entity<Delivery>().ToTable("deliveries","transport");
        }
    }
}
