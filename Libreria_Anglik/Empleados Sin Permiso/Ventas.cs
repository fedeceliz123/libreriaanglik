using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria_Anglik
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        double Desc;


        private void CargarComboCliente()
        {


            DataTable dt = new DataTable();
            Clases_Clientes.ConsultasClientes cC = new Clases_Clientes.ConsultasClientes();
            if (cC.CargarCombo() != null)
            {
                dt = cC.CargarCombo();
                cbClientes.DataSource = dt;
                cbClientes.DisplayMember = "cli";
                cbClientes.ValueMember = "Dni";
            }

        }


        private void CargarComboVendedor()
        {


            DataTable dt = new DataTable();
            Clases_Empleados.ConsultasEmpledos cV = new Clases_Empleados.ConsultasEmpledos();
            if (cV.CargarComboVendedores() != null)
            {
                dt = cV.CargarComboVendedores();
                cbVendedor.DataSource = dt;
                cbVendedor.DisplayMember = "vendedor";
                cbVendedor.ValueMember = "DNI";
            }

        }


        private void CargarGrilla()
        {
            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conPro.ListarVenta();

            dtvProductos.DataSource = null;
            dtvProductos.DataSource = dt;
            dtvProductos.Columns[1].Width = 150;
            dtvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void CargarTicket()
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conVen.Detalleventa(long.Parse(tbNFactura.Text));

         dgvVenta.DataSource = null;
          dgvVenta.DataSource = dt;
            Alingdgv();

        }

        private void Alingdgv()
        {
            dgvVenta.Columns[0].Visible = false;
            dgvVenta.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[2].Width = 150;
            dgvVenta.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[3].Width = 80;
            dgvVenta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[4].Width = 80;
            dgvVenta.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[5].Width = 80;
        }

        private void CargarPuesto()
        {
            DataTable dt = new DataTable();
            Clases_Ventas.ConsultasVentas cV = new Clases_Ventas.ConsultasVentas();
            if (cV.CargarPuestoVenta() != null)
            {
                dt = cV.CargarPuestoVenta();
                cbSucursal.DataSource = dt;
                cbSucursal.DisplayMember = "puesto";
                cbSucursal.ValueMember = "Id";
            }

        }

      

        private void Ventas_Load(object sender, EventArgs e)
        {
            

            NuevoTicket();
            CargarPuesto();

            CargarGrilla();
            CargarTicket();
            CargarComboCliente();
            CargarComboVendedor();
            Limpiar();

           
        }

      

        private void BuscarporCodigo()
        {
            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conPro.ListarVentaCod(tbCodigo.Text);

            dtvProductos.DataSource = null;
            dtvProductos.DataSource = dt;

        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarporCodigo();
        }

        private void dtvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nudCantidad.Enabled = true;

            

            try
            {

                tbCodigo.Text = dtvProductos.Rows[e.RowIndex].Cells[0].Value.ToString();

                Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

                DataRow dr = conPro.CargarCamposV(tbCodigo.Text);

                if (dr["Cod_Producto"] != null)
                {
                    Disponible.Text = (dr["Cantidad"].ToString());
                    tbProducto.Text = (dr["Producto"].ToString());
                    Precio.Text = (dr["Precio"].ToString());

                    if (double.Parse(dr["Descuento1"].ToString()) != 0 && double.Parse(dr["Descuento2"].ToString()) != 0)
                    {
                        nudDescuento.Value = decimal.Parse(dr["Descuento1"].ToString()) + decimal.Parse(dr["Descuento2"].ToString());

                    }
                    else if (double.Parse(dr["Descuento1"].ToString()) != 0)
                    {
                        nudDescuento.Value = decimal.Parse(dr["Descuento1"].ToString());
                    }
                    else
                    {
                        nudDescuento.Value = 0;
                    }

                }

                nudCantidad.Maximum = int.Parse(Disponible.Text);
                SubTotal.Text = "-";
                nudCantidad.Value = 0;
            }
            catch 
            {
             
            }

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {

            double total = (double.Parse(Precio.Text)) * double.Parse(nudCantidad.Value.ToString());
            if (nudDescuento.Value != 0)
            {
                 total = (double.Parse(Precio.Text)) * double.Parse(nudCantidad.Value.ToString()) * (1 - double.Parse(nudDescuento.Value.ToString()));

                SubTotal.Text = total.ToString();
            }
            else
            {

                SubTotal.Text = total.ToString();
            }


            if (nudCantidad.Value!=0)
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }



        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            if (CHbDesc.Checked == true && tbCodigo.Text!="" && lblDisponible.Text!="-")
            {
                if (nudDescuento.Value != 0)
                {
                    double total = (double.Parse(Precio.Text)) * double.Parse(nudCantidad.Value.ToString()) * (1 - double.Parse(nudDescuento.Value.ToString()));

                    SubTotal.Text = total.ToString();
                }
            }

        }

        private void CHbDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (CHbDesc.Checked == true && tbCodigo.Text != "" && lblDisponible.Text != "-")
            {
                nudDescuento.Enabled = true;
            }
            else if (CHbDesc.Checked == false && tbCodigo.Text != "" && lblDisponible.Text != "-")
            {
                nudDescuento.Enabled = false;
                nudDescuento.Value = 0;

                double total = (double.Parse(Precio.Text)) * double.Parse(nudCantidad.Value.ToString());


                SubTotal.Text = total.ToString();
            }
        }

        // contador 
        int contador=0;
        // total
        double TOTAL = 0;
        private void btnCargar_Click(object sender, EventArgs e)
        {
           
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro en cargar producto";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {

                    Clases_Ventas.VentasR Ven = new Clases_Ventas.VentasR();
                    Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();
                    Clases_Ventas.DetalleVenta DVen = new Clases_Ventas.DetalleVenta();
                    // venta

                    Ven.N_Venta = long.Parse(tbNFactura.Text);
                    Ven.Puesto_Venta = cbSucursal.Text;
                    Ven.N_Ticket = cbSucursal.Text + "-" + tbNFactura.Text;
                    Ven.DNI_Vendedor = cbVendedor.SelectedValue.ToString();
                    Ven.Cliente = cbClientes.SelectedValue.ToString();
                    Ven.Fecha = dtphoy.Value;
                    Ven.Total = 0;

                    if (contador == 0)
                    {
                        conVen.CargarVenta(Ven);
                    }
                    contador++;

                    // detalle venta
                    DVen.Codigo_Producto = tbCodigo.Text;
                    DVen.Detalle = tbProducto.Text;
                    DVen.N_Venta_Detalle = long.Parse(tbNFactura.Text);
                    DVen.Cantidad = int.Parse(nudCantidad.Value.ToString());
                    DVen.Precio = float.Parse(Precio.Text);
                    DVen.Descuento = float.Parse(nudDescuento.Value.ToString());
                    decimal subt = Math.Round((decimal.Parse(SubTotal.Text)), 2);
                    DVen.Subtotal = Math.Round(subt, 2);

                    conVen.CargarDetalleVenta(DVen);

                    Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

                    conPro.DiminucionProductoVenta(int.Parse(Disponible.Text), int.Parse(nudCantidad.Value.ToString()), tbCodigo.Text);

                    CargarGrilla();
                    CargarTicket();


                    TOTAL = TOTAL + double.Parse(SubTotal.Text);
                    Total.Text = TOTAL.ToString();

                    Limpiar();

                }

                btnFinalizar.Enabled = true;
                btnCargar.Enabled = false;
            
        }

        private void NuevoTicket()
        {

            Clases_Ventas.ConsultasVentas cV = new Clases_Ventas.ConsultasVentas();

            if (cV.NtoTicket() != "")
            {
                tbNFactura.Text = cV.NtoTicket();
            }
            else
            {
                tbNFactura.Text = "00000001";
            }
        }

        private void Limpiar()

        {
            cbSucursal.SelectedIndex = 0;
            tbCodigo.Clear();
            Disponible.Text = "-";
            nudCantidad.Value = 0;
            Precio.Text = "-";
            SubTotal.Text = "-";
            nudDescuento.Value = 0;
            tbProducto.Clear();
            nudCantidad.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea finalizar venta";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                imprimir();

                Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

                conVen.IngresarTotal(double.Parse(Total.Text),long.Parse(tbNFactura.Text));

                NuevoTicket();

                CargarTicket();

                Total.Text = "-";

                TOTAL = 0;
                contador = 0;


                

            }

            btnQuitar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnCargar.Enabled = false;




        }

        long IDDet;
        string Codigo;
        int stock;
        int vendido;
        double subtotal;
        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases_Ventas.ConsultasVentas conven = new Clases_Ventas.ConsultasVentas();
            if (conven.ContarDetalle(tbNFactura.Text) == true)
            {
                btnQuitar.Enabled = true;
            }
            else
            {
                btnQuitar.Enabled = false;
            }

            try
            {

                IDDet = long.Parse(dgvVenta.Rows[e.RowIndex].Cells[0].Value.ToString());

                Codigo = dgvVenta.Rows[e.RowIndex].Cells[1].Value.ToString();

                vendido = int.Parse(dgvVenta.Rows[e.RowIndex].Cells[3].Value.ToString());

                subtotal= double.Parse(dgvVenta.Rows[e.RowIndex].Cells[5].Value.ToString());

                Clases_Producto.ConsustasProductos cP = new Clases_Producto.ConsustasProductos();

               stock= cP.ProductoaDevolver(Codigo);

            }
            catch 
            {
         

            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();
            conVen.BorrarProducto(IDDet);

            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            conPro.DevolucionProducto(Codigo,stock,vendido);

            TOTAL = TOTAL - subtotal;

            Total.Text = TOTAL.ToString();


            CargarGrilla();
            CargarTicket();

            btnQuitar.Enabled = false;

            if (conVen.ContarDetalle(tbNFactura.Text) == true) 
            {
                btnFinalizar.Enabled = true;
            }
            else
            {
                btnFinalizar.Enabled = false;
            }



        }

        private void btnNuevoCli_Click(object sender, EventArgs e)
        {
            Libreria_Anglik.Cargar_Cliente carCli = new Cargar_Cliente();

            carCli.panel14.Visible = true;

            if(carCli.ShowDialog()==DialogResult.OK)
            {
                CargarComboCliente();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            CargarGrilla();
        }

        private void tbProducto_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            DataTable dt = new DataTable();
            
           dt= conPro.ListarInventarioFiltro(tbProducto.Text);

            dtvProductos.DataSource = null;
            dtvProductos.DataSource = dt;




        }
        //
        //
        //
        // imprimir
      

        private void imprimir()
        {
            ImprimirTicket = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            ImprimirTicket.PrinterSettings = ps;
            ImprimirTicket.PrintPage += Imprecion;
            ImprimirTicket.Print();

        }

        private void Imprecion(object sender,PrintPageEventArgs e)
        {
            Font font = new Font("Arial",8,FontStyle.Regular,GraphicsUnit.Point);
            Font font2 = new Font("Arial", 2, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Arial", 5, FontStyle.Regular, GraphicsUnit.Point);
            int width = 100;
            int y = 20;
            int caracteres = 62;
            string imp="";
          


            e.Graphics.DrawString("Libreria Anglik",font,Brushes.Black,new RectangleF(0,0,width,20));
            for(int i=0; i<caracteres;i++)
            {
                imp = imp + "_";
            }
            /// datos de la empresa 

            e.Graphics.DrawString(imp, font2, Brushes.Black, new RectangleF(0, 12, width, 20));
            e.Graphics.DrawString("Comprovante no Valido como factura", font2, Brushes.Black, new RectangleF(0, y, width,20));
            e.Graphics.DrawString(" Fecha: "+dtphoy.Value.ToString("dd-MM-yyyy")+"\n N° Comprovante:"+cbSucursal.Text+"-"+tbNFactura.Text, font2, Brushes.Black, new RectangleF(0, y+=10, width, 20));
            e.Graphics.DrawString(imp, font2, Brushes.Black, new RectangleF(0, y+=10, width, 20));

            /// detalle de compra 
            /// 
            e.Graphics.DrawString("Vendedor: "+ cbVendedor.SelectedValue.ToString() , font2, Brushes.Black, new RectangleF(0, y += 8, width, 20));
            e.Graphics.DrawString(imp, font2, Brushes.Black, new RectangleF(0, y += 5, width, 20));

            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            DataTable dt = new DataTable();

            int nvent = int.Parse(tbNFactura.Text);

            dt = conVen.ImprimirDetalle(nvent.ToString());

            e.Graphics.DrawString("Codigo                Detalle                            Cantidad                  Sutotal", font2, Brushes.Black, new RectangleF(0, y += 8, width, 20));
            e.Graphics.DrawString(imp, font2, Brushes.Black, new RectangleF(0, y += 8, width, 20));
            foreach (DataRow col in dt.Rows)
            {
                string codigo = col["Codigo_Producto"].ToString();
                int cod = codigo.Length;
                int maxCod = 22;
                for(int i=0;i<(maxCod-cod);i++)
                {
                    codigo = codigo + " ";
                }

                string detalle = col["Detalle"].ToString();
                int det = detalle.Length;
                if(det>10)
                {
                    detalle = detalle.Substring(0, 10)+"...";
                    det = detalle.Length;
                }
                int maxDet = 33;
                for(int i = 0; i < (maxDet - det); i++)
                {
                    detalle = detalle + " ";
                }

                decimal cant =   Math.Round(decimal.Parse(col["Subtotal"].ToString()),2);

                string cantidad = col["Cantidad"].ToString();
                int can = cantidad.Length;
                int maxCan = 26;
                for (int i = 0; i < (maxCan - can); i++)
                {
                    cantidad = cantidad + " ";
                }

                 string subtotal ="$ "+ cant.ToString();
               


                 e.Graphics.DrawString( codigo+detalle+cantidad+subtotal, font2, Brushes.Black, new RectangleF(0, y += 10, width, 20));


            }

            e.Graphics.DrawString(imp, font2, Brushes.Black, new RectangleF(0, y += 8, width, 20));



            //total
            e.Graphics.DrawString("Total: $ "+Total.Text, font3, Brushes.Black, new RectangleF(0, y += 8, width, 20));




        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
