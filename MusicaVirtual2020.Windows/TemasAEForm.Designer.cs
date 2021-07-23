namespace MusicaVirtual2020.Windows
{
    partial class TemasAEForm
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.agregarTemaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TituloTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.DuracionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pistaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.agregarTemaButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 54);
            this.panel3.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(53, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Temas";
            // 
            // agregarTemaButton
            // 
            this.agregarTemaButton.Image = global::MusicaVirtual2020.Windows.Properties.Resources.AgregarAE;
            this.agregarTemaButton.Location = new System.Drawing.Point(941, 14);
            this.agregarTemaButton.Name = "agregarTemaButton";
            this.agregarTemaButton.Size = new System.Drawing.Size(31, 30);
            this.agregarTemaButton.TabIndex = 15;
            this.agregarTemaButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Duración:";
            // 
            // TituloTextBox
            // 
            this.TituloTextBox.Location = new System.Drawing.Point(164, 107);
            this.TituloTextBox.Name = "TituloTextBox";
            this.TituloTextBox.Size = new System.Drawing.Size(592, 20);
            this.TituloTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Título:";
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::MusicaVirtual2020.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(512, 189);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::MusicaVirtual2020.Windows.Properties.Resources.Aceptar;
            this.OkButton.Location = new System.Drawing.Point(271, 189);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DuracionDateTimePicker
            // 
            this.DuracionDateTimePicker.CustomFormat = "";
            this.DuracionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DuracionDateTimePicker.Location = new System.Drawing.Point(165, 150);
            this.DuracionDateTimePicker.Name = "DuracionDateTimePicker";
            this.DuracionDateTimePicker.ShowUpDown = true;
            this.DuracionDateTimePicker.Size = new System.Drawing.Size(82, 20);
            this.DuracionDateTimePicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Título:";
            // 
            // pistaNumericUpDown
            // 
            this.pistaNumericUpDown.Location = new System.Drawing.Point(165, 71);
            this.pistaNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pistaNumericUpDown.Name = "pistaNumericUpDown";
            this.pistaNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.pistaNumericUpDown.TabIndex = 10;
            this.pistaNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TemasAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 270);
            this.Controls.Add(this.pistaNumericUpDown);
            this.Controls.Add(this.DuracionDateTimePicker);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TituloTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TemasAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TemasAEForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button agregarTemaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TituloTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker DuracionDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown pistaNumericUpDown;
    }
}