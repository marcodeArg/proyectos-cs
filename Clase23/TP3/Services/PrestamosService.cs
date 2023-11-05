using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class PrestamosService
    {
        private BibliotecaContext contexto = new();

        public int CantidadPrestamos()
        {
            return contexto.Prestamos.Count();
        }

        // Obtener prestamo por id
        public Prestamo? ObtenerPrestamo(int id)
        {
            return contexto.Prestamos.Include(x => x.Libro).FirstOrDefault(p => p.Id == id);
        }

        public bool AgregarPrestamo(Prestamo p)
        {
            try
            {
                contexto.Prestamos.Add(p);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ActualizarPrestamo(int id, Prestamo p)
        {
            try
            {
                Prestamo? encontrado = ObtenerPrestamo(id);

                if (encontrado != null)
                {
                    p.Id = encontrado.Id;
                    contexto.Prestamos.Entry(encontrado).CurrentValues.SetValues(p);

                    contexto.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}