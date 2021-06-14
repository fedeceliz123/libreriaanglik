namespace Libreria_Anglik
{
    partial class Proveedor_Mensaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbProveedor = new System.Windows.Forms.TextBox();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCaracteres = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(110, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "CUIT Proveedor:";
            // 
            // tbProveedor
            // 
            this.tbProveedor.Location = new System.Drawing.Point(261, 75);
            this.tbProveedor.Name = "tbProveedor";
            this.tbProveedor.Size = new System.Drawing.Size(247, 20);
            this.tbProveedor.TabIndex = 0;
            this.tbProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProveedor_KeyPress);
            // 
            // tbAsunto
            // 
            this.tbAsunto.Location = new System.Drawing.Point(261, 119);
            this.tbAsunto.MaxLength = 100;
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(247, 20);
            this.tbAsunto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(175, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Asunto:";
            // 
            // tbMensaje
            // 
            this.tbMensaje.Location = new System.Drawing.Point(261, 177);
            this.tbMensaje.MaxLength = 1500;
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(381, 256);
            this.tbMensaje.TabIndex = 2;
            this.tbMensaje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbMensaje_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(175, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mensaje:";
            // 
            // lblCaracteres
            // 
            this.lblCaracteres.AutoSize = true;
            this.lblCaracteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaracteres.ForeColor = System.Drawing.Color.White;
            this.lblCaracteres.Location = new System.Drawing.Point(502, 438);
            this.lblCaracteres.Name = "lblCaracteres";
            this.lblCaracteres.Size = new System.Drawing.Size(140, 13);
            this.lblCaracteres.TabIndex = 36;
            this.lblCaracteres.Text = "Caracteres disponibles 1500";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(352, 497);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(169, 54);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar Mensaje";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // Proveedor_Mensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(839, 649);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lblCaracteres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMensaje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAsunto);
            this.Controls.Add(this.tbProveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Proveedor_Mensaje";
            this.Text = "Proveedor_Mensaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProveedor;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCaracteres;
        public System.Windows.Forms.Button btnEnviar;
    }
}