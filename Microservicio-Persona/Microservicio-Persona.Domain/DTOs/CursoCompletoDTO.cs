
using System.Collections.Generic;

namespace Microservicio_Persona.Domain.DTOs
{
    public class CursoCompletoDTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int ProfesorId { get; set; }
        public int CategoriaId { get; set; }
        public string Imagen { get; set; }
        public ICollection<ClaseConCuestionarioDTO> ClasesNavegacion { get; set; }
    }
}