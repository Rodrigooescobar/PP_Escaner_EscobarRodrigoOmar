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

        /// <summary>
        /// Compara 2 mapas si son iguales segun tengan : el mismo barcode o
        /// el mismo título y el mismo autor y el mismo año y la misma superficie.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            if (m1 is Mapa && m2 is Mapa)
            {
                return (m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor &&
                m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
            }
            return false;
        }

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1.Barcode == m2.Barcode);
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
