using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAppoved = table.Column<bool>(type: "bit", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
