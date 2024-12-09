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
    public partial class FormOpciones : Form
    {
        // Árbol de categorías que organizará las tareas en diferentes categorías (como un árbol)
        private NodoArbolCategoria arbolCategorias;

        // Propiedad que contiene la referencia al formulario principal (Form1)
        public Form1 formPrincipal { get; set; }

        // Constructor que inicializa el formulario y muestra las tareas en el TreeView
        public FormOpciones(Form1 form1)
        {
            InitializeComponent();
            formPrincipal = form1; // Guarda la referencia al formulario principal

            Task task = MostrarTareasEnTreeView(); // Llama al método para mostrar las tareas organizadas por categorías en el TreeView
        }

        public async Task MostrarTareasEnTreeView()
        {
            // Obtener la lista de todas las tareas a través del gestor de tareas
            List<Tarea> listaTareas = await Gestor.ObtenerTareas();

            // Crear los nodos principales que representan las categorías
            NodoArbolCategoria nodoPersonal = new NodoArbolCategoria("Personal");
            NodoArbolCategoria nodoTrabajo = new NodoArbolCategoria("Trabajo");
            NodoArbolCategoria nodoEstudios = new NodoArbolCategoria("Estudios");

            // Crear las subcategorías dentro de cada categoría
            NodoArbolCategoria subPendientePersonal = new NodoArbolCategoria("Pendiente");
            NodoArbolCategoria subEnProcesoPersonal = new NodoArbolCategoria("En Proceso");

            NodoArbolCategoria subPendienteTrabajo = new NodoArbolCategoria("Pendiente");
            NodoArbolCategoria subEnProcesoTrabajo = new NodoArbolCategoria("En Proceso");

            NodoArbolCategoria subPendienteEstudios = new NodoArbolCategoria("Pendiente");
            NodoArbolCategoria subEnProcesoEstudios = new NodoArbolCategoria("En Proceso");

            // Asignar las subcategorías a sus respectivas categorías
            nodoPersonal.AgregarSubcategoria(subPendientePersonal);
            nodoPersonal.AgregarSubcategoria(subEnProcesoPersonal);

            nodoTrabajo.AgregarSubcategoria(subPendienteTrabajo);
            nodoTrabajo.AgregarSubcategoria(subEnProcesoTrabajo);

            nodoEstudios.AgregarSubcategoria(subPendienteEstudios);
            nodoEstudios.AgregarSubcategoria(subEnProcesoEstudios);

            // Clasificar las tareas según su categoría y estatus, y agregarlas a la subcategoría correspondiente
            foreach (var tarea in listaTareas)
            {
                switch (tarea.Categoria)
                {
                    case "Personal":
                        if (tarea.Estatus == "Pendiente")
                        {
                            subPendientePersonal.AgregarTarea(tarea);
                        }
                        else if (tarea.Estatus == "En Proceso")
                        {
                            subEnProcesoPersonal.AgregarTarea(tarea);
                        }
                        break;

                    case "Trabajo":
                        if (tarea.Estatus == "Pendiente")
                        {
                            subPendienteTrabajo.AgregarTarea(tarea);
                        }
                        else if (tarea.Estatus == "En Proceso")
                        {
                            subEnProcesoTrabajo.AgregarTarea(tarea);
                        }
                        break;

                    case "Estudios":
                        if (tarea.Estatus == "Pendiente")
                        {
                            subPendienteEstudios.AgregarTarea(tarea);
                        }
                        else if (tarea.Estatus == "En Proceso")
                        {
                            subEnProcesoEstudios.AgregarTarea(tarea);
                        }
                        break;

                    default:
                        break;
                }
            }

            // Limpiar el TreeView antes de agregar los nodos
            treeViewCategorias.Nodes.Clear();

            // Agregar los nodos de las categorías (Personal, Trabajo, Estudios) al TreeView
            AgregarNodoCategoriaAlTreeView(nodoPersonal, treeViewCategorias);
            AgregarNodoCategoriaAlTreeView(nodoTrabajo, treeViewCategorias);
            AgregarNodoCategoriaAlTreeView(nodoEstudios, treeViewCategorias);
        }

        // Método auxiliar que agrega un nodo de categoría al TreeView de manera recursiva
        private void AgregarNodoCategoriaAlTreeView(NodoArbolCategoria nodoCategoria, TreeView treeView)
        {
            // Crear un nuevo TreeNode para la categoría
            TreeNode categoriaNode = new TreeNode(nodoCategoria.Nombre);

            // Agregar las subcategorías (Pendiente, En Proceso) como subnodos de la categoría principal
            foreach (var subcategoria in nodoCategoria.Subcategorias)
            {
                TreeNode subcategoriaNode = new TreeNode(subcategoria.Nombre);

                // Agregar las tareas dentro de cada subcategoría
                foreach (var tarea in subcategoria.Tareas)
                {
                    TreeNode tareaNode = new TreeNode(tarea.Nombre); // Crear un nodo para la tarea
                    subcategoriaNode.Nodes.Add(tareaNode); // Agregar el nodo de la tarea como subnodo del nodo de subcategoría
                }

                // Agregar el nodo de la subcategoría como subnodo del nodo de categoría principal
                categoriaNode.Nodes.Add(subcategoriaNode);
            }

            // Agregar el nodo de la categoría al TreeView
            treeView.Nodes.Add(categoriaNode);
        }


        // Evento que se ejecuta cuando se hace clic en el botón "Inicio", abre el formulario de inicio dentro del panel principal
        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Abre el formulario de inicio en el panel principal del formulario principal (Form1)
            Form1.AbrirFormHijo(new FormInicio(formPrincipal), formPrincipal.panelPrincipal);
        }

        // Evento que se ejecuta cuando se hace clic en el botón "Importante", abre el formulario de tareas urgentes dentro del panel principal
        private void btnImportante_Click(object sender, EventArgs e)
        {
            // Abre el formulario de tareas urgentes en el panel principal del formulario principal (Form1)
            Form1.AbrirFormHijo(new FormTareasUrgentes(formPrincipal), formPrincipal.panelPrincipal);
        }
    }

}
