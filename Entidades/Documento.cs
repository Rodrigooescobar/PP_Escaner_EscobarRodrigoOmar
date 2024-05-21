using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        string numNormalizado;
        string titulo;
        Paso estado;

        // El estado debe inicializarse como “Inicio”.
        protected Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
            this.estado = Paso.Inicio;
        }

        public int Anio { get => anio;}
        public string Autor { get => autor;}
        public string Barcode { get => barcode; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }
        public Paso Estado { get => estado; }

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevicion,
            Terminado
        }

        // El método AvanzarEstado() debe pasar al siguiente estado dentro del orden que se
        // estableció en el requerimiento.Debe devolver false si el documento ya está
        // terminado.

        public bool AvanzarEstado()
        {
            switch (this.estado)
            {
                case Paso.Inicio:
                    this.estado = Paso.Distribuido;
                    return true;
                case Paso.Distribuido:
                    this.estado = Paso.EnEscaner;
                    return true;
                case Paso.EnEscaner:
                    this.estado = Paso.EnRevicion;
                    return true;
                case Paso.EnRevicion:
                    this.estado = Paso.Terminado;
                    return true;
                case Paso.Terminado:
                    return false;
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine($"Titulo: {this.titulo}");
            sb.AppendLine($"Autor: {this.autor}");
            sb.AppendLine($"Año: {this.anio}");
            sb.AppendLine($"Cód. de barras: {this.barcode}");

            return sb.ToString();
        }
    }
}
