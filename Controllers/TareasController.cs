using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ListaTareas.DTOs;
using ListaTareas.Models;
using ListaTareas.Interfaces;


namespace ListaTareas.Controllers
{
    [Route("[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareas _context;
       
       
        public TareasController(ITareas context )
        {
            _context = context;           
          
        }

        // GET: api/<controller>
        [HttpGet]
       public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            var tarea = await _context.GetTareas();

            if (tarea==null)
            {
                return NotFound("No Existen tareas.");
            }

            return Ok(tarea);
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}" , Name="GetTareaById")]
        public async Task<ActionResult<Tarea>> GetTareaById(int id)
        {
            var tarea = await _context.GetTareaById(id);

            if (tarea==null)
            {
                return NotFound("Tarea no Encontrada.");
            }
           
            return Ok(tarea);
        }

      
        // POST /controller
        [HttpPost]
        public ActionResult<Tarea> CreateTarea([FromBody]Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest(ModelState);
            }
            _context.CreateTarea(tarea);
         
            return CreatedAtRoute(nameof(GetTareaById), new { id = tarea.Id }, tarea);
        }

        // PUT /controller>/5
        [HttpPatch("{id}", Name = "UpdateTarea")]
        public ActionResult UpdateTarea(int Id, [FromBody] Tarea tarea )
        {

            if (tarea ==null  || Id!= tarea.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_context.BuscarTareaId(Id))
            {
                return NotFound("No Existe ninguna tarea con ese ID.");
            }


            _context.UpdateTarea(tarea);
            return NoContent();        
        }
        

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
           
            if (!_context.BuscarTareaId(Id))
            {
                return NotFound("No Existe ninguna tarea con ese ID.");
            }

            var objTarea = await _context.GetTareaById(Id);

            if (!_context.DeleteTarea(objTarea))
            {

                return StatusCode(500,ModelState);
            }
            
            return NoContent(); ;

        }
    }
}
