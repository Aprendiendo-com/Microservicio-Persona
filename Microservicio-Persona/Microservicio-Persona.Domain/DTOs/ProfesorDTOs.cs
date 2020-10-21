using Microservicio_Persona.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.DTOs
{
   public class ProfesorDTOs
    {
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public int EspecialidadId { get; set; }
    }
}
