using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    public class Tarea
    {
        // Aqui declaramos la propiedades de la clase Tarea
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAccion { get; set; }
        public string Accion { get; set; }


        // Aqui creamos un constructor para la clase
        // Variable estática para generar IDs únicos
        private static int contadorId = 0;

        // Constructor para crear nuevas tareas
        public Tarea(string nombre, string descripcion, int prioridad, string categoria, DateTime fechaVencimiento)
        {
            this.Id = ++contadorId;                 // Asignar un Id único automáticamente
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Prioridad = prioridad;
            this.Categoria = categoria;
            this.FechaVencimiento = fechaVencimiento;
            this.Estatus = "Pendiente";
            this.FechaCreacion = DateTime.Now;
        }

        // Método para clonar una tarea
        public Tarea Copiar()
        {
            return new Tarea(Nombre, Descripcion, Prioridad, Categoria, FechaVencimiento)
            {
                Id = this.Id,                        // Copiar también el Id
                Estatus = this.Estatus,
                FechaCreacion = this.FechaCreacion,
                FechaAccion = this.FechaAccion,
                Accion = this.Accion
            };
        }

    }
}
