using System;
using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Query
{
   public interface IEstudianteQuery
    {
        List<EstudianteDTOs> GetAllEstudiantes(); 
        EstudianteDTOs GetById(int EstudianteId);

    }
}
