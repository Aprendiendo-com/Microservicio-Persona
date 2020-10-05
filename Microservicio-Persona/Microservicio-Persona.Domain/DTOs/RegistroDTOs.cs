using Microservicio_Persona.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.DTOs
{
   public class RegistroDTOs
    {
        public class RegistroDTO
        {
        public int RegistroId { get; set; }
        public int EstudianteId { get; set; }
        public int CuestionarioId { get; set; }
        }
    }
}