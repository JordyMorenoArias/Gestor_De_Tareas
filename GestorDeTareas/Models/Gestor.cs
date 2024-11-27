using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestorDeTareas.Models
{
    // Clase que gestiona la lista de tareas pendientes.
    public class Gestor
    {
        // Arreglo privado que contiene todas las tareas.
        private static List<Tarea> tareas = new List<Tarea>();

        // Método para agregar una nueva tarea a la lista.
        public static void AgregarTarea(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        // Método para eliminar una tarea de la lista.
        public static void EliminarTarea(Tarea tarea)
        {
            tareas.Remove(tarea);
        }

        // Método para modificar una tarea existente en la lista.
        public static void ModificarTarea(Tarea tareaOriginal, Tarea tareaModificada)
        {
            var indice = tareas.IndexOf(tareaOriginal);
            if (indice != -1)
            {
                tareas[indice] = tareaModificada;
            }
        }

        // Ordena la lista de tareas en orden descendente según la fecha de creación.
        public static void OrdenarReciente()
        {
            tareas = tareas.OrderByDescending(t => t.FechaCreacion).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la fecha de creación.
        public static void OrdenarAntiguo()
        {
            tareas = tareas.OrderBy(t => t.FechaCreacion).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la fecha de vencimiento.
        public static void OrdenarFechaLimite()
        {
            tareas = tareas.OrderBy(t => t.FechaVencimiento).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la prioridad.
        public static void OrdenarPrioridad()
        {
            tareas = tareas.OrderBy(t => t.Prioridad).ToList();
        }

        // Este método decide qué tipo de ordenamiento aplicar a la lista de tareas 
        public static void Ordernamiento(string TipoDeOrden)
        {
            switch (TipoDeOrden)
            {
                case "Prioridad":
                    OrdenarPrioridad();
                    break;
                case "Antiguo":
                    OrdenarAntiguo();
                    break;
                case "Fecha Limite":
                    OrdenarFechaLimite();
                    break;
                default:
                    OrdenarReciente();
                    break;
            }
        }

        // Devuelve la lista ordenada de tareas.
        public static List<Tarea> ObtenerTareas() => tareas;
    }
}
