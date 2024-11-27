using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeTareas
{
    public partial class FormTareasUrgentes : Form
    {
        // Propiedad que guarda una referencia al formulario principal (Form1)
        public Form1 formPrincipal { get; set; }

        // Constructor que inicializa el formulario y actualiza el DataGridView con las tareas urgentes
        public FormTareasUrgentes(Form1 form1)
        {
            InitializeComponent();
            ActualizarDGVTareaUrgente(); // Llama al método para cargar las tareas urgentes en el DataGridView
            formPrincipal = form1; // Asigna la instancia del formulario principal a la propiedad 'formPrincipal'
        }

        // Método que actualiza el DataGridView con las tareas urgentes obtenidas de 'ColaTareasUrgentes'
        public void ActualizarDGVTareaUrgente()
        {
            dgvTareaUrgente.Rows.Clear(); // Limpia el DataGridView de cualquier fila anterior

            // Itera sobre las tareas urgentes obtenidas de la cola de tareas urgentes
            foreach (var tareaUrgente in ColaTareasUrgentes.ObtenerTareasUrgentes())
            {
                // Se agrega cada tarea urgente al DataGridView con sus propiedades: Nombre, Descripción, Fecha, Estatus, Categoría y Id
                dgvTareaUrgente.Rows.Add(
                    tareaUrgente.Nombre,
                    tareaUrgente.Descripcion,
                    tareaUrgente.FechaVencimiento.ToString("dd/MM/yyyy"), // Muestra solo la parte de la fecha
                    tareaUrgente.Estatus,
                    tareaUrgente.Categoria,
                    tareaUrgente.Id); // Se agrega el ID como columna oculta para futuras referencias
            }
        }

        private void btnCompletada_Click(object sender, EventArgs e)
        {
            // Muestra un mensaje de confirmación indicando que la tarea urgente ha sido procesada
            MessageBox.Show($"La Tarea {ColaTareasUrgentes.ProcesarTareaUrgente().Nombre} fue Completada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarDGVTareaUrgente(); // Actualiza el DataGridView después de procesar una tarea
        }

        // Evento que se activa cuando se hace doble clic en una celda del DataGridView
        private void dgvTareaUrgente_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho clic en una fila válida
            {
                // Obtiene el ID de la tarea seleccionada desde la columna oculta (última columna del DataGridView)
                int tareaID = Convert.ToInt32(dgvTareaUrgente.Rows[e.RowIndex].Cells["ColumnID"].Value);

                // Busca la tarea en la lista de tareas urgentes usando el ID
                Tarea tareaSeleccionada = ColaTareasUrgentes.ObtenerTareasUrgentes().FirstOrDefault(t => t.Id == tareaID);

                // Si la tarea es encontrada, abre un formulario de consulta y edición de la tarea
                // 'FormConsultarTarea' es un nuevo formulario que permite consultar y modificar la tarea seleccionada
                Form1.AbrirFormHijo(new FormConsultarTarea(null, this, tareaSeleccionada), formPrincipal.panelContenedor);
            }
        }
    }
}
