using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.EF
{
    public partial class PhoneShopDbContext : DbContext
    {
        public PhoneShopDbContext()
        {
        }

        public PhoneShopDbContext(DbContextOptions<PhoneShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategory> TbCategories { get; set; } = null!;
        public virtual DbSet<TbCustomer> TbCustomers { get; set; } = null!;
        public virtual DbSet<TbCustomerHistory> TbCustomerHistories { get; set; } = null!;
        public virtual DbSet<TbEmployee> TbEmployees { get; set; } = null!;
        public virtual DbSet<TbEmployeePermission> TbEmployeePermissions { get; set; } = null!;
        public virtual DbSet<TbInventory> TbInventories { get; set; } = null!;
        public virtual DbSet<TbManufacturer> TbManufacturers { get; set; } = null!;
        public virtual DbSet<TbOrder> TbOrders { get; set; } = null!;
        public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; } = null!;
        public virtual DbSet<TbProduct> TbProducts { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AVPLSS5\\SQLEXPRESS;Initial Catalog=PhoneShopManagementDB;User ID=sa;Password=Satrymra2003!;TrustServerCertificate=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__tbCatego__A9FDEC1208FCD229");

                entity.ToTable("tbCategory");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("C_Name");
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__tbCustom__A9FDEC12673BF399");

                entity.ToTable("tbCustomer");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CAddress)
                    .HasMaxLength(200)
                    .HasColumnName("C_Address");

                entity.Property(e => e.CEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("C_Email");

                entity.Property(e => e.CName)
                    .HasMaxLength(50)
                    .HasColumnName("C_Name");

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("C_Phone");
            });

            modelBuilder.Entity<TbCustomerHistory>(entity =>
            {
                entity.HasKey(e => new { e.CId, e.OId });

                entity.ToTable("tbCustomer_History");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.OId).HasColumnName("O_ID");

                entity.Property(e => e.ChPurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("CH_PurchaseDate");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.TbCustomerHistories)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbCustomer__C_ID__239E4DCF");

                entity.HasOne(d => d.OIdNavigation)
                    .WithMany(p => p.TbCustomerHistories)
                    .HasForeignKey(d => d.OId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbCustomer__O_ID__24927208");
            });

            modelBuilder.Entity<TbEmployee>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK__tbEmploy__D730AF542A9F69C1");

                entity.ToTable("tbEmployee");

                entity.Property(e => e.EId)
                    .ValueGeneratedNever()
                    .HasColumnName("E_ID");

                entity.Property(e => e.EAddress)
                    .HasMaxLength(200)
                    .HasColumnName("E_Address");

                entity.Property(e => e.EName)
                    .HasMaxLength(50)
                    .HasColumnName("E_Name");

                entity.Property(e => e.EPassword)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("E_Password");

                entity.Property(e => e.EPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("E_Phone");

                entity.Property(e => e.EUserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_UserName");
            });

            modelBuilder.Entity<TbEmployeePermission>(entity =>
            {
                entity.HasKey(e => e.EId);

                entity.ToTable("tbEmployee_Permissions");

                entity.Property(e => e.EId)
                    .ValueGeneratedNever()
                    .HasColumnName("E_ID");

                entity.Property(e => e.EReadPermission).HasColumnName("E_ReadPermission");

                entity.Property(e => e.ETableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("E_TableName");

                entity.Property(e => e.EWritePermission).HasColumnName("E_WritePermission");

                entity.HasOne(d => d.EIdNavigation)
                    .WithOne(p => p.TbEmployeePermission)
                    .HasForeignKey<TbEmployeePermission>(d => d.EId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbEmployee__E_ID__29572725");
            });

            modelBuilder.Entity<TbInventory>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK_Inventory");

                entity.ToTable("tbInventory");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("P_ID");

                entity.Property(e => e.PQuantity).HasColumnName("P_Quantity");

                entity.HasOne(d => d.PIdNavigation)
                    .WithOne(p => p.TbInventory)
                    .HasForeignKey<TbInventory>(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbInventor__P_ID__182C9B23");
            });

            modelBuilder.Entity<TbManufacturer>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK__tbManufa__18B1A31756039C2F");

                entity.ToTable("tbManufacturer");

                entity.Property(e => e.MId).HasColumnName("M_ID");

                entity.Property(e => e.MAddress)
                    .HasMaxLength(500)
                    .HasColumnName("M_Address");

                entity.Property(e => e.MEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("M_Email");

                entity.Property(e => e.MName)
                    .HasMaxLength(50)
                    .HasColumnName("M_Name");

                entity.Property(e => e.MPhone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("M_Phone");
            });

            modelBuilder.Entity<TbOrder>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__tbOrder__5AAB0C18FEC12BC8");

                entity.ToTable("tbOrder");

                entity.Property(e => e.OId).HasColumnName("O_ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.ODate)
                    .HasColumnType("date")
                    .HasColumnName("O_Date");

                entity.Property(e => e.OStatus).HasColumnName("O_Status");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.TbOrders)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__tbOrder__C_ID__1CF15040");
            });

            modelBuilder.Entity<TbOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.PId, e.OId });

                entity.ToTable("tbOrder_Detail");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.OId).HasColumnName("O_ID");

                entity.Property(e => e.OdQuantity).HasColumnName("OD_Quantity");

                entity.HasOne(d => d.OIdNavigation)
                    .WithMany(p => p.TbOrderDetails)
                    .HasForeignKey(d => d.OId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbOrder_De__O_ID__20C1E124");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TbOrderDetails)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbOrder_De__P_ID__1FCDBCEB");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__tbProduc__A3420A7798F0F559");

                entity.ToTable("tbProduct");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.MId).HasColumnName("M_ID");

                entity.Property(e => e.PBatteryCapacity)
                    .HasMaxLength(20)
                    .HasColumnName("P_Battery_Capacity");

                entity.Property(e => e.PCamera)
                    .HasMaxLength(20)
                    .HasColumnName("P_Camera");

                entity.Property(e => e.PColor)
                    .HasMaxLength(20)
                    .HasColumnName("P_Color");

                entity.Property(e => e.PConnectivity)
                    .HasMaxLength(50)
                    .HasColumnName("P_Connectivity");

                entity.Property(e => e.PDescriptions).HasColumnName("P_Descriptions");

                entity.Property(e => e.PDimensions)
                    .HasMaxLength(50)
                    .HasColumnName("P_Dimensions");

                entity.Property(e => e.PImages)
                    .IsUnicode(false)
                    .HasColumnName("P_Images");

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .HasColumnName("P_Name");

                entity.Property(e => e.POperatingSystem)
                    .HasMaxLength(20)
                    .HasColumnName("P_Operating_System");

                entity.Property(e => e.PPrice).HasColumnName("P_Price");

                entity.Property(e => e.PRam)
                    .HasMaxLength(20)
                    .HasColumnName("P_Ram");

                entity.Property(e => e.PResolution)
                    .HasMaxLength(20)
                    .HasColumnName("P_Resolution");

                entity.Property(e => e.PScreenSize)
                    .HasMaxLength(20)
                    .HasColumnName("P_Screen_Size");

                entity.Property(e => e.PStorage)
                    .HasMaxLength(20)
                    .HasColumnName("P_Storage");

                entity.Property(e => e.PWeights)
                    .HasMaxLength(20)
                    .HasColumnName("P_Weights");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbProduct__C_ID__15502E78");

                entity.HasOne(d => d.MIdNavigation)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.MId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbProduct__M_ID__145C0A3F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
