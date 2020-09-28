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
        Profesor CreateProfesor(ProfesorDTOs profesor);
        ProfesorDTOs GetProfesorEspecialidad(string Especialidad);
       List<ProfesorDTOs> GetProfesoresByEspecialidad(string especialidad);
       ProfesorDTOs GetById(int ProfesorId);
       List<ProfesorDTOs> GetAllProfesores();
        
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
                Especialidad = profesor.Especialidad
            };
            _repository.Add<Profesor>(entity);
            Console.WriteLine("creando profesor");
            return entity;
        }
        
        
        public ProfesorDTOs GetProfesorEspecialidad(string Especialidad)
        {
            return _query.GetProfesorEspecialidad(Especialidad);

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
    }
}
