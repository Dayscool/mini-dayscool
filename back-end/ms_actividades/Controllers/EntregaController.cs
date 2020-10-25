using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("ms_actividades/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly EntregaService _entregaService;

        public EntregaController(EntregaService bookService)
        {
            _entregaService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Entrega>> Get() =>
            _entregaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEntrega")]
        public ActionResult<Entrega> Get(string id)
        {
            var book = _entregaService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Entrega> Create(Entrega book)
        {
            _entregaService.Create(book);

            return CreatedAtRoute("GetEntrega", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Entrega bookIn)
        {
            var book = _entregaService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _entregaService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _entregaService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _entregaService.Remove(book.Id);

            return NoContent();
        }
    }
}