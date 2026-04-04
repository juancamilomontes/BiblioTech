using BiblioTech.Models;

namespace BiblioTech.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        // Agregar
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        // Eliminar por documento
        public void EliminarUsuario(string documento)
        {
            Usuario usuario = usuarios.Find(u => u.Documento == documento);
            if (usuario != null)
                usuarios.Remove(usuario);
        }

        // Obtener todos
        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        // Obtener activos
        public List<Usuario> ObtenerActivos()
        {
            return usuarios.FindAll(u => u.Activo);
        }

        // Obtener inactivos
        public List<Usuario> ObtenerInactivos()
        {
            return usuarios.FindAll(u => !u.Activo);
        }

        // Buscar por documento
        public Usuario BuscarPorDocumento(string documento)
        {
            return usuarios.Find(u => u.Documento == documento);
        }

        // Buscar por nombre
        public Usuario BuscarPorNombre(string nombre)
        {
            return usuarios.Find(u => u.Nombre.Contains(nombre,
                   StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar
        public void ActualizarUsuario(string documento, Usuario datosNuevos)
        {
            Usuario usuario = usuarios.Find(u => u.Documento == documento);
            if (usuario != null)
            {
                usuario.Nombre = datosNuevos.Nombre;
                usuario.Contacto = datosNuevos.Contacto;
                usuario.Activo = datosNuevos.Activo;
            }
        }

        // Ordenar por nombre
        public List<Usuario> OrdenarPorNombre()
        {
            List<Usuario> ordenados = new List<Usuario>(usuarios);
            ordenados.Sort((a, b) => string.Compare(a.Nombre, b.Nombre));
            return ordenados;
        }

        public int TotalUsuarios() => usuarios.Count;

        public int TotalActivos() => usuarios.FindAll(u => u.Activo).Count;

        public int TotalInactivos() => usuarios.FindAll(u => !u.Activo).Count;


    }
}