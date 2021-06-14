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
    public partial class Menu_Clientes : Form
    {
        public Menu_Clientes()
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

        private void Menu_Clientes_Load(object sender, EventArgs e)
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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Catalogo());
        }

        private void btnCargaPoducto_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Clientes_Mensajes());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Clientes_Venta());
        }
    }
}
