using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoomBookingPocos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoomBookingEntityFrameworkDataAccess
{
    public class RoomBookingContext : DbContext
    {
        public DbSet<BookingsPoco> Bookings { get; set; }

        public DbSet<PaymentTranscationPoco> PaymentTranscations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;

            optionsBuilder.UseSqlServer(_connStr);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookingsPoco>(
                entity =>
                {
                    modelBuilder.Entity<BookingsPoco>()
                        .HasOne<PaymentTranscationPoco>(s => s.PaymentTranscation)
                        .WithOne(ad => ad.Booking)
                        .HasForeignKey<PaymentTranscationPoco>(ad => ad.BookingID);

                }
                );
            modelBuilder.Entity<PaymentTranscationPoco>(
                entity => { entity.HasKey(pt => pt.PaymentTranscationID); });

            base.OnModelCreating(modelBuilder);
        }
    }
}
