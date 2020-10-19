using Microservicio_Persona.Domain.DTOs;
using System.Collections.Generic;

namespace Microservicio_Persona.Domain.Entities
{
    public class EstudianteCurso
    {
        public int EstudianteCursoID { get; set; }
        public int CursoID { get; set; }
        public int EstudianteID { get; set; }
        public string Estado { get; set; }

        public Estudiante EstudianteNavegador { get; set; }
        public CursoDTO CursoDTONavegador { get; set; }
    }
}
