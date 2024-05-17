using Entidades;
using System.Reflection.Metadata;
using static Entidades.Documento;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // En el caso de libros, se considerará que son el mismo libro cuando:
            // Tenga el mismo barcode o
            // tenga el mismo ISBN o
            // tenga el mismo título y el mismo autor.

            Escaner escanerLibro = new Escaner("Marca patito", Escaner.TipoDoc.libro);

            Libro l1 = new Libro("Titulo1", "Yo", 2024, "123", "0123", 20);
            Libro l2 = new Libro("Titulo1", "Yo", 2024, "1234", "01233", 20);
            Libro l3 = new Libro("Titulo2", "Yoo", 20245, "12345", "012334", 220);
            Libro l4 = new Libro("Titulo3", "Yooo", 203245, "123345", "0132334", 2220);

            escanerLibro.ListaDocumentos.Add(l1);
            Console.WriteLine($"Se agrega al escaner el libro: {l1}");

            Console.WriteLine($"Mismo Libro : {l1 == l2}");
            Console.WriteLine($"Distinto Libro : {l1 == l3}");
            Console.WriteLine($"Se puede agregar un libro Igual al escaner ?: " +
                              $"{escanerLibro + l2}");
            
            Console.WriteLine($"Se puede agregar un libro  distinto al escaner ?: " +
                              $"{escanerLibro + l3}");

            Console.WriteLine($"estado Libro que se agrego: {l3.Estado}");

            l4.AvanzarEstado();
            Console.WriteLine($"Estado de otro libro avanzado: {l4.Estado}");
            Console.WriteLine($"Se puede agregar el otro libro Avanzado al escaner ?: " +
                              $"{escanerLibro + l4}");


            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            // En el caso de los mapas se considerará que son el mismo mapa cuando:
            // Tenga el mismo barcode o
            // tenga el mismo título y el mismo autor y el mismo año y la misma superficie.

            Escaner escanerMapa = new Escaner("Marca acme", Escaner.TipoDoc.mapa);

            Mapa m1 = new Mapa("Titulomap1", "AutorMap", 2024, "", "01234", 10, 20);
            Mapa m2 = new Mapa("Titulomap1", "AutorMap", 2024, "", "01234", 10, 20);

            escanerMapa.ListaDocumentos.Add(m1);
            Console.WriteLine($"Se agrega al escaner el mapa: {m1}");

            Console.WriteLine($"Es el mismo mapa ? {m1 == m2}");
            Console.WriteLine($"Se puede agregar el otro libro al escaner ?: " +
                              $"{escanerMapa + m2}");



        }
    }
}
