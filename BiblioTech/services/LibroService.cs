using BiblioTech.Models;

namespace BiblioTech.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        // Agregar
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        // Eliminar por ISBN
        public void EliminarLibro(string isbn)
        {
            Libro libro = libros.Find(l => l.Isbn == isbn);
            if (libro != null)
                libros.Remove(libro);
        }

        // Obtener todos
        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        // Obtener disponibles
        public List<Libro> ObtenerDisponibles()
        {
            return libros.FindAll(l => l.Disponible);
        }

        // Obtener prestados
        public List<Libro> ObtenerPrestados()
        {
            return libros.FindAll(l => !l.Disponible);
        }

        // Buscar por ISBN
        public Libro BuscarPorIsbn(string isbn)
        {
            return libros.Find(l => l.Isbn == isbn);
        }

        // Buscar por título
        public Libro BuscarPorTitulo(string titulo)
        {
            return libros.Find(l => l.Titulo.Contains(titulo, 
                   StringComparison.OrdinalIgnoreCase));
        }

        // Buscar por autor
        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros.FindAll(l => l.Autor.Contains(autor, 
                   StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar
        public void ActualizarLibro(string isbn, Libro datosNuevos)
        {
            Libro libro = libros.Find(l => l.Isbn == isbn);
            if (libro != null)
            {
                libro.Titulo = datosNuevos.Titulo;
                libro.Autor = datosNuevos.Autor;
                libro.Disponible = datosNuevos.Disponible;
            }
        }

        // Ordenar por título
        public List<Libro> OrdenarPorTitulo()
        {
            List<Libro> ordenados = new List<Libro>(libros);
            ordenados.Sort((a, b) => string.Compare(a.Titulo, b.Titulo));
            return ordenados;
        }

        public int TotalLibros() => libros.Count;

        public int TotalDisponibles() => libros.FindAll(l => l.Disponible).Count;

        public int TotalPrestados() => libros.FindAll(l => !l.Disponible).Count;

    }
}