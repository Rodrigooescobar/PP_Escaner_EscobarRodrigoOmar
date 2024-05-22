using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    // Cada uno de los informes públicos devolverá, dado un escáner y un estado en el que deban
    // encontrarse los documentos tenidos en cuenta, los siguientes datos:
    // - extensión: el total de la extensión de lo procesado según el escáner y el estado.Es
    // decir, el total de páginas en el caso de los libros y el total de cm2 en el caso de los
    // mapas.
    // - cantidad: el número total de ítems únicos procesados según el escáner y el estado.
    // - resumen: se muestran los datos de cada uno de los ítems contenidos en una lista
    // según el escáner y el estado.

    public static class Informes
    {
        /// <summary>
        /// Devuelve e: un escaner con el estado de los docuemntos en "Distribuidos",
        /// extensión: el total de páginas en el caso de los libros y el total de cm2 en el caso de los
        /// mapas, cantidad: el número total de ítems únicos procesados en estado "Distribuidos",  y resumen:
        /// muestran cada uno de los ítems contenidos en una lista, en el estado dicho anteriormente.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Devuelve e: un escaner con el estado de los documentos en "EnRevision",
        /// extensión: el total de páginas en el caso de los libros y el total de cm2 en el caso de los
        /// mapas, cantidad: el número total de ítems únicos procesados en estado "EnRevision",  y resumen:
        /// muestran cada uno de los ítems contenidos en una lista, en el estado dicho anteriormente.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.EnRevicion, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Devuelve e: un escaner con el estado de los documentos en "EnEscaner",
        /// extensión: el total de páginas en el caso de los libros y el total de cm2 en el caso de los
        /// mapas, cantidad: el número total de ítems únicos procesados en estado "EnEscaner",  y resumen:
        /// muestran cada uno de los ítems contenidos en una lista, en el estado dicho anteriormente.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Devuelve e: un escaner con el estado de los documentos en "Terminados",
        /// extensión: el total de páginas en el caso de los libros y el total de cm2 en el caso de los
        /// mapas, cantidad: el número total de ítems únicos procesados en estado "Terminados",  y resumen:
        /// muestran cada uno de los ítems contenidos en una lista, en el estado dicho anteriormente.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Devuelve e: un escaner con el estado de los documentos en segun el "estado" que se le pasa,
        /// extensión: el total de páginas en el caso de los libros y el total de cm2 en el caso de los
        /// mapas, cantidad: el número total de ítems únicos procesados en estado "Terminados",  y resumen:
        /// muestran cada uno de los ítems contenidos en una lista, en el estado dicho anteriormente.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="estado"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        private static void MostrarDocumentos(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            List<Documento> listaDistribuidos = new List<Documento>();

            // Extension: el total de paginas en el caso de los libros y el total de cm2 en el caso de los
            // mapas.
            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (doc is Libro)
                    {
                        Libro libro = (Libro)doc;
                        extension += libro.NumPaginas;
                    }
                    else
                    {
                        if (doc is Mapa mapa)
                        {
                            //Mapa mapa = (Mapa)doc;
                            extension += mapa.Superficie;
                        }
                    }
                    cantidad++;
                    listaDistribuidos.Add(doc);
                    resumen += doc.ToString();
                }
            }

            if (listaDistribuidos.Count == 0)
            {
                resumen = $"Escaner {e.Marca} sin Documentos en estado: {estado}";
            }

        }
    }
}
