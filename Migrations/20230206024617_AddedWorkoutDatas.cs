using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutapplicationservices.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkoutDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exerciseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTimeResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endTimeResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caloriesBurnedResult = table.Column<int>(type: "int", nullable: false),
                    caloriesGoalResult = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDatas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDatas");
        }
    }
}
