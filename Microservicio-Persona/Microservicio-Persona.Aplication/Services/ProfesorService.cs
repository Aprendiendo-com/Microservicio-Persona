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

namespace Microservicio_Persona.Aplication.Services
{
   public interface IProfesorService
    {
        Profesor CreateProfesor(ProfesorDTOs profesor);
       List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad);
       ProfesorDTOs GetById(int ProfesorId);
       List<ProfesorDTOs> GetAllProfesores();
       Task<List<RegistroDTOs>> GetRegistros();
        
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
                EspecialidadId = profesor.EspecialidadId
            };
            _repository.Add<Profesor>(entity);
            Console.WriteLine("creando profesor");
            return entity;
        }
        
        public List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad)
        {
            return _query.GetProfesoresByEspecialidad(especialidad);
        }

        public ProfesorDTOs GetById(int ProfesorId)
        {

            return _query.GetById(ProfesorId);
        }

        public List<ProfesorDTOs> GetAllProfesores()
        {

           return  _query.GetAllProfesores();
        }

        public async Task<List<RegistroDTOs>> GetRegistros()
        {
            //string url = "https://localhost:44326/api/Registro";
            
            
            using (var http = new HttpClient())
            {
                    var uri = new Uri("https://localhost:44326/api/Registro");
                    string request = await http.GetStringAsync(uri);

                    //response.EnsureSuccessStatusCode();
                    //string responseBody = await response.Content.ReadAsStringAsync();

                    //var _stringSerialized = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    //var registrosObtenidos = JsonConvert.DeserializeObject<List<RegistroDTOs>>(_stringSerialized);

                    List<RegistroDTOs> registros = JsonConvert.DeserializeObject<List<RegistroDTOs>>(request);

                    return  registros;
            }  
        }
    }
}
