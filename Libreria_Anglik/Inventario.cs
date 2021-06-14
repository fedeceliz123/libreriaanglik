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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

      

        private void Inventario_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }
        private void cargarGrilla()
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarInventario();

            dgvDisponibilidad.DataSource = null;
            dgvDisponibilidad.DataSource = dt;
            dgvDisponibilidad.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDisponibilidad.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDisponibilidad.Columns[2].Width = 150;
        }
    }
}
