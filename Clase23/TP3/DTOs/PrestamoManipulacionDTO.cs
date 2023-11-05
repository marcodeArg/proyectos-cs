
namespace Biblioteca.DTOs
{
    public record PrestamoManipulacionDTO(string Nombre, int DiasPrestamo, bool FueDevuelto, int LibroId);

}