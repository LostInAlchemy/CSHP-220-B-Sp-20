using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryDatabase
{
    public partial class ClientApplicationsDatabaseContext : DbContext
    {
        public ClientApplicationsDatabaseContext()
        {
        }

        public ClientApplicationsDatabaseContext(DbContextOptions<ClientApplicationsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=ClientApplicationsDatabase;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.InventoryId)
                    .HasColumnName("Inventory_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Attributes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Desc).IsUnicode(false);

                entity.Property(e => e.DeviceName)
                    .HasColumnName("Device_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MfgName)
                    .HasColumnName("MFG_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartNumber)
                    .HasColumnName("Part_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
