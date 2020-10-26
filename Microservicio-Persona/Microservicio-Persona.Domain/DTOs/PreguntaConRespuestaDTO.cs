using System.Collections.Generic;

namespace Microservicio_Persona.Domain.DTOs
{
    public class PreguntaConRespuestaDTO
    {
        public string Descripcion { get; set; }
        public List<RespuestaDescripcionDTO> Respuestas { get; set; }
    }
}
