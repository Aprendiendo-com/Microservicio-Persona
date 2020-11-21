using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservicio_Persona.Aplication.Services;
using Microservicio_Persona.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservicio_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpDelete]
        public IActionResult BajaCursoEstudiante([FromQuery]int estudianteId, [FromQuery] int cursoId)
        {
            try
            {
                var resul = _service.BajaCursoEstudiante(estudianteId, cursoId);
                if (resul == 0)
                {
                    return NotFound("No se encontro el registro pedido a eliminar.");
                }
                
                return new JsonResult ("Se dio de baja al alumno del curso "+ cursoId){ StatusCode = 200 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetDetalleCursos/{id}")]
        public async Task<IActionResult> GetDetalleCursos(int id)
        {
            try
            {
                return new JsonResult(await _service.GetDetalleCursos(id)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}