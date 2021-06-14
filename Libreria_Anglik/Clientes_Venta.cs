using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Libreria_Anglik
{
    public partial class Clientes_Venta : Form
    {
        public Clientes_Venta()
        {
            InitializeComponent();
        }

        private void cargargrilla()
        {

            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarParaClientes();

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].Visible = false;
            dgvListar.Columns[3].Visible = false;

        }

        string codigo;
        private void Cargarimagen()
        {
            ConexionBD con = new ConexionBD();

            con.Conetar();
            SqlCommand a = new SqlCommand();
            string consulta = "select Imagen from Productos where Cod_producto='" + codigo + "'";

            a = new SqlCommand(consulta, con.Conetar());

            SqlDataReader leer = a.ExecuteReader();

            if (leer.HasRows)
            {
                //convertir los datos byts a la imagen 
                leer.Read();
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])leer["Imagen"]);
                Bitmap bm = new Bitmap(ms);
                pbImagen.Image = bm;


            }

        }

        private void Clientes_Venta_Load(object sender, EventArgs e)
        {
            cargargrilla();
        }

        private void dgvListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                codigo = dgvListar.Rows[e.RowIndex].Cells[0].Value.ToString();

                Clases_Producto.ConsustasProductos cargartxb = new Clases_Producto.ConsustasProductos();
                DataRow dr = cargartxb.CargarCampos(codigo);

                if (dr["Cod_producto"] != null)
                {

                    lbDisponible.Text = (dr["Cantidad"].ToString());
                    lblPrecio.Text = (dr["Precio"].ToString());





                    // 
                    Cargarimagen();
                    numericUpDown1.Value = 0;
                    numericUpDown1.Maximum= int.Parse(dr["Cantidad"].ToString());

                }
            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }
        }
    }
}
