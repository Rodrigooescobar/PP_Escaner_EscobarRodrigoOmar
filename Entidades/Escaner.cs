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
        }

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        // La sobrecarga del operador “+” añade el documento a la lista de documentos en el
        // caso de que no haya un documento igual ya en ella.También debe añadirlo solo si
        // está en estado “Inicio”. Antes de añadirlo a la lista debe cambiar el estado a
        // “Distribuido”.
        public static bool operator +(Escaner e, Documento d)
        {
            if (e == d)
            {
                return false;
            }

            if (d.Estado == Documento.Paso.Inicio)
            {
                e.listaDocumentos.Add(d);
            }
            return true;
        }

        // La sobrecarga del operador “==” comprueba si hay un documento igual en la lista.
        // Devuelve true si encuentra, false si no.
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento lista in e.listaDocumentos)
            {
                // Si el documento es un libro y tiene la misma cantidad de paginas, son iguales
                //if (d is Libro && ((Libro)d).NumPaginas == ((Libro)lista).NumPaginas)
                //{
                //    return true;
                //}
                if(d.GetType() == typeof(Libro) && ((Libro)d).NumPaginas == ((Libro)lista).NumPaginas)
                {
                    return true;
                }
                // Si el documento es un mapa y ya existe uno con la misma superficie, son iguales
                else if (d is Mapa && lista is Mapa && ((Mapa)d).Superficie == ((Mapa)lista).Superficie)
                {
                    return true;
                }
            }

            return false;
        }

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
