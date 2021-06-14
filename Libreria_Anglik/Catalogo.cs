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
    public partial class Catalogo : Form
    {
        public Catalogo()
        {
            InitializeComponent();
        }

        int CantVen = 5;
        int CantDes = 5;
        private void dgvListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
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



                }
            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }

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

        private void Catalogo_Load(object sender, EventArgs e)
        {
            cargargrilla();
            CargarProductos();
            CargarProductosDescuento();
        }

        string codigo;


        private Bitmap Cargarimagen1(string cod)
        {

            ConexionBD con = new ConexionBD();

            con.Conetar();
            SqlCommand a = new SqlCommand();
            string consulta = "select Imagen from Productos where Cod_producto='" + cod + "'";

            a = new SqlCommand(consulta, con.Conetar());

            SqlDataReader leer = a.ExecuteReader();

            if (leer.HasRows)
            {
                //convertir los datos byts a la imagen 
                leer.Read();
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])leer["Imagen"]);

                Bitmap bm = new Bitmap(ms);

                return bm;
            }
            else
            {
                return null;
            }


        }

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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CantVen = CantVen + 5;
            CargarProductos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (CantVen > 5)
            {
                CantVen = CantVen - 5;
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();
            DataTable dt = new DataTable();
            dt = conVen.vendidos(CantVen.ToString());

            int contador = 0;

            foreach (DataRow colum in dt.Rows)
            {
                contador++;

                if (contador == 1)
                {
                    lblNombre1.Text = colum["nombre"].ToString();
                    lblPrecio1.Text = colum["Precio"].ToString();
                    lblDisp1.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb1.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }



                }
                else if (contador == 2)
                {
                    lblNombre2.Text = colum["nombre"].ToString();
                    lblPrecio2.Text = colum["Precio"].ToString();
                    lblDisp2.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb2.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }

                }
                else if (contador == 3)
                {
                    lblNombre3.Text = colum["nombre"].ToString();
                    lblPrecio3.Text = colum["Precio"].ToString();
                    lblDisp3.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb3.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }

                }
                else if (contador == 4)
                {
                    lblNombre4.Text = colum["nombre"].ToString();
                    lblPrecio4.Text = colum["Precio"].ToString();
                    lblDisp4.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb3.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }
                }
                else if (contador == 5)
                {
                    lblNombre5.Text = colum["nombre"].ToString();
                    lblPrecio5.Text = colum["Precio"].ToString();
                    lblDisp5.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb5.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }
                }

            }

        }

        private void CargarProductosDescuento()
        {
            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();
            DataTable dt = new DataTable();

           dt= conPro.ProductosDescuento(CantDes.ToString());
            int contador = 0;

            foreach (DataRow colum in dt.Rows)
            {
                contador++;

                float descuento;

                if (contador == 1)
                {
                    lblNombre6.Text = colum["Productos"].ToString();

                    descuento = 1 - (float.Parse(colum["Descuento1"].ToString()) + float.Parse(colum["Descuento2"].ToString()));

                    lblPrecio6.Text = (float.Parse(colum["Precio"].ToString()) * descuento).ToString();
                    lblDis6.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb6.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }

                    lblAnt1.Text = colum["Precio"].ToString();


                }
                else if (contador == 2)
                {
                    lblNombre7.Text = colum["Productos"].ToString();

                    descuento = 1 - (float.Parse(colum["Descuento1"].ToString()) + float.Parse(colum["Descuento2"].ToString()));

                    lblPrecio7.Text = (float.Parse(colum["Precio"].ToString()) * descuento).ToString();
                    lblDis7.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb7.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }

                    lblAntes2.Text = colum["Precio"].ToString();

                }
                else if (contador == 3)
                {
                    lblNombre8.Text = colum["Productos"].ToString();

                    descuento = 1 - (float.Parse(colum["Descuento1"].ToString()) + float.Parse(colum["Descuento2"].ToString()));

                    lblPrecio8.Text = (float.Parse(colum["Precio"].ToString()) * descuento).ToString();
                    lblDis8.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb8.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }


                    lblAntes3.Text = colum["Precio"].ToString();

                }
                else if (contador == 4)
                {
                    lblNobre9.Text = colum["Productos"].ToString();

                    descuento = 1 - (float.Parse(colum["Descuento1"].ToString()) + float.Parse(colum["Descuento2"].ToString()));

                    lblPrecio9.Text = (float.Parse(colum["Precio"].ToString()) * descuento).ToString();
                    lblDis9.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb9.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }


                    lblAntes4.Text = colum["Precio"].ToString();
                }
                else if (contador == 5)
                {
                    lblNombre10.Text = colum["Productos"].ToString();

                    descuento =1 - (float.Parse(colum["Descuento1"].ToString()) + float.Parse(colum["Descuento2"].ToString()));

                    lblPrecio10.Text = (float.Parse(colum["Precio"].ToString())*descuento).ToString();
                    lblDis10.Text = colum["Cantidad"].ToString();

                    if (Cargarimagen1(colum["Cod_producto"].ToString()) != null)
                    {
                        pb10.Image = Cargarimagen1(colum["Cod_producto"].ToString());
                    }

                    lblAntes5.Text = colum["Precio"].ToString();
                }




            }
        }

        private void btnAtras2_Click(object sender, EventArgs e)
        {
            if (CantDes > 5)
            {
                CantDes = CantDes - 5;
                CargarProductosDescuento();
            }
        }

        private void btnSig2_Click(object sender, EventArgs e)
        {
            CantDes = CantDes + 5;
            CargarProductosDescuento();
        }

        private void tbBuscar_KeyUp(object sender, KeyEventArgs e)
        {

            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            DataTable dt = new DataTable();

            dt = conPro.ListarInventarioFiltro(tbBuscar.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].Visible = false;
            dgvListar.Columns[3].Visible = false;

        }
    }
}
