# Primer Parcial Laboratorio II
---
![imagen logo de la carrera](/imagenes/UTN.jpg "UTN Tecnicatura universitaria en programacionar")
<!-- UL-->
## Alumno:
---
* Rodrigo Omar Escobar

## PP Escaner
---
**Requerimientos:**
<p style="text-align: justify;">
En una biblioteca se van a escanear dos tipos de documento: mapas y libros.  
Necesitamos
un programa que nos permita saber en qué paso del proceso tenemos cada uno de los
documentos que se van a escanear y también sacar indicadores de tipo cuantitativo.
Los pasos del proceso, es decir, los estados en los que podemos encontrar los documentos
(de cualquiera de los dos tipos) son los siguientes:
<p>

* Inicio: el valor por defecto de los documentos.
* Distribuido: el documento ya está en el escáner que le corresponde.
* EnEscaner: el documento está siendo escaneado.
* EnRevision: el documento está en el paso del proceso en el que se revisa si el escaneo
no tuvo fallos (problemas de pixelado, páginas faltantes…).
* Terminado: el documento ya ha sido escaneado y aprobado pues el proceso de revisión
fue positivo.
El programa tendrá mecanismos de control para no cometer el error de escanear dos veces
el mismo documento.
En el caso de libros, se considerará que son el mismo libro cuando:
* Tenga el mismo barcode o
* tenga el mismo ISBN o
* tenga el mismo título y el mismo autor.
En el caso de los mapas se considerará que son el mismo mapa cuando:
* Tenga el mismo barcode o
* tenga el mismo título y el mismo autor y el mismo año y la misma superficie.

## Esquema
---
### Clase Documento (padre)
![imagen de un punto de requisito](/imagenes/documento.jpg "Clase Documento")
* La propiedad de NumNormalizado solo debe poder verse desde las clases
derivadas.
* El estado debe inicializarse como “Inicio”.
* El método ToString() debe usar StringBuilder para mostrar todos los datos del
documento.
* El método AvanzarEstado() debe pasar al siguiente estado dentro del orden que se
estableció en el requerimiento. Debe devolver false si el documento ya está
terminado.
<!-- Bloque de codigos -->
```C#
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
```
### Clase Libro y Mapa (hijas)
![imagen de un punto de requisito](/imagenes/libro-mapa.jpg "Clase Libro")
* La sobrecarga del operador “==” debe funcionar según lo descripto en el
requerimiento para cada uno de los dos tipos de documento.

* La propiedad ISBN en los libros muestra el NumNormalizado.
* Los mapas no tienen NumNormalizado.
* La superficie de los mapas se calcula multiplicando alto por ancho.
* El método ToString() debe mostrar todos los datos del documento en cuestión (los
de la clase de la que heredan y los propios, incluida la superficie en el caso de los
mapas). Usar StringBuilder.
#### Codigos hechos segun los requisitos pedidos.
<!-- Bloque de codigos -->
```C#
public static bool operator ==(Libro l1, Libro l2)
        {
            if (l1 is Libro && l2 is Libro)
            {
                return (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN ||
                    (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
            }
            return false;
        }
```
```C#
 public static bool operator ==(Mapa m1, Mapa m2)
        {
            if (m1 is Mapa && m2 is Mapa)
            {
                return (m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor &&
                m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
            }
            return false;
        }
```

**La información sobre los libros debe mostrarse así:**

![imagen de un punto de requisito](/imagenes/info-libro.jpg "informacion de libro")

**La información sobre los mapa debe mostrarse así:**

![imagen de un punto de requisito](/imagenes/info-mapa.jpg "informacion de mapa")

### Clase Escaner
![imagen de un punto de requisito](/imagenes/documento.jpg "Clase Documento")

* El constructor debe inicializar la lista de documentos.
* El constructor inicializa la locación según el tipo de documento a escanear (si es
“mapa” la locación es “mapoteca” y si es “libro” va a “procesosTecnicos”).
* La sobrecarga del operador “==” comprueba si hay un documento igual en la lista.
Devuelve true si encuentra, false si no.
* La sobrecarga del operador “+” añade el documento a la lista de documentos en el
caso de que no haya un documento igual ya en ella. También debe añadirlo solo si
está en estado “Inicio”. Antes de añadirlo a la lista debe cambiar el estado a
“Distribuido”.
* El método “CambiarEstadoDocumento()” cámbiará el estado del documento de
dentro de la lista de documentos.
#### Codigos hechos segun los requisitos pedidos.
<!-- Bloque de codigos -->
```C#
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento doc in e.listaDocumentos)
            {
                // Si el documento es un libro y ya existe uno con la misma cant. de hojas, retorna true
                if(d is Libro && doc is Libro && ((Libro)d).NumPaginas == ((Libro)doc).NumPaginas)
                {
                    return true;
                }
                // Si el documento es un mapa y ya existe uno con la misma superficie, retorna true
                else if (d is Mapa && doc is Mapa && ((Mapa)d).Superficie == ((Mapa)doc).Superficie)
                {
                    return true;
                }
            }

            // No encontro ningun libro o mapa igual en el escaner, retorna falso
            return false;
        }
```
<!-- Bloque de codigos -->
```C#
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
```
```C#
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
```
### Clase Escaner
![imagen de un punto de requisito](/imagenes/informe.jpg "Clase Informe")

<p style="text-align: justify;">
Cada uno de los informes públicos devolverá, dado un escáner y un estado en el que deban
encontrarse los documentos tenidos en cuenta, los siguientes datos:
<p>

* extensión: el total de la extensión de lo procesado según el escáner y el estado. Es
decir, el total de páginas en el caso de los libros y el total de cm2 en el caso de los
mapas.
* cantidad: el número total de ítems únicos procesados según el escáner y el estado.
* resumen: se muestran los datos de cada uno de los ítems contenidos en una lista
según el escáner y el estado.

#### Metodo privado que se va a reutilizar para no repetir codigo.
```C#
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
                resumen = $"Escaner {e.Marca} sin Documentos en estado Distriudo";
            }
        }
```
#### Usamos el metodo privado en los siguientes metodos para no repetir codigo.
```C#
public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.EnRevicion, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

         public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentos(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
```





