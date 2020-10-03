using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Entities
{
    public class Profesor
    {
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public int EspecialidadId { get; set; }
        public virtual Especialidad EspecialidadNavegator { get; set; }   //FK

    }
}
