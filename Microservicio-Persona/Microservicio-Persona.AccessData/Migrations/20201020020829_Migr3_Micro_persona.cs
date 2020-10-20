using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Persona.AccessData.Migrations
{
    public partial class Migr3_Micro_persona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false)
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
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
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
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ProfesorId);
                    table.ForeignKey(
                        name: "FK_Profesor_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteCurso",
                columns: table => new
                {
                    EstudianteCursoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoID = table.Column<int>(nullable: false),
                    EstudianteID = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteCurso", x => x.EstudianteCursoID);
                    table.ForeignKey(
                        name: "FK_EstudianteCurso_Estudiante_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiante",
                        principalColumn: "EstudianteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Especialidad",
                columns: new[] { "EspecialidadId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Programacion" },
                    { 2, "Documentacion" },
                    { 3, "Matematica" },
                    { 4, "Base de datos" }
                });

            migrationBuilder.InsertData(
                table: "Estudiante",
                columns: new[] { "EstudianteID", "Apellido", "Email", "Legajo", "Nombre" },
                values: new object[,]
                {
                    { 1, "oliver", "pepeolivera@hotmail.com>", 1233, "pepe" },
                    { 2, "gonzalez", "pepag@hotmail.com>", 1234, "pepa" },
                    { 3, "perez", "juanperez@hotmail.com>", 1235, "juan" },
                    { 4, "lopez", "ariellopez@hotmail.com>", 1236, "ariel" }
                });

            migrationBuilder.InsertData(
                table: "EstudianteCurso",
                columns: new[] { "EstudianteCursoID", "CursoID", "Estado", "EstudianteID" },
                values: new object[,]
                {
                    { 101, 1, "aprobado", 1 },
                    { 105, 2, "desaprobado", 1 },
                    { 102, 1, "aprobado", 2 },
                    { 106, 3, "desaprobado", 2 },
                    { 103, 2, "aprobado", 3 },
                    { 107, 3, "desaprobado", 3 },
                    { 104, 2, "desaprobado", 4 }
                });

            migrationBuilder.InsertData(
                table: "Profesor",
                columns: new[] { "ProfesorId", "Apellido", "Email", "EspecialidadId", "Nombre" },
                values: new object[,]
                {
                    { 1, "olivera", "lolivera.unaj@gmail.com>", 1, "lucas" },
                    { 3, "jorge", "octaviojorge37@gmail.com>", 1, "octavio" },
                    { 4, "Amet", "leonardoAmet@gmail.com>", 1, "leonardo" },
                    { 2, "conde", "sergiounaj@gmail.com>", 2, "sergio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCurso_EstudianteID",
                table: "EstudianteCurso",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_EspecialidadId",
                table: "Profesor",
                column: "EspecialidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteCurso");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Especialidad");
        }
    }
}
