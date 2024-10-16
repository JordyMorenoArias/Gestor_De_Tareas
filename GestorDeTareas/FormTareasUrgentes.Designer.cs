namespace GestorDeTareas
{
    partial class FormTareasUrgentes
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
            lblHistorial = new Label();
            dgvTareaUrgente = new DataGridView();
            ColumnNombre = new DataGridViewTextBoxColumn();
            ColumnDescripcion = new DataGridViewTextBoxColumn();
            ColumnFechaLimite = new DataGridViewTextBoxColumn();
            ColumnEstatus = new DataGridViewTextBoxColumn();
            ColumnCategoria = new DataGridViewTextBoxColumn();
            ColumnID = new DataGridViewTextBoxColumn();
            btnHecho = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTareaUrgente).BeginInit();
            SuspendLayout();
            // 
            // lblHistorial
            // 
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Century Gothic", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHistorial.Location = new Point(32, 38);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(332, 44);
            lblHistorial.TabIndex = 4;
            lblHistorial.Text = "TAREAS URGENTES";
            // 
            // dgvTareaUrgente
            // 
            dgvTareaUrgente.AllowUserToAddRows = false;
            dgvTareaUrgente.AllowUserToDeleteRows = false;
            dgvTareaUrgente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTareaUrgente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTareaUrgente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTareaUrgente.Columns.AddRange(new DataGridViewColumn[] { ColumnNombre, ColumnDescripcion, ColumnFechaLimite, ColumnEstatus, ColumnCategoria, ColumnID });
            dgvTareaUrgente.Cursor = Cursors.Hand;
            dgvTareaUrgente.GridColor = SystemColors.ActiveBorder;
            dgvTareaUrgente.Location = new Point(32, 141);
            dgvTareaUrgente.Name = "dgvTareaUrgente";
            dgvTareaUrgente.RowHeadersVisible = false;
            dgvTareaUrgente.RowHeadersWidth = 51;
            dgvTareaUrgente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTareaUrgente.Size = new Size(806, 457);
            dgvTareaUrgente.TabIndex = 3;
            dgvTareaUrgente.CellDoubleClick += dgvTareaUrgente_CellDoubleClick_1;
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
            ColumnFechaLimite.HeaderText = "Fecha Limite";
            ColumnFechaLimite.MinimumWidth = 6;
            ColumnFechaLimite.Name = "ColumnFechaLimite";
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
            // btnHecho
            // 
            btnHecho.Font = new Font("Century Gothic", 10.8F);
            btnHecho.Location = new Point(301, 109);
            btnHecho.Name = "btnHecho";
            btnHecho.Size = new Size(124, 27);
            btnHecho.TabIndex = 14;
            btnHecho.Text = "Hecho";
            btnHecho.UseVisualStyleBackColor = true;
            btnHecho.Click += btnCompletada_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 112);
            label1.Name = "label1";
            label1.Size = new Size(263, 21);
            label1.TabIndex = 15;
            label1.Text = "Completar Tarea mas Antigua";
            // 
            // FormTareasUrgentes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 643);
            Controls.Add(label1);
            Controls.Add(btnHecho);
            Controls.Add(lblHistorial);
            Controls.Add(dgvTareaUrgente);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTareasUrgentes";
            Text = "FormTareasUrgentes";
            ((System.ComponentModel.ISupportInitialize)dgvTareaUrgente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHistorial;
        private DataGridView dgvTareaUrgente;
        private DataGridViewTextBoxColumn ColumnNombre;
        private DataGridViewTextBoxColumn ColumnDescripcion;
        private DataGridViewTextBoxColumn ColumnFechaLimite;
        private DataGridViewTextBoxColumn ColumnEstatus;
        private DataGridViewTextBoxColumn ColumnCategoria;
        private DataGridViewTextBoxColumn ColumnID;
        private Button btnHecho;
        private Label label1;
    }
}