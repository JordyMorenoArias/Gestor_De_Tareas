using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    internal static class PilaHistorialAcciones
    {
        // Pila que almacena las acciones para deshacer, incluyendo tarea original y modificada.
        private static Stack<(Tarea tareaOriginal, Tarea tareaModificada, string accion)> pilaDeshacer = new Stack<(Tarea, Tarea, string)>();

        // Pila que almacena las acciones para rehacer, incluyendo tarea original y modificada.
        private static Stack<(Tarea tareaOriginal, Tarea tareaModificada, string accion)> pilaRehacer = new Stack<(Tarea, Tarea, string)>();

        // Registra una acción en la pila de deshacer.
        public static void RegistrarAccion(Tarea tareaOriginal, Tarea tareaModificada, string accion)
        {
            pilaDeshacer.Push((tareaOriginal, tareaModificada, accion));
            pilaRehacer.Clear(); // Limpiar la pila de rehacer si se realiza una nueva acción
        }

        // Deshace la última acción registrada y la almacena en la pila de rehacer.
        public static void Deshacer()
        {
            if (pilaDeshacer.Count > 0)
            {
                var (tareaOriginal, tareaModificada, accion) = pilaDeshacer.Pop();
                pilaRehacer.Push((tareaOriginal, tareaModificada, accion));

                switch (accion)
                {
                    case "Agregar":
                        // Si se deshizo una tarea agregada, la eliminamos
                        Gestor.EliminarTarea(tareaModificada);
                        break;
                    case "Eliminado":
                        // Si se deshizo una tarea eliminada, la restauramos
                        Gestor.AgregarTarea(tareaOriginal);
                        break;
                    case "Modificar":
                        // Revertir a la tarea original
                        Gestor.ModificarTarea(tareaModificada, tareaOriginal);
                        break;
                }
            }
        }

        // Rehace la última acción deshecha.
        public static void Rehacer()
        {
            if (pilaRehacer.Count > 0)
            {
                var (tareaOriginal, tareaModificada, accion) = pilaRehacer.Pop();
                pilaDeshacer.Push((tareaOriginal, tareaModificada, accion));

                switch (accion)
                {
                    case "Agregar":
                        // Si se rehizo una tarea agregada, la restauramos
                        Gestor.AgregarTarea(tareaModificada);
                        break;
                    case "Eliminado":
                        // Si se rehizo una tarea eliminada, la eliminamos de nuevo
                        Gestor.EliminarTarea(tareaOriginal);
                        break;
                    case "Modificar":
                        // Reaplicar la modificación
                        Gestor.ModificarTarea(tareaOriginal, tareaModificada);
                        break;
                }
            }
        }
    }
}
