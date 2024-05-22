# PP_Escaner_EscobarRodrigoOmar# Primer Parcial Laboratorio II
![imagen logo de la carrera](/imagenes/UTN.jpg "UTN Tecnicatura universitaria en programacionar")
<!-- UL-->
## Alumno:
---
* Rodrigo Omar Escobar

## PP Escaner
---
Requerimientos: 

En una biblioteca se van a escanear dos tipos de documento: mapas y libros. 

Necesitamos
un programa que nos permita saber en qué paso del proceso tenemos cada uno de los
documentos que se van a escanear y también sacar indicadores de tipo cuantitativo.
Los pasos del proceso, es decir, los estados en los que podemos encontrar los documentos
(de cualquiera de los dos tipos) son los siguientes:

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
---
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





