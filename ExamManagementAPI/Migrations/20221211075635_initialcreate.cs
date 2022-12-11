using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamManagementAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheoryQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheoryQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectiveQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_ObjectiveQuestions_ObjectiveQuestionId",
                        column: x => x.ObjectiveQuestionId,
                        principalTable: "ObjectiveQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveQuestions_ExamId",
                table: "ObjectiveQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_ObjectiveQuestionId",
                table: "QuestionOptions",
                column: "ObjectiveQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryQuestions_ExamId",
                table: "TheoryQuestions",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "TheoryQuestions");

            migrationBuilder.DropTable(
                name: "ObjectiveQuestions");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
