using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrandeTravel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "tb_TravelPackage");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "tb_TravelPackage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "tb_TravelPackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "tb_TravelPackage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
