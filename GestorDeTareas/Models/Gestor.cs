using GestorDeTareas.Data;
using Microsoft.Data.SqlClient;
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
        private static Conexión conexión = new Conexión("Server=LAPTOP-989OF5PS\\MSSQLSERVER02;Database=GestorDeTareas;Integrated Security=True;TrustServerCertificate=True");

        // Método para agregar una nueva tarea a la lista.
        public static async Task AgregarTarea(Tarea tarea)
        {
            using (var connection = await conexión.AbrirConexiónAsync())
            {
                var query = "INSERT INTO Tareas (nombre, descripcion, prioridad, categoria, fechaVencimiento, estatus, fechaCreacion, fechaAccion, accion, activo) VALUES (@Nombre, @Descripcion, @Prioridad, @Categoria, @FechaVencimiento, @Estatus, @FechaCreacion, @FechaAccion, @Accion, @Activo)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", tarea.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                    command.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
                    command.Parameters.AddWithValue("@Categoria", tarea.Categoria);
                    command.Parameters.AddWithValue("@FechaVencimiento", tarea.FechaVencimiento);
                    command.Parameters.AddWithValue("@Estatus", tarea.Estatus);
                    command.Parameters.AddWithValue("@FechaCreacion", tarea.FechaCreacion);
                    command.Parameters.AddWithValue("@FechaAccion", tarea.FechaAccion);
                    command.Parameters.AddWithValue("@Accion", tarea.Accion);
                    command.Parameters.AddWithValue("@Activo", tarea.Activo); // Mapeo de bool a bit
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para "eliminar" una tarea de la lista (cambiar su valor activo a false).
        public static async Task EliminarTarea(Tarea tarea)
        {
            using (var connection = await conexión.AbrirConexiónAsync())
            {
                var query = "UPDATE Tareas SET activo = 0 WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tarea.Id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para modificar una tarea existente en la lista.
        public static async Task ModificarTarea(int tareaID, Tarea tareaModificada)
        {
            using (var connection = await conexión.AbrirConexiónAsync())
            {
                var query = "UPDATE Tareas SET nombre = @Nombre, descripcion = @Descripcion, prioridad = @Prioridad, categoria = @Categoria, " +
                            "fechaVencimiento = @FechaVencimiento, estatus = @Estatus, fechaAccion = @FechaAccion, accion = @Accion, activo = @Activo WHERE id = @Id AND activo = 1";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tareaID);
                    command.Parameters.AddWithValue("@Nombre", tareaModificada.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", tareaModificada.Descripcion);
                    command.Parameters.AddWithValue("@Prioridad", tareaModificada.Prioridad);
                    command.Parameters.AddWithValue("@Categoria", tareaModificada.Categoria);
                    command.Parameters.AddWithValue("@FechaVencimiento", tareaModificada.FechaVencimiento);
                    command.Parameters.AddWithValue("@Estatus", tareaModificada.Estatus);
                    command.Parameters.AddWithValue("@FechaAccion", tareaModificada.FechaAccion);
                    command.Parameters.AddWithValue("@Accion", tareaModificada.Accion);
                    command.Parameters.AddWithValue("@Activo", tareaModificada.Activo);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Devuelve la lista ordenada de tareas.
        public static async Task<List<Tarea>> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();
            try
            {
                using (var connection = await conexión.AbrirConexiónAsync())
                {
                    string query = "SELECT * FROM Tareas WHERE activo = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Tarea tarea = new Tarea(
                                    reader.GetInt32(0), // Id
                                    reader.GetString(1), // Nombre
                                    reader.GetString(2), // Descripcion
                                    reader.GetInt32(3), // Prioridad
                                    reader.GetString(4), // Categoria
                                    reader.GetDateTime(5) // FechaVencimiento
                                )
                                {
                                    Estatus = reader.IsDBNull(6) ? string.Empty : reader.GetString(6), // Estatus
                                    FechaCreacion = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7), // FechaCreacion
                                    FechaAccion = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8), // FechaAccion
                                    Accion = reader.IsDBNull(9) ? string.Empty : reader.GetString(9), // Accion
                                    Activo = reader.GetBoolean(10) // Activo
                                };
                                tareas.Add(tarea);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Manejo de excepciones
            }
            return tareas;
        }
    }
}
