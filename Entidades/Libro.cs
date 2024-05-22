using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas) : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public int NumPaginas { get => numPaginas; }
        public string ISBN { get => NumNormalizado; }

        /// <summary>
        /// Compara 2 libros si son iguales segun tengan :
        /// el mismo barcode o el mismo ISBN o el mismo título y el mismo autor
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static bool operator ==(Libro l1, Libro l2)
        {
            if (l1 is Libro && l2 is Libro)
            {
                return (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN ||
                    (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
            }
            return false;
            //return l1.Equals(l2);
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public override string ToString()
        {
            string stringBase = base.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append(stringBase);
            int codBarras = stringBase.IndexOf("Cód.");

            sb.Insert(codBarras, $"ISBN: {this.ISBN} \n");
            sb.Append($"Número de páginas: {this.numPaginas}.");

            return sb.ToString();
        }
    }
}
