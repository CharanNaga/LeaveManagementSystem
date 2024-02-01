using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class RenamedIsApprovedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAppoved",
                table: "LeaveRequests",
                newName: "IsApproved");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "4288b6d3-d238-445a-80d2-358d310accc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "2bcecb33-5527-4b71-8474-eca09adccd81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a185d767-55f6-4226-8d6b-54c301078527", "AQAAAAEAACcQAAAAENMnpgIfis7yQpC3u7LI5iee8+xsGpLigg5m3x03a8G7p5fOQfrDI0gfY+PyVd7fQQ==", "5bf4a977-f0e1-4a7c-9068-2053290f0225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b2457f8-fd49-4472-9d49-c3cc8f65fb15", "AQAAAAEAACcQAAAAEHLGhiuC+OEJeu+E6+v7eEctycRjGqBt5CfMDS2UcmVgN7MBQHvZkLD2tNm98HVKmg==", "ed33eacb-ef1f-4611-9bde-0aeb665f4b73" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "LeaveRequests",
                newName: "IsAppoved");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "25cb0452-9f89-4877-b835-c06afbce0c65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "3804f133-1ea8-46eb-8d24-f6c4919dafd4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ac66a01-a8a1-40bf-9cbc-5ab2e08cab7f", "AQAAAAEAACcQAAAAEKHWNuZriq93cgERwC+heQNaHMXBuQjhAM3gx6dT6tcBxfjsAjVMFmD4gYg9Heg04w==", "567bce8f-396c-45dc-9fa2-14400083e720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c51d8f2-e4c1-4b10-a673-efc7b84bcb63", "AQAAAAEAACcQAAAAELaMwkv2hcbbXtSqsGJ4HTYGQlb3zWZmfAX79UW3KJuALRm/hUq/cosDODxXm0pvxQ==", "d6cb8a45-51d7-4c82-b183-58bd9fcc3572" });
        }
    }
}
