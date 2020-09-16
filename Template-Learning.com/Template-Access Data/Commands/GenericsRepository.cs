using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Access_Data.Commands
{
   public class GenericsRepository: IGenericsRepository
    {
        private readonly DbContexto _context;
        public GenericsRepository (DbContexto dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<T> Traer<T>() where T : class
        {
            _context.Attach();  
        }

        public T Agregar<T>(T entity) where T : class   //revisar
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Delete(entity);
            _context.SaveChanges();
        }
    }
}
