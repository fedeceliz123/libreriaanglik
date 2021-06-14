namespace Libreria_Anglik
{
    partial class Mensaje_Si_No
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensaje_Si_No));
            this.panel14 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
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
            this.panel14.Size = new System.Drawing.Size(723, 39);
            this.panel14.TabIndex = 20;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(679, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSi
            // 
            this.btnSi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnSi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSi.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSi.FlatAppearance.BorderSize = 0;
            this.btnSi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSi.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSi.Location = new System.Drawing.Point(416, 237);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(129, 38);
            this.btnSi.TabIndex = 23;
            this.btnSi.Text = "Si";
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Location = new System.Drawing.Point(564, 237);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(129, 38);
            this.btnNo.TabIndex = 24;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(43, 99);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(13, 16);
            this.lblMensaje.TabIndex = 25;
            this.lblMensaje.Text = "-";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Mensaje_Si_No
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(723, 311);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.panel14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mensaje_Si_No";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensaje_Si_No";
            this.TopMost = true;
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Button btnSi;
        public System.Windows.Forms.Button btnNo;
        public System.Windows.Forms.Label lblMensaje;
    }
}