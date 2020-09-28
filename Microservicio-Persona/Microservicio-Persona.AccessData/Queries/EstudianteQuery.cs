using System;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using SqlKata.Compilers;
using System.Data;
using System.Linq;
using SqlKata.Execution;
using System.Text;

namespace Microservicio_Persona.AccessData.Queries
{
  public class EstudianteQuery: IEstudianteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public EstudianteQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }
        
        
        
        public List<EstudianteDTOs> GetAllEstudiantes()
        {
          var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Estudiantes");

            var result = query.Get<EstudianteDTOs>();

            return result.ToList();

        } 
        public EstudianteDTOs GetById(int EstudianteId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var estudiante = db.Query("Estudiantes")
                .Select("EstudianteID", "Nombre", "Apellido","Email","Legajo")
                .Where("EstudianteID", "=", EstudianteId)
                .FirstOrDefault<EstudianteDTOs>();

            return new EstudianteDTOs
            {
                EstudianteID = estudiante.EstudianteID,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Email = estudiante.Email,
                Legajo = estudiante.Legajo
            };
        }
    }
}
