using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricBike.Infrastructure.Data.Migrations.CoreDb
{
    public partial class addreferencetobicycleentityandlinetomotorcycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Line",
                table: "Motorcycles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Bicycles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Bicycles");
        }
    }
}
