using System;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Entities;

namespace Microservicio_Persona.Domain.DTOs
{
   public class CursoDTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int ProfesorId { get; set; }
        public int CategoriaId { get; set; }
        
        public ICollection<EstudianteCurso> EstudianteCursoNavegacion { get; set; }
    }
}