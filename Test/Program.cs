using Entidades;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using static Entidades.Documento;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escaner escanerLibro = new Escaner("Marca patito", Escaner.TipoDoc.libro);

            Libro l1 = new Libro("TituloLibro1", "Yo1", 2024, "123", "0123", 20);
            Libro l2 = new Libro("TituloLibro1", "Yo1", 2024, "1234", "01233", 20);
            Libro l3 = new Libro("TituloLibro3", "Yoo3", 20245, "12345", "012334", 220);
            Libro l4 = new Libro("TituloLibro4", "Yooo4", 203245, "123345", "0132334", 2220);
            Libro l5 = new Libro("TituloLibro5", "Yooo5", 203245, "123345", "0132334", 2220);
            Libro l6 = new Libro("TituloLibro6", "Yooo6", 2032456, "1233456", "013233456", 26);
            Libro l7 = new Libro("TituloLibro7", "Yooo7", 20324567, "123345567", "0132334567", 27);
            Libro l8 = new Libro("TituloLibro8", "Yooo8", 203245678, "123345678", "01323345678", 28);
            Libro l9 = new Libro("TituloLibro9", "Yooo9", 2032456789, "1233456789", "013233456789", 29);
            Libro l10 = new Libro("TituloLibro10", "Yooo10", 20324510, "12334510", "013233410", 30);
            Libro l11 = new Libro("TituloLibro6", "Yooo11", 20324511, "12334511", "013233411", 31);
            Mapa mapa = new Mapa("TituloMapa", "AutorMapA", 2030, "", "12345", 2, 5);

            if (escanerLibro + l1)
                Console.WriteLine($"Se agrega al escaner el libro: {l1}");

            Console.WriteLine();
            Console.WriteLine($"Agrego el mismo Libro: libro es igual ? T: {l1 == l2}");
            Console.WriteLine($"Agrego distinto Libro: libro es igual ? F: {l1 == l3}");

            Console.WriteLine();
            Console.WriteLine($"Se puede agregar un libro Igual al escaner ? F: " +
                              $"{escanerLibro + l2}");

            Console.WriteLine($"Se puede agregar un libro  distinto al escaner ? T: " +
                              $"{escanerLibro + l3}");

            Console.WriteLine();
            Console.WriteLine($"Pruebo == de escaner, comparo el mismo libro a la lista T: " +
                              $"{escanerLibro == l1}");

            Console.WriteLine($"Pruebo == de escaner, comparo un libro distinto a la lista F: " +
                              $"{escanerLibro == l4}");
            Console.WriteLine($"Pruebo == de escaner, con un mapa F: {escanerLibro == mapa}");

            Console.WriteLine($"Estado del libro que se agrego: {l3.Estado}");

            Console.WriteLine();
            l4.AvanzarEstado();
            Console.WriteLine($"Avanzo el estado de otro libro a (Distribuido): {l4.Estado}");

            Console.WriteLine();
            Console.WriteLine($"Se puede agregar el libro Distribuido al escaner ? F: " +
                              $"{escanerLibro + l4}");

            Console.WriteLine();
            Console.WriteLine($"Sepuede agregar un mapa al escaner de libros ? F:{escanerLibro + mapa}");

            l10.AvanzarEstado();
            l10.AvanzarEstado();
            l10.AvanzarEstado();
            l10.AvanzarEstado();
            Console.WriteLine();
            Console.WriteLine($"Avanzando un libro terminado F: {l10.AvanzarEstado()}");

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////// Probando escaner de mapas ///////////");
            Console.WriteLine();
            Escaner escanerMapa = new Escaner("Marca acme", Escaner.TipoDoc.mapa);

            Mapa m1 = new Mapa("Titulomap1", "AutorMap", 2024, "", "1234", 10, 20);
            Mapa m2 = new Mapa("Titulomap1", "AutorMap", 2024, "", "1234", 10, 20);
            Mapa m3 = new Mapa("Titulomap3", "AutorMap3", 2023, "", "0123", 20, 30);
            Mapa m4 = new Mapa("Titulomap4", "AutorMap4", 2022, "", "01234", 30, 40);
            Mapa m5 = new Mapa("Titulomap5", "AutorMap5", 2021, "", "012345", 40, 50);
            Mapa m6 = new Mapa("Titulomap6", "AutorMap6", 2020, "", "0123456", 50, 60);

            escanerMapa.ListaDocumentos.Add(m1);
            Console.WriteLine($"Se agrega al escaner el mapa: {m1}");

            Console.WriteLine($"Agrego el mismo mapa: mapa igual ? T: {m1 == m2}");
            Console.WriteLine($"Agrego distinto mapa: mapa igual ? F: {m1 == m3}");
            Console.WriteLine($"Se puede agregar un mapa igual al escaner ? F: " +
                              $"{escanerMapa + m2}");
            Console.WriteLine($"Se puede agregar un mapa distinto al escaner ? T: " +
                              $"{escanerMapa + m3}");

            m4.AvanzarEstado();
            Console.WriteLine($"Se puede agregar un mapa Avanzado al escaner ? F: " +
                              $"{escanerMapa + m4}");

            Console.WriteLine($"Se puede agregar un libro al escaner ? F: " +
                              $"{escanerMapa + l6}");

            Console.WriteLine();
            Console.WriteLine($"Pruebo == de escaner, comparo con un mapa de la lista T: " +
                              $"{escanerMapa == m1}");

            Console.WriteLine($"Pruebo == de escaner, comparo un mapa distinto de la lista F: " +
                              $"{escanerMapa == m5}");

            Console.WriteLine($"Pruebo == de escaner, con un libro F: {escanerMapa == l5}");

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("///// Probando clase informe en Esc. Libro ///////");
            Console.WriteLine();
            // Variables para los resultados
            int extension;
            int cantidad;
            string resumen;

            // agrego un libro en estado inicio l5  y otro EnRevision l6
            Console.WriteLine("En total son 8 libros, 2 de cada Estado");
            l4.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l4);
            l5.AvanzarEstado();
            l5.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l5);
            // l6 en revicion
            l6.AvanzarEstado();
            l6.AvanzarEstado();
            l6.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l6);
            // l7 en revicion
            l7.AvanzarEstado();
            l7.AvanzarEstado();
            l7.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l7);
            // l8 terminado
            l8.AvanzarEstado();
            l8.AvanzarEstado();
            l8.AvanzarEstado();
            l8.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l8);
            // l9 terminado
            l9.AvanzarEstado();
            l9.AvanzarEstado();
            l9.AvanzarEstado();
            l9.AvanzarEstado();
            escanerLibro.ListaDocumentos.Add(l9);

            // Mostrar los resultados
            // Llamar al metodo MostrarDistribuidos
            Informes.MostrarDistribuidos(escanerLibro, out extension, out cantidad, out resumen);
            Console.WriteLine("Metodo MostrarDistribuidos, solo debe mostrar 2 l1 y l3:");
            Console.WriteLine($"Extensión total: {extension}");
            Console.WriteLine($"Cantidad total de ítems: {cantidad}");
            Console.WriteLine(resumen);

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine();

            // Llamar al metodo EnEscaner
            Informes.MostrarEnEscaner(escanerLibro, out extension, out cantidad, out resumen);
            Console.WriteLine("Metodo EnEscaner, solo debe mostrar 2: l4 y l5");
            Console.WriteLine($"Extensión total: {extension}");
            Console.WriteLine($"Cantidad total de ítems: {cantidad}");
            Console.WriteLine(resumen);

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine();

            // Llamar al metodo MostrarEnRevision
            Informes.MostrarEnRevision(escanerLibro, out extension, out cantidad, out resumen);
            Console.WriteLine("Metodo MostrarEnRevision, solo debe mostrar 2: l6 y l7");
            Console.WriteLine($"Extensión total: {extension}");
            Console.WriteLine($"Cantidad total de ítems: {cantidad}");
            Console.WriteLine(resumen);

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine();

            // Llamar al metodo MostrarTerminado
            Informes.MostrarTerminados(escanerLibro, out extension, out cantidad, out resumen);
            Console.WriteLine("Metodo MostrarTerminados, solo debe mostrar 2: l8 y l9");
            Console.WriteLine($"Extensión total: {extension}");
            Console.WriteLine($"Cantidad total de ítems: {cantidad}");
            Console.WriteLine(resumen);
        }
    }
}
