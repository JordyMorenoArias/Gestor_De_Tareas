using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    /// <summary>
    /// Clase estática que gestiona el historial de acciones para deshacer y rehacer.
    /// </summary>
    internal static class PilaHistorialAcciones
    {
        // Pila que almacena las acciones para deshacer, incluyendo tarea original y modificada.
        private static readonly Stack<(Tarea tareaOriginal, Tarea tareaModificada, string accion)> pilaDeshacer = new Stack<(Tarea, Tarea, string)>();

        // Pila que almacena las acciones para rehacer, incluyendo tarea original y modificada.
        private static readonly Stack<(Tarea tareaOriginal, Tarea tareaModificada, string accion)> pilaRehacer = new Stack<(Tarea, Tarea, string)>();

        /// <summary>
        /// Registra una acción en la pila de deshacer.
        /// </summary>
        /// <param name="tareaOriginal">La tarea original antes de la modificación.</param>
        /// <param name="tareaModificada">La tarea modificada después de la acción.</param>
        /// <param name="accion">El tipo de acción realizada.</param>
        public static void RegistrarAccion(Tarea tareaAnterior, Tarea tareaActual, string accion)
        {
            pilaDeshacer.Push((tareaAnterior, tareaActual, accion));
            pilaRehacer.Clear(); // Limpiar la pila de rehacer si se realiza una nueva acción
        }
        public static async Task Deshacer()
        {
            if (pilaDeshacer.Count > 0)
            {
                var (tareaAnterior, tareaActual, accion) = pilaDeshacer.Pop();
                pilaRehacer.Push((tareaAnterior, tareaActual, accion));

                try
                {
                    switch (accion)
                    {
                        case "Agregar":
                            // Si se deshizo una tarea agregada, la eliminamos
                            await Gestor.EliminarTarea(tareaActual);
                            break;
                        case "Eliminar":
                            // Si se deshizo una tarea eliminada, la restauramos
                            tareaAnterior.Activo = true;
                            await Gestor.AgregarTarea(tareaAnterior);
                            break;
                        case "Modificar":
                            // Revertir a la tarea original
                            await Gestor.ModificarTarea(tareaAnterior.Id, tareaAnterior);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine($"Error al deshacer la acción: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Rehace la última acción deshecha.
        /// </summary>
        public static async Task Rehacer()
        {
            if (pilaRehacer.Count > 0)
            {
                var (tareaOriginal, tareaModificada, accion) = pilaRehacer.Pop();
                pilaDeshacer.Push((tareaOriginal, tareaModificada, accion));

                try
                {
                    switch (accion)
                    {
                        case "Agregar":
                            // Si se rehizo una tarea agregada, la restauramos
                            await Gestor.AgregarTarea(tareaModificada);
                            break;
                        case "Eliminado":
                            // Si se rehizo una tarea eliminada, la eliminamos de nuevo
                            await Gestor.EliminarTarea(tareaOriginal);
                            break;
                        case "Modificar":
                            // Reaplicar la modificación
                            await Gestor.ModificarTarea(tareaOriginal.Id, tareaModificada);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine($"Error al rehacer la acción: {ex.Message}");
                }
            }
        }
    }
}
