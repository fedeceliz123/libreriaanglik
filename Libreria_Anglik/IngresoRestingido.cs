using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Libreria_Anglik
{
    public partial class IngresoRestingido : Form
    {
        public IngresoRestingido()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbClave.UseSystemPasswordChar = false;
            }
            else
            {
                tbClave.UseSystemPasswordChar = true;
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Clases_Empleados.ConsultasEmpledos conEm = new Clases_Empleados.ConsultasEmpledos();

            if (conEm.PermisoAceptado(tbUser.Text, tbClave.Text) == "Gerente")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Su usuario no tiene acceso a esta ventana";

            }
           
        }

        private void IngresoRestingido_Load(object sender, EventArgs e)
        {


            tbUser.Focus();
        }

        
    }
}
