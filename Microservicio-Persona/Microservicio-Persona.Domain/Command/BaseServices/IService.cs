using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Persona.Domain.Command.BaseServices
{
    public interface IService
    {
        void Add<T>(T entity) where T : class;
        List<T> Traer<T>() where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteBy<T>(int id) where T : class;
        T FindBy<T>(int id) where T : class;

    }
}
