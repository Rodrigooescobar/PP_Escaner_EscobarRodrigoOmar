using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            listaDocumentos = new List<Documento>();
            this.locacion = IniciarLocacion();
        }

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }


        /// <summary>
        /// La sobrecarga del operador “+” añade el documento a la lista de documentos en el
        /// caso de que no haya un documento igual ya en ella.También debe añadirlo solo si
        /// está en estado “Inicio”. Despues de añadirlo a la lista se cambia el estado a
        /// “Distribuido”.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool operator +(Escaner e, Documento d)
        {
            if (e == d)
            {
                return false;
            }

            if (d.Estado == Documento.Paso.Inicio)
            {
                e.listaDocumentos.Add(d);
                d.AvanzarEstado();
                return true;
            }

            return false;
        }


        /// <summary>
        /// La sobrecarga del operador “==” comprueba si hay un documento igual en la lista.
        /// Devuelve true si encuentra, false si no.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento lista in e.listaDocumentos)
            {
                // Si el documento es un libro y ya existe uno con la misma cant. de hojas, retorna true
                if (d.GetType() == typeof(Libro) && ((Libro)d).NumPaginas == ((Libro)lista).NumPaginas)
                {
                    return true;
                }
                // Si el documento es un mapa y ya existe uno con la misma superficie, retorna true
                else if (d is Mapa && lista is Mapa && ((Mapa)d).Superficie == ((Mapa)lista).Superficie)
                {
                    return true;
                }
            }

            // No encontro ningun libro o mapa igual en el escaner, retorna falso
            return false;
        }

        // Sobrcarga del operador != (distinto)
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }

        /// <summary>
        /// Metodo para inicializar la locacion del escaner, segun el tipo: 
        /// Si el escáner es de mapas se inicializa en la mapoteca y si es de
        /// libros en la oficina de procesos técnicos.
        /// </summary>
        /// <returns></returns>
        private Departamento IniciarLocacion()
        {
            if (this.tipo == TipoDoc.libro)
            {
                return Departamento.procesosTecnicos;
            }
            else
            {
                return Departamento.mapoteca;
            }
        }

        // No se configura el metodo Equals ya que no pide el enunciado
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        // No se configura el metodo GetHashCode, ya que no pide el enunciado
        public override int GetHashCode()
        {
            return 0;
        }

    }
}
