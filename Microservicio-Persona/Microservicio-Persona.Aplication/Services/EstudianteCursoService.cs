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
   public interface IEstudianteCursoService
    {
        EstudianteCurso CreateRelacion(EstudianteCursoDTO profesor);
        List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId);
        List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
        Task<List<EstudianteDTOs>> GetListado();
        int BajaCursoEstudiante(int estudianteId, int cursoId);


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
    }
}
