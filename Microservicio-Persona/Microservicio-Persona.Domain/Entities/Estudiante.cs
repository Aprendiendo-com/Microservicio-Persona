using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Entities
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public int Legajo { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<EstudianteCurso> EstudianteCursoNavegacion { get; set; }

       
    }
}
