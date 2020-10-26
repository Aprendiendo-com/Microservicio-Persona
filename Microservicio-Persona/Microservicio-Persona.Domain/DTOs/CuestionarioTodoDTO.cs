using System.Collections.Generic;

namespace Microservicio_Persona.Domain.DTOs
{
    public class CuestionarioTodoDTO
    {
        public string Descripcion { get; set; }
        public List<PreguntaConRespuestaDTO> Preguntas { get; set; }
    }
}