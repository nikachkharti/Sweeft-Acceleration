using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sweeft.Console.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    PupilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.PupilID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPupil",
                columns: table => new
                {
                    PupilID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPupil", x => new { x.PupilID, x.TeacherID });
                    table.ForeignKey(
                        name: "FK_TeacherPupil_Pupils_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupils",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPupil_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "PupilID", "Class", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "SE-123", "Giorgi", "M", "Giorgadze" },
                    { 2, "SE-123", "Aleksandre", "M", "Maisuradze" },
                    { 3, "SE-123", "Mariam", "F", "Davitashvili" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "FirstName", "Gender", "LastName", "Subject" },
                values: new object[,]
                {
                    { 1, "Nika", "M", "Chkhartishvili", "History" },
                    { 2, "Zurab", "M", "Zurabishvili", "Biology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPupil_TeacherID",
                table: "TeacherPupil",
                column: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherPupil");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
