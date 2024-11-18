using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Enums;
using PhoneShop.Data.Extensions;

namespace PhoneShop.Data.EF;

public partial class PhoneShopDbContext : DbContext
{
    public PhoneShopDbContext()
    {
    }

    public PhoneShopDbContext(DbContextOptions<PhoneShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInCategory> ProductInCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AVPLSS5\\SQLEXPRESS;Initial Catalog=PhoneShopManagementDB;User ID=sa;Password=123456@Aa;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("tbCategory");

            entity.Property(e => e.CId).HasColumnName("C_Id").UseIdentityColumn();
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("C_Name");
            entity.Property(e => e.CSortOrder).HasColumnName("C_SortOrder");
            entity.Property(e => e.CParentId).HasColumnName("C_ParentId");
        });


        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("tbManufacturer");

            entity.Property(e => e.MId).HasColumnName("M_ID").UseIdentityColumn();
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

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("tbCustomer");
            entity.HasKey(e => e.CusId);
            entity.Property(e => e.CusId).HasColumnName("Cus_ID").UseIdentityColumn();
            entity.Property(e => e.CusName).HasColumnName("Cus_Name").HasMaxLength(50).IsRequired();
            entity.Property(e => e.CusAddress).HasColumnName("Cus_Address").HasMaxLength(200).IsRequired();
            entity.Property(e => e.CusEmail).HasColumnName("Cus_Email").HasMaxLength(50).IsRequired();
            entity.Property(e => e.CusPhone).HasColumnName("Cus_Phone").HasMaxLength(20).IsRequired();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId);

            entity.ToTable("tbOrder");

            entity.Property(e => e.OId).HasColumnName("O_ID").UseIdentityColumn();
            entity.Property(e => e.ODate).HasColumnType("date").HasColumnName("O_Date");
            entity.Property(e => e.OStatus).HasColumnName("O_Status");
            entity.Property(e => e.CusId).HasColumnName("Cus_ID");

            entity.HasOne(e => e.Customer).WithMany(e => e.OrderList).HasForeignKey(e => e.CusId);

        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.PId, e.OId });

            entity.ToTable("tbOrder_Detail");

            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.ODQuantity).HasColumnName("OD_Quantity");
            entity.Property(e => e.ODPrice).HasColumnName("OD_Price").HasColumnType("decimal(18,2)");

            entity.HasOne(e => e.Order).WithMany(e => e.OrderDetails).HasForeignKey(e => e.OId);
            entity.HasOne(e => e.Product).WithMany(e => e.OrderDetails).HasForeignKey(e => e.PId);

        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.ToTable("tbProduct");

            entity.Property(e => e.PId).HasColumnName("P_ID").UseIdentityColumn();
            entity.Property(e => e.PBatteryCapacity)
                .HasMaxLength(50)
                .HasColumnName("P_BatteryCapacity");
            entity.Property(e => e.PCamera)
                .HasMaxLength(50)
                .HasColumnName("P_Camera");
            entity.Property(e => e.PColor)
                .HasMaxLength(50)
                .HasColumnName("P_Color");
            entity.Property(e => e.PConnectivity)
                .HasMaxLength(50)
                .HasColumnName("P_Connectivity");
            entity.Property(e => e.PDescription).HasColumnName("P_Description");
            entity.Property(e => e.PDimension)
                .HasMaxLength(50)
                .HasColumnName("P_Dimension");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .HasColumnName("P_Name");
            entity.Property(e => e.POperatingSystem)
                .HasMaxLength(50)
                .HasColumnName("P_Operating_System");
            entity.Property(e => e.PRam)
                .HasMaxLength(50)
                .HasColumnName("P_Ram");
            entity.Property(e => e.PResolution)
                .HasMaxLength(50)
                .HasColumnName("P_Resolution");
            entity.Property(e => e.PScreenSize)
                .HasMaxLength(50)
                .HasColumnName("P_Screen_Size");
            entity.Property(e => e.PStorage)
                .HasMaxLength(50)
                .HasColumnName("P_Storage");
            entity.Property(e => e.PWeight)
                .HasMaxLength(50)
                .HasColumnName("P_Weights");
            entity.Property(e => e.PPrice).HasColumnName("P_Price").IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.POriginalPrice).HasColumnName("P_OriginalPrice").IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.PStock).HasColumnName("P_Stock").IsRequired().HasDefaultValue(0);
            entity.Property(e => e.PAvatar).HasColumnName("P_Avatar");
            entity.Property(e => e.MId).HasColumnName("M_Id");

            entity.HasOne(e => e.Manufacturer).WithMany(e => e.Products).HasForeignKey(e => e.MId);
        });


        modelBuilder.Entity<ProductInCategory>(entity =>
        {
            entity.HasKey(e => new { e.CId, e.PId });
            entity.ToTable("tbProductInCategory");
            entity.HasOne(e => e.Product).WithMany(e => e.ProductInCategories).HasForeignKey(e => e.PId);
            entity.HasOne(e => e.Category).WithMany(e => e.ProductInCategories).HasForeignKey(e => e.CId);

        });

        /*modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("tbAppUser");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Dob).IsRequired();


        });

        modelBuilder.Entity<AppRole>(entity =>
        {
            entity.ToTable("tbAppRole");
            entity.Property(e => e.Description).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("tbAppUserClaim");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("tbAppUserRole").HasKey(e => new {e.RoleId, e.UserId});
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("tbAppUserLogin").HasKey(e => e.UserId);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("tbAppRoleClaim");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("tbAppUserToken").HasKey(e => e.UserId);*/



        //Data Seeding
        modelBuilder.Seed();
        //
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
