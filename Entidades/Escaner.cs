using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
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
            if (this.tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        /// <summary>
        /// Cambia el estado del documento de
        /// dentro de la lista de documentos.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            // Iterala lista de documentos
            foreach (Documento doc in listaDocumentos)
            {
                // Verifica si el documento es un Libro y usa la sobrecarga del operador ==
                if (d is Libro libro && ((Libro)d == (Libro)doc))
                {
                    return doc.AvanzarEstado();
                }
                // Verifica si el documento es un Mapa y usa la sobrecarga del operador ==
                else if (d is Mapa mapa && doc is Mapa mapaExistente && mapa == mapaExistente)
                {
                    return doc.AvanzarEstado();
                }
            }

            // Si el documento no se encuentra en la lista, retorna false
            return false;
        }

        /// <summary>
        /// La sobrecarga del operador “+” añade el documento a la lista de documentos en el
        /// caso de que no haya un documento igual ya en ella.También debe añadirlo solo si
        /// está en estado “Inicio”. Se añade a la lista se cambia el estado a
        /// “Distribuido”.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool operator +(Escaner e, Documento d)
        {
            // Si el documento no existe en la lista, el estado es Inicio, esta en deptoTecnicos y es un libro
            if (e != d && d.Estado == Documento.Paso.Inicio && e.locacion == Departamento.procesosTecnicos && d is Libro)
            {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                return true;
            }
            else
            {
                if (e != d && d.Estado == Documento.Paso.Inicio && e.locacion == Departamento.mapoteca && d is Mapa)
                {
                    d.AvanzarEstado();
                    e.listaDocumentos.Add(d);
                    return true;
                }
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
            foreach (Documento doc in e.listaDocumentos)
            {
                // Si el documento es un libro y ya existe uno con la misma cant. de hojas, retorna true
                //if (d.GetType() == typeof(Libro) && ((Libro)d).NumPaginas == ((Libro)doc).NumPaginas)
                //{
                //    return true;
                //}
                if(d is Libro && doc is Libro && ((Libro)d) == ((Libro)doc))
                {
                    return true;
                }
                // Si el documento es un mapa y ya existe uno con la misma superficie, retorna true
                else if (d is Mapa && doc is Mapa && ((Mapa)d) == ((Mapa)doc))
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

    }
}
