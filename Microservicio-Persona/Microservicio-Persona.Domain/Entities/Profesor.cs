using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Entities
{
    public class Profesor
    {
        public int ProfesorID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
    }
}
