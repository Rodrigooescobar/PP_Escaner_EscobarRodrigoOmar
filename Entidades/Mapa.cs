using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto) : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        public int Alto { get => alto; }
        public int Ancho { get => ancho; }
        public int Superficie { get => ancho * alto; }

        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return (m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor &&
                m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
        }

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1.Barcode == m2.Barcode);
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

            Mapa otroLibro = (Mapa)obj;

            return (this.Barcode == otroLibro.Barcode || (this.Titulo == otroLibro.Titulo && this.Autor == otroLibro.Autor &&
                this.Anio == otroLibro.Anio && this.Superficie == otroLibro.Superficie));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.Superficie} cm2.");

            return sb.ToString();
        }
    }
}
