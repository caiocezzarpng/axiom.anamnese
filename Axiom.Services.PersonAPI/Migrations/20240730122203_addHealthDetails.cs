using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axiom.Services.PersonAPI.Migrations
{
    /// <inheritdoc />
    public partial class addHealthDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ocuppation",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceExpectations",
                table: "PersonDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "PreferredTouchPressure",
                table: "PersonDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "HealthDetails",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalTreatment = table.Column<byte>(type: "tinyint", nullable: false),
                    TreatmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakingContinuousMedication = table.Column<byte>(type: "tinyint", nullable: false),
                    MedicationsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAllergies = table.Column<byte>(type: "tinyint", nullable: false),
                    AllergiesList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureLevel = table.Column<int>(type: "int", nullable: false),
                    HadRecentSurgery = table.Column<byte>(type: "tinyint", nullable: false),
                    RecentSurgeryList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasProsthesisPinPlate = table.Column<byte>(type: "tinyint", nullable: false),
                    ProsthesisPinPlateList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pregnant = table.Column<byte>(type: "tinyint", nullable: false),
                    WeeksPregnant = table.Column<int>(type: "int", nullable: false),
                    HighRiskPregnancy = table.Column<byte>(type: "tinyint", nullable: false),
                    DoExercises = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeeklyFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakesRepetitiveMovement = table.Column<byte>(type: "tinyint", nullable: false),
                    Considerations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthDetails", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_HealthDetails_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Ocuppation",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ServiceExpectations",
                table: "PersonDetails",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "PreferredTouchPressure",
                table: "PersonDetails",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
