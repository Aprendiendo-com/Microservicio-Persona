using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microservicio_Persona.AccessData.Context;
using Microservicio_Persona.Domain.Command.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Persona.AccessData.Command
{
    class GenericRepository : IRepository
    {
        protected DbContexto Context;
        public GenericRepository(DbContexto contexto)
        {
            this.Context = contexto;
        }
        
        public void Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteBy<T>(int id) where T : class
        {
            T entity = FindBy<T>(id);
            Delete<T>(entity);
        }

        public T FindBy<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> Traer<T>() where T : class
        {
            List<T> query = Context.Set<T>().ToList();
            return query;
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
