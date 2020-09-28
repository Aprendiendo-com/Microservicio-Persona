using System;
using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Entities;
using System.Text;

namespace Microservicio_Persona.Domain.Query
{
   public interface IProfesorQuery
    {
        //List<ProfesorDTOs> GetAllProfesoresEspecialidad(string Especialidad );
        Profesor GetCursosByEspecialidad(string especialidad);
       ResponseGetProfesorByIdDTO GetById(int ProfesorId);
       List<ResponseGetAllProfesorDTO> GetAllProfesor();

    }
}
