namespace Libreria_Anglik
{
    partial class Mensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensajes));
            this.panel14 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbLeidos = new System.Windows.Forms.ComboBox();
            this.cbNoleidos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFecha = new System.Windows.Forms.TextBox();
            this.btnLeido = new System.Windows.Forms.Button();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel14.Controls.Add(this.pictureBox2);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(984, 39);
            this.panel14.TabIndex = 19;
            this.panel14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel14_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(940, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // cbLeidos
            // 
            this.cbLeidos.FormattingEnabled = true;
            this.cbLeidos.Location = new System.Drawing.Point(149, 123);
            this.cbLeidos.Name = "cbLeidos";
            this.cbLeidos.Size = new System.Drawing.Size(229, 21);
            this.cbLeidos.TabIndex = 20;
            this.cbLeidos.SelectionChangeCommitted += new System.EventHandler(this.cbLeidos_SelectionChangeCommitted);
            // 
            // cbNoleidos
            // 
            this.cbNoleidos.FormattingEnabled = true;
            this.cbNoleidos.Location = new System.Drawing.Point(590, 123);
            this.cbNoleidos.Name = "cbNoleidos";
            this.cbNoleidos.Size = new System.Drawing.Size(229, 21);
            this.cbNoleidos.TabIndex = 21;
            this.cbNoleidos.SelectionChangeCommitted += new System.EventHandler(this.cbNoleidos_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(78, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Leidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(505, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "No leidos:";
            // 
            // tbAsunto
            // 
            this.tbAsunto.Enabled = false;
            this.tbAsunto.Location = new System.Drawing.Point(149, 184);
            this.tbAsunto.MaxLength = 100;
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(335, 20);
            this.tbAsunto.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(78, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Asunto:";
            // 
            // tbMensaje
            // 
            this.tbMensaje.Enabled = false;
            this.tbMensaje.Location = new System.Drawing.Point(149, 230);
            this.tbMensaje.MaxLength = 1500;
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(335, 328);
            this.tbMensaje.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(66, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Mensaje:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(529, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Fecha:";
            // 
            // tbFecha
            // 
            this.tbFecha.Enabled = false;
            this.tbFecha.Location = new System.Drawing.Point(590, 183);
            this.tbFecha.MaxLength = 100;
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.Size = new System.Drawing.Size(166, 20);
            this.tbFecha.TabIndex = 38;
            // 
            // btnLeido
            // 
            this.btnLeido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnLeido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLeido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeido.FlatAppearance.BorderSize = 0;
            this.btnLeido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnLeido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeido.ForeColor = System.Drawing.Color.White;
            this.btnLeido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeido.Location = new System.Drawing.Point(590, 354);
            this.btnLeido.Name = "btnLeido";
            this.btnLeido.Size = new System.Drawing.Size(169, 54);
            this.btnLeido.TabIndex = 45;
            this.btnLeido.Text = "Leido";
            this.btnLeido.UseVisualStyleBackColor = false;
            this.btnLeido.Click += new System.EventHandler(this.btnLeido_Click);
            // 
            // Mensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(984, 647);
            this.Controls.Add(this.btnLeido);
            this.Controls.Add(this.tbFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMensaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAsunto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNoleidos);
            this.Controls.Add(this.cbLeidos);
            this.Controls.Add(this.panel14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mensajes";
            this.Text = "Mensajes";
            this.Load += new System.EventHandler(this.Mensajes_Load);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbLeidos;
        private System.Windows.Forms.ComboBox cbNoleidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMensaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFecha;
        public System.Windows.Forms.Button btnLeido;
    }
}