using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class MadeRequestCommentsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98C71863-BE20-4C2F-A0D5-DA3DE78193C7",
                column: "ConcurrencyStamp",
                value: "d9ab316a-d2c7-4c96-b1b9-34632baf50be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D8F882CD-1FF0-4CD7-BF4F-0AA85CD27DF3",
                column: "ConcurrencyStamp",
                value: "5998af60-5d6d-4178-afcd-493fd454d654");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F5BC4ECE-E0D9-46B4-9763-FDD3D6745B58",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf024da2-db28-4253-9ea4-01216e41d14f", "AQAAAAEAACcQAAAAEIqiL/sYGMUhiojPECiuggRKxE5L3IGQFC+VNO5n47bIuAdizsXC5DKChdu1JJs/gw==", "256783d1-c4ee-4d3a-a35a-81e86659e81e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FBCE25C0-9092-4A1D-86F0-3F0D73D03768",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bcbde73-6ffb-487b-a23a-4d081ff8b632", "AQAAAAEAACcQAAAAEPdYcoP2xID/JyVj/Hfb6c9DKrRjquqO5zPPMIFn4YBi8RTkFWyzsE4vTyYjXNIPbA==", "644ed854-2711-45ac-be6b-767afca233a4" });
        }
    }
}
