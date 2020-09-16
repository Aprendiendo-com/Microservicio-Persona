using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template_Domain.Entities;

namespace Template_Access_Data
{
   public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //METODO PARA CARGAR DATOS A LA BD DIRECTAMENTE
        {
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");
                entity.HasData(new Estudiante { EstudianteID = 1, Nombre = "Octavio", Apellido = "jorge", Email = "gfdgfg4", Legajo = 345 });
            });
        }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}
