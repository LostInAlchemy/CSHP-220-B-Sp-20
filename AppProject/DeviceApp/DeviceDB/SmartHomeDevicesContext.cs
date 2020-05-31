using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeviceDB
{
    public partial class SmartHomeDevicesContext : DbContext
    {
        public SmartHomeDevicesContext()
        {
        }

        public SmartHomeDevicesContext(DbContextOptions<SmartHomeDevicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeviceInventory> DeviceInventory { get; set; }
        public virtual DbSet<TypeInventory> TypeInventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=SmartHomeDevices;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceInventory>(entity =>
            {
                entity.Property(e => e.DeviceInventoryId)
                    .HasColumnName("Device_InventoryID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeviceAddedDate)
                    .HasColumnName("Device_AddedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceAttributes)
                    .HasColumnName("Device_Attributes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceControlledBy)
                    .HasColumnName("Device_ControlledBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceCost)
                    .HasColumnName("Device_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.DeviceDeviceName)
                    .IsRequired()
                    .HasColumnName("Device_DeviceName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceLocation)
                    .HasColumnName("Device_Location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceMfgdesc)
                    .HasColumnName("Device_MFGDesc")
                    .IsUnicode(false);

                entity.Property(e => e.DeviceMfgname)
                    .IsRequired()
                    .HasColumnName("Device_MFGName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DevicePartNumber)
                    .IsRequired()
                    .HasColumnName("Device_PartNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DevicePowerType)
                    .HasColumnName("Device_PowerType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceProtocol)
                    .IsRequired()
                    .HasColumnName("Device_Protocol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceSerialNumber)
                    .IsRequired()
                    .HasColumnName("Device_SerialNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceStatus)
                    .IsRequired()
                    .HasColumnName("Device_Status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasColumnName("Device_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeInventory>(entity =>
            {
                entity.Property(e => e.TypeInventoryId)
                    .HasColumnName("Type_InventoryID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TypeAddedDate)
                    .HasColumnName("Type_AddedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeDesc)
                    .HasColumnName("Type_Desc")
                    .IsUnicode(false);

                entity.Property(e => e.TypeType)
                    .IsRequired()
                    .HasColumnName("Type_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
