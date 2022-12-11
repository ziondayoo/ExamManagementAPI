using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamManagementAPI.Migrations
{
    public partial class addedtheanswerfeild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "ObjectiveQuestions",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "ObjectiveQuestions");
        }
    }
}
