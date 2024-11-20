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
        var adminRoleId = "5768A50E-31B6-4933-B3B3-B0336F5656E6";
        var adminId = "7642BE16-2C21-40F0-81BB-CE85B30B0783";

        var manageRoleId = "F621A3F0-4989-4646-9E9C-9A34CC279A70";
        var manageId = "57ADB60C-DBE4-4903-B281-030A9331279D";

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = adminRoleId,
            Name = "admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = manageRoleId,
            Name = "manager",
            NormalizedName = "MANAGER"
        });

        // Seed dữ liệu cho user
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
        {
            Id = adminId,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "duccong29092003@gmail.com",
            NormalizedEmail = "DUCCONG29092003@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "Cong",
            LastName = "Do"
        },
        new ApplicationUser
        {
            Id = manageId,
            UserName = "manager",
            NormalizedUserName = "MANAGER",
            Email = "manager1@gmail.com",
            NormalizedEmail = "MANAGER1@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "Long",
            LastName = "Do"
        });

        // Seed dữ liệu cho UserRoles (AspNetUserRoles)
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            },
            new IdentityUserRole<string>
            {
                RoleId = manageRoleId,
                UserId = manageId
            });
    }


}
