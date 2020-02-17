using Microsoft.EntityFrameworkCore.Migrations;

namespace MLD.Migrations
{
    public partial class UserLymphSiteAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LymphSites",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LymphSites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LymphSites");

            migrationBuilder.InsertData(
                table: "LymphSites",
                columns: new[] { "Id", "IsAffected", "MaxMeasuringPoints", "Name", "NumMeasuringPoints" },
                values: new object[,]
                {
                    { 1, false, 8, "Head", 0 },
                    { 2, false, 30, "Right Arm", 0 },
                    { 3, false, 20, "Trunk", 0 },
                    { 4, false, 30, "Left Arm", 0 },
                    { 5, false, 8, "Groin", 0 },
                    { 6, false, 40, "Right Leg", 0 },
                    { 7, false, 40, "Left Leg", 0 }
                });
        }
    }
}
