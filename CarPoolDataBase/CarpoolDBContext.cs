using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPoolDataBase
{
    public partial class CarpoolDBContext : DbContext
    {
        public CarpoolDBContext()
        {
        }

        public CarpoolDBContext(DbContextOptions<CarpoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingTable> BookingTable { get; set; }
        public virtual DbSet<LocationTable> LocationTable { get; set; }
        public virtual DbSet<OfferTable> OfferTable { get; set; }
        public virtual DbSet<StationTable> StationTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }
        public virtual DbSet<VehicleTable> VehicleTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OBCVH11;Database=CarpoolDB;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPointId)
                    .IsRequired()
                    .HasColumnName("FromPointID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferId)
                    .IsRequired()
                    .HasColumnName("OfferID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerId)
                    .IsRequired()
                    .HasColumnName("PassengerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToPointId)
                    .IsRequired()
                    .HasColumnName("ToPointID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromPoint)
                    .WithMany(p => p.BookingTableFromPoint)
                    .HasForeignKey(d => d.FromPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingTable_LocationTable1");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.BookingTable)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingTable_OfferTable");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.BookingTable)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingTable_UserTable");

                entity.HasOne(d => d.ToPoint)
                    .WithMany(p => p.BookingTableToPoint)
                    .HasForeignKey(d => d.ToPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingTable_LocationTable");
            });

            modelBuilder.Entity<LocationTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OfferTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostperPoint).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DriverId)
                    .IsRequired()
                    .HasColumnName("DriverID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromPointId)
                    .IsRequired()
                    .HasColumnName("FromPointID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RideStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToPointId)
                    .IsRequired()
                    .HasColumnName("ToPointID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId)
                    .IsRequired()
                    .HasColumnName("VehicleID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.OfferTable)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferTable_UserTable");

                entity.HasOne(d => d.FromPoint)
                    .WithMany(p => p.OfferTableFromPoint)
                    .HasForeignKey(d => d.FromPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferTable_LocationTable1");

                entity.HasOne(d => d.ToPoint)
                    .WithMany(p => p.OfferTableToPoint)
                    .HasForeignKey(d => d.ToPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferTable_LocationTable");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.OfferTable)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferTable_VehicleTable");
            });

            modelBuilder.Entity<StationTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasColumnName("LocationID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferId)
                    .IsRequired()
                    .HasColumnName("OfferID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.StationTable)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationTable_OfferTable");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VehicleTable)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleTable_UserTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
