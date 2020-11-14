using Microservicio_Persona.Aplication.Services;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microservicio_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _service;

        public EstudianteController(IEstudianteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(EstudianteDTOs estudiante ) //primer post de creacion o agregar un estudiante 
        {
            try
            {
                return new JsonResult(_service.CreateEstudiante(estudiante)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(_service.GetAllEstudiantes()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult FindBy(int id)
        {
            try
            {
                return new JsonResult(_service.GetById(id)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerIdEstudiante/{usuarioId}")]
        public IActionResult GetId(int usuarioId)
        {
            try
            {
                return new JsonResult(_service.ObtenerEstudianteId(usuarioId)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        //[Route("Dar de baja a un estudiante")]
        //[HttpGet]





    }

}
