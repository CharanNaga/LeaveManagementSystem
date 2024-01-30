using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedUserNameForDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "61ad2459-841b-4fb7-9828-945192ec023f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "6f4b77c0-91db-4469-bf58-8540e8d50a06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d234f4dc-0b5c-41ca-89b1-5303b71065ef", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEEbd6DaM39fUsIWgQyd+s6uvfD756eNrUpMha/JLkj1fLFvO4Ms8bIIIQIqmlyAWRw==", "eb8fcb63-9405-4e5b-9fcc-1596fbef63bc", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2c78fc08-0feb-4f92-9d5c-b85957933e89", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAECDqtqX4L1JBBTkL6RykPVnbVCby3MRz+C0WmNfodAm85kkL65grZvxyHvtz26C2fA==", "61b5d7e5-1d2e-4819-a1e5-659e054b6fe0", "user@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "1943e865-067f-48b2-9310-7c10d65f409c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "8eb133e0-ffe1-4d80-a6e1-1b55de395189");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d69b3861-c9f3-4e37-9977-88f8d028d04c", false, null, "AQAAAAEAACcQAAAAECh08356KHbwbGBYTlzpF+Qe+uk//nKFATYJZ/SZBSonvo4TXUvgrr8NPShedqwYVQ==", "8be0d102-5112-416c-a64c-72d01e8e8381", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e06a194a-b55d-4a6b-a061-195bf5e500a4", false, null, "AQAAAAEAACcQAAAAELR3ouuheS0sF4D2/AVcsvUhnRPL6iViv4pc5TmvP2iE+TTMSFe3W4UPebggyy8DMw==", "59edd7dc-2955-49b2-a21f-bde925c3a256", null });
        }
    }
}
