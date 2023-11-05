
using Biblioteca.DTOs;
using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("prestamos")]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamosService prestamosService;

        public PrestamoController(PrestamosService service)
        {
            prestamosService = service;
        }

        [HttpGet("{id}")]
        public ActionResult<PrestamoConsultaDTO> ObtenerPrestamo(int id)
        {
            Prestamo? presEncontrado = prestamosService.ObtenerPrestamo(id);

            if (presEncontrado != null)
            {
                PrestamoConsultaDTO prestamo = new(presEncontrado.Id, presEncontrado.Nombre, presEncontrado.DiasPrestamo, presEncontrado.FueDevuelto ? "Si" : "No");
                return Ok(prestamo);
            }

            return BadRequest();
        }

        [HttpPost]
        public ActionResult CrearPrestamo(PrestamoManipulacionDTO p)
        {
            Prestamo prestamo = new() { Nombre = p.Nombre, DiasPrestamo = p.DiasPrestamo, FueDevuelto = p.FueDevuelto, LibroId = p.LibroId };

            if (prestamosService.AgregarPrestamo(prestamo))
            {
                return CreatedAtAction(nameof(ObtenerPrestamo), new { id = prestamo.Id }, new { prestamo.Id });
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarPrestamo(int id, PrestamoManipulacionDTO p)
        {
            Prestamo prestamo = new() { Nombre = p.Nombre, DiasPrestamo = p.DiasPrestamo, FueDevuelto = p.FueDevuelto, LibroId = p.LibroId };


            if (prestamosService.ActualizarPrestamo(id, prestamo))
            {
                return Ok($"Prestamo {id} actualizado correctamente");
            }

            return BadRequest();
        }
    }
}