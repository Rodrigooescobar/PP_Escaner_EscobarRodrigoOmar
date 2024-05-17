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

        public static bool operator ==(Libro l1, Libro l2)
        {
            return (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || 
                (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));

            //return l1.Equals(l2);
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object? obj)
        {
            //if (obj is Libro && obj != null)
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Libro otroLibro = (Libro)obj;

            return (this.Barcode == otroLibro.Barcode || this.ISBN == otroLibro.ISBN || 
                this.Titulo == otroLibro.Titulo && this.Autor == otroLibro.Autor);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"ISBN: {this.ISBN}");
            sb.AppendLine($"Cód: de barras: {this.Barcode}");
            sb.AppendLine($"Número de páginas: {this.numPaginas}.");

            return sb.ToString();
        }
    }
}
