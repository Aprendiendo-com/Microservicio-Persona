using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Persona.AccessData
{
    public class DbContexto : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<EstudianteCurso> EstudianteCurso { get; set; }

        public DbContexto() { }


        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Server= .\\SQLEXPRESS ;Database=MicroservicioPersonav3;Trusted_Connection=True;MultipleActiveResultSets=true ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //METODO PARA CARGAR DATOS A LA BD DIRECTAMENTE, EN ESTE CASO CARGAREMOS A PROFESORES
        {

            modelBuilder.Entity<Profesor>()
                        .HasOne<Especialidad>(e => e.EspecialidadNavegator)
                        .WithMany(e => e.Profesor)
                        .HasForeignKey(k => k.EspecialidadId);

            modelBuilder.Entity<EstudianteCurso>()
                        .HasOne<Estudiante>(e => e.EstudianteNavegador)
                        .WithMany(e => e.EstudianteCursoNavegacion)
                        .HasForeignKey(k => k.EstudianteID);
            
            modelBuilder.Entity<Especialidad>().Property(d => d.Descripcion).IsRequired();
            modelBuilder.Entity<Profesor>().Property(p => p.Nombre).IsRequired();
            modelBuilder.Entity<Profesor>().Property(p => p.Apellido).IsRequired();
            modelBuilder.Entity<Profesor>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<Estudiante>().Property(p => p.Nombre).IsRequired();
            modelBuilder.Entity<Estudiante>().Property(p => p.Apellido).IsRequired();
            modelBuilder.Entity<Estudiante>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<Estudiante>().Property(p => p.Legajo).IsRequired();


            modelBuilder.Entity<Especialidad>(entity =>
            {  
                entity.ToTable("Especialidad");
                entity.HasData(new Especialidad { EspecialidadId = 1, Descripcion = "Programacion"});
                entity.HasData(new Especialidad { EspecialidadId = 2, Descripcion = "Documentacion"});
                entity.HasData(new Especialidad { EspecialidadId = 3, Descripcion = "Matematica"});
                entity.HasData(new Especialidad { EspecialidadId = 4, Descripcion = "Base de datos"});
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("Profesor");

                entity.HasData(new Profesor { ProfesorId = 1, Nombre = "lucas", Apellido = "olivera", Email = "lolivera.unaj@gmail.com>", EspecialidadId = 1 });
                entity.HasData(new Profesor { ProfesorId = 2, Nombre = "sergio", Apellido = "conde", Email = "sergiounaj@gmail.com>", EspecialidadId = 2 });
                entity.HasData(new Profesor { ProfesorId = 3, Nombre = "octavio", Apellido = "jorge", Email = "octaviojorge37@gmail.com>", EspecialidadId = 1 });
                entity.HasData(new Profesor { ProfesorId = 4, Nombre = "leonardo", Apellido = "Amet", Email = "leonardoAmet@gmail.com>", EspecialidadId = 1 }); 
            }); 

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");
                entity.HasData(new Estudiante { EstudianteID = 1, Nombre = "pepe", Apellido = "oliver", Email = "pepeolivera@hotmail.com>", Legajo = 1233 });
                entity.HasData(new Estudiante { EstudianteID = 2, Nombre = "pepa", Apellido = "gonzalez", Email = "pepag@hotmail.com>", Legajo = 1234 });
                entity.HasData(new Estudiante { EstudianteID = 3, Nombre = "juan", Apellido = "perez", Email = "juanperez@hotmail.com>", Legajo = 1235 });
                entity.HasData(new Estudiante { EstudianteID = 4, Nombre = "ariel", Apellido = "lopez", Email = "ariellopez@hotmail.com>", Legajo = 1236 });
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.ToTable("EstudianteCurso");
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 101, CursoID = 1, EstudianteID = 1, Estado = "aprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 102, CursoID = 1, EstudianteID = 2, Estado = "aprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 103, CursoID = 2, EstudianteID = 3, Estado = "aprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 104, CursoID = 2, EstudianteID = 4, Estado = "desaprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 105, CursoID = 2, EstudianteID = 1, Estado = "desaprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 106, CursoID = 3, EstudianteID = 2, Estado = "desaprobado"});
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 107, CursoID = 3, EstudianteID = 3, Estado = "desaprobado"});
            });

        }
    }
}
