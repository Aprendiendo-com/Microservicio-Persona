using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Entities
{
    public class Especialidad
    {
        public int EspecialidadId { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Profesor> Profesor { get; set; }
    }
}