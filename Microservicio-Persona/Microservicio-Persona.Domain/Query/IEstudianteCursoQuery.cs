
using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;

namespace Microservicio_Persona.Domain.Query
{
   public interface IEstudianteCursoQuery
    {

       List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
       List<EstudianteCursoDTO> GetEstudiantesByCurso(int cursoId);

    }
}