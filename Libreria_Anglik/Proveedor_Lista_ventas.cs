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
    public partial class Proveedor_Lista_ventas : Form
    {
        public Proveedor_Lista_ventas()
        {
            InitializeComponent();
        }
        // hacer que se mueva ventana desde la tabla de barra

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);


        private void Proveedor_Lista_ventas_Load(object sender, EventArgs e)
        {
            Menu_Proveedores a = new Menu_Proveedores();


            lblCuit.Text = a.lblprov.Text;

        }

        private void ListarVenta()
        {
            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();
            Menu_Proveedores mPro = new Menu_Proveedores();

            DataTable dt = new DataTable();
            dt = conCom.ListarCompra(lblCuit.Text);

            dgvLisarVentas.DataSource = null;
            dgvLisarVentas.DataSource = dt;

            DataTable dt2 = new DataTable();

            dt2 = conCom.ListarDetCompra(lblCuit.Text);

            dgvDetallecom.DataSource = null;
            dgvDetallecom.DataSource = dt2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarVenta();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
