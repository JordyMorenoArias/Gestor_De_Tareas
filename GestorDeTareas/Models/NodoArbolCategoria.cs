using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    internal class NodoArbolCategoria
    {
        // Nombre de la categoría.
        public string Nombre { get; set; }

        // Lista de tareas asociadas a esta categoría.
        public List<Tarea> Tareas { get; set; }

        // Lista de subcategorías dentro de esta categoría.
        public List<NodoArbolCategoria> Subcategorias { get; set; }

        // Constructor que inicializa una nueva instancia de la clase NodoCategoria.
        public NodoArbolCategoria(string nombre)
        {
            Nombre = nombre;
            Tareas = new List<Tarea>();
            Subcategorias = new List<NodoArbolCategoria>();
        }

        // Agrega una nueva subcategoría a la categoría actual.
        public void AgregarSubcategoria(NodoArbolCategoria subcategoria)
        {
            Subcategorias.Add(subcategoria);
        }

        // Agrega una nueva tarea a la categoría actual.
        public void AgregarTarea(Tarea tarea)
        {
            Tareas.Add(tarea);
        }

        // Devuelve todas las tareas dentro de esta categoría y sus subcategorías.
        public List<Tarea> ObtenerTareas()
        {
            List<Tarea> todasLasTareas = new List<Tarea>(Tareas);
            foreach (var subcategoria in Subcategorias)
            {
                todasLasTareas.AddRange(subcategoria.ObtenerTareas());
            }
            return todasLasTareas;
        }
    }
}
