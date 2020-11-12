using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Persona.Aplication.Services;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservicio_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _service;

        public ProfesorController(IProfesorService service)
        {
            _service = service;
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public IActionResult Post(ProfesorDTOs profesor) //primer post de creacion o agregar un estudiante 
        {
            try
            {
                return new JsonResult(_service.CreateProfesor(profesor)) { StatusCode = 200 };
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
                return new JsonResult(_service.GetAllProfesores()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return new JsonResult(await _service.GetById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route ("especialidad")]
        [HttpGet]
        public IActionResult GetProfesoresEspecialidad(string especialidad)
        {
            try
            {
                return new JsonResult(_service.GetProfesoresByEspecialidad(especialidad)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route ("TraerRegistro")]
        [HttpGet]
        public IActionResult GetRegistro()
        {
            try
            {
                return new JsonResult(_service.GetRegistros()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        // DELETE api/<ProfesorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
