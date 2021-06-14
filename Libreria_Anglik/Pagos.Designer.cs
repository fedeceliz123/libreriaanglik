namespace Libreria_Anglik
{
    partial class Pagos
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
            this.comboBoxListar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.gbProv = new System.Windows.Forms.GroupBox();
            this.gbOtros = new System.Windows.Forms.GroupBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbProv = new System.Windows.Forms.CheckBox();
            this.chbOtros = new System.Windows.Forms.CheckBox();
            this.gbPago = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPago = new System.Windows.Forms.NumericUpDown();
            this.tbConsepto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbProv.SuspendLayout();
            this.gbOtros.SuspendLayout();
            this.gbPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPago)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxListar
            // 
            this.comboBoxListar.FormattingEnabled = true;
            this.comboBoxListar.Items.AddRange(new object[] {
            "Provedores"});
            this.comboBoxListar.Location = new System.Drawing.Point(141, 61);
            this.comboBoxListar.Name = "comboBoxListar";
            this.comboBoxListar.Size = new System.Drawing.Size(241, 24);
            this.comboBoxListar.TabIndex = 29;
            this.comboBoxListar.SelectedIndexChanged += new System.EventHandler(this.comboBoxListar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(397, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Saldo: $";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Proveedores:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.White;
            this.lblSaldo.Location = new System.Drawing.Point(484, 62);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(13, 16);
            this.lblSaldo.TabIndex = 32;
            this.lblSaldo.Text = "-";
            // 
            // gbProv
            // 
            this.gbProv.Controls.Add(this.comboBoxListar);
            this.gbProv.Controls.Add(this.lblSaldo);
            this.gbProv.Controls.Add(this.label1);
            this.gbProv.Controls.Add(this.label2);
            this.gbProv.Enabled = false;
            this.gbProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProv.ForeColor = System.Drawing.Color.White;
            this.gbProv.Location = new System.Drawing.Point(32, 78);
            this.gbProv.Name = "gbProv";
            this.gbProv.Size = new System.Drawing.Size(562, 138);
            this.gbProv.TabIndex = 33;
            this.gbProv.TabStop = false;
            this.gbProv.Text = "Proveedores";
            // 
            // gbOtros
            // 
            this.gbOtros.Controls.Add(this.tbDescripcion);
            this.gbOtros.Controls.Add(this.label6);
            this.gbOtros.Enabled = false;
            this.gbOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOtros.ForeColor = System.Drawing.Color.White;
            this.gbOtros.Location = new System.Drawing.Point(614, 78);
            this.gbOtros.Name = "gbOtros";
            this.gbOtros.Size = new System.Drawing.Size(520, 138);
            this.gbOtros.TabIndex = 34;
            this.gbOtros.TabStop = false;
            this.gbOtros.Text = "Otros";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(141, 61);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(285, 22);
            this.tbDescripcion.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Descripcion:";
            // 
            // chbProv
            // 
            this.chbProv.AutoSize = true;
            this.chbProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbProv.ForeColor = System.Drawing.Color.White;
            this.chbProv.Location = new System.Drawing.Point(265, 55);
            this.chbProv.Name = "chbProv";
            this.chbProv.Size = new System.Drawing.Size(97, 17);
            this.chbProv.TabIndex = 35;
            this.chbProv.Text = "Proveedores";
            this.chbProv.UseVisualStyleBackColor = true;
            this.chbProv.CheckedChanged += new System.EventHandler(this.chbProv_CheckedChanged);
            // 
            // chbOtros
            // 
            this.chbOtros.AutoSize = true;
            this.chbOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbOtros.ForeColor = System.Drawing.Color.White;
            this.chbOtros.Location = new System.Drawing.Point(690, 55);
            this.chbOtros.Name = "chbOtros";
            this.chbOtros.Size = new System.Drawing.Size(56, 17);
            this.chbOtros.TabIndex = 36;
            this.chbOtros.Text = "Otros";
            this.chbOtros.UseVisualStyleBackColor = true;
            this.chbOtros.CheckedChanged += new System.EventHandler(this.chbOtros_CheckedChanged);
            // 
            // gbPago
            // 
            this.gbPago.Controls.Add(this.dtpFecha);
            this.gbPago.Controls.Add(this.label3);
            this.gbPago.Controls.Add(this.button2);
            this.gbPago.Controls.Add(this.label4);
            this.gbPago.Controls.Add(this.nudPago);
            this.gbPago.Controls.Add(this.tbConsepto);
            this.gbPago.Controls.Add(this.label7);
            this.gbPago.Enabled = false;
            this.gbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPago.ForeColor = System.Drawing.Color.White;
            this.gbPago.Location = new System.Drawing.Point(32, 252);
            this.gbPago.Name = "gbPago";
            this.gbPago.Size = new System.Drawing.Size(1102, 192);
            this.gbPago.TabIndex = 34;
            this.gbPago.TabStop = false;
            this.gbPago.Text = "Pago";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "yyyy-MM-dd";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(857, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(151, 22);
            this.dtpFecha.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(787, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Fecha:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(487, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 54);
            this.button2.TabIndex = 47;
            this.button2.Text = "Cargar Pago";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(512, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Valor:";
            // 
            // nudPago
            // 
            this.nudPago.DecimalPlaces = 2;
            this.nudPago.Location = new System.Drawing.Point(597, 62);
            this.nudPago.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudPago.Name = "nudPago";
            this.nudPago.Size = new System.Drawing.Size(151, 22);
            this.nudPago.TabIndex = 34;
            // 
            // tbConsepto
            // 
            this.tbConsepto.Location = new System.Drawing.Point(202, 59);
            this.tbConsepto.Name = "tbConsepto";
            this.tbConsepto.Size = new System.Drawing.Size(285, 22);
            this.tbConsepto.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(33, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Recibo/Consepto:";
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1159, 694);
            this.Controls.Add(this.gbPago);
            this.Controls.Add(this.chbOtros);
            this.Controls.Add(this.chbProv);
            this.Controls.Add(this.gbOtros);
            this.Controls.Add(this.gbProv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            this.gbProv.ResumeLayout(false);
            this.gbProv.PerformLayout();
            this.gbOtros.ResumeLayout(false);
            this.gbOtros.PerformLayout();
            this.gbPago.ResumeLayout(false);
            this.gbPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxListar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox gbProv;
        private System.Windows.Forms.GroupBox gbOtros;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbProv;
        private System.Windows.Forms.CheckBox chbOtros;
        private System.Windows.Forms.GroupBox gbPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPago;
        private System.Windows.Forms.TextBox tbConsepto;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
    }
}