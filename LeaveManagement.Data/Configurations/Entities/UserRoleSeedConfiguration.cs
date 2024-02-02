using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string> //for admin
                    {
                        RoleId = "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3", //same as id in roleseedconfiguration.cs
                        UserId = "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58" //same as id in userseedconfiguration.cs
                    },
                    new IdentityUserRole<string> //for user
                    {
                        RoleId = "98C71863-BE20-4C2F-A0D5-DA3DE78193C7", //same as id in 2nd roleseedconfiguration object
                        UserId = "FBCE25C0-9092-4A1D-86F0-3F0D73D03768" //same as id in 2nd userseedconfiguration object
                    }
                );
        }
    }
}