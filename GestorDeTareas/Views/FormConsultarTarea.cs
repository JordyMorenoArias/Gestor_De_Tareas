using GestorDeTareas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace GestorDeTareas
{
    public partial class FormConsultarTarea : Form
    {
        // Se crea una propiedad que contiene el formulario principal (FormInicio) que invoca este formulario.
        private FormInicio FormInicio { get; set; }

        // Se crea una propiedad para un formulario de tareas urgentes (FormTareasUrgentes).
        private FormTareasUrgentes FormTareasUrgentes { get; set; }

        // Variable para almacenar la tarea seleccionada que se va a editar o consultar.
        private Tarea? tareaSeleccionada { get; set; }

        // Constructor del formulario, donde se pasan instancias del formulario de inicio, el formulario de tareas urgentes y la tarea seleccionada.
        // Si la tarea es nula, se habilita la opción de crear una nueva tarea.
        public FormConsultarTarea(FormInicio FormInicio, FormTareasUrgentes formTareasUrgentes, Tarea? tarea)
        {
            InitializeComponent(); // Inicializa los componentes del formulario.

            this.FormInicio = FormInicio;
            this.FormTareasUrgentes = formTareasUrgentes;
            tareaSeleccionada = tarea;

            // Si hay una tarea seleccionada, se rellenan los campos del formulario con los datos de la tarea.
            if (tareaSeleccionada != null)
            {
                txtNombre.Text = tareaSeleccionada.Nombre;
                txtDescripcion.Text = tareaSeleccionada.Descripcion;
                txtPrioridad.Value = tareaSeleccionada.Prioridad;
                txtCategoria.Text = tareaSeleccionada.Categoria;
                txtFechaLimite.Value = tareaSeleccionada.FechaVencimiento;

                // Se habilitan los botones para modificar y eliminar la tarea.
                btnCrear.Visible = false;
                btnModificar.Visible = true;
                lblTarea.Text = "Modificar Tarea";
                if (FormInicio != null)
                {
                    btnEliminar.Visible = true;
                }
            }
            else
            {
                // Si no hay tarea seleccionada (nueva tarea), solo se habilita el botón para crear una nueva tarea.
                btnCrear.Visible = true;
                btnModificar.Visible = false;
            }
        }

        // Método para limpiar los campos del formulario.
        public void LimpiarForm()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrioridad.Value = 1;
            txtFechaLimite.Value = DateTime.Now;
        }

        // Evento que se dispara al hacer clic en el botón para modificar una tarea.
        private async void btnModificar_Click_1(object sender, EventArgs e)
        {
            // Se confirma si el usuario realmente desea modificar la tarea.
            DialogResult result = MessageBox.Show("¿Seguro que quieres modificar esta Tarea?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario confirma la acción:
            if (result == DialogResult.Yes)
            {
                if (FormInicio != null)
                {
                    // Se guarda la acción de "Modificar" y se copia la tarea original.
                    tareaSeleccionada!.Accion = "Modificar";
                    Tarea tareaAnterior = tareaSeleccionada; // Copia de la tarea original.

                    // Se crea una nueva tarea con los valores modificados.
                    Tarea tareaActual = new Tarea(txtNombre.Text, txtDescripcion.Text, (int)txtPrioridad.Value, txtCategoria.Text, txtFechaLimite.Value);
                    tareaActual.Accion = "Modificar";

                    // Se registra la acción en el historial (acción de modificar).
                    PilaHistorialAcciones.RegistrarAccion(tareaAnterior, tareaActual, "Modificar");

                    // Se actualiza la tarea en el gestor.
                    await Gestor.ModificarTarea(tareaSeleccionada.Id, tareaActual);

                    // Se actualiza el DataGridView del formulario principal.
                    await FormInicio.ActualizarDGVPrincipal();

                    // Se abre el formulario de opciones después de la modificación.
                    Form1.AbrirFormHijo(new FormOpciones(FormInicio.formPrincipal), FormInicio.formPrincipal.panelContenedor);
                }
                else
                {
                    // En caso de estar trabajando con tareas urgentes, se modifica la tarea en la cola de tareas urgentes.
                    Tarea tareaModificada = new Tarea(tareaSeleccionada.Id, txtNombre.Text, txtDescripcion.Text, (int)txtPrioridad.Value, txtCategoria.Text, txtFechaLimite.Value);

                    ColaTareasUrgentes.ModificarTareaUrgente(tareaSeleccionada.Id, tareaModificada);

                    // Se actualiza el DataGridView de tareas urgentes.
                    FormTareasUrgentes.ActualizarDGVTareaUrgente();

                    // Se abre el formulario de opciones después de la modificación.
                    Form1.AbrirFormHijo(new FormOpciones(FormTareasUrgentes.formPrincipal), FormTareasUrgentes.formPrincipal.panelContenedor);
                }
            }
            // Llama al método OrdenarDataGridView del formulario FormInicio para ordenar y actualizar las tareas mostradas en el DataGridView.
            if (FormInicio != null)
            {
                await FormInicio.OrdenarDataGridView();
            }
        }

        // Evento que se dispara al hacer clic en el botón para crear una nueva tarea.
        private async void btnCrear_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Se crea una nueva tarea con los valores del formulario.
                Tarea Tarea = new Tarea(txtNombre.Text, txtDescripcion.Text, (int)txtPrioridad.Value, txtCategoria.Text, txtFechaLimite.Value);

                // Se registra la acción de agregar la nueva tarea en el historial.
                PilaHistorialAcciones.RegistrarAccion(null, Tarea, "Agregar");
                Tarea.Accion = "Agregar";

                // Se agrega la tarea al gestor.
                await Gestor.AgregarTarea(Tarea);

                // Dependiendo de si el formulario de inicio o de tareas urgentes está abierto, se actualiza el DataGridView correspondiente.
                if (FormInicio != null)
                {
                    await FormInicio.ActualizarDGVPrincipal();
                }
                else
                {
                    FormTareasUrgentes.ActualizarDGVTareaUrgente();
                }

                // Se limpia el formulario y se cierra.
                LimpiarForm();
                this.Close();

                // Se abre el formulario de opciones.
                if (FormInicio != null)
                    Form1.AbrirFormHijo(new FormOpciones(FormInicio.formPrincipal), FormInicio.formPrincipal.panelContenedor);
                else
                    Form1.AbrirFormHijo(new FormOpciones(FormTareasUrgentes.formPrincipal), FormTareasUrgentes.formPrincipal.panelContenedor);

                // Mensaje de confirmación indicando que la tarea ha sido creada.
                MessageBox.Show("La tarea fue creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Llama al método OrdenarDataGridView del formulario FormInicio para ordenar y actualizar las tareas mostradas en el DataGridView.
                await FormInicio.OrdenarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara al hacer clic en el botón para eliminar una tarea.
        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            // Se confirma si el usuario realmente desea eliminar la tarea.
            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar esta Tarea?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario confirma la acción:
            if (result == DialogResult.Yes)
            {
                tareaSeleccionada.Accion = "Eliminado";

                // Se copia la tarea original antes de eliminarla.
                Tarea tareaOriginal = tareaSeleccionada;

                // Se registra la acción de eliminar en el historial.
                PilaHistorialAcciones.RegistrarAccion(tareaOriginal, null, "Eliminado");

                // Se elimina la tarea del gestor.
                await Gestor.EliminarTarea(tareaSeleccionada);

                // Se actualiza el DataGridView del formulario principal.
                await FormInicio.ActualizarDGVPrincipal();

                // Se limpia el formulario y se cierra.
                LimpiarForm();
                this.Close();

                // Se abre el formulario de opciones.
                Form1.AbrirFormHijo(new FormOpciones(FormInicio.formPrincipal), FormInicio.formPrincipal.panelContenedor);
            }
            // Llama al método OrdenarDataGridView del formulario FormInicio para ordenar y actualizar las tareas mostradas en el DataGridView.
            await FormInicio.OrdenarDataGridView();
        }

        // Evento que se dispara al hacer clic en el botón de cerrar.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Se cierra el formulario.
            this.Close();

            // Dependiendo de si el formulario de inicio o de tareas urgentes está abierto, se abre el formulario de opciones correspondiente.
            if (FormInicio != null)
            {
                Form1.AbrirFormHijo(new FormOpciones(FormInicio.formPrincipal), FormInicio.formPrincipal.panelContenedor);
            }
            else
            {
                Form1.AbrirFormHijo(new FormOpciones(FormTareasUrgentes.formPrincipal), FormTareasUrgentes.formPrincipal.panelContenedor);
            }
        }
    }
}
