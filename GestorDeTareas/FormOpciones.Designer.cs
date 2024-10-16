namespace GestorDeTareas
{
    partial class FormOpciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInicio = new FontAwesome.Sharp.IconButton();
            btnImportante = new FontAwesome.Sharp.IconButton();
            treeViewCategorias = new TreeView();
            SuspendLayout();
            // 
            // btnInicio
            // 
            btnInicio.Font = new Font("Century Gothic", 12F);
            btnInicio.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnInicio.IconColor = Color.Black;
            btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInicio.ImageAlign = ContentAlignment.MiddleRight;
            btnInicio.Location = new Point(12, 17);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(370, 52);
            btnInicio.TabIndex = 3;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnImportante
            // 
            btnImportante.Font = new Font("Century Gothic", 12F);
            btnImportante.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            btnImportante.IconColor = Color.Black;
            btnImportante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImportante.ImageAlign = ContentAlignment.MiddleRight;
            btnImportante.Location = new Point(12, 75);
            btnImportante.Name = "btnImportante";
            btnImportante.Size = new Size(370, 52);
            btnImportante.TabIndex = 5;
            btnImportante.Text = "Tareas Urgentes";
            btnImportante.UseVisualStyleBackColor = true;
            btnImportante.Click += btnImportante_Click;
            // 
            // treeViewCategorias
            // 
            treeViewCategorias.Location = new Point(12, 146);
            treeViewCategorias.Name = "treeViewCategorias";
            treeViewCategorias.Size = new Size(370, 485);
            treeViewCategorias.TabIndex = 6;
            // 
            // FormOpciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 643);
            Controls.Add(treeViewCategorias);
            Controls.Add(btnImportante);
            Controls.Add(btnInicio);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOpciones";
            Text = "FormOpciones";
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnInicio;
        private FontAwesome.Sharp.IconButton btnImportante;
        public TreeView treeViewCategorias;
    }
}