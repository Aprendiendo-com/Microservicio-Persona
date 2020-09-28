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
        public ProfesorDTOs GetProfesorEspecialidad(string Especialidad)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            
            var profe = db.Query("Profesor")
                                .Select("ProfesorId","Nombre", "Apellido","Email")
                                .Where("Especialidad", "=", Especialidad)
                                .FirstOrDefault<ProfesorDTOs>();
            
            return new ProfesorDTOs 
            {
                ProfesorId = profe.ProfesorId,
                Nombre = profe.Nombre,
                Apellido = profe.Apellido,
                Email = profe.Email,
                Especialidad = profe.Especialidad
            };
        }

        public List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Profesores")
                        .Select("ProfesorId","Nombre", "Apellido","Email","Especialidad")
                        .Where("Especialidad", "=", especialidad);

            var result = query.Get<ProfesorDTOs>();

            return result.ToList();
        }
       public ProfesorDTOs GetById(int ProfesorId)
       {
           var db = new QueryFactory(connection, sqlKataCompiler);
            
            var profe = db.Query("Profesor")
                                .Select("ProfesorId","Nombre", "Apellido","Email","Especialidad")
                                .Where("ProfesorId", "=", ProfesorId)
                                .FirstOrDefault<ProfesorDTOs>();
            
            return new ProfesorDTOs 
            {
                ProfesorId = profe.ProfesorId,
                Nombre = profe.Nombre,
                Apellido = profe.Apellido,
                Email = profe.Email,
                Especialidad = profe.Especialidad
            };

       }
       public List<ProfesorDTOs> GetAllProfesores()
       {
           var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Profesores");

            var result = query.Get<ProfesorDTOs>();

            return result.ToList();

       }

    }



    }

