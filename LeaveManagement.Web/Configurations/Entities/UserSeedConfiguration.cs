using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hashPassword = new PasswordHasher<Employee>(); //aspnet users table
            builder.HasData(
                new Employee //admin user
                {
                    Id = "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hashPassword.HashPassword(null, "Admin@123"),
                    EmailConfirmed = true
                },
                new Employee //normal user
                {
                    Id = "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hashPassword.HashPassword(null, "User@123"),
                    EmailConfirmed = true
                }
            );
        }
    }
}