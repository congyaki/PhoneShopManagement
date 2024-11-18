using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneShop.AdminApp.Areas.Identity.Data;

namespace PhoneShop.AdminApp.Areas.Identity.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Thêm vai trò admin và manager
        var adminRoleId = new Guid("5768A50E-31B6-4933-B3B3-B0336F5656E6");
        var adminId = new Guid("7642BE16-2C21-40F0-81BB-CE85B30B0783");

        var manageRoleId = new Guid("F621A3F0-4989-4646-9E9C-9A34CC279A70");
        var manageId = new Guid("57ADB60C-DBE4-4903-B281-030A9331279D");

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = adminRoleId.ToString(),
            Name = "admin",
            NormalizedName = "admin"
        },
        new IdentityRole
        {
            Id = manageRoleId.ToString(),
            Name = "manager",
            NormalizedName = "manager"
        });

        // Seed dữ liệu cho user
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
        {
            Id = adminId.ToString(),
            UserName = "admin",
            NormalizedUserName = "admin".ToUpper(),
            Email = "duccong29092003@gmail.com",
            NormalizedEmail = "duccong29092003@gmail.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "Cong",
            LastName = "Do"
        },
        new ApplicationUser
        {
            Id = manageId.ToString(),
            UserName = "manager",
            NormalizedUserName = "manager".ToUpper(),
            Email = "manager1@gmail.com",
            NormalizedEmail = "manager1@gmail.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "Long",
            LastName = "Do"
        });

        // Chỉ định khóa chính cho IdentityUserRole
        builder.Entity<IdentityUserRole<Guid>>().HasKey(r => new { r.UserId, r.RoleId });

        // Seed dữ liệu cho UserRoles
        builder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            },
            new IdentityUserRole<Guid>
            {
                RoleId = manageRoleId,
                UserId = manageId
            });
    }

}
