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
                entity.HasData(new Especialidad { EspecialidadId = 5, Descripcion = "Idioma"});
                entity.HasData(new Especialidad { EspecialidadId = 6, Descripcion = "Tecnico"});
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("Profesor");

                entity.HasData(new Profesor { ProfesorId = 1, Nombre = "Lucas", Apellido = "Olivera", Email = "lolivera.unaj@gmail.com>", EspecialidadId = 1 });
                entity.HasData(new Profesor { ProfesorId = 2, Nombre = "Sergio", Apellido = "Conde", Email = "sergiounaj@gmail.com>", EspecialidadId = 2 });
                entity.HasData(new Profesor { ProfesorId = 3, Nombre = "Octavio", Apellido = "Jorge", Email = "octaviojorge37@gmail.com>", EspecialidadId = 1 });
                entity.HasData(new Profesor { ProfesorId = 4, Nombre = "Leonardo", Apellido = "Amet", Email = "leonardoAmet@gmail.com>", EspecialidadId = 1 }); 
                entity.HasData(new Profesor { ProfesorId = 5, Nombre = "Jorge", Apellido = "Osio", Email = "jorgeosio@gmail.com>", EspecialidadId = 1 }); 
                entity.HasData(new Profesor { ProfesorId = 6, Nombre = "Maria", Apellido = "Rosa", Email = "mariarosa@gmail.com>", EspecialidadId = 5 }); 
            }); 

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");
                entity.HasData(new Estudiante { EstudianteID = 1, Nombre = "Pablo", Apellido = "Oliver", Email = "pablolivera@hotmail.com>", Legajo = 1233 });
                entity.HasData(new Estudiante { EstudianteID = 2, Nombre = "Patricia", Apellido = "Gonzalez", Email = "patriciagonzalez@hotmail.com>", Legajo = 1234 });
                entity.HasData(new Estudiante { EstudianteID = 3, Nombre = "Dimitri", Apellido = "Perez", Email = "dimitriperez@hotmail.com>", Legajo = 1235 });
                entity.HasData(new Estudiante { EstudianteID = 4, Nombre = "Ariel", Apellido = "Lopez", Email = "ariellopez@hotmail.com>", Legajo = 1236 });
                entity.HasData(new Estudiante { EstudianteID = 5, Nombre = "Camila", Apellido = "Sanchez", Email = "camilasanchez@hotmail.com>", Legajo = 1237 });
                entity.HasData(new Estudiante { EstudianteID = 6, Nombre = "Paula", Apellido = "Gomez", Email = "paulagomez@hotmail.com>", Legajo = 1238 });
                entity.HasData(new Estudiante { EstudianteID = 7, Nombre = "Mayra", Apellido = "Ayala", Email = "mayraayala@hotmail.com>", Legajo = 1239 });
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
                entity.HasData(new EstudianteCurso { EstudianteCursoID = 108, CursoID = 3, EstudianteID = 5, Estado = "aprobado"});
            });

        }
    }
}
