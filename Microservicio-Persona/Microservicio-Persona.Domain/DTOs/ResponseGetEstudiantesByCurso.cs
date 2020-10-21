namespace Microservicio_Persona.Domain.DTOs
{
    public class ResponseGetEstudiantesByCurso
    {
        public int EstudianteCursoID { get; set; }
        public int CursoID { get; set; }
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Legajo { get; set; }
        public string Estado { get; set; }
        
       
    }
}