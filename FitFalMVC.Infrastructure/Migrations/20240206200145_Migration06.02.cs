using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration0602 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfEatings_Meals_MealId",
                table: "DayOfEatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_DayOfEatings_DayOfEatingId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_DayOfEatingId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_DayOfEatings_MealId",
                table: "DayOfEatings");

            migrationBuilder.DropColumn(
                name: "DayOfEatingId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "DayOfEatings");

            migrationBuilder.CreateTable(
                name: "DayOfEatingMeal",
                columns: table => new
                {
                    DayOfEatingsId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfEatingMeal", x => new { x.DayOfEatingsId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_DayOfEatingMeal_DayOfEatings_DayOfEatingsId",
                        column: x => x.DayOfEatingsId,
                        principalTable: "DayOfEatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayOfEatingMeal_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOfEatingMeal_MealsId",
                table: "DayOfEatingMeal",
                column: "MealsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOfEatingMeal");

            migrationBuilder.AddColumn<int>(
                name: "DayOfEatingId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "DayOfEatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DayOfEatingId",
                table: "Meals",
                column: "DayOfEatingId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfEatings_MealId",
                table: "DayOfEatings",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfEatings_Meals_MealId",
                table: "DayOfEatings",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_DayOfEatings_DayOfEatingId",
                table: "Meals",
                column: "DayOfEatingId",
                principalTable: "DayOfEatings",
                principalColumn: "Id");
        }
    }
}
