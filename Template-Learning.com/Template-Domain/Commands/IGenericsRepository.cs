using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Template_Domain.Commands
{
  public  interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class; //puedo recibir cualq objeto y hago lo que tengo que hacer

        List<T> Traer<T>() where T : class;

        T Agregar<T>(T entity) where T : class; //??? revisar uso 

        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}