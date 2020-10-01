using System;
using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Entities;
using System.Text;

namespace Microservicio_Persona.Domain.Query
{
   public interface IProfesorQuery
    {
        ////ProfesorDTOs GetProfesorEspecialidad(string Especialidad);
        List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad);
       ProfesorDTOs GetById(int ProfesorId);
       List<ProfesorDTOs> GetAllProfesores();

    }
}
