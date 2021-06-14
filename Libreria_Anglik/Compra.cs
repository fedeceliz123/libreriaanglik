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
    public partial class Compra : Form
    {
        public Compra()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);



        private void CargarCombo()
        {


            DataTable dt = new DataTable();
            Consultas_Proveedores cP = new Consultas_Proveedores();
            dt = cP.CargarCombo();
            cbProv.DataSource = dt;
            cbProv.DisplayMember = "prov";
            cbProv.ValueMember = "CUIT";


        }

        private void CargarNcom()
        {
            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();
            if (conCom.codCompra() != "")
            {
                long Com = long.Parse(conCom.codCompra()) + 1;

                lblNcom.Text = Com.ToString();
            }
            else
            {
                lblNcom.Text = "1";
            }

        }

        private void Compra_Load(object sender, EventArgs e)
        {
            CargarCombo();

            CargarNcom();

            tbFechaCom.MaxDate = DateTime.Now;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Proveedores a = new Proveedores();
            a.panel14.Visible = true;
            if (a.ShowDialog() == DialogResult.OK)
            {
                CargarCombo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Carga_Productos CP = new Carga_Productos();
            CP.Show();
            CP.panel14.Visible = true;
        }

        int contador;
        float TOTAL;
        long IDCom;

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbProv.Text == "" || tbRecibo.Text == "" || tbCod_Pro.Text == "" || tbDetalle.Text == "" || nudCantidad.Value == 0 || nudPrecio.Value == 0)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Es obligatorio cargar los campos Proveedor, Codigo, Detalle, Recibo, Cantidad y Precio";
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea cargar nuevo proveedor";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_Compras.ComprasR com = new Clases_Compras.ComprasR();
                    Clases_Compras.Detalle_Compra det = new Clases_Compras.Detalle_Compra();
                    Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();


                    com.N_Compra = long.Parse(lblNcom.Text);
                    com.Fecha = tbFechaCom.Value;
                    com.Proveedor = cbProv.SelectedValue.ToString();
                    com.Recibo = tbRecibo.Text;
                    com.Pagado = float.Parse(nudPagado.Value.ToString());
                  
                    if (contador == 0)
                    {
                        conCom.CargarCompra(com);
                        contador++;
                    }

                    det.Codigo_Producto = tbCod_Pro.Text;
                    det.Detalle = tbDetalle.Text;

                    det.Numero_Compra = long.Parse(lblNcom.Text);

                    det.Cantidad = int.Parse(nudCantidad.Value.ToString());
                    det.Precio = float.Parse(nudPrecio.Value.ToString());
                    det.SubTotal = float.Parse(lblSubtotal.Text);

                    conCom.CargarDetalleCompra(det);


                    Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

                    conPro.DevolucionProducto(tbCod_Pro.Text,cant,int.Parse(nudCantidad.Value.ToString()));

                    cargarGrilla();



                    CargarTicket();

                    button5.Enabled = true;
                }
            }


            TOTAL = TOTAL + subtotal;
            lblTotal.Text = TOTAL.ToString();

            Limpiar();
        }




        private void button2_Click(object sender, EventArgs e)
        {

            cargarGrilla();

        }
        string Activo = "Si";
        private void cargarGrilla()
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.Listar(Activo);

            dgvStock.DataSource = null;
            dgvStock.DataSource = dt;
            dgvStock.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
        }

        private void BuscarporCodigo()
        {
            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conPro.ListarVentaCod(tbCod_Pro.Text);

            dgvStock.DataSource = null;
            dgvStock.DataSource = dt;

        }

        private void tbRecibo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbCod_Pro_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarporCodigo();
        }


        int cant;
        string cod;
        int com;
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

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            subtotal = float.Parse(nudPrecio.Value.ToString()) * float.Parse(nudCantidad.Value.ToString());

            lblSubtotal.Text = subtotal.ToString();

            if (nudCantidad.Value > 0 && nudPrecio.Value > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            subtotal = float.Parse(nudPrecio.Value.ToString()) * float.Parse(nudCantidad.Value.ToString());

            lblSubtotal.Text = subtotal.ToString();

            if(nudCantidad.Value>0&&nudPrecio.Value>0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }


        }



        private void CargarTicket()
        {
            Clases_Compras.ConsultasCompras conCOM = new Clases_Compras.ConsultasCompras();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conCOM.Detalleventa(long.Parse(lblNcom.Text));

            dgvCompra.DataSource = null;
            dgvCompra.DataSource = dt;
            dgvCompra.Columns[0].Visible = false;
            dgvCompra.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
         
            dgvCompra.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

       
        }


        private void Limpiar()
        {
            tbCod_Pro.Clear();
            tbDetalle.Clear();
            nudCantidad.Value = 0;
            nudPrecio.Value = 0;

        }

        float saldo;
        private void button5_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea finalizar la carga de la compra";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();

                conCom.IngresarTotal(float.Parse(lblTotal.Text), long.Parse(lblNcom.Text), float.Parse(nudPagado.Value.ToString()));

                if (lblSaldo.Text != "-" && lblSaldo.Text != "0")
                {
                    Clases_Saldos.SaldosR sal = new Clases_Saldos.SaldosR();
                    Clases_Saldos.Consultas_Saldos conSal = new Clases_Saldos.Consultas_Saldos();

                   
                        sal.Saldo = float.Parse(lblSaldo.Text) + conSal.SaldoActual(cbProv.SelectedValue.ToString());
                    
                   
                    conSal.AumentarSaldo(sal.Saldo,cbProv.SelectedValue.ToString());

                }
                else if(lblSaldo.Text == "-" )
                {
                    Clases_Saldos.SaldosR sal = new Clases_Saldos.SaldosR();
                    Clases_Saldos.Consultas_Saldos conSal = new Clases_Saldos.Consultas_Saldos();

                    sal.Saldo = float.Parse(lblTotal.Text) + conSal.SaldoActual(cbProv.SelectedValue.ToString());

                    conSal.AumentarSaldo(sal.Saldo, cbProv.SelectedValue.ToString());
                }

                nudPagado.Value = 0;
                lblSaldo.Text = "-";
                lblTotal.Text = "-";
                CargarNcom();
                CargarTicket();
                TOTAL = 0;
                contador = 0;
                button5.Enabled = false;
                tbRecibo.Clear();

            }
        }

        private void nudPagado_ValueChanged(object sender, EventArgs e)
        {
            saldo = float.Parse(lblTotal.Text) - float.Parse(nudPagado.Value.ToString());
            lblSaldo.Text = saldo.ToString();
        }


        float subto;
        private void dgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDCom = long.Parse(dgvCompra.Rows[e.RowIndex].Cells[0].Value.ToString());
                cod = dgvCompra.Rows[e.RowIndex].Cells[1].Value.ToString();
                com = int.Parse(dgvCompra.Rows[e.RowIndex].Cells[3].Value.ToString());
                subto=float.Parse(dgvCompra.Rows[e.RowIndex].Cells[5].Value.ToString());

                button6.Enabled = true;

            }
            catch 
            {
             

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea finalizar la carga de la compra";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                Clases_Compras.ConsultasCompras conCOM = new Clases_Compras.ConsultasCompras();
                Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();



                conPro.DiminucionProductoVenta(conPro.ProductoaDevolver(cod), com, cod);
                TOTAL = TOTAL - subto;
                lblTotal.Text = TOTAL.ToString();
                conCOM.BorrarproCom(IDCom);

                cargarGrilla();
                CargarTicket();

                button6.Enabled = false;
            }

            Clases_Compras.ConsultasCompras conCom = new Clases_Compras.ConsultasCompras();


            if (conCom.ContarDetalle(lblNcom.Text) == true)
            {
                button5.Enabled = true;
            }
            else
            {
               button5.Enabled = false;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ModificarCompra mCompra = new ModificarCompra();


            mCompra.Show();
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
