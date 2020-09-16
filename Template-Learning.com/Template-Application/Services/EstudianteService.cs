using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Application.Services
{
    public interface IEstudianteService
    {
        Estudiante CreateAlumno(EstudianteDto estudiante);
    }

    public class EstudianteService : IEstudianteService
    {
        private readonly IGenericsRepository _repository;
        public EstudianteService(IGenericsRepository repository)
        {
            _repository = repository;
        }

        public Estudiante CreateEstudiante(EstudianteDto estudiante)
        {
            var entity = new Estudiante
            {
                EstudianteId = Guid.NewGuid(),
                Apellido = estudiante.Apellido,
                CursoId = Guid.Parse(estudiante.CursoId),
                Nombre = estudiante.Nombre,
                Mail = estudiante.Mail,
                Legajo = estudiante.Legajo
            };
            _repository.Add<Estudiante>(entity);
            Console.WriteLine("creando estudiante");
            Console.WriteLine("Creation");
            return entity;
        }
    }
}
