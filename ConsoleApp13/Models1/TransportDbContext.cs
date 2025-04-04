//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace ConsoleApp13.Models1;

//public partial class TransportDbContext : DbContext
//{
//    public TransportDbContext()
//    {
//    }

//    public TransportDbContext(DbContextOptions<TransportDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Car> Cars { get; set; }

//    public virtual DbSet<City> Cities { get; set; }

//    public virtual DbSet<Way> Ways { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TransportDB;Integrated Security=True;Encrypt=False");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Car>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC07A8046B3B");

//            entity.Property(e => e.Coeffiecnt)
//                .HasDefaultValueSql("((1.0))")
//                .HasColumnType("decimal(4, 2)");
//            entity.Property(e => e.Mark).HasMaxLength(50);
//            entity.Property(e => e.Model).HasMaxLength(50);
//            entity.Property(e => e.Type).HasMaxLength(50);
//        });

//        modelBuilder.Entity<City>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__City__3214EC0799E99048");

//            entity.ToTable("City");

//            entity.Property(e => e.Name).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Way>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Way__3214EC07DECBD631");

//            entity.ToTable("Way");

//            entity.Property(e => e.StartPrice).HasColumnType("decimal(20, 2)");

//            entity.HasOne(d => d.CityFrom).WithMany(p => p.WayCityFroms)
//                .HasForeignKey(d => d.CityFromId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CityFrom");

//            entity.HasOne(d => d.CityTo).WithMany(p => p.WayCityTos)
//                .HasForeignKey(d => d.CityToId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CityTo");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
