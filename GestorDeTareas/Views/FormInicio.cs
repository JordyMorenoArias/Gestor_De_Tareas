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
    public partial class FormInicio : Form
    {
        // Instancia global de Gestor para manejar la lista de tareas
        private Gestor gestor;

        // Variable para almacenar la tarea seleccionada (cuando se edita)
        private Tarea tareaSeleccionada;

        // Propiedad para tener referencia al formulario principal
        public Form1 formPrincipal { get; set; }

        // Constructor que recibe la instancia del formulario principal
        public FormInicio(Form1 formPrincipal)
        {
            InitializeComponent(); // Inicializa los componentes visuales

            this.formPrincipal = formPrincipal; // Guarda la referencia al formulario principal

            ActualizarDGVPrincipal(); // Llama al método para actualizar el DataGridView con las tareas
        }

        // Método para actualizar el DataGridView con las tareas actuales
        public void ActualizarDGVPrincipal()
        {
            dgvPrincipal.Rows.Clear(); // Limpia las filas actuales del DataGridView

            // Recorre las tareas obtenidas desde el gestor y las agrega al DataGridView
            foreach (var tarea in Gestor.ObtenerTareas())
            {
                dgvPrincipal.Rows.Add(false, // Checkbox para selección
                    tarea.Nombre, // Nombre de la tarea
                    tarea.Descripcion, // Descripción de la tarea
                    tarea.FechaVencimiento.ToShortDateString(), // Fecha de vencimiento
                    tarea.Prioridad, // Prioridad de la tarea
                    tarea.Estatus, // Estatus de la tarea
                    tarea.Categoria, // Categoría de la tarea
                    tarea.Id); // ID único de la tarea (columna oculta)
            }
        }


        // Metodo que ordena las tareas dependiendo el valor tenga el ComboBox
        public void OrdenarDataGridView()
        {
            // Limpia el DataGridView
            dgvPrincipal.Rows.Clear();

            // Llama al método del Gestor para ordenar las tareas según el criterio seleccionado
            Gestor.Ordernamiento(cmbOrdenamiento.Text);

            // Obtiene las tareas ya ordenadas
            var tareasOrdenadas = Gestor.ObtenerTareas();

            // Agrega las tareas ordenadas al DataGridView
            foreach (var tarea in tareasOrdenadas)
            {
                dgvPrincipal.Rows.Add(
                    false,
                    tarea.Nombre,
                    tarea.Descripcion,
                    tarea.FechaVencimiento.ToString("dd/MM/yyyy"),
                    tarea.Prioridad,
                    tarea.Estatus,
                    tarea.Categoria,
                    tarea.Id
                );
            }
        }

        // Evento del botón Añadir que abre un formulario para crear una nueva tarea
        private void btnAñádir_Click(object sender, EventArgs e)
        {
            // Abre el formulario de consulta de tarea para crear una nueva tarea (null indica que es una nueva tarea)
            Form1.AbrirFormHijo(new FormConsultarTarea(this, null, null), formPrincipal.panelContenedor);
        }

        // Evento del botón Aplicar que procesa las tareas seleccionadas
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            // Lista temporal para almacenar las tareas a eliminar o procesar
            List<Tarea> tareas = new List<Tarea>();

            // Recorre las filas del DataGridView para verificar las tareas seleccionadas
            foreach (DataGridViewRow row in dgvPrincipal.Rows)
            {
                if (!row.IsNewRow) // Si no es una fila nueva
                {
                    bool isChecked = Convert.ToBoolean(row.Cells[0].Value); // Verifica si la tarea está seleccionada (checkbox marcado)

                    if (isChecked)
                    {
                        // Obtiene el ID de la tarea desde la columna oculta
                        int tareaID = Convert.ToInt32(row.Cells["ColumnID"].Value);

                        // Busca la tarea en el gestor usando el ID
                        Tarea tarea = Gestor.ObtenerTareas().FirstOrDefault(t => t.Id == tareaID);

                        if (tarea != null)
                        {
                            // Actualiza el estatus de la tarea con el valor del combobox
                            tarea.Estatus = cmbEstatus.Text;

                            // Agrega la tarea a la lista para procesarla después
                            tareas.Add(tarea);
                        }
                    }
                }
            }

            // Si el estatus es "Urgente", muestra un cuadro de confirmación
            if (cmbEstatus.Text == "Urgente")
            {
                DialogResult result = MessageBox.Show("¿Seguro que quieres agregar estas tareas a la Cola de Urgentes?", "Esta acción no es reversible", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Si el usuario confirma, agrega las tareas a la cola de urgentes y las elimina del gestor
                    foreach (Tarea tarea in tareas)
                    {
                        ColaTareasUrgentes.AgregarTareaUrgente(tarea); // Agrega la tarea a la cola de urgentes
                        Gestor.EliminarTarea(tarea); // Elimina la tarea del gestor
                    }
                }
            }
            else if (cmbEstatus.Text == "Completado")
            {
                // Procesa las tareas marcadas como "Completadas"
                foreach (Tarea tarea in tareas)
                {
                    tarea.Accion = "Eliminado"; // Marca la acción como "Eliminado"
                    Tarea tareaOriginal = tarea; // Crea una copia de la tarea original

                    // Registra la acción de eliminar la tarea en el historial de acciones
                    PilaHistorialAcciones.RegistrarAccion(tareaOriginal, null, "Eliminado");

                    Gestor.EliminarTarea(tarea); // Elimina la tarea del gestor
                }
            }

            // Actualiza el DataGridView y reinicia el combobox de estatus
            ActualizarDGVPrincipal();
            cmbEstatus.Text = "Pendiente"; // Reinicia el valor del combobox

            // Regresa al formulario de opciones
            Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
        }

        // Evento para editar una tarea cuando se hace doble clic en una fila del DataGridView
        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada es válida
            {
                // Obtiene el ID de la tarea desde la columna oculta
                int tareaID = Convert.ToInt32(dgvPrincipal.Rows[e.RowIndex].Cells["ColumnID"].Value);

                // Busca la tarea en el gestor usando el ID
                Tarea tareaSeleccionada = Gestor.ObtenerTareas().FirstOrDefault(t => t.Id == tareaID);

                // Abre el formulario de consulta para editar la tarea seleccionada
                Form1.AbrirFormHijo(new FormConsultarTarea(this, null, tareaSeleccionada), formPrincipal.panelContenedor);
            }
        }

       
        private void cmbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            OrdenarDataGridView();
        }

        // Evento que deshace la última acción realizada
        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            PilaHistorialAcciones.Deshacer(); // Deshace la última acción

            ActualizarDGVPrincipal(); // Actualiza el DataGridView

            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            OrdenarDataGridView();

            // Regresa al formulario de opciones
            Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
        }

        // Evento que rehace la última acción deshecha
        private void btnRehacer_Click(object sender, EventArgs e)
        {
            PilaHistorialAcciones.Rehacer(); // Rehace la última acción deshecha

            ActualizarDGVPrincipal(); // Actualiza el DataGridView

            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            OrdenarDataGridView();

            // Regresa al formulario de opciones
            Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
        }
    }

}
