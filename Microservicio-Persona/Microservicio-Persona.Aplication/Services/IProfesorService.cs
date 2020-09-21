using Microservicio_Persona.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IProfesorService
    {
        
       Profesor GetCursoEspecialidad(string especialidad);
        
    }
    public class ProfesorService : IProfesorService
    {
        public Profesor GetCursoEspecialidad(string especialidad)
        {
            throw new NotImplementedException();
        }
    }
}
