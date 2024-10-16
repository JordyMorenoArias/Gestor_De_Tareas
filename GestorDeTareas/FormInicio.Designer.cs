namespace GestorDeTareas
{
    partial class FormInicio
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
            dgvPrincipal = new DataGridView();
            ColumnCheckBox = new DataGridViewCheckBoxColumn();
            ColumnNombre = new DataGridViewTextBoxColumn();
            ColumnDescripcion = new DataGridViewTextBoxColumn();
            ColumnFechaLimite = new DataGridViewTextBoxColumn();
            ColumnPrioridad = new DataGridViewTextBoxColumn();
            ColumnEstatus = new DataGridViewTextBoxColumn();
            ColumnCategoria = new DataGridViewTextBoxColumn();
            ColumnID = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cmbEstatus = new ComboBox();
            cmbOrdenamiento = new ComboBox();
            label2 = new Label();
            btnAñádir = new Button();
            btnAplicar = new Button();
            label3 = new Label();
            btnDeshacer = new FontAwesome.Sharp.IconButton();
            btnRehacer = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvPrincipal).BeginInit();
            SuspendLayout();
            // 
            // dgvPrincipal
            // 
            dgvPrincipal.AllowUserToAddRows = false;
            dgvPrincipal.AllowUserToDeleteRows = false;
            dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrincipal.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPrincipal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrincipal.Columns.AddRange(new DataGridViewColumn[] { ColumnCheckBox, ColumnNombre, ColumnDescripcion, ColumnFechaLimite, ColumnPrioridad, ColumnEstatus, ColumnCategoria, ColumnID });
            dgvPrincipal.Cursor = Cursors.Hand;
            dgvPrincipal.GridColor = SystemColors.ActiveBorder;
            dgvPrincipal.Location = new Point(32, 155);
            dgvPrincipal.Name = "dgvPrincipal";
            dgvPrincipal.RowHeadersVisible = false;
            dgvPrincipal.RowHeadersWidth = 51;
            dgvPrincipal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrincipal.Size = new Size(786, 406);
            dgvPrincipal.TabIndex = 0;
            dgvPrincipal.CellDoubleClick += dgvPrincipal_CellDoubleClick;
            // 
            // ColumnCheckBox
            // 
            ColumnCheckBox.FillWeight = 26.7379684F;
            ColumnCheckBox.HeaderText = "";
            ColumnCheckBox.MinimumWidth = 6;
            ColumnCheckBox.Name = "ColumnCheckBox";
            // 
            // ColumnNombre
            // 
            ColumnNombre.FillWeight = 118.315506F;
            ColumnNombre.HeaderText = "Nombre";
            ColumnNombre.MinimumWidth = 6;
            ColumnNombre.Name = "ColumnNombre";
            ColumnNombre.Resizable = DataGridViewTriState.True;
            ColumnNombre.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDescripcion
            // 
            ColumnDescripcion.FillWeight = 118.315506F;
            ColumnDescripcion.HeaderText = "Descripcion";
            ColumnDescripcion.MinimumWidth = 6;
            ColumnDescripcion.Name = "ColumnDescripcion";
            ColumnDescripcion.Resizable = DataGridViewTriState.True;
            ColumnDescripcion.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnFechaLimite
            // 
            ColumnFechaLimite.FillWeight = 118.315506F;
            ColumnFechaLimite.HeaderText = "Fecha Limite";
            ColumnFechaLimite.MinimumWidth = 6;
            ColumnFechaLimite.Name = "ColumnFechaLimite";
            ColumnFechaLimite.Resizable = DataGridViewTriState.True;
            ColumnFechaLimite.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrioridad
            // 
            ColumnPrioridad.FillWeight = 118.315506F;
            ColumnPrioridad.HeaderText = "Prioridad";
            ColumnPrioridad.MinimumWidth = 6;
            ColumnPrioridad.Name = "ColumnPrioridad";
            ColumnPrioridad.Resizable = DataGridViewTriState.True;
            ColumnPrioridad.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnEstatus
            // 
            ColumnEstatus.HeaderText = "Estatus";
            ColumnEstatus.MinimumWidth = 6;
            ColumnEstatus.Name = "ColumnEstatus";
            // 
            // ColumnCategoria
            // 
            ColumnCategoria.HeaderText = "Categoria";
            ColumnCategoria.MinimumWidth = 6;
            ColumnCategoria.Name = "ColumnCategoria";
            // 
            // ColumnID
            // 
            ColumnID.HeaderText = "ID";
            ColumnID.MinimumWidth = 6;
            ColumnID.Name = "ColumnID";
            ColumnID.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 33);
            label1.Name = "label1";
            label1.Size = new Size(322, 40);
            label1.TabIndex = 1;
            label1.Text = "GESTOR DE TAREAS";
            // 
            // cmbEstatus
            // 
            cmbEstatus.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Pendiente", "En Proceso", "Urgente", "Completado" });
            cmbEstatus.Location = new Point(109, 574);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(151, 29);
            cmbEstatus.TabIndex = 2;
            cmbEstatus.Text = "Pendiente";
            // 
            // cmbOrdenamiento
            // 
            cmbOrdenamiento.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbOrdenamiento.FormattingEnabled = true;
            cmbOrdenamiento.Items.AddRange(new object[] { "Reciente", "Prioridad", "Antiguo", "Fecha Limite" });
            cmbOrdenamiento.Location = new Point(155, 107);
            cmbOrdenamiento.Name = "cmbOrdenamiento";
            cmbOrdenamiento.Size = new Size(151, 29);
            cmbOrdenamiento.TabIndex = 5;
            cmbOrdenamiento.Text = "Reciente";
            cmbOrdenamiento.SelectedIndexChanged += cmbOrdenamiento_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 110);
            label2.Name = "label2";
            label2.Size = new Size(117, 21);
            label2.TabIndex = 6;
            label2.Text = "Ordenar por";
            // 
            // btnAñádir
            // 
            btnAñádir.Font = new Font("Century Gothic", 10.8F);
            btnAñádir.Location = new Point(380, 574);
            btnAñádir.Name = "btnAñádir";
            btnAñádir.Size = new Size(108, 31);
            btnAñádir.TabIndex = 7;
            btnAñádir.Text = "Añádir Tarea";
            btnAñádir.UseVisualStyleBackColor = true;
            btnAñádir.Click += btnAñádir_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Century Gothic", 10.8F);
            btnAplicar.Location = new Point(266, 574);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(108, 31);
            btnAplicar.TabIndex = 8;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 577);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 11;
            label3.Text = "Estatus";
            // 
            // btnDeshacer
            // 
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateLeft;
            btnDeshacer.IconColor = Color.Black;
            btnDeshacer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeshacer.Location = new Point(720, 98);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(44, 46);
            btnDeshacer.TabIndex = 12;
            btnDeshacer.UseVisualStyleBackColor = true;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnRehacer
            // 
            btnRehacer.FlatStyle = FlatStyle.Flat;
            btnRehacer.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateForward;
            btnRehacer.IconColor = Color.Black;
            btnRehacer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRehacer.Location = new Point(770, 98);
            btnRehacer.Name = "btnRehacer";
            btnRehacer.Size = new Size(48, 46);
            btnRehacer.TabIndex = 13;
            btnRehacer.UseVisualStyleBackColor = true;
            btnRehacer.Click += btnRehacer_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 643);
            Controls.Add(btnRehacer);
            Controls.Add(btnDeshacer);
            Controls.Add(label3);
            Controls.Add(btnAplicar);
            Controls.Add(btnAñádir);
            Controls.Add(label2);
            Controls.Add(cmbOrdenamiento);
            Controls.Add(cmbEstatus);
            Controls.Add(label1);
            Controls.Add(dgvPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInicio";
            Text = "FormInicio";
            ((System.ComponentModel.ISupportInitialize)dgvPrincipal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrincipal;
        private Label label1;
        private ComboBox cmbEstatus;
        public ComboBox cmbOrdenamiento;
        private Label label2;
        private Button btnAñádir;
        private Button btnAplicar;
        private Label label3;
        private DataGridViewCheckBoxColumn ColumnCheckBox;
        private DataGridViewTextBoxColumn ColumnNombre;
        private DataGridViewTextBoxColumn ColumnDescripcion;
        private DataGridViewTextBoxColumn ColumnFechaLimite;
        private DataGridViewTextBoxColumn ColumnPrioridad;
        private DataGridViewTextBoxColumn ColumnEstatus;
        private DataGridViewTextBoxColumn ColumnCategoria;
        private DataGridViewTextBoxColumn ColumnID;
        private FontAwesome.Sharp.IconButton btnDeshacer;
        private FontAwesome.Sharp.IconButton btnRehacer;
    }
}