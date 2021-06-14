namespace Libreria_Anglik
{
    partial class Asistencia_Personal
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpIngreso = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraEn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbIngreso = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDniIng = new System.Windows.Forms.ComboBox();
            this.gbSalida = new System.Windows.Forms.GroupBox();
            this.cbDniSal = new System.Windows.Forms.ComboBox();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHoraSal = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxIngreso = new System.Windows.Forms.CheckBox();
            this.checkBoxSalida = new System.Windows.Forms.CheckBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.gbIngreso.SuspendLayout();
            this.gbSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(355, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Asisencia personal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpIngreso
            // 
            this.dtpIngreso.Enabled = false;
            this.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIngreso.Location = new System.Drawing.Point(92, 89);
            this.dtpIngreso.Name = "dtpIngreso";
            this.dtpIngreso.Size = new System.Drawing.Size(179, 22);
            this.dtpIngreso.TabIndex = 25;
            this.dtpIngreso.Value = new System.DateTime(2021, 6, 14, 16, 3, 54, 0);
            // 
            // dtpHoraEn
            // 
            this.dtpHoraEn.CustomFormat = "HH:mm:ss";
            this.dtpHoraEn.Enabled = false;
            this.dtpHoraEn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraEn.Location = new System.Drawing.Point(92, 132);
            this.dtpHoraEn.Name = "dtpHoraEn";
            this.dtpHoraEn.Size = new System.Drawing.Size(179, 22);
            this.dtpHoraEn.TabIndex = 26;
            this.dtpHoraEn.Value = new System.DateTime(2021, 6, 14, 16, 3, 49, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Hora:";
            // 
            // gbIngreso
            // 
            this.gbIngreso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbIngreso.Controls.Add(this.label1);
            this.gbIngreso.Controls.Add(this.cbDniIng);
            this.gbIngreso.Controls.Add(this.dtpIngreso);
            this.gbIngreso.Controls.Add(this.label4);
            this.gbIngreso.Controls.Add(this.dtpHoraEn);
            this.gbIngreso.Controls.Add(this.label3);
            this.gbIngreso.Enabled = false;
            this.gbIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIngreso.ForeColor = System.Drawing.Color.White;
            this.gbIngreso.Location = new System.Drawing.Point(103, 112);
            this.gbIngreso.Name = "gbIngreso";
            this.gbIngreso.Size = new System.Drawing.Size(312, 197);
            this.gbIngreso.TabIndex = 30;
            this.gbIngreso.TabStop = false;
            this.gbIngreso.Text = "Ingreso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Empleado:";
            // 
            // cbDniIng
            // 
            this.cbDniIng.FormattingEnabled = true;
            this.cbDniIng.Location = new System.Drawing.Point(92, 39);
            this.cbDniIng.Name = "cbDniIng";
            this.cbDniIng.Size = new System.Drawing.Size(179, 24);
            this.cbDniIng.TabIndex = 30;
            // 
            // gbSalida
            // 
            this.gbSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbSalida.Controls.Add(this.cbDniSal);
            this.gbSalida.Controls.Add(this.dtpSalida);
            this.gbSalida.Controls.Add(this.label5);
            this.gbSalida.Controls.Add(this.dtpHoraSal);
            this.gbSalida.Controls.Add(this.label6);
            this.gbSalida.Controls.Add(this.label7);
            this.gbSalida.Enabled = false;
            this.gbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSalida.ForeColor = System.Drawing.Color.White;
            this.gbSalida.Location = new System.Drawing.Point(540, 112);
            this.gbSalida.Name = "gbSalida";
            this.gbSalida.Size = new System.Drawing.Size(312, 197);
            this.gbSalida.TabIndex = 31;
            this.gbSalida.TabStop = false;
            this.gbSalida.Text = "Salida";
            // 
            // cbDniSal
            // 
            this.cbDniSal.FormattingEnabled = true;
            this.cbDniSal.Location = new System.Drawing.Point(92, 39);
            this.cbDniSal.Name = "cbDniSal";
            this.cbDniSal.Size = new System.Drawing.Size(179, 24);
            this.cbDniSal.TabIndex = 31;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Enabled = false;
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalida.Location = new System.Drawing.Point(92, 89);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(179, 22);
            this.dtpSalida.TabIndex = 25;
            this.dtpSalida.Value = new System.DateTime(2021, 6, 14, 16, 3, 44, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Hora:";
            // 
            // dtpHoraSal
            // 
            this.dtpHoraSal.CustomFormat = "HH:mm:ss";
            this.dtpHoraSal.Enabled = false;
            this.dtpHoraSal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraSal.Location = new System.Drawing.Point(92, 132);
            this.dtpHoraSal.Name = "dtpHoraSal";
            this.dtpHoraSal.Size = new System.Drawing.Size(179, 22);
            this.dtpHoraSal.TabIndex = 26;
            this.dtpHoraSal.Value = new System.DateTime(2021, 6, 14, 16, 3, 39, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Empleado:";
            // 
            // checkBoxIngreso
            // 
            this.checkBoxIngreso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxIngreso.AutoSize = true;
            this.checkBoxIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIngreso.ForeColor = System.Drawing.Color.White;
            this.checkBoxIngreso.Location = new System.Drawing.Point(360, 70);
            this.checkBoxIngreso.Name = "checkBoxIngreso";
            this.checkBoxIngreso.Size = new System.Drawing.Size(79, 20);
            this.checkBoxIngreso.TabIndex = 32;
            this.checkBoxIngreso.Text = "Ingreso";
            this.checkBoxIngreso.UseVisualStyleBackColor = true;
            this.checkBoxIngreso.CheckedChanged += new System.EventHandler(this.checkBoxIngreso_CheckedChanged);
            // 
            // checkBoxSalida
            // 
            this.checkBoxSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxSalida.AutoSize = true;
            this.checkBoxSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSalida.ForeColor = System.Drawing.Color.White;
            this.checkBoxSalida.Location = new System.Drawing.Point(527, 70);
            this.checkBoxSalida.Name = "checkBoxSalida";
            this.checkBoxSalida.Size = new System.Drawing.Size(72, 20);
            this.checkBoxSalida.TabIndex = 33;
            this.checkBoxSalida.Text = "Salida";
            this.checkBoxSalida.UseVisualStyleBackColor = true;
            this.checkBoxSalida.CheckedChanged += new System.EventHandler(this.checkBoxSalida_CheckedChanged);
            // 
            // btnCarga
            // 
            this.btnCarga.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCarga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarga.FlatAppearance.BorderSize = 0;
            this.btnCarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarga.ForeColor = System.Drawing.Color.White;
            this.btnCarga.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarga.Location = new System.Drawing.Point(374, 356);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(178, 54);
            this.btnCarga.TabIndex = 34;
            this.btnCarga.Text = "Cargar asistencia";
            this.btnCarga.UseVisualStyleBackColor = false;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // Asistencia_Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(938, 673);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.checkBoxSalida);
            this.Controls.Add(this.checkBoxIngreso);
            this.Controls.Add(this.gbSalida);
            this.Controls.Add(this.gbIngreso);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Asistencia_Personal";
            this.Text = "Asistencia_Personal";
            this.Load += new System.EventHandler(this.Asistencia_Personal_Load);
            this.gbIngreso.ResumeLayout(false);
            this.gbIngreso.PerformLayout();
            this.gbSalida.ResumeLayout(false);
            this.gbSalida.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpIngreso;
        private System.Windows.Forms.DateTimePicker dtpHoraEn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbIngreso;
        private System.Windows.Forms.GroupBox gbSalida;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHoraSal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxIngreso;
        private System.Windows.Forms.CheckBox checkBoxSalida;
        public System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.ComboBox cbDniIng;
        private System.Windows.Forms.ComboBox cbDniSal;
        private System.Windows.Forms.Label label1;
    }
}