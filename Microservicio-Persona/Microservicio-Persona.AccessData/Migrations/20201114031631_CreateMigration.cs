using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Persona.AccessData.Migrations
{
    public partial class CreateMigration : Migration
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
                    DNI = table.Column<int>(nullable: false),
                    Legajo = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    EspecialidadId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    { 4, "Base de datos" },
                    { 5, "Idioma" },
                    { 6, "Tecnico" }
                });

            migrationBuilder.InsertData(
                table: "Profesor",
                columns: new[] { "ProfesorId", "Apellido", "Email", "EspecialidadId", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Olivera", "lolivera.unaj@gmail.com", 1, "Lucas", 20 },
                    { 3, "Jorge", "octaviojorge37@gmail.com", 1, "Octavio", 22 },
                    { 4, "Amet", "leonardoAmet@gmail.com", 1, "Leonardo", 23 },
                    { 5, "Osio", "jorgeosio@gmail.com", 1, "Jorge", 24 },
                    { 2, "Conde", "sergiounaj@gmail.com", 2, "Sergio", 21 },
                    { 6, "Rosa", "mariarosa@gmail.com", 5, "Maria", 25 }
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
