using Microsoft.AspNetCore.Mvc;
using Biblioteca.Services;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("libros")]
    public class LibroController : ControllerBase
    {

        private readonly LibrosService librosService;

        public LibroController(LibrosService service)
        {
            librosService = service;
        }

        [HttpGet]
        public ActionResult<List<Libro>> ObtenerLibros()
        {
            return Ok(librosService.ObtenerLibros());
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> ObtenerLibro(int id)
        {
            Libro? libro = librosService.ObtenerLibro(id);
            if (libro != null)
            {
                return Ok(libro);
            }
            return NotFound();
        }

        [HttpGet("titulos")]
        public ActionResult<List<Libro>> ObtenerLibros([FromQuery] string titulo)
        {
            List<Libro> libros = librosService.ObtenerLibros(titulo);
            if (libros != null)
            {
                return Ok(libros);
            }
            return NotFound();
        }
    }
}