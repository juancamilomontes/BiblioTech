using System;

namespace BiblioTech.Models
{
    public class Prestamo
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaDevolucion { get; set; } // DateTime? es anulable
        public EstadoPrestamo Estado { get; set; }

        public Prestamo() 
        { 
            Estado = EstadoPrestamo.Activo; // Condición: Estado inicial Activo
            FechaDevolucion = null;          // Condición: Fecha inicial null
        }

        public Prestamo(Libro libro, Usuario usuario, DateTime inicio, DateTime fin)
        {
            Libro = libro;
            Usuario = usuario;
            FechaInicio = inicio;
            FechaFin = fin;
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        public bool EstaVencido() => FechaDevolucion == null && DateTime.Now > FechaFin;
        public int DiasTranscurridos() => ( (FechaDevolucion ?? DateTime.Now) - FechaInicio ).Days;
        public string ResumenCorto() => $"{Libro.Titulo} prestado a {Usuario.Nombre}";
        public string DetalleCompleto() => $"Libro: {Libro.Titulo} | Usuario: {Usuario.Nombre} | Estado: {Estado} | Vencido: {EstaVencido()}";
        public override string ToString() => ResumenCorto();
    }
}