namespace Libreria_Anglik
{
    partial class Reportes_Empleados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVentadia = new System.Windows.Forms.Button();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.dgvLisarAsistencia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVenM = new System.Windows.Forms.Label();
            this.lblToV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLisarAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVentadia);
            this.groupBox1.Controls.Add(this.cbEmpleado);
            this.groupBox1.Controls.Add(this.dtpfecha);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(154, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 92);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros De Busqueda";
            // 
            // btnVentadia
            // 
            this.btnVentadia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnVentadia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVentadia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentadia.FlatAppearance.BorderSize = 0;
            this.btnVentadia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnVentadia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentadia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentadia.ForeColor = System.Drawing.Color.White;
            this.btnVentadia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentadia.Location = new System.Drawing.Point(447, 28);
            this.btnVentadia.Name = "btnVentadia";
            this.btnVentadia.Size = new System.Drawing.Size(112, 41);
            this.btnVentadia.TabIndex = 21;
            this.btnVentadia.Text = "Buscar";
            this.btnVentadia.UseVisualStyleBackColor = false;
            this.btnVentadia.Click += new System.EventHandler(this.btnVentadia_Click);
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Location = new System.Drawing.Point(47, 38);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(211, 24);
            this.cbEmpleado.TabIndex = 1;
            // 
            // dtpfecha
            // 
            this.dtpfecha.CustomFormat = "yyyy-MM";
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfecha.Location = new System.Drawing.Point(280, 38);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(146, 22);
            this.dtpfecha.TabIndex = 0;
            this.dtpfecha.Value = new System.DateTime(2021, 6, 14, 2, 38, 50, 0);
            // 
            // dgvLisarAsistencia
            // 
            this.dgvLisarAsistencia.AllowUserToAddRows = false;
            this.dgvLisarAsistencia.AllowUserToDeleteRows = false;
            this.dgvLisarAsistencia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.dgvLisarAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLisarAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLisarAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLisarAsistencia.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLisarAsistencia.EnableHeadersVisualStyles = false;
            this.dgvLisarAsistencia.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvLisarAsistencia.Location = new System.Drawing.Point(154, 177);
            this.dgvLisarAsistencia.Name = "dgvLisarAsistencia";
            this.dgvLisarAsistencia.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLisarAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLisarAsistencia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLisarAsistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLisarAsistencia.Size = new System.Drawing.Size(658, 256);
            this.dgvLisarAsistencia.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(844, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dias Total Trabajado en el Mes:";
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.ForeColor = System.Drawing.Color.White;
            this.lblDias.Location = new System.Drawing.Point(1114, 249);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(13, 16);
            this.lblDias.TabIndex = 9;
            this.lblDias.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(844, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Horas Total Trabajado en el Mes:";
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.ForeColor = System.Drawing.Color.White;
            this.lblHoras.Location = new System.Drawing.Point(1114, 319);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(13, 16);
            this.lblHoras.TabIndex = 11;
            this.lblHoras.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(844, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cantidad de Ventas en el Mes:";
            // 
            // dgvVenta
            // 
            this.dgvVenta.AllowUserToAddRows = false;
            this.dgvVenta.AllowUserToDeleteRows = false;
            this.dgvVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.dgvVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVenta.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVenta.EnableHeadersVisualStyles = false;
            this.dgvVenta.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvVenta.Location = new System.Drawing.Point(154, 477);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvVenta.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta.Size = new System.Drawing.Size(658, 256);
            this.dgvVenta.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(844, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total de Ventas en el Mes:";
            // 
            // lblVenM
            // 
            this.lblVenM.AutoSize = true;
            this.lblVenM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenM.ForeColor = System.Drawing.Color.White;
            this.lblVenM.Location = new System.Drawing.Point(1114, 512);
            this.lblVenM.Name = "lblVenM";
            this.lblVenM.Size = new System.Drawing.Size(13, 16);
            this.lblVenM.TabIndex = 15;
            this.lblVenM.Text = "-";
            // 
            // lblToV
            // 
            this.lblToV.AutoSize = true;
            this.lblToV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToV.ForeColor = System.Drawing.Color.White;
            this.lblToV.Location = new System.Drawing.Point(1114, 556);
            this.lblToV.Name = "lblToV";
            this.lblToV.Size = new System.Drawing.Size(13, 16);
            this.lblToV.TabIndex = 16;
            this.lblToV.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(198, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ventas Realizadas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(198, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Asistencia";
            // 
            // Reportes_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1410, 777);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblToV);
            this.Controls.Add(this.lblVenM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLisarAsistencia);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes_Empleados";
            this.Text = "Reportes_Empleados";
            this.Load += new System.EventHandler(this.Reportes_Empleados_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLisarAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.DataGridView dgvLisarAsistencia;
        public System.Windows.Forms.Button btnVentadia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVenM;
        private System.Windows.Forms.Label lblToV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}