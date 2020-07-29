namespace MusicaVirtual2020.Windows
{
    partial class DetallesAlbumForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CostoTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PistasTextBox = new System.Windows.Forms.TextBox();
            this.SoporteTextBox = new System.Windows.Forms.TextBox();
            this.EstiloTextBox = new System.Windows.Forms.TextBox();
            this.InterpreteTextBox = new System.Windows.Forms.TextBox();
            this.NegocioTextBox = new System.Windows.Forms.TextBox();
            this.AnioCompraTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TituloTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.temasDatosGridView = new System.Windows.Forms.DataGridView();
            this.cmnNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temasDatosGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.CostoTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.PistasTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.SoporteTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.EstiloTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.InterpreteTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.NegocioTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AnioCompraTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.TituloTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.temasDatosGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 576);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Negocio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Soporte:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Estilo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Intérprete:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Pistas:";
            // 
            // CostoTextBox
            // 
            this.CostoTextBox.Enabled = false;
            this.CostoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostoTextBox.Location = new System.Drawing.Point(607, 150);
            this.CostoTextBox.Name = "CostoTextBox";
            this.CostoTextBox.Size = new System.Drawing.Size(90, 22);
            this.CostoTextBox.TabIndex = 43;
            this.CostoTextBox.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(559, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Costo:";
            // 
            // PistasTextBox
            // 
            this.PistasTextBox.Enabled = false;
            this.PistasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PistasTextBox.Location = new System.Drawing.Point(107, 202);
            this.PistasTextBox.Name = "PistasTextBox";
            this.PistasTextBox.Size = new System.Drawing.Size(67, 22);
            this.PistasTextBox.TabIndex = 37;
            // 
            // SoporteTextBox
            // 
            this.SoporteTextBox.Enabled = false;
            this.SoporteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoporteTextBox.Location = new System.Drawing.Point(107, 168);
            this.SoporteTextBox.Name = "SoporteTextBox";
            this.SoporteTextBox.Size = new System.Drawing.Size(332, 22);
            this.SoporteTextBox.TabIndex = 38;
            // 
            // EstiloTextBox
            // 
            this.EstiloTextBox.Enabled = false;
            this.EstiloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstiloTextBox.Location = new System.Drawing.Point(107, 128);
            this.EstiloTextBox.Name = "EstiloTextBox";
            this.EstiloTextBox.Size = new System.Drawing.Size(332, 22);
            this.EstiloTextBox.TabIndex = 39;
            // 
            // InterpreteTextBox
            // 
            this.InterpreteTextBox.Enabled = false;
            this.InterpreteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterpreteTextBox.Location = new System.Drawing.Point(107, 93);
            this.InterpreteTextBox.Name = "InterpreteTextBox";
            this.InterpreteTextBox.Size = new System.Drawing.Size(332, 22);
            this.InterpreteTextBox.TabIndex = 40;
            // 
            // NegocioTextBox
            // 
            this.NegocioTextBox.Enabled = false;
            this.NegocioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NegocioTextBox.Location = new System.Drawing.Point(607, 93);
            this.NegocioTextBox.Name = "NegocioTextBox";
            this.NegocioTextBox.Size = new System.Drawing.Size(332, 22);
            this.NegocioTextBox.TabIndex = 41;
            // 
            // AnioCompraTextBox
            // 
            this.AnioCompraTextBox.Enabled = false;
            this.AnioCompraTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnioCompraTextBox.Location = new System.Drawing.Point(607, 124);
            this.AnioCompraTextBox.Name = "AnioCompraTextBox";
            this.AnioCompraTextBox.Size = new System.Drawing.Size(90, 22);
            this.AnioCompraTextBox.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Año Compra:";
            // 
            // TituloTextBox
            // 
            this.TituloTextBox.Enabled = false;
            this.TituloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloTextBox.Location = new System.Drawing.Point(107, 50);
            this.TituloTextBox.Name = "TituloTextBox";
            this.TituloTextBox.Size = new System.Drawing.Size(592, 22);
            this.TituloTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Título:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 31);
            this.panel1.TabIndex = 48;
            // 
            // temasDatosGridView
            // 
            this.temasDatosGridView.AllowUserToAddRows = false;
            this.temasDatosGridView.AllowUserToDeleteRows = false;
            this.temasDatosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.temasDatosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnNro,
            this.cmnTema,
            this.cmnDuracion});
            this.temasDatosGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temasDatosGridView.Location = new System.Drawing.Point(0, 0);
            this.temasDatosGridView.MultiSelect = false;
            this.temasDatosGridView.Name = "temasDatosGridView";
            this.temasDatosGridView.ReadOnly = true;
            this.temasDatosGridView.RowHeadersVisible = false;
            this.temasDatosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.temasDatosGridView.Size = new System.Drawing.Size(1001, 328);
            this.temasDatosGridView.TabIndex = 5;
            // 
            // cmnNro
            // 
            this.cmnNro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmnNro.HeaderText = "Nro";
            this.cmnNro.Name = "cmnNro";
            this.cmnNro.ReadOnly = true;
            this.cmnNro.Width = 49;
            // 
            // cmnTema
            // 
            this.cmnTema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnTema.HeaderText = "Tema";
            this.cmnTema.Name = "cmnTema";
            this.cmnTema.ReadOnly = true;
            // 
            // cmnDuracion
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.cmnDuracion.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnDuracion.HeaderText = "Duración";
            this.cmnDuracion.Name = "cmnDuracion";
            this.cmnDuracion.ReadOnly = true;
            // 
            // DetallesAlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 576);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DetallesAlbumForm";
            this.Text = "DetallesAlbumForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.temasDatosGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CostoTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PistasTextBox;
        private System.Windows.Forms.TextBox SoporteTextBox;
        private System.Windows.Forms.TextBox EstiloTextBox;
        private System.Windows.Forms.TextBox InterpreteTextBox;
        private System.Windows.Forms.TextBox NegocioTextBox;
        private System.Windows.Forms.TextBox AnioCompraTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TituloTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView temasDatosGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTema;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDuracion;
    }
}