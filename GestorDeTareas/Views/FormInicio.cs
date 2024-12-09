using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        public async Task ActualizarDGVPrincipal()
        {
            try
            {
                dgvPrincipal.Rows.Clear(); // Limpia las filas actuales del DataGridView
                ColaTareasUrgentes.LimpiarCola(); // Limpia la cola de tareas urgentes

                var tareas = await Gestor.ObtenerTareas();
                foreach (var tarea in tareas)
                {
                    if (tarea.Estatus == "Pendiente")
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
                    else if (tarea.Estatus == "Urgente")
                    {
                        ColaTareasUrgentes.AgregarTareaUrgente(tarea);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show($"Error al actualizar las tareas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Metodo que ordena las tareas dependiendo el valor tenga el ComboBox
        public async Task OrdenarDataGridView()
        {
            // Limpia el DataGridView
            dgvPrincipal.Rows.Clear();

            // Obtiene las tareas ya ordenadas
            var tareas = await Gestor.ObtenerTareas();

            // Dependiendo el valor del ComboBox, se ordenan las tareas
            switch (cmbOrdenamiento.Text)
            {
                case "Prioridad":
                    tareas = OrdenarPrioridad(tareas.Where(t => t.Estatus == "Pendiente").ToList());
                    break;
                case "Antiguo":
                    tareas = OrdenarAntiguo(tareas.Where(t => t.Estatus == "Pendiente").ToList());
                    break;
                case "Fecha Limite":
                    tareas = OrdenarFechaLimite(tareas.Where(t => t.Estatus == "Pendiente").ToList());
                    break;
                default:
                    tareas = OrdenarReciente(tareas.Where(t => t.Estatus == "Pendiente").ToList());
                    break;
            }

            // Agrega las tareas ordenadas al DataGridView
            foreach (var tarea in tareas)
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

        // Ordena la lista de tareas en orden descendente según la fecha de creación.
        public static List<Tarea> OrdenarReciente(List<Tarea> tareas)
        {
            return tareas = tareas.OrderByDescending(t => t.FechaCreacion).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la fecha de creación.
        public static List<Tarea> OrdenarAntiguo(List<Tarea> tareas)
        {
            return tareas = tareas.OrderBy(t => t.FechaCreacion).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la fecha de vencimiento.
        public static List<Tarea> OrdenarFechaLimite(List<Tarea> tareas)
        {
            return tareas = tareas.OrderBy(t => t.FechaVencimiento).ToList();
        }

        // Ordena la lista de tareas en orden ascendente según la prioridad.
        public static List<Tarea> OrdenarPrioridad(List<Tarea> tareas)
        {
            return tareas = tareas.OrderBy(t => t.Prioridad).ToList();
        }

        // Evento del botón Añadir que abre un formulario para crear una nueva tarea
        private void btnAñádir_Click(object sender, EventArgs e)
        {
            // Abre el formulario de consulta de tarea para crear una nueva tarea (null indica que es una nueva tarea)
            Form1.AbrirFormHijo(new FormConsultarTarea(this, null, null), formPrincipal.panelContenedor);
        }

        // Evento del botón Aplicar que procesa las tareas seleccionadas
        private async void btnAplicar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres agregar estas tareas a la Cola de Urgentes?", "Esta acción no es reversible", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
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
                            var tareasList = await Gestor.ObtenerTareas();
                            Tarea tarea = tareasList.FirstOrDefault(t => t.Id == tareaID);

                            if (tarea != null)
                            {
                                // Actualiza el estatus de la tarea con el valor del combobox
                                tarea.Estatus = cmbEstatus.Text;
                                await Gestor.ModificarTarea(tarea.Id, tarea); // Actualiza la tarea en el gestor

                                // Agrega la tarea a la lista para procesarla después
                                tareas.Add(tarea);
                            }
                        }
                    }
                }

                // Si el estatus es "Urgente", muestra un cuadro de confirmación
                if (cmbEstatus.Text == "Urgente")
                {
                    // Si el usuario confirma, agrega las tareas a la cola de urgentes y las elimina del gestor
                    foreach (Tarea tarea in tareas)
                    {
                        ColaTareasUrgentes.AgregarTareaUrgente(tarea); // Agrega la tarea a la cola de urgentes
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
                        await Gestor.EliminarTarea(tarea); // Elimina la tarea del gestor
                    }
                }

                // Actualiza el DataGridView y reinicia el combobox de estatus
                await ActualizarDGVPrincipal();
                cmbEstatus.Text = "Pendiente"; // Reinicia el valor del combobox

                // Regresa al formulario de opciones
                Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
            }
        }

        // Evento para editar una tarea cuando se hace doble clic en una fila del DataGridView
        private async void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada es válida
            {
                // Obtiene el ID de la tarea desde la columna oculta
                int tareaID = Convert.ToInt32(dgvPrincipal.Rows[e.RowIndex].Cells["ColumnID"].Value);

                // Busca la tarea en el gestor usando el ID
                var tareasList = await Gestor.ObtenerTareas();
                Tarea? tareaSeleccionada = tareasList.FirstOrDefault(t => t.Id == tareaID);

                // Abre el formulario de consulta para editar la tarea seleccionada
                Form1.AbrirFormHijo(new FormConsultarTarea(this, null, tareaSeleccionada), formPrincipal.panelContenedor);
            }
        }


        private async void cmbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            await OrdenarDataGridView();
        }

        // Evento que deshace la última acción realizada
        private async void btnDeshacer_Click(object sender, EventArgs e)
        {
            await PilaHistorialAcciones.Deshacer(); // Deshace la última acción

            await ActualizarDGVPrincipal(); // Actualiza el DataGridView

            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            await OrdenarDataGridView();

            // Regresa al formulario de opciones
            Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
        }

        // Evento que rehace la última acción deshecha
        private async void btnRehacer_Click(object sender, EventArgs e)
        {
            await PilaHistorialAcciones.Rehacer(); // Rehace la última acción deshecha

            await ActualizarDGVPrincipal(); // Actualiza el DataGridView

            // Llama al método OrdenarDataGridView y actualiza las tareas mostradas en el DataGridView.
            await OrdenarDataGridView();

            // Regresa al formulario de opciones
            Form1.AbrirFormHijo(new FormOpciones(formPrincipal), formPrincipal.panelContenedor);
        }
    }

}
