using ConsoleApp13.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class DataContext : DbContext
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=TransportDB1;Integrated Security=True;Encrypt=False";

        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Way>()
                .HasOne(w => w.CityFrom)
                .WithMany(c => c.WaysFrom)
                .HasForeignKey(w => w.CityFromId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Way>()
                .HasOne(w => w.CityTo)
                .WithMany(c => c.WaysTo)
                .HasForeignKey(w => w.CityToId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                 .HasOne(o => o.WayObj)
                 .WithMany()
                 .HasForeignKey(w => w.WayId)
                 .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.CarObj)
                .WithMany()
                .HasForeignKey(w => w.CarId)
                .OnDelete(DeleteBehavior.ClientNoAction);
               
        }

    }
}
