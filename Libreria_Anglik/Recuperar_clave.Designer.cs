namespace Libreria_Anglik
{
    partial class Recuperar_clave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recuperar_clave));
            this.panel14 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel14.Size = new System.Drawing.Size(664, 39);
            this.panel14.TabIndex = 34;
            this.panel14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel14_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(620, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(163, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "E-mail:";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(236, 125);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(212, 20);
            this.textBoxMail.TabIndex = 35;
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnRecuperar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRecuperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecuperar.FlatAppearance.BorderSize = 0;
            this.btnRecuperar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.ForeColor = System.Drawing.Color.White;
            this.btnRecuperar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecuperar.Location = new System.Drawing.Point(236, 188);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(191, 54);
            this.btnRecuperar.TabIndex = 37;
            this.btnRecuperar.Text = "Recuperar clave";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(165, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Coloca tu mail para enviar tu clave";
            // 
            // Recuperar_clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(664, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.panel14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recuperar_clave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar_clave";
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Label label1;
    }
}