using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "720b7888-74ad-42ac-a47a-af4c70d0d0d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "61764e39-b1b0-477b-91c3-4d484dfa1322");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c30c8876-ea24-4349-812b-ed213c72bc6a", "AQAAAAEAACcQAAAAENQ2QncdpHQnK9AlEbfFID5K9gT3QOPX87723wO/+rxvfYeRlv1cP7uyrdK7+Y7efA==", "7a4ca6fc-d178-4c5f-8155-b79d71a145ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77df735c-5770-4590-b596-1e6310bccefc", "AQAAAAEAACcQAAAAECYmFp+NUWfiCKMq3HA51Qrz2KjrMpRsraoqGaNOor0Q/83sXPlnBhf9RRaSr6GmTA==", "f8b9af5f-67a5-4bd1-914c-f38010eeb864" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d234f4dc-0b5c-41ca-89b1-5303b71065ef", "AQAAAAEAACcQAAAAEEbd6DaM39fUsIWgQyd+s6uvfD756eNrUpMha/JLkj1fLFvO4Ms8bIIIQIqmlyAWRw==", "eb8fcb63-9405-4e5b-9fcc-1596fbef63bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c78fc08-0feb-4f92-9d5c-b85957933e89", "AQAAAAEAACcQAAAAECDqtqX4L1JBBTkL6RykPVnbVCby3MRz+C0WmNfodAm85kkL65grZvxyHvtz26C2fA==", "61b5d7e5-1d2e-4819-a1e5-659e054b6fe0" });
        }
    }
}
