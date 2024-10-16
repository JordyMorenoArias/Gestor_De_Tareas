namespace GestorDeTareas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContenedor = new Panel();
            panelPrincipal = new Panel();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Right;
            panelContenedor.Location = new Point(865, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(422, 643);
            panelContenedor.TabIndex = 1;
            // 
            // panelPrincipal
            // 
            panelPrincipal.Dock = DockStyle.Left;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(868, 643);
            panelPrincipal.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 643);
            Controls.Add(panelPrincipal);
            Controls.Add(panelContenedor);
            Name = "Form1";
            Text = "GESTOR DE TAREAS";
            ResumeLayout(false);
        }

        #endregion

        public Panel panelContenedor;
        public Panel panelPrincipal;
    }
}
