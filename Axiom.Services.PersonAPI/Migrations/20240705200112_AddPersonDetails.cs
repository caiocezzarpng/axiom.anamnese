using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axiom.Services.PersonAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedProfessionalMassage = table.Column<bool>(type: "bit", nullable: false),
                    PreferredTechniques = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceExpectations = table.Column<byte>(type: "tinyint", nullable: false),
                    PreferredTouchPressure = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PersonDetails_Persons_PersonId",
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
                name: "PersonDetails");
        }
    }
}
