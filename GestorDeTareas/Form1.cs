using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace GestorDeTareas
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();

            // Llama al método 'AbrirFormHijo' para cargar dos formularios secundarios al inicio: FormInicio y FormOpciones.
            // 'FormInicio' se carga en 'panelPrincipal' y 'FormOpciones' se carga en 'panelContenedor'.
            AbrirFormHijo(new FormInicio(this), panelPrincipal);
            AbrirFormHijo(new FormOpciones(this), panelContenedor);
        }

        // Método estático para abrir formularios dentro de un panel específico (formulario hijo).
        // Recibe un formulario hijo ('formhijo') y el panel en el que se va a mostrar ('panelBase').
        public static void AbrirFormHijo(object formhijo, System.Windows.Forms.Panel panelBase)
        {
            // Si el panel tiene controles (formularios ya abiertos), los elimina antes de abrir el nuevo.
            if (panelBase.Controls.Count > 0)
            {
                panelBase.Controls.RemoveAt(0); // Elimina el primer control del panel (en este caso, el formulario actual).
            }

            // Convierte el objeto recibido 'formhijo' en un formulario.
            Form fh = formhijo as Form;
            fh.TopLevel = false; // Indica que este formulario no es de nivel superior, es decir, se comporta como un control dentro del panel.
            fh.Dock = DockStyle.Fill; // Hace que el formulario ocupe todo el espacio disponible en el panel.

            // Agrega el formulario hijo al panel base y lo muestra
            panelBase.Controls.Add(fh);
            panelBase.Tag = fh; // Establece el formulario como el control actual del panel.
            fh.Show(); // Muestra el formulario.
        }
    }
}
