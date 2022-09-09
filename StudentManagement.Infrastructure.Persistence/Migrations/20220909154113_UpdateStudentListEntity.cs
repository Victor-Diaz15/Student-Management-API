using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Infrastructure.Persistence.Migrations
{
    public partial class UpdateStudentListEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Student_Lists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Student_Lists");
        }
    }
}
