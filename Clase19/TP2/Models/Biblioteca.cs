using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Biblioteca
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual List<Libro> Libros { get; }

        private BibliotecaContext contexto;

        public Biblioteca()
        {
            Libros = new();
            contexto = new();
        }

        public Biblioteca(string nombre)
        {
            contexto = new();


            Nombre = nombre;
            contexto.Bibliotecas.Add(this);
            contexto.SaveChanges();

            Libros = contexto.Libros.ToList();
        }

        public void AgregarLibro(Libro l)
        {
            Libros.Add(l);

            using (var transaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    contexto.Libros.Add(l);
                    contexto.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);

                }
            }
        }

        public void AgregarPrestamo(Prestamo p)
        {
            using (var transaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    contexto.Prestamos.Add(p);
                    contexto.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
                }
            }
        }











        // Puntos del ejercicio

        public void CantidadPorEstado()
        {
            try
            {
                var estados = Libros.GroupBy(libro => libro.Estado).Select(e => e.Count());
                Console.WriteLine(estados);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}

