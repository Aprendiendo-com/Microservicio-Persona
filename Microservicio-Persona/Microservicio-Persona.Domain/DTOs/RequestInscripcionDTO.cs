using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.DTOs
{
    public class RequestInscripcionDTO
    {
        public int EstudianteCursoID { get; set; }
        public int CursoID { get; set; }
        public int EstudianteID { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoDestinatario { get; set; }
    }
}
