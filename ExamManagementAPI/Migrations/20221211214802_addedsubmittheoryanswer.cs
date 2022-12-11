using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamManagementAPI.Migrations
{
    public partial class addedsubmittheoryanswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "TheoryQuestions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "TheoryQuestions");
        }
    }
}
