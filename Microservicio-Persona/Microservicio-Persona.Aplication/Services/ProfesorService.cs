using System;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IProfesorService
    {
        Profesor CreateProfesor(ProfesorDTOs profesor);
       List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad);
       Task<List<CursoCompletoDTO>> GetById(int ProfesorId);
       List<ProfesorDTOs> GetAllProfesores();
       Task<List<RegistroDTOs>> GetRegistros();
        int ObtenerProfesorId(int usuarioId);
        
    }
    public class ProfesorService : IProfesorService
    {
        private readonly IGenericsRepository _repository;
        private readonly IProfesorQuery _query;
        public ProfesorService(IGenericsRepository repository,IProfesorQuery query)
        {
            _repository = repository;
            _query= query;
        }

        public Profesor CreateProfesor(ProfesorDTOs profesor) 
        {
            var entity = new Profesor
            {
                ProfesorId = profesor.ProfesorId,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Email,
                EspecialidadId = profesor.EspecialidadId,
                UsuarioId = profesor.UsuarioId
            };
            _repository.Add<Profesor>(entity);
            Console.WriteLine("creando profesor");
            return entity;
        }
        
        public List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad)
        {
            return _query.GetProfesoresByEspecialidad(especialidad);
        }

        public async Task<List<CursoCompletoDTO>>  GetById(int ProfesorId)
        {
            using var http = new HttpClient();

            var url = "https://localhost:44308/api/Curso";

            var request = await http.GetStringAsync(url);

            var response = JsonConvert.DeserializeObject<List<CursoSimpleDTO>>(request).Where(x => x.ProfesorId == ProfesorId)
                .Select(x => x.CursoId).ToList();


            string url_2 = "https://localhost:44308/api/Curso/GetCursosByLista";
            var cursosJson = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json");
            var responseCursos = await http.PatchAsync(url_2, cursosJson);
            responseCursos.EnsureSuccessStatusCode();
            var stringContentAsync = await responseCursos.Content.ReadAsStringAsync().ConfigureAwait(false);


            List<CursoCompletoDTO> cursos = JsonConvert.DeserializeObject<List<CursoCompletoDTO>>(stringContentAsync.ToString());

            return cursos;
        }

        public List<ProfesorDTOs> GetAllProfesores()
        {

           return  _query.GetAllProfesores();
        }

        public async Task<List<RegistroDTOs>> GetRegistros()
        {
            string url = "https://localhost:44326/api/Registro";
            
            
            using (var http = new HttpClient())
            {
                    string request = await http.GetStringAsync(url);

                    //response.EnsureSuccessStatusCode();
                    //string responseBody = await response.Content.ReadAsStringAsync();

                    //var _stringSerialized = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    //var registrosObtenidos = JsonConvert.DeserializeObject<List<RegistroDTOs>>(_stringSerialized);

                    List<RegistroDTOs> registros = JsonConvert.DeserializeObject<List<RegistroDTOs>>(request);

                    return  registros;
            }  
        }

        public int ObtenerProfesorId(int usuarioId)
        {
            var id = this._repository.Traer<Profesor>().Where(x => x.UsuarioId == usuarioId).Select(x => x.ProfesorId).FirstOrDefault();

            return id;
        }
    }
}
