using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estatus { get; set; } = "Pendiente"; // Valor por defecto "Pendiente"
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAccion { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; } = true; // Valor por defecto true

        public Tarea(string nombre, string descripcion, int prioridad, string categoria, DateTime fechaVencimiento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Categoria = categoria;
            FechaVencimiento = fechaVencimiento;
            FechaCreacion = DateTime.Now;
            FechaAccion = DateTime.Now;
            Activo = true; // Valor por defecto true
        }

        public Tarea(int id, string nombre, string descripcion, int prioridad, string categoria, DateTime fechaVencimiento)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Categoria = categoria;
            FechaVencimiento = fechaVencimiento;
            FechaCreacion = DateTime.Now;
            FechaAccion = DateTime.Now;
            Activo = true; // Valor por defecto true
        }
    }
}
