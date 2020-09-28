using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.DTOs
{
    public class ResponseGetProfesorByIdDTO
    {
        public int ProfesorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Especialidad{ get; set; }
    }

}