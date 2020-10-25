using System;
using System.Text;
using System.Net.Mime;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IEstudianteCursoService
    {
        EstudianteCurso CreateRelacion(EstudianteCursoDTO profesor);
        List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId);
        List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
        Task<List<EstudianteDTOs>> GetListado();
        int BajaCursoEstudiante(int estudianteId, int cursoId);
        Task<List<CursoCompletoDTO>> GetDetalleCursos(List<int> idCursos);


    }
    public class EstudianteCursoService : IEstudianteCursoService
    {
        private readonly IGenericsRepository _repository;
        private readonly IEstudianteCursoQuery _query;
        public EstudianteCursoService(IGenericsRepository repository,IEstudianteCursoQuery query)
        {
            _repository = repository;
            _query= query;
        }

        public EstudianteCurso CreateRelacion(EstudianteCursoDTO relacion) 
        {
            var entity = new EstudianteCurso
            {
                EstudianteCursoID = relacion.EstudianteCursoID,
                CursoID = relacion.CursoID,
                EstudianteID = relacion.EstudianteID,
                Estado = relacion.Estado
            };
            _repository.Add<EstudianteCurso>(entity);

            return entity;
        }

        public List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId)
        {

           return  _query.GetEstudiantesByCurso(cursoId);
        }

        public List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId)
        {

           return  _query.GetCursosByEstudiante(estudianteId);
        }

        public async Task<List<EstudianteDTOs>> GetListado()
        {
            string url = "https://localhost:44326/api/Registro";
            
            
            using (var http = new HttpClient())
            {
                    string request = await http.GetStringAsync(url);

                    List<EstudianteDTOs> registros = JsonConvert.DeserializeObject<List<EstudianteDTOs>>(request);

                    return  registros;
            }  
        }
        public int BajaCursoEstudiante(int estudianteId, int cursoId) {         
            return _query.BajaCursoEstudiante(estudianteId,cursoId);
        }


        public async Task<List<CursoCompletoDTO>> GetDetalleCursos(List<int> idCursos)
        {
            string url = "https://localhost:44326/api/Curso/GetCursosByLista";
            
            
            using (var http = new HttpClient())
            {
                    var cursosJson = new StringContent(JsonConvert.SerializeObject(idCursos), Encoding.UTF8, "application/json");
                    var response = await http.PatchAsync(url, cursosJson);
                    var stringContentAsync = response.Content.ReadAsStringAsync().ConfigureAwait(false);                    

                    response.EnsureSuccessStatusCode();
                    List<CursoCompletoDTO> cursos = JsonConvert.DeserializeObject<List<CursoCompletoDTO>>(stringContentAsync.ToString());

                    return  cursos;
            }  
        }
    }
}
