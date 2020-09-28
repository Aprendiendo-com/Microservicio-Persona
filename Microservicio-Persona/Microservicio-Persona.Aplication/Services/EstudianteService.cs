using System;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.Entities;

namespace Microservicio_Persona.Aplication.Services
{
    public interface IEstudianteService
    {
        Estudiante CreateEstudiante(EstudianteDTOs estudiante);
        List<ResponseGetAllEstudianteDTO> GetAllEstudiante(); 
        ResponseGetEstudianteByIdDTO GetById(int EstudianteId);
        ResponseGetEstudianteByLegajoDTO GetByLegajo(int Legajo);

    }
    public class EstudianteService : IEstudianteService
    {
        private readonly IGenericsRepository _repository;
        private readonly IEstudianteQuery _query;
        public EstudianteService(IGenericsRepository repository,IEstudianteQuery query)
        {
            _repository = repository;
            _query= query;
        }

        public Estudiante CreateEstudiante(EstudianteDTOs estudiante)
        {
            var entity = new Estudiante
            {
                EstudianteID = estudiante.EstudianteID,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Email = estudiante.Email,
                Legajo = estudiante.Legajo
            };
            _repository.Add<Estudiante>(entity);
            Console.WriteLine("creando alumno");
            return entity;
        }

        public ResponseGetEstudianteByIdDTO GetById(int EstudianteID)
        {

            return _query.GetById(EstudianteID);
        }

        public ResponseGetEstudianteByLegajoDTO GetByLegajo(int Legajo)
        {

            return _query.GetByLegajo(Legajo);
        }

        public List<ResponseGetAllEstudianteDTO> GetAllEstudiante()
        {

           return  _query.GetAllEstudiante();
        }

    }
}

