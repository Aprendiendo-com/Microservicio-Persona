using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using Microservicio_Persona.Domain.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Microservicio_Persona.AccessData.Queries
{
   public class EstudianteCursoQuery : IEstudianteCursoQuery
    {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public EstudianteCursoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }
       public List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId)
       {
           var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("EstudianteCurso")
                            .Where("EstudianteID", "=", estudianteId);

            var result = query.Get<EstudianteCursoDTO>();

            return result.ToList();

       }
       public List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId)
       {
           var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("EstudianteCurso")
                            .Select("EstudianteCurso.EstudianteCursoID",
                            "EstudianteCurso.CursoID",
                            "EstudianteCurso.EstudianteID",
                            "Estudiante.Nombre",
                            "Estudiante.Apellido",
                            "Estudiante.Email",
                            "Estudiante.Dni",
                            "EstudianteCurso.Estado")
                            .Join("Estudiante", "EstudianteCurso.EstudianteID", "Estudiante.EstudianteID")
                            .Where("CursoID", "=", cursoId);

            var result = query.Get<ResponseGetEstudiantesByCurso>();

            return result.ToList();

       }
        public int BajaCursoEstudiante(int estudianteId, int cursoId)
       {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("EstudianteCurso").Where(new
            {
                EstudianteID = estudianteId,
                CursoID = cursoId,
            }).Delete();
            
            return query;
        }


    }       
}