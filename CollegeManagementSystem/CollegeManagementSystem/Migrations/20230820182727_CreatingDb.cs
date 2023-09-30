using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "first_Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_end = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schedules_Courses_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete:ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contact_add = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_Courses_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.studentId, x.courseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StudentCourses_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schedules_CoursesID",
                table: "schedules",
                column: "CoursesID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_courseId",
                table: "StudentCourses",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentID",
                table: "students",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "first_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "last_Name",
                table: "AspNetUsers");
        }
    }
}
