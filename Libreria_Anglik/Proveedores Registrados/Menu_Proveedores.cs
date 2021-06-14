using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria_Anglik
{
    public partial class Menu_Proveedores : Form
    {
        public Menu_Proveedores()
        {
            InitializeComponent();
        }

       


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Proveedores_Load(object sender, EventArgs e)
        {
            AbrirFormhijo(new Inicio());
            

        }

        // hacer contenedor el panel

        private void AbrirFormhijo(object formhijo)
        {
            if (this.panelGeneral.Controls.Count > 0)
                this.panelGeneral.Controls.RemoveAt(0);

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelGeneral.Controls.Add(fh);
            this.panelGeneral.Tag = fh;

            fh.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Inicio());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            Proveedor_Lista_ventas lis = new Proveedor_Lista_ventas();

         


            lis.Show();



            lis.lblCuit.Text = lblprov.Text;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Clases_Saldos.Consultas_Saldos consal = new Clases_Saldos.Consultas_Saldos();
            Proveedor_saldo a = new Proveedor_saldo();
            a.lblsaldo.Text = consal.SaldoActual(lblprov.Text).ToString();

            a.Show();
             
        }

        private void btnCargaPoducto_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Proveedor_Mensaje());
        }
    }


}
