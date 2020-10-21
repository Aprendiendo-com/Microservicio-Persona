using System;
using Microservicio_Persona.Aplication.Services;
using Microservicio_Persona.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservicio_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteCursoController : ControllerBase
    {
        private readonly IEstudianteCursoService _service;

        public EstudianteCursoController(IEstudianteCursoService service)
        {
            _service = service;
        }

        // POST api/<EstudianteCursoController>
        [HttpPost]
        public IActionResult Post(EstudianteCursoDTO estudianteCurso) 
        {
            try
            {
                return new JsonResult(_service.CreateRelacion(estudianteCurso)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route ("estudiante/{cursoId?}")]
        [HttpGet]
        public IActionResult GetEstudiantesByCurso(int cursoId)
        {
            try
            {
                return new JsonResult(_service.GetEstudiantesByCurso(cursoId)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route ("cursos/{estudianteId?}")]
        [HttpGet]
        public IActionResult GetCursosByEstudiante(int estudianteId)
        {
            try
            {
                return new JsonResult(_service.GetCursosByEstudiante(estudianteId)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}