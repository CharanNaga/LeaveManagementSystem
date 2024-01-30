using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98C71863-BE20-4C2F-A0D5-DA3DE78193C7", "1943e865-067f-48b2-9310-7c10d65f409c", "User", "USER" },
                    { "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3", "8eb133e0-ffe1-4d80-a6e1-1b55de395189", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58", 0, "d69b3861-c9f3-4e37-9977-88f8d028d04c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAECh08356KHbwbGBYTlzpF+Qe+uk//nKFATYJZ/SZBSonvo4TXUvgrr8NPShedqwYVQ==", null, false, "8be0d102-5112-416c-a64c-72d01e8e8381", null, false, null },
                    { "FBCE25C0-9092-4A1D-86F0-3F0D73D03768", 0, "e06a194a-b55d-4a6b-a061-195bf5e500a4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAELR3ouuheS0sF4D2/AVcsvUhnRPL6iViv4pc5TmvP2iE+TTMSFe3W4UPebggyy8DMw==", null, false, "59edd7dc-2955-49b2-a21f-bde925c3a256", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3", "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98C71863-BE20-4C2F-A0D5-DA3DE78193C7", "FBCE25C0-9092-4A1D-86F0-3F0D73D03768" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3", "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98C71863-BE20-4C2F-A0D5-DA3DE78193C7", "FBCE25C0-9092-4A1D-86F0-3F0D73D03768" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768");
        }
    }
}
