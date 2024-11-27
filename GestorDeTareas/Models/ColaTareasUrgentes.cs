using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    internal class ColaTareasUrgentes
    {
        // Cola que contiene las tareas urgentes.
        private static Queue<Tarea> colaTareasUrgentes = new Queue<Tarea>();

        // Agrega una tarea a la cola de urgentes.
        public static void AgregarTareaUrgente(Tarea tarea)
        {
            colaTareasUrgentes.Enqueue(tarea);
        }

        // Procesa (elimina y devuelve) la tarea más antigua de la cola de urgentes.
        public static Tarea ProcesarTareaUrgente()
        {
            if (colaTareasUrgentes.Count > 0)
            {
                return colaTareasUrgentes.Dequeue();
            }
            return null;
        }

        // Devuelve todas las tareas urgentes en la cola.
        public static IEnumerable<Tarea> ObtenerTareasUrgentes()
        {
            return colaTareasUrgentes;
        }

        // Método para modificar una tarea en la cola de urgentes.
        public static void ModificarTareaUrgente(int tareaId, Tarea tareaModificada)
        {
            Queue<Tarea> nuevaCola = new Queue<Tarea>();

            // Procesar la cola original
            while (colaTareasUrgentes.Count > 0)
            {
                Tarea tareaActual = colaTareasUrgentes.Dequeue();

                // Si el ID coincide, agregar la tarea modificada en lugar de la original
                if (tareaActual.Id == tareaId)
                {
                    nuevaCola.Enqueue(tareaModificada);
                }
                else
                {
                    nuevaCola.Enqueue(tareaActual);
                }
            }

            // Reemplazar la cola original con la nueva
            colaTareasUrgentes = nuevaCola;
        }
    }
}
