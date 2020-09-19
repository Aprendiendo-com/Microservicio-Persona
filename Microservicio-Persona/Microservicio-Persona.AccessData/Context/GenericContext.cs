using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Persona.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Persona.AccessData.Context
{
    public class DbContexto :DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbContexto() { }


        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
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
    }
}
