
using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;

namespace Microservicio_Persona.Domain.Query
{
   public interface IEstudianteCursoQuery
    {
       int BajaCursoEstudiante(int estudianteId, int cursoId);
       List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
       List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId);

    }
}