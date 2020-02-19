using Microsoft.EntityFrameworkCore.Migrations;

namespace MLD.Migrations
{
    public partial class removeUserFromMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Measurements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
