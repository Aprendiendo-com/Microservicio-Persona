using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using Microservicio_Persona.Domain.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Microservicio_Persona.AccessData.Queries
{
   public class ProfesorQuery : IProfesorQuery
    {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public ProfesorQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }


         public List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Profesor")
                .Select("Profesor.EspecialidadId",
                    "Especialidad.Descripcion",
                    "Profesor.ProfesorId",
                    "Profesor.Nombre",
                    "Profesor.Apellido",
                    "Profesor.Email")
                .Join("Especialidad", "Profesor.EspecialidadId", "Especialidad.EspecialidadId")
                .Where("Especialidad.Descripcion", "=", especialidad);
                
            var result = query.Get<ProfesorDTOs>();

            return result.ToList();
        } 
       public ProfesorDTOs GetById(int ProfesorId)
       {
           var db = new QueryFactory(connection, sqlKataCompiler);
            
            var profe = db.Query("Profesor")
                                .Select("ProfesorId","Nombre", "Apellido","Email","EspecialidadId")
                                .Where("ProfesorId", "=", ProfesorId)
                                .FirstOrDefault<ProfesorDTOs>();
            
            return new ProfesorDTOs 
            {
                ProfesorId = profe.ProfesorId,
                Nombre = profe.Nombre,
                Apellido = profe.Apellido,
                Email = profe.Email,
                EspecialidadId = profe.EspecialidadId
            };

       }
       public List<ProfesorDTOs> GetAllProfesores()
       {
           var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Profesor")
                            .Select("ProfesorId","Nombre", "Apellido","Email","EspecialidadId");

            var result = query.Get<ProfesorDTOs>();

            return result.ToList();

       }

    }



    }

