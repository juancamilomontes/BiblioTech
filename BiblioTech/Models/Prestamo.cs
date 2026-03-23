using System;

namespace BiblioTech.Models
{
    public class Prestamo
    {
        public int Id { get; set; } // Añadimos el ID
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public Prestamo() { Estado = EstadoPrestamo.Activo; FechaDevolucion = null; }

        // Constructor corregido para aceptar 5 argumentos (incluyendo el ID)
        public Prestamo(int id, Libro libro, Usuario usuario, DateTime inicio, DateTime fin)
        {
            Id = id;
            Libro = libro;
            Usuario = usuario;
            FechaInicio = inicio;
            FechaFin = fin;
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        public bool EstaVencido() => FechaDevolucion == null && DateTime.Now > FechaFin;
        public int DiasTranscurridos() => ((FechaDevolucion ?? DateTime.Now) - FechaInicio).Days;
        public string DetalleCompleto() => $"Préstamo #{Id} | Libro: {Libro.Titulo} | Usuario: {Usuario.Nombre} | Vencido: {EstaVencido()}";
    }
}