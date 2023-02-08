using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutapplicationservices.Migrations
{
    /// <inheritdoc />
    public partial class ADDEDConfigureDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "caloriesGoalResult",
                table: "ExerciseDatas",
                newName: "caloriesBurnedGoalResult");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "caloriesBurnedGoalResult",
                table: "ExerciseDatas",
                newName: "caloriesGoalResult");
        }
    }
}
