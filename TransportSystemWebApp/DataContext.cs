using TransportSystemWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystemWebApp;

public class DataContext : DbContext
{
    private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=TransportCompanyDB;Integrated Security=True;Encrypt=False";

    public DbSet<Car> Cars { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Way> Ways { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CarType> CarTypes { get; set; }

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
        
        modelBuilder.Entity<Car>()
            .HasOne(o => o.Type)
            .WithMany(c => c.Cars)
            .HasForeignKey(w => w.CarTypeId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<Order>()
             .HasOne(o => o.WayObj)
             .WithMany(w => w.Orders)
             .HasForeignKey(w => w.WayId)
             .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.CarObj)
            .WithMany(c => c.Orders)
            .HasForeignKey(w => w.CarId)
            .OnDelete(DeleteBehavior.ClientNoAction);



    }

}
