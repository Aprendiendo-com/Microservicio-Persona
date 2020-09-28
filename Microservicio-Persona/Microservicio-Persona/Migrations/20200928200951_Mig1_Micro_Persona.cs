using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Persona.Migrations
{
    public partial class Mig1_Micro_Persona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.EspecialidadId);
                });

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

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true),
                    EspecialidadNavegatorEspecialidadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ProfesorId);
                    table.ForeignKey(
                        name: "FK_Profesor_Especialidad_EspecialidadNavegatorEspecialidadId",
                        column: x => x.EspecialidadNavegatorEspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Estudiante",
                columns: new[] { "EstudianteID", "Apellido", "Email", "Legajo", "Nombre" },
                values: new object[,]
                {
                    { 1, "olivera", "pepeolivera@hotmail.com>", 1233, "pepe" },
                    { 2, "gonzalez", "pepag@hotmail.com>", 1234, "pepa" },
                    { 3, "perez", "juanperez@hotmail.com>", 1235, "juan" },
                    { 4, "lopez", "ariellopez@hotmail.com>", 1236, "ariel" }
                });

            migrationBuilder.InsertData(
                table: "Profesor",
                columns: new[] { "ProfesorId", "Apellido", "Email", "Especialidad", "EspecialidadNavegatorEspecialidadId", "Nombre" },
                values: new object[,]
                {
                    { 1, "olivera", "lolivera.unaj@gmail.com>", "Programacion", null, "lucas" },
                    { 2, "conde", "sergiounaj@gmail.com>", "Documentacion", null, "sergio" },
                    { 3, "jorge", "octaviojorge37@gmail.com>", "Programacion orientada a objetos", null, "octavio" },
                    { 4, "Amet", "leonardoAmet@gmail.com>", "complejidad temporal", null, "leonardo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_EspecialidadNavegatorEspecialidadId",
                table: "Profesor",
                column: "EspecialidadNavegatorEspecialidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Especialidad");
        }
    }
}
