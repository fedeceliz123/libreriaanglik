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
    public partial class ModificarCompra : Form
    {
        public ModificarCompra()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModificarCompra_Load(object sender, EventArgs e)
        {
            CargardgvCompra();
            CargarCombo();
            tbFechaCom.MaxDate = DateTime.Now;
            cargarGrilla();
        }
        private void cargarGrilla()
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.Listar("Si");

            dgvStock.DataSource = null;
            dgvStock.DataSource = dt;

        }

        private void CargarCombo()
        {


            DataTable dt = new DataTable();
            Consultas_Proveedores cP = new Consultas_Proveedores();
            dt = cP.CargarCombo();
            cbProv.DataSource = dt;
            cbProv.DisplayMember = "prov";
            cbProv.ValueMember = "CUIT";


        }

        private void CargardgvCompra()
        {
            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

            DataTable dt = new DataTable();

            dt = conCom.ListarCompras();


            dgvCompra.DataSource = null;

            dgvCompra.DataSource = dt;
            dgvCompra.Columns[5].Visible = false;


        }

        long IdCompra;
        float TOTAL;
        private void dgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                IdCompra = long.Parse(dgvCompra.Rows[e.RowIndex].Cells[0].Value.ToString());

                Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

                DataRow dr = conCom.CargarCampos(IdCompra.ToString());

                if (Convert.ToString(dr["N_Compra"]) != "")
                {

                    cbProveedor.Text = (dr["Proveedor"]).ToString();
                    dtpFecha.Value = DateTime.Parse((dr["Fecha"]).ToString());
                    tbCarRecibo.Text = (dr["Recibo"]).ToString();
                    TOTAL = float.Parse((dr["Total"]).ToString());
                    lblTotal.Text = (dr["Total"]).ToString();
                }

                CargarDetallecompra();

                button1.Enabled = false;
                button6.Enabled = false;

            }
            catch
            {

            }
        }

        private void CargarDetallecompra()
        {
            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

            DataTable dt = new DataTable();

            dt = conCom.Detalleventa(IdCompra);

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = dt;

            dgvDetalle.Columns[0].Visible = false;



        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea finalizar la carga de la compra";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Compras.ConsultasCompras conCOM = new Clases_Compras.ConsultasCompras();
                Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();



                conPro.DiminucionProductoCompra(cant, cod);
                TOTAL = TOTAL - subto;
                lblTotal.Text = TOTAL.ToString();
                conCOM.BorrarproCom(IdDetCom);

                button6.Enabled = false;
            }

            cargarGrilla();
            CargardgvCompra();
            CargarDetallecompra();
        }

        long IdDetCom;
        float subto;
        string cod;
        int cant;
        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdDetCom=long.Parse(dgvDetalle.Rows[e.RowIndex].Cells[0].Value.ToString());
                cod = dgvDetalle.Rows[e.RowIndex].Cells[1].Value.ToString();
                subto = float.Parse(dgvDetalle.Rows[e.RowIndex].Cells[5].Value.ToString());
                cant = int.Parse(dgvDetalle.Rows[e.RowIndex].Cells[4].Value.ToString());

                button6.Enabled = true;
                button1.Enabled = false;
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea cargar un nuevo Producto ";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

                conCom.ModificarCompra(lblTotal.Text, dtpFecha.Value.ToString(), IdCompra.ToString());

                CargardgvCompra();

                dgvDetalle.DataSource = null;
            }

        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbCod_Pro.Text = dgvStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbDetalle.Text = dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() + ", " + dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString(); ;

                cant = int.Parse(dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString());

                nudCantidad.Enabled = true;
                nudPrecio.Enabled = true;

            }
            catch 
            {
              
            }
        }
        float subtotal;
        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            subtotal = float.Parse(nudPrecio.Value.ToString()) * float.Parse(nudCantidad.Value.ToString());

            lblSubtotal.Text = subtotal.ToString();

            if (nudPrecio.Value>0&&nudCantidad.Value>0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }


        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            subtotal = float.Parse(nudPrecio.Value.ToString()) * float.Parse(nudCantidad.Value.ToString());

            lblSubtotal.Text = subtotal.ToString();

            if (nudPrecio.Value > 0 && nudCantidad.Value > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbProveedor.Text == "" || tbCarRecibo.Text == "" || tbCod_Pro.Text == "" || tbDetalle.Text == "" || nudCantidad.Value == 0 || nudPrecio.Value == 0)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Es obligatorio cargar los campos De la compra, Codigo, Detalle, Recibo, Cantidad y Precio";
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea cargar un nuevo Producto ";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                  
                    Clases_Compras.Detalle_Compra det = new Clases_Compras.Detalle_Compra();
                    Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();


                  

                    det.Codigo_Producto = tbCod_Pro.Text;
                    det.Detalle = tbDetalle.Text;

                    det.Numero_Compra = long.Parse(IdCompra.ToString());

                    det.Cantidad = int.Parse(nudCantidad.Value.ToString());
                    det.Precio = float.Parse(nudPrecio.Value.ToString());
                    det.SubTotal = float.Parse(lblSubtotal.Text);

                    conCom.CargarDetalleCompra(det);


                    Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

                    conPro.DevolucionProducto(tbCod_Pro.Text, cant, int.Parse(nudCantidad.Value.ToString()));

                    cargarGrilla();



                    CargarDetallecompra();

                    nudCantidad.Enabled = false;
                    nudPrecio.Enabled = false;
                }
            }


            TOTAL = TOTAL + subtotal;
            lblTotal.Text = TOTAL.ToString();

            Limpiar();
        }


        private void Limpiar()
        {
            tbCod_Pro.Clear();
            tbDetalle.Clear();
            nudCantidad.Value = 0;
            nudPrecio.Value = 0;

        }


        string fecha="";
        string prov = "";
        string recibo = "";
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            recibo = tbRecibo.Text;

            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

            DataTable dt = new DataTable();

            dt = conCom.listarConFiltro(prov,fecha,recibo);

            dgvCompra.DataSource = null;
            dgvCompra.DataSource = dt;
            dgvCompra.Columns[5].Visible = false;

            if (prov != "" || fecha != "" || recibo != "")
            {
                button2.Visible = true;
            }

            dgvDetalle.DataSource = null;

        }

        private void cbProv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            prov = cbProv.SelectedValue.ToString();
        }

        private void tbFechaCom_CloseUp(object sender, EventArgs e)
        {
            fecha = tbFechaCom.Value.ToString("yyyy-MM-dd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbFechaCom.Value = tbFechaCom.MaxDate;

            cbProv.SelectedIndex = 0;

            tbRecibo.Clear();

            button2.Visible = false;

            fecha = "";
            prov = "";
            recibo = "";

            dgvDetalle.DataSource = null;

        }
    }
}
