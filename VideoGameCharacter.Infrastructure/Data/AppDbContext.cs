using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Domain.Entities;

namespace VideoGameCharacter.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed Roles
        var adminRoleId = "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a";
        var userRoleId = "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a";

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0e" },
            new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER", ConcurrencyStamp = "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0f" }
        );

        // Seed Admin User
        var adminUserId = "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a";
        var adminUser = new IdentityUser
        {
            Id = adminUserId,
            UserName = "admin@videogame.com",
            NormalizedUserName = "ADMIN@VIDEOGAME.COM",
            Email = "admin@videogame.com",
            NormalizedEmail = "ADMIN@VIDEOGAME.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEAfTkxvr0sgR0Zdqh6VMeoLzMc4DzP7G3j0eLr7H5nZYAIPiCydjgeZsP2rg8H0Ksw==",
            SecurityStamp = "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0g",
            ConcurrencyStamp = "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0h"
        };
        // Original code  replaced:
       // adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");
        builder.Entity<IdentityUser>().HasData(adminUser);

        // Assign Admin role to Admin user
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        });
    }
}
