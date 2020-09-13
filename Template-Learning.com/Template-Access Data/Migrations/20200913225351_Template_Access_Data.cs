using Microsoft.EntityFrameworkCore.Migrations;

namespace Template_Access_Data.Migrations
{
    public partial class Template_Access_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    EstudianteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Legajo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.EstudianteID);
                });

            migrationBuilder.InsertData(
                table: "Estudiante",
                columns: new[] { "EstudianteID", "Apellido", "Email", "Legajo", "Nombre" },
                values: new object[] { 1, "jorge", "gfdgfg4", 345, "Octavio" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
