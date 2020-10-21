using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Persona.AccessData.Migrations
{
    public partial class Persona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "Estudiante",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Estudiante");
        }
    }
}
