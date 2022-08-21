using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace jwtcore.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    AdvisorId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StaffId = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.AdvisorId);
                });

            migrationBuilder.CreateTable(
                name: "Authentications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FacultyCode = table.Column<string>(nullable: false),
                    FacultyDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ProgramId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProgramCode = table.Column<string>(nullable: false),
                    ProgramDescription = table.Column<string>(nullable: false),
                    StudentUwiId = table.Column<string>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true),
                    AdvisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_Programmes_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programmes_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LevelCode = table.Column<string>(nullable: false),
                    LevelDescription = table.Column<string>(nullable: false),
                    ProgrammeProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                    table.ForeignKey(
                        name: "FK_Levels_Programmes_ProgrammeProgramId",
                        column: x => x.ProgrammeProgramId,
                        principalTable: "Programmes",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MajCode = table.Column<string>(nullable: true),
                    MajDesc = table.Column<string>(nullable: true),
                    StudentUwiId = table.Column<string>(nullable: true),
                    ProgrammeProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                    table.ForeignKey(
                        name: "FK_Specializations_Programmes_ProgrammeProgramId",
                        column: x => x.ProgrammeProgramId,
                        principalTable: "Programmes",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentUwiId = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    ProgrammeProgramId = table.Column<int>(nullable: true),
                    AdvisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Programmes_ProgrammeProgramId",
                        column: x => x.ProgrammeProgramId,
                        principalTable: "Programmes",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Levels_ProgrammeProgramId",
                table: "Levels",
                column: "ProgrammeProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_AdvisorId",
                table: "Programmes",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_FacultyId",
                table: "Programmes",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_ProgrammeProgramId",
                table: "Specializations",
                column: "ProgrammeProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdvisorId",
                table: "Students",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgrammeProgramId",
                table: "Students",
                column: "ProgrammeProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentications");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
