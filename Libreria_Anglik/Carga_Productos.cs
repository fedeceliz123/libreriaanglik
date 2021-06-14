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
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using BarcodeLib;


namespace Libreria_Anglik
{
    public partial class Carga_Productos : Form
    {
        public Carga_Productos()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

        private void pbImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscarimagen = new OpenFileDialog();
            //buscarimagen.Filter = "Archivos de imagen|*.png";

            buscarimagen.InitialDirectory = "C:\\";

            if (buscarimagen.ShowDialog() == DialogResult.OK)
            {
                pbImagen.ImageLocation = buscarimagen.FileName;
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvListar.Visible = true;
            cargarGrilla();
            btnReactivar.Visible = false;

        }

        private void cargarGrilla()
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.Listar(Activo);

            dgvListar.DataSource = null;
           dgvListar.DataSource = dt;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCargarNuevo_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoNuevo.Text == ""  || textBoxProductoNuevo.Text == "" || textBoxDescripcion.Text == "")
            {

                errorCampos();

            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea Cargar producto";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    // pasar imagen
                    System.IO.MemoryStream MS = new System.IO.MemoryStream();
                    System.IO.MemoryStream MS2 = new System.IO.MemoryStream();
                    pbImagen.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);


                    Clases_Producto.ProductosR prod = new Clases_Producto.ProductosR();

                    prod.Cod_producto = textBoxCodigoNuevo.Text;
                    prod.Activo = "Si";
                    prod.Nombre = textBoxProductoNuevo.Text;
                    prod.Descripcion = textBoxDescripcion.Text;
                    prod.Marca = textBoxMarca.Text;
                    prod.Cantidad = int.Parse(numericUpDownCantidadNuevo.Value.ToString());
                    prod.Precio = float.Parse(numericUpDownPrecioNuevo.Value.ToString());
                    prod.Can_min = int.Parse(numericUpDownCanMinNuevo.Value.ToString());
                    prod.Descuento1 = float.Parse(numericUpDownDesc1Nuevo.Value.ToString());
                    prod.Descuento2 = float.Parse(numericUpDownDesc2Nuevo.Value.ToString());
                    prod.Fecha_Ultima_Compra = dateTimePickerFechaNuevo.Value;
                    prod.Imagen = MS;
                    pbCodBarra.Image.Save(MS2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    prod.Codigo_Barra = MS2;

                    Clases_Producto.ConsustasProductos carga = new Clases_Producto.ConsustasProductos();

                    carga.CargarProducto(prod);

                    cargarGrilla();

                    Limpiar();
                }
            }

        }

        private void Limpiar()
        {
            textBoxCodigoNuevo.Clear();
            
            textBoxProductoNuevo.Clear();
            textBoxDescripcion.Clear();
            textBoxMarca.Clear();
            numericUpDownCantidadNuevo.Value = 0;
            numericUpDownPrecioNuevo.Value = 0;
            numericUpDownCanMinNuevo.Value = 0;
            numericUpDownDesc1Nuevo.Value = 0;
            numericUpDownDesc2Nuevo.Value = 0;
            dateTimePickerFechaNuevo.Value = dateTimePickerFechaNuevo.MaxDate;
            pbImagen.Image = Image.FromFile(@"C:\back\3er semestre\tp integrador\Libreria_Anglik\Libreria_Anglik\Agregar imagen.jpg");
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbCodBarra.Image = null;
            



        }

        private void errorCampos()
        {
            if(textBoxCodigoNuevo.Text == "")
            {
                epCodigo.SetError(textBoxCodigoNuevo,"Igrese codigo");
            }
            else
            {
                epCodigo.Clear();
            }
          
            if(textBoxProductoNuevo.Text == "")
            {
                epProduc.SetError(textBoxProductoNuevo, "Ingrese nombre del Producto");
            }
            else
            {
                epProduc.Clear();
            }
            if(textBoxDescripcion.Text == "")
            {
                epDescripcion.SetError(textBoxDescripcion, "Ingrese descripcion del producto");
            }
            else
            {
                epDescripcion.Clear();
            }

        }

        private void dgvListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btnReactivar.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                btnReactivar.Visible = false;
            }

            try
            {

                textBoxCodigoNuevo.Text = dgvListar.Rows[e.RowIndex].Cells[0].Value.ToString();

                Clases_Producto.ConsustasProductos cargartxb = new Clases_Producto.ConsustasProductos();
                DataRow dr = cargartxb.CargarCampos(textBoxCodigoNuevo.Text);

                if (dr["Cod_producto"] != null)
                {
                 
                    textBoxProductoNuevo.Text = (dr["Nombre"].ToString());
                    textBoxDescripcion.Text = (dr["Descripcion"].ToString());
                    textBoxMarca.Text = (dr["Marca"].ToString());
                    numericUpDownCantidadNuevo.Value = (int.Parse(dr["Cantidad"].ToString()));
                    numericUpDownPrecioNuevo.Value = (decimal.Parse(dr["Precio"].ToString()));
                    numericUpDownCanMinNuevo.Value = (int.Parse(dr["Can_min"].ToString()));
                    numericUpDownDesc1Nuevo.Value = (decimal.Parse(dr["Descuento1"].ToString()));
                    numericUpDownDesc2Nuevo.Value = (decimal.Parse(dr["Descuento2"].ToString()));

                    if (Convert.ToString(dr["Fecha_Ultima_Compra"]) != "")
                    {
                        dateTimePickerFechaNuevo.Value = Convert.ToDateTime(dr["Fecha_Ultima_Compra"]);
                    }


                    // 
                    Cargarimagen();

                    CargarCodBarra();

                    btnImprimir.Visible = true;
                    CantImp.Visible = true;

                }
            }
            catch 
            {
             
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoNuevo.Text == ""  || textBoxProductoNuevo.Text == "" || textBoxDescripcion.Text == "")
            {
                errorCampos();
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea modificar el Producto";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_Producto.ProductosR modificar = new Clases_Producto.ProductosR();
                    System.IO.MemoryStream MS = new System.IO.MemoryStream();
                    System.IO.MemoryStream MS2 = new System.IO.MemoryStream();

                    pbImagen.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);



                    modificar.Cod_producto = textBoxCodigoNuevo.Text;
                    
                    modificar.Nombre = textBoxProductoNuevo.Text;
                    modificar.Descripcion = textBoxDescripcion.Text;
                    modificar.Marca = textBoxMarca.Text;
                    modificar.Cantidad = int.Parse(numericUpDownCantidadNuevo.Value.ToString());
                    modificar.Precio = double.Parse(numericUpDownPrecioNuevo.Value.ToString());
                    modificar.Can_min = int.Parse(numericUpDownCanMinNuevo.Value.ToString());
                    modificar.Descuento1 = double.Parse(numericUpDownDesc1Nuevo.Value.ToString());
                    modificar.Descuento2 = double.Parse(numericUpDownDesc2Nuevo.Value.ToString());
                    modificar.Fecha_Ultima_Compra = dateTimePickerFechaNuevo.Value;
                    

                    modificar.Imagen = MS;
                    pbCodBarra.Image.Save(MS2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    modificar.Codigo_Barra = MS2;


                    Clases_Producto.ConsustasProductos consulta = new Clases_Producto.ConsustasProductos();
                    consulta.ModificarProductos(modificar);

                    //
                    cargarGrilla();
                    Limpiar();


                }
            }


        }


        private void Cargarimagen()
        {
            ConexionBD con = new ConexionBD();

            con.Conetar();
            SqlCommand a = new SqlCommand();
            string consulta = "select * from Productos where Cod_producto='" + textBoxCodigoNuevo.Text + "'";

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
        private void CargarCodBarra()
        {
            ConexionBD con = new ConexionBD();

            con.Conetar();
            SqlCommand a = new SqlCommand();
            string consulta = "select * from Productos where Cod_producto='" + textBoxCodigoNuevo.Text + "'";

            a = new SqlCommand(consulta, con.Conetar());

            SqlDataReader leer = a.ExecuteReader();

            if (leer.HasRows)
            {
                //convertir los datos byts a la imagen 
                leer.Read();
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])leer["Codigo_Barra"]);
                Bitmap bm = new Bitmap(ms);
                pbCodBarra.Image = bm;


            }

        }

        string Activo = "Si";
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar el Producto";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Producto.ConsustasProductos a = new Clases_Producto.ConsustasProductos();

                a.BorrarProducto(textBoxCodigoNuevo.Text,DateTime.Now.ToString("yyyy-MM-dd"));

                cargarGrilla();
                Limpiar();
            }

        }

        private void Carga_Productos_Load(object sender, EventArgs e)
        {
           textBoxCodigoNuevo.Focus();

            dateTimePickerFechaNuevo.MaxDate = DateTime.Now;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Activo = "No";
            }
            else if (checkBox1.Checked == false)
            {
                Activo = "Si";
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar el Producto";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Producto.ConsustasProductos a = new Clases_Producto.ConsustasProductos();

                a.ReActivarProducto(textBoxCodigoNuevo.Text);

                cargarGrilla();
                Limpiar();

                btnReactivar.Visible = false;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            pbCodBarra.Image = Codigo.Encode(BarcodeLib.TYPE.CODE128, textBoxCodigoNuevo.Text+" "+textBoxProductoNuevo.Text, Color.Black, Color.White, 263, 157);

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {



            imprimir();


            btnImprimir.Visible = false;
            btnImprimir.Enabled = false;
            CantImp.Visible = false;
            CantImp.Value = 0;
        }

        private void imprimir()
        {
            ImprimirTicket = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            ImprimirTicket.PrinterSettings = ps;
            ImprimirTicket.PrintPage += Imprecion;
            ImprimirTicket.Print();

        }

        private void Imprecion(object sender, PrintPageEventArgs e)
        {
            Image img = pbCodBarra.Image;

            int ancho = 300;
            int alto = 140;
            int y = 10;

            for (int i = 0; i < int.Parse(CantImp.Value.ToString()); i++)
            {
                e.Graphics.DrawImage(img, new Rectangle(10, y, ancho, alto));
                y = y + alto+5;
            }
        }

        private void ImprimirTicket_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void CantImp_ValueChanged(object sender, EventArgs e)
        {
            if(CantImp.Value!=0)
            {
                btnImprimir.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
            }
        }

        private void textBoxCodigoNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxCodigoNuevo_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporCodigo(Activo,textBoxCodigoNuevo.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void textBoxProductoNuevo_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporProducto(Activo, textBoxProductoNuevo.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void textBoxDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBoxMarca_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporMarca(Activo, textBoxMarca.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void textBoxDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Producto.ConsustasProductos con = new Clases_Producto.ConsustasProductos();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporDescripcion(Activo, textBoxDescripcion.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
