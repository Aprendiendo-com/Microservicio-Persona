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
        //public List<ProfesorDTOs> GetAllProfesoresEspecialidad(string Especialidad)
        //{
        //}

        //public ResponseGetCursoById GetById(string cursoId)
        //{
        //    var db = new QueryFactory(connection, sqlKataCompiler);
        //    var curso = db.Query("Cursos")
        //        .Select("CursoId", "Materia", "ProfesorId")
        //        .Where("CursoId", "=", cursoId)
        //        .FirstOrDefault<ResponseGetAllCursoDto>();

        //    var profesor = db.Query("Profesores")
        //        .Select("ProfesorId", "Nombre", "Apellido")
        //        .Where("ProfesorId", "=", curso.ProfesorId)
        //        .FirstOrDefault<ResponseGetCursoByIdProfesor>();

        //    var alumnos = db.Query("Alumnos")
        //        .Select("AlumnoId", "Nombre", "Apellido", "Legajo")
        //        .Where("CursoId", "=", cursoId)
        //        .Get<ResponseGetCursoByIdAlumno>()
        //        .ToList();

        //    return new ResponseGetCursoById
        //    {
        //        CursoId = curso.CursoId,
        //        Materia = curso.Materia,
        //        Profesor = profesor,
        //        Alumnos = alumnos
        //    };
        //}
    }



    }

