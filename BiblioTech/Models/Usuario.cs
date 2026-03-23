namespace BiblioTech.Models
{
    public class Usuario
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public bool Activo { get; set; }

        public Usuario() { Activo = true; } // Condición: Inicializar en true

        public Usuario(string documento, string nombre, string contacto)
        {
            Documento = documento;
            Nombre = nombre;
            Contacto = contacto;
            Activo = true;
        }

        public string ResumenCorto() => $"{Nombre} ({Documento})";
        public string DetalleCompleto() => $"Nombre: {Nombre} | Doc: {Documento} | Contacto: {Contacto} | Activo: {Activo}";
        public override string ToString() => ResumenCorto();
    }
}