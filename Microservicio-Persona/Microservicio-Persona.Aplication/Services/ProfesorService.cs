using System;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.Entities;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IProfesorService
    {
        
       Profesor GetCursosByEspecialidad(string especialidad);
       ResponseGetProfesorByIdDTO GetById(int ProfesorId);
       List<ResponseGetAllProfesorDTO> GetAllProfesor();
        
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
        public Profesor GetCursosByEspecialidad(string especialidad)
        {
            return _query.GetCursosByEspecialidad(especialidad);
            //throw new NotImplementedException();
        }

        public ResponseGetProfesorByIdDTO GetById(int ProfesorId)
        {

            return _query.GetById(ProfesorId);
        }

        public List<ResponseGetAllProfesorDTO> GetAllProfesor()
        {

           return  _query.GetAllProfesor();
        }
    }
}
