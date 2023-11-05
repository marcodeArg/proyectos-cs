using Microsoft.AspNetCore.Mvc;
using Biblioteca.Services;
using Biblioteca.Models;
using Biblioteca.DTOs;

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
        public ActionResult<List<LibroConsultaDTO>> ObtenerLibros([FromQuery] string titulo = null)
        {
            List<Libro> libros;

            if (string.IsNullOrWhiteSpace(titulo))
            {
                libros = librosService.ObtenerLibros();
            }
            else
            {
                libros = librosService.ObtenerLibros(titulo);
            }

            if (libros == null || libros.Count == 0)
            {
                return NotFound("No se encontraron libros.");
            }

            var librosDto = libros.Select(libro =>
                new LibroConsultaDTO(libro.Id, libro.Titulo, libro.PrecioReposicion, libro.Estado.Nombre)).ToList();

            return Ok(librosDto);
        }

        [HttpGet("{id}")]
        public ActionResult<LibroConsultaDTO> ObtenerLibro(int id)
        {
            var libEncontrado = librosService.ObtenerLibro(id);
            if (libEncontrado != null)
            {
                LibroConsultaDTO libro = new(libEncontrado.Id, libEncontrado.Titulo, libEncontrado.PrecioReposicion, libEncontrado.Estado.Nombre);

                return Ok(libro);
            }
            return NotFound();
        }

        [HttpGet("{id}/solicitantes")]
        public ActionResult<List<PrestamoConsultaDTO>> ObtenerPrestamos(int id)
        {
            List<Prestamo> solicitantes = librosService.ObtenerPrestamos(id);
            if (solicitantes != null)
            {
                List<PrestamoConsultaDTO> listPrestamos = solicitantes.Select(s => new PrestamoConsultaDTO(s.Id, s.Nombre, s.DiasPrestamo, s.FueDevuelto ? "Si" : "No")).ToList();

                return Ok(listPrestamos);
            }
            return NotFound();
        }

    }
}