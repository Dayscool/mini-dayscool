using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("ms_actividades/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ActividadService _actividadService;

        public ActividadController(ActividadService bookService)
        {
            _actividadService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Actividad>> Get() =>
            _actividadService.Get();


        [HttpGet("{idCurso:length(12)}", Name = "GetActividadByCourse")]
        public ActionResult<List<Actividad>> Get2(string idCurso)
        {
            var book = _actividadService.Get2(idCurso);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
            

        [HttpGet("{id:length(24)}", Name = "GetActividad")]
        public ActionResult<Actividad> Get(string id)
        {
            var book = _actividadService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Actividad> Create(Actividad book)
        {
            _actividadService.Create(book);

            return CreatedAtRoute("GetActividad", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Actividad bookIn)
        {
            var book = _actividadService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _actividadService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _actividadService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _actividadService.Remove(book.Id);

            return NoContent();
        }
    }
}