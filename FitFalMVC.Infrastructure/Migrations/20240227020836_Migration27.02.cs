using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration2702 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyPartExercise_BodyParts_BodyPartExercisesId",
                table: "BodyPartExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_BodyPartExercise_Exercises_TypeId",
                table: "BodyPartExercise");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "BodyPartExercise",
                newName: "ExercisesId");

            migrationBuilder.RenameColumn(
                name: "BodyPartExercisesId",
                table: "BodyPartExercise",
                newName: "BodyPartId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyPartExercise_TypeId",
                table: "BodyPartExercise",
                newName: "IX_BodyPartExercise_ExercisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPartExercise_BodyParts_BodyPartId",
                table: "BodyPartExercise",
                column: "BodyPartId",
                principalTable: "BodyParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPartExercise_Exercises_ExercisesId",
                table: "BodyPartExercise",
                column: "ExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyPartExercise_BodyParts_BodyPartId",
                table: "BodyPartExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_BodyPartExercise_Exercises_ExercisesId",
                table: "BodyPartExercise");

            migrationBuilder.RenameColumn(
                name: "ExercisesId",
                table: "BodyPartExercise",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "BodyPartId",
                table: "BodyPartExercise",
                newName: "BodyPartExercisesId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyPartExercise_ExercisesId",
                table: "BodyPartExercise",
                newName: "IX_BodyPartExercise_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPartExercise_BodyParts_BodyPartExercisesId",
                table: "BodyPartExercise",
                column: "BodyPartExercisesId",
                principalTable: "BodyParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyPartExercise_Exercises_TypeId",
                table: "BodyPartExercise",
                column: "TypeId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
