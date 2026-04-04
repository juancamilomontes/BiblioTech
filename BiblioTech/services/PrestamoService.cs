using BiblioTech.Models;

namespace BiblioTech.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        // Agregar
        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        // Eliminar por ID
        public void EliminarPrestamo(int id)
        {
            Prestamo prestamo = prestamos.Find(p => p.Id == id);
            if (prestamo != null)
                prestamos.Remove(prestamo);
        }

        // Obtener todos
        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        // Obtener activos
        public List<Prestamo> ObtenerActivos()
        {
            return prestamos.FindAll(p => p.Estado == EstadoPrestamo.Activo);
        }

        // Obtener devueltos
        public List<Prestamo> ObtenerDevueltos()
        {
            return prestamos.FindAll(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        // Obtener vencidos
        public List<Prestamo> ObtenerVencidos()
        {
            return prestamos.FindAll(p => p.EstaVencido());
        }

        // Buscar por ID
        public Prestamo BuscarPorId(int id)
        {
            return prestamos.Find(p => p.Id == id);
        }

        // Buscar por estado
        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            return prestamos.FindAll(p => p.Estado == estado);
        }

        // Registrar devolución
        public void RegistrarDevolucion(int id)
        {
            Prestamo prestamo = prestamos.Find(p => p.Id == id);
            if (prestamo != null)
            {
                prestamo.Estado = EstadoPrestamo.Devuelto;
                prestamo.FechaDevolucion = DateTime.Now;
                prestamo.Libro.Disponible = true;
            }
        }

        // Actualizar estados vencidos
        public void ActualizarEstadosVencidos()
        {
            foreach (Prestamo p in prestamos)
            {
                if (p.EstaVencido() && p.Estado == EstadoPrestamo.Activo)
                    p.Estado = EstadoPrestamo.Vencido;
            }
        }

        // Ordenar por fecha límite
        public List<Prestamo> OrdenarPorFechaFin()
        {
            List<Prestamo> ordenados = new List<Prestamo>(prestamos);
            ordenados.Sort((a, b) => DateTime.Compare(a.FechaFin, b.FechaFin));
            return ordenados;
        }

        public int TotalPrestamos() => prestamos.Count;

        public int TotalActivos() => prestamos.FindAll(p => p.Estado == EstadoPrestamo.Activo).Count;

        public int TotalVencidos() => prestamos.FindAll(p => p.EstaVencido()).Count;

        public int TotalDevueltos() => prestamos.FindAll(p => p.Estado == EstadoPrestamo.Devuelto).Count;

        public double PromedioDiasPrestamo()
        {
            if (prestamos.Count == 0) return 0;
            double total = 0;
            foreach (Prestamo p in prestamos)
                total += p.DiasTranscurridos();
            return total / prestamos.Count;
        }
    }
}