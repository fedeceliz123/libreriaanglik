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
    public partial class Mensajes : Form
    {
        public Mensajes()
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

        private void Mensajes_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {


            DataTable dt = new DataTable();
            Clases_Mensajes.Consulta_mensajes cM = new Clases_Mensajes.Consulta_mensajes();
            dt = cM.ListarLeidos();
            cbLeidos.DataSource = dt;
            cbLeidos.DisplayMember = "Mens";
            cbLeidos.ValueMember = "ID";

            DataTable dts = new DataTable();
           
            dts = cM.ListarNoLeidos();
            cbNoleidos.DataSource = dts;
            cbNoleidos.DisplayMember = "Mens";
            cbNoleidos.ValueMember = "ID";



        }
      


        private void cbNoleidos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Clases_Mensajes.Consulta_mensajes cM = new Clases_Mensajes.Consulta_mensajes();

            DataRow dr = cM.CargarCampos(cbNoleidos.SelectedValue.ToString());

            tbAsunto.Text = (dr["Asunto"]).ToString();
            tbMensaje.Text = (dr["Mensaje"]).ToString();
            tbFecha.Text = (dr["Fecha"]).ToString();

        }

        private void btnLeido_Click(object sender, EventArgs e)
        {

            if(tbMensaje.Text!="")
            {
                Clases_Mensajes.Consulta_mensajes conmen = new Clases_Mensajes.Consulta_mensajes();

                conmen.CargarLeido(cbNoleidos.SelectedValue.ToString());

                cbLeidos.Text = "";
                cbNoleidos.Text = "";

                CargarCombos();

                this.DialogResult = DialogResult.OK;
            }

            tbAsunto.Clear();
            tbFecha.Clear();
            tbMensaje.Clear();
            


        }

        private void cbLeidos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Clases_Mensajes.Consulta_mensajes cM = new Clases_Mensajes.Consulta_mensajes();

            DataRow dr = cM.CargarCampos(cbLeidos.SelectedValue.ToString());

            tbAsunto.Text = (dr["Asunto"]).ToString();
            tbMensaje.Text = (dr["Mensaje"]).ToString();
            tbFecha.Text = (dr["Fecha"]).ToString();
        }
    }
}
