using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Persona.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Persona.AccessData
{
    public class DbContexto : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }

        public DbContexto() { }


        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //METODO PARA CARGAR DATOS A LA BD DIRECTAMENTE, EN ESTE CASO CARGAREMOS A PROFESORES
        {
            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("Profesor");
                entity.HasData(new Profesor { ProfesorId = 1, Nombre = "lucas", Apellido = "olivera", Email = "lolivera.unaj@gmail.com>", Especialidad = "Programacion"  });
                entity.HasData(new Profesor { ProfesorId = 2, Nombre = "sergio", Apellido = "conde", Email = "sergiounaj@gmail.com>", Especialidad = "Documentacion" });
                entity.HasData(new Profesor { ProfesorId = 3, Nombre = "octavio", Apellido = "jorge", Email = "octaviojorge37@gmail.com>", Especialidad = "Programacion orientada a objetos" });
                entity.HasData(new Profesor { ProfesorId = 4, Nombre = "leonardo", Apellido = "Amet", Email = "leonardoAmet@gmail.com>", Especialidad = "complejidad temporal" });
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");
                entity.HasData(new Estudiante { EstudianteID = 1, Nombre = "pepe", Apellido = "olivera", Email = "pepeolivera@hotmail.com>", Legajo = 1233 });
                entity.HasData(new Estudiante { EstudianteID = 2, Nombre = "pepa", Apellido = "gonzalez", Email = "pepag@hotmail.com>", Legajo = 1234 });
                entity.HasData(new Estudiante { EstudianteID = 3, Nombre = "juan", Apellido = "perez", Email = "juanperez@hotmail.com>", Legajo = 1235 });
                entity.HasData(new Estudiante { EstudianteID = 4, Nombre = "ariel", Apellido = "lopez", Email = "ariellopez@hotmail.com>", Legajo = 1236 });
            });

        }
    }
}
