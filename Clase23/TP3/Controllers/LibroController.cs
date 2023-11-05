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
        private readonly PrestamosService prestamosService;

        public LibroController(LibrosService service, PrestamosService servicePrest)
        {
            librosService = service;
            prestamosService = servicePrest;
        }

        [HttpGet] // Usado para obtener todos los libros o filtrar por titulo
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

        [HttpGet("{id}/solicitantes")]  // Obtener los solicitantes de un libro en particular
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

        [HttpPost]
        public ActionResult CrearLibro(LibroManipulacionDTO l)
        {
            Libro libro = new() { Titulo = l.Titulo, PrecioReposicion = l.PrecioReposicion, EstadoId = l.EstadoId };

            if (librosService.AgregarLibro(libro))
            {
                return CreatedAtAction(nameof(ObtenerLibros), new { libro.Id });
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<string> ActualizarLibro(int id, LibroManipulacionDTO l)
        {
            Libro libro = new() { Titulo = l.Titulo, PrecioReposicion = l.PrecioReposicion, EstadoId = l.EstadoId };

            if (librosService.ActualizarLibro(id, libro))
            {
                return Ok($"Libro {id} actualizado correctamente");
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public ActionResult<string> EliminarLibro(int id)
        {
            if (librosService.EliminarLibro(id))
            {
                return Ok($"Libro {id} eliminado correctamente");
            }

            return BadRequest();
        }

        [HttpGet("informe/estados")]
        public ActionResult<CantidadEstadoDTO> ObtenerCantidadPorEstado()
        {
            var (cantDisponible, cantPrestados, cantExtraviados) = librosService.CantidadPorEstado();

            var resultado = new CantidadEstadoDTO(cantDisponible, cantPrestados, cantExtraviados);

            return Ok(resultado);
        }

        [HttpGet("informe/total")]
        public ActionResult<decimal> ObtenerTotalExtraviados()
        {
            var totalExtraviados = librosService.TotalExtraviados();
            return Ok(totalExtraviados);
        }

        [HttpGet("informe/promedio")]
        public ActionResult<decimal> ObtenerPromedioPrestamos()
        {
            var promedio = (decimal)prestamosService.CantidadPrestamos() / librosService.CantidadLibros();
            return Ok(promedio);
        }

        [HttpGet("informe/multiples")]
        public ActionResult<IEnumerable<SolicitudesLibrosDTO>> GetLibrosSolicitadosMasDeUnaVez()
        {
            var resultado = librosService.LibrosSolicitadosMasDeUnaVez();
            if (resultado.Any())
            {
                return Ok(resultado);
            }

            return NoContent();

        }


    }
}