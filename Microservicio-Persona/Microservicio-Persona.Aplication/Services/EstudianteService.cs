using System;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;

namespace Microservicio_Persona.Aplication.Services
{
    public interface IEstudianteService
    {
        Estudiante CreateEstudiante(EstudianteDTOs estudiante);

    }
    public class EstudianteService : IEstudianteService
    {
        private readonly IGenericsRepository _repository;
        public EstudianteService(IGenericsRepository repository)
        {
            _repository = repository;
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
    }
}

