
namespace Microservicio_Persona.Domain.DTOs
{
    public class ClaseConCuestionarioDTO
    {
        public int ClaseId { get; set; }
        public string Descripcion { get; set; }
        public string Tema { get; set; }
        public int CursoId { get; set; }
        public VideoDTO Video { get; set; }
        public ForoDTO Foro { get; set; }
        public CuestionarioTodoDTO Cuestionario { get; set; }

    }
}