namespace BiblioTech.Models
{
    public class Libro
    {
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; }

        public Libro() { Disponible = true; }

        public Libro(string isbn, string titulo, string autor)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Disponible = true;
        }

        public string ResumenCorto() => $"{Titulo} - {Autor}";
        public string DetalleCompleto() => $"ISBN: {Isbn} | Título: {Titulo} | Autor: {Autor} | Disponible: {Disponible}";
        public override string ToString() => ResumenCorto();
    }
}