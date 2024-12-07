 namespace GestorDeTareas
{
    partial class FormConsultarTarea
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
            btnCerrar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtPrioridad = new NumericUpDown();
            txtFechaLimite = new DateTimePicker();
            btnCrear = new Button();
            lblTarea = new Label();
            txtCategoria = new ComboBox();
            label7 = new Label();
            txtDescripcion = new RichTextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)txtPrioridad).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.Control;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCerrar.Location = new Point(1, 9);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(42, 32);
            btnCerrar.TabIndex = 82;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Century Gothic", 9F);
            btnEliminar.Location = new Point(25, 405);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(145, 29);
            btnEliminar.TabIndex = 81;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Century Gothic", 9F);
            btnModificar.Location = new Point(182, 405);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(144, 29);
            btnModificar.TabIndex = 80;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Visible = false;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // txtPrioridad
            // 
            txtPrioridad.Font = new Font("Century Gothic", 9F);
            txtPrioridad.Location = new Point(25, 288);
            txtPrioridad.Margin = new Padding(3, 2, 3, 2);
            txtPrioridad.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            txtPrioridad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtPrioridad.Name = "txtPrioridad";
            txtPrioridad.Size = new Size(133, 22);
            txtPrioridad.TabIndex = 79;
            txtPrioridad.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // txtFechaLimite
            // 
            txtFechaLimite.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaLimite.Location = new Point(25, 350);
            txtFechaLimite.Margin = new Padding(3, 2, 3, 2);
            txtFechaLimite.Name = "txtFechaLimite";
            txtFechaLimite.Size = new Size(301, 22);
            txtFechaLimite.TabIndex = 78;
            // 
            // btnCrear
            // 
            btnCrear.Font = new Font("Century Gothic", 9F);
            btnCrear.Location = new Point(182, 405);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(144, 29);
            btnCrear.TabIndex = 77;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click_1;
            // 
            // lblTarea
            // 
            lblTarea.AutoSize = true;
            lblTarea.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTarea.Location = new Point(173, 9);
            lblTarea.Name = "lblTarea";
            lblTarea.Size = new Size(141, 25);
            lblTarea.TabIndex = 76;
            lblTarea.Text = "Crear Tarea";
            // 
            // txtCategoria
            // 
            txtCategoria.Font = new Font("Century Gothic", 9F);
            txtCategoria.FormattingEnabled = true;
            txtCategoria.Items.AddRange(new object[] { "Personal", "Estudios", "Trabajo" });
            txtCategoria.Location = new Point(164, 288);
            txtCategoria.Margin = new Padding(3, 2, 3, 2);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(162, 25);
            txtCategoria.TabIndex = 75;
            txtCategoria.Text = "Personal";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F);
            label7.Location = new Point(164, 271);
            label7.Name = "label7";
            label7.Size = new Size(69, 17);
            label7.TabIndex = 74;
            label7.Text = "Categoria";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Century Gothic", 9F);
            txtDescripcion.Location = new Point(22, 169);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(304, 72);
            txtDescripcion.TabIndex = 73;
            txtDescripcion.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F);
            label6.Location = new Point(25, 271);
            label6.Name = "label6";
            label6.Size = new Size(61, 17);
            label6.TabIndex = 72;
            label6.Text = "Prioridad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F);
            label5.Location = new Point(25, 332);
            label5.Name = "label5";
            label5.Size = new Size(84, 17);
            label5.TabIndex = 71;
            label5.Text = "Fecha Limite";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(21, 152);
            label4.Name = "label4";
            label4.Size = new Size(79, 17);
            label4.TabIndex = 70;
            label4.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(21, 92);
            label3.Name = "label3";
            label3.Size = new Size(119, 17);
            label3.TabIndex = 69;
            label3.Text = "Nombre Completo";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Century Gothic", 9F);
            txtNombre.Location = new Point(22, 110);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(304, 22);
            txtNombre.TabIndex = 68;
            // 
            // FormConsultarTarea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 482);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(txtPrioridad);
            Controls.Add(txtFechaLimite);
            Controls.Add(btnCrear);
            Controls.Add(lblTarea);
            Controls.Add(txtCategoria);
            Controls.Add(label7);
            Controls.Add(txtDescripcion);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormConsultarTarea";
            Text = "ConsultarTarea";
            ((System.ComponentModel.ISupportInitialize)txtPrioridad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button btnEliminar;
        private Button btnModificar;
        private NumericUpDown txtPrioridad;
        private DateTimePicker txtFechaLimite;
        private Button btnCrear;
        private Label lblTarea;
        private ComboBox txtCategoria;
        private Label label7;
        private RichTextBox txtDescripcion;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtNombre;
    }
}