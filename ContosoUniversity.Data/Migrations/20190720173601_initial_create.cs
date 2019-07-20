using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Data.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "office_assignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    location = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_assignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    hire_date = table.Column<DateTime>(nullable: true),
                    enrollment_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    budget = table.Column<decimal>(type: "money", nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    instructor_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_department_person_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    code = table.Column<string>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    credits = table.Column<int>(nullable: false),
                    department_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_assignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    instructor_id = table.Column<Guid>(nullable: false),
                    course_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_assignment_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_assignment_person_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    grade = table.Column<int>(nullable: false),
                    course_id = table.Column<Guid>(nullable: false),
                    student_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrollment_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollment_person_student_id",
                        column: x => x.student_id,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_department_id",
                table: "course",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_assignment_course_id",
                table: "course_assignment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_assignment_instructor_id",
                table: "course_assignment",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_instructor_id",
                table: "department",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_course_id",
                table: "enrollment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_student_id",
                table: "enrollment",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_assignment");

            migrationBuilder.DropTable(
                name: "enrollment");

            migrationBuilder.DropTable(
                name: "office_assignment");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
