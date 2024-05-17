using Entidades;
using System.Reflection.Metadata;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Libro l1 = new Libro("Titulo1", "Yo", 2024, "123", "0123", 20);
            Libro l2 = new Libro("Titulo1", "Yo", 2024, "123", "0123", 20);

            Escaner escaner = new Escaner("Marca patito", Escaner.TipoDoc.libro);

            escaner.ListaDocumentos.Add(l1);

            bool agregadoL1 = escaner + l2;

            Console.WriteLine($"Libro agregado ?: {agregadoL1}");

        }
    }
}
