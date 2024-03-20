using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration2702V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvolvedParties",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tips",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "InvolvedParties",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Tips",
                table: "Exercises");
        }
    }
}
