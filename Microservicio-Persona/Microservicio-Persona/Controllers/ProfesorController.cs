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

        [Route("obtenerProfesorByEspecialidad")] //Revisar la relacion entidad-profesor para corregirlo
        [HttpGet]
        public IActionResult GetProfesorEspecialidad(string especialidad)
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
        

      


        [Route("obtenerListadoProfesores")]
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


        // PUT api/<ProfesorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProfesorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
