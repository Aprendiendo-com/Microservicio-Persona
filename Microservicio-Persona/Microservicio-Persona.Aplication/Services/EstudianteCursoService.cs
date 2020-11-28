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
using System.Linq;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IEstudianteCursoService
    {
        Task<EstudianteCurso> CreateRelacion(EstudianteCursoDTO relacion);
        /*EstudianteCurso CreateRelacion(EstudianteCursoDTO profesor);*/
        List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId);
        List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
        Task<List<EstudianteDTOs>> GetListado();
        int BajaCursoEstudiante(int estudianteId, int cursoId);
        Task<List<CursoCompletoDTO>> GetDetalleCursos(int id);


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




        public async Task<EstudianteCurso> CreateRelacion(EstudianteCursoDTO relacion) 
        {
            /*
            Program p = new Program();
            p.EnviarMailAsync().Wait();
            */

           var respuesta = await RestarCupoDeCurso(relacion.CursoID);


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

        public async Task<CursoRespondeAsyncDTO> RestarCupoDeCurso(int idCurso)
        {
            RequestIdCursoDTO curso = new RequestIdCursoDTO
            {
                CursoId = idCurso
            };
            using (var http = new HttpClient())
            {
                string url = "https://localhost:44308/api/Curso/RestarCupoById";
                var uri = new Uri(url);
                var cursosJson = new StringContent(JsonConvert.SerializeObject(curso), Encoding.UTF8, "application/json");

                var response = await http.PutAsync(uri, cursosJson);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);




                CursoRespondeAsyncDTO cursoConId = JsonConvert.DeserializeObject<CursoRespondeAsyncDTO>(stringContentAsync.ToString());

                return cursoConId;
            }
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
            string url = "https://localhost:51913/api/Registro";
            
            
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


        public async Task<List<CursoCompletoDTO>> GetDetalleCursos(int id)
        {

            var lista = _repository.Traer<EstudianteCurso>().Where(x => x.EstudianteID == id).ToList();
            List<int> idsCurso = new List<int>();

            foreach (var x in lista)
            {
                idsCurso.Add(x.CursoID);
            }

            using (var http = new HttpClient())
            {
                string url = "https://localhost:44308/api/Curso/GetCursosByLista";
                var cursosJson = new StringContent(JsonConvert.SerializeObject(idsCurso), Encoding.UTF8, "application/json");
                var response = await http.PatchAsync(url, cursosJson);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


                List<CursoCompletoDTO> cursos = JsonConvert.DeserializeObject<List<CursoCompletoDTO>>(stringContentAsync.ToString());

                return cursos;
            }




        }
    }
}
