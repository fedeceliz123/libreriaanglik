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
//validar mail
using System.Text.RegularExpressions;

using System.Runtime.InteropServices;


namespace Libreria_Anglik
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);



        long IdTel, IdDri, IdMail;


        private void CargarComboPais()
        {


            DataTable dt = new DataTable();
            ConsultasSQL cP = new ConsultasSQL();
            dt = cP.CargarComboPais();
            cbPais.DataSource = dt;
            cbPais.DisplayMember = "nombrepais";
            cbPais.ValueMember = "id";


        }

        private void CargarComboProvincia()
        {


            DataTable dt = new DataTable();
            ConsultasSQL cP = new ConsultasSQL();
            if (cbPais.SelectedIndex != 0)
            {
                dt = cP.CargarComboProvincia(int.Parse(cbPais.SelectedValue.ToString()));
                cbProvincia.DataSource = dt;
                cbProvincia.DisplayMember = "estadonombre";
                cbProvincia.ValueMember = "id";
            }



        }


        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            CargarGrilla();

            btnReactivar.Visible = false;




        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            Limpiar();

            CargarCombo();

            CargarComboPais();

            textBoxCuit.Focus();

            comboBoxIVA.SelectedIndex =0;


            dtpFechaIng.MaxDate = DateTime.Now;
        }

        private void comboBoxListar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxCuit.Text = comboBoxListar.SelectedValue.ToString();

    
            Consultas_Proveedores conPR = new Consultas_Proveedores();
            DataRow dr = conPR.CargarCampos(textBoxCuit.Text);

            if (dr["CUIT"]!= null)
            {
                textBoxRazonSo.Text = (dr["Razon_Social"]).ToString();
                textBoxNomFan.Text = (dr["Nombre_Fantasia"]).ToString();
                comboBoxIVA.Text = (dr["Condicion_IVA"]).ToString();
                tbRubro.Text = (dr["Rubro"]).ToString();
                if (Convert.ToString(dr["Fecha_Ingreso"]) != null)
                {
                    dtpFechaIng.Value = Convert.ToDateTime(dr["Fecha_Ingreso"]);
                }

                CargardgvDirMailTel();

            }


        }

        private void dataGridViewListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                btnReactivar.Visible = true;
            }
            else
            {
                btnReactivar.Visible = false;
            }

            button3.Enabled = true;
            button4.Enabled = true;
            

            try
            {
                textBoxCuit.Text = dataGridViewListar.Rows[e.RowIndex].Cells[0].Value.ToString();


                Consultas_Proveedores conPR = new Consultas_Proveedores();
                DataRow dr = conPR.CargarCampos(textBoxCuit.Text);

                if (dr["CUIT"] != null)
                {
                    textBoxRazonSo.Text = (dr["Razon_Social"]).ToString();
                    textBoxNomFan.Text = (dr["Nombre_Fantasia"]).ToString();
                    comboBoxIVA.Text = (dr["Condicion_IVA"]).ToString();
                   
                    tbRubro.Text = (dr["Rubro"]).ToString();

                    if (Convert.ToString(dr["Fecha_Ingreso"]) != "")
                    {
                        dtpFechaIng.Value = Convert.ToDateTime(dr["Fecha_Ingreso"]);
                    }
                }

                CargardgvDirMailTel();



            }

            catch 
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxCuit.Text == "" || textBoxRazonSo.Text == "" || comboBoxIVA.Text == "" )
            {
                ErroresCapos();
            }

            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea modificar";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_proveedores.ProveedoresR provedor = new Clases_proveedores.ProveedoresR();

                    provedor.CUIT = textBoxCuit.Text;
                    provedor.Razon_Social = textBoxRazonSo.Text;
                    provedor.Nombre_Fantacia = textBoxNomFan.Text;
                    provedor.Condicion_IVA = comboBoxIVA.SelectedItem.ToString();
                    provedor.Rubro = tbRubro.Text;
                    provedor.Fecha_Ingreso = dtpFechaIng.Value;

                    Consultas_Proveedores a = new Consultas_Proveedores();
                    a.ModificarProveedores(provedor);

                    

                    // cargar grilla 

                    CargarGrilla();



                    // cargar combo

                    CargarCombo();

                    //limpiar errores
                    Limpiar();

                    Borrarerror();


                }
            }
        }


        private void Limpiar()
        {

            textBoxRazonSo.Text = "";
            textBoxNomFan.Text = "";
            comboBoxIVA.Text = "";
            textBoxCP.Text = "";
          
           
            textBoxMail.Text = "";
            dtpFechaIng.Value=dtpFechaIng.MaxDate;
            textBoxCuit.Focus();
            textBoxNumero.Text = "";
            tbRubro.Text = "";
            textBoxDir.Text = "";
            textBoxTel.Text = "";
           
            cbProvincia.Text = "Seleccione";
            cbPais.SelectedIndex = 0;
            textBoxLocalidad.Clear();
            textBoxCP.Clear();
            tbBarrio.Clear();
            tbCodArea.Clear();
            tbDpto.Clear();
            tbPiso.Clear();
          
            cbProvincia.Enabled = false;



            errorProviderCuit.Clear();
            errorProviderRazon.Clear();
            errorProviderIVA.Clear();
            errorProviderMail.Clear();

            dgvDir.DataSource = null;
            dgvMail.DataSource = null;
            dgvTel.DataSource = null;

            IdDri = 0;
            IdMail = 0;
            IdTel = 0;


            btnReactivar.Visible = false;
            button3.Enabled = false;
            button4.Enabled = false;

            comboBoxIVA.SelectedIndex = 0;

            textBoxCuit.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textBoxCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

      

        //validar mail
        private Boolean email_bien_escrito(String email)
        {
            if (textBoxMail.Text != "")
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxCuit.Text == "" || textBoxRazonSo.Text == "" || comboBoxIVA.SelectedIndex==0  )
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Complete los campos obligatorios *";
                mjs.Show();
            }

            else
            {

                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea cargar nuevo proveedor";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {



                    if (EstaCargado() == false)
                    {
                        Consultas_Proveedores a = new Consultas_Proveedores();
                        a.CargarProveedor(textBoxCuit.Text, textBoxRazonSo.Text, textBoxNomFan.Text, comboBoxIVA.SelectedItem.ToString(), tbRubro.Text, dtpFechaIng.Value);

                        Clases_Saldos.Consultas_Saldos conSal = new Clases_Saldos.Consultas_Saldos();
                        Clases_Saldos.SaldosR sal = new Clases_Saldos.SaldosR();
                        sal.CUIT = textBoxCuit.Text;
                        sal.Saldo = 0;

                        conSal.CargarSaldo(sal);

                    }


                    CarDirTelMail();

                    //cargar grilla


                    CargarGrilla();


                    ///cargar combo

                    CargarCombo();

                    //limpiar errores
                    Limpiar();

                    Borrarerror();


                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
               
                Consultas_Proveedores a = new Consultas_Proveedores();
               

                a.BorrarProveedor(textBoxCuit.Text,DateTime.Now.ToString("yyyy-MM-dd"));
               

                // cargar grilla 

                CargarGrilla();

                // cargar combo

                CargarCombo();

                // limpiar errores 
                Limpiar();

                Borrarerror();

            }


        }


        private void ErroresCapos()
        {
            if (textBoxCuit.Text == "")
            {
                errorProviderCuit.SetError(textBoxCuit, "Coloque un numero de Cuit");
            }
            else
            {
                errorProviderCuit.Clear();
            }

            if (textBoxRazonSo.Text == "")
            {
                errorProviderRazon.SetError(textBoxRazonSo, "Ingrese nombre de razon social");
            }
            else
            {
                errorProviderRazon.Clear();

            }
            if (comboBoxIVA.Text == "")
            {
                errorProviderIVA.SetError(comboBoxIVA, "Selecione condicion de IVA");

            }
            else
            {
                errorProviderIVA.Clear();
            }
            if (email_bien_escrito(textBoxMail.Text) == false)
            {
                errorProviderMail.SetError(textBoxMail, "Email Incorrecto");
            }
            else
            {
                errorProviderMail.Clear();
            }

        }


        string Activo = "Si";

        private void CargarGrilla()
        {
            Consultas_Proveedores con = new Consultas_Proveedores();
            
            

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.Listar(Activo);

            dataGridViewListar.DataSource = null;
            dataGridViewListar.DataSource = dt;
            dataGridViewListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewListar.Columns[1].Width = 150;
            dataGridViewListar.Columns[2].Width = 150;
            dataGridViewListar.Columns[3].Width = 150;
            dataGridViewListar.Columns[4].Width = 150;
            dataGridViewListar.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarCombo()
        {
                   

            DataTable dt = new DataTable();
            Consultas_Proveedores cP = new Consultas_Proveedores();
            dt = cP.CargarCombo();
            comboBoxListar.DataSource = dt;
            comboBoxListar.DisplayMember = "prov";
            comboBoxListar.ValueMember = "CUIT";
            
            
        }

        private void Borrarerror()
        {

            errorProviderCuit.Clear();
            errorProviderRazon.Clear();
            errorProviderIVA.Clear();
            errorProviderMail.Clear();

        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboProvincia();
            cbProvincia.Enabled = true;
        }

        private void dgvDir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

               
                
          

               string ID = dgvDir.Rows[e.RowIndex].Cells[0].Value.ToString();

                IdDri = long.Parse(ID);

                Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                DataRow dr = conDir.CargarCampos(ID);




                if (Convert.ToString(dr["ID"]) != "")
                {
                    cbPais.Text = (dr["Pais"]).ToString();
                    cbProvincia.Text = (dr["Provincia"]).ToString();
                    textBoxLocalidad.Text = (dr["Localidad"]).ToString();
                    textBoxCP.Text = (dr["CP"]).ToString();
                    tbBarrio.Text = (dr["Barrio"]).ToString();
                    textBoxDir.Text = (dr["Calle"]).ToString();
                    textBoxNumero.Text = (dr["Altura"]).ToString();
                    tbPiso.Text = (dr["Piso"]).ToString();
                    tbDpto.Text = (dr["Dpto"]).ToString();

                  }






            }

            catch 
            {
             
            }
        }

        private void dgvTel_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string ID = dgvTel.Rows[e.RowIndex].Cells[0].Value.ToString();

               IdTel = long.Parse(ID);
              

                Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                DataRow dr = conTel.CargarCampos(ID);

                if (dr["Id"].ToString() != "")
                {
                    tbCodArea.Text = (dr["Codigo_de_area"]).ToString();
                    textBoxTel.Text = (dr["Telefono"]).ToString();
                 
                    

                }

               



            }

            catch 
            {
                
            }




        }

        private void dgvMail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                string ID = dgvMail.Rows[e.RowIndex].Cells[0].Value.ToString();
                IdMail = long.Parse(ID);

               

                Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                DataRow dr = conMail.CargarCampos(ID);

                if (Convert.ToString(dr["Id"]) != "")
                {
                    
                    textBoxMail.Text = (dr["Email"]).ToString();

                }





            }

            catch 
            {
                
            }


        }

        private void CargardgvDirMailTel()
        {

           
                Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();


                DataSet dsDir = new DataSet();
                DataTable dtDir = new DataTable();
                dtDir = conDir.ListarFiltro(textBoxCuit.Text);

                dgvDir.DataSource = null;
                dgvDir.DataSource = dtDir;
            dgvDir.Columns[0].Visible = false;
            dgvDir.Columns[1].Visible = false;
            dgvDir.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                       
            DataSet dsMail = new DataSet();
            DataTable dtMail = new DataTable();
            dtMail = conMail.ListarFiltro(textBoxCuit.Text);

            dgvMail.DataSource = null;
            dgvMail.DataSource = dtMail;
            dgvMail.Columns[0].Visible = false;
            dgvMail.Columns[1].Visible = false;
            dgvMail.Columns[2].Width = 200;

            Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();

                DataSet dsTel = new DataSet();
                DataTable dtTel = new DataTable();
                dtTel = conTel.ListarFiltro(textBoxCuit.Text);

                dgvTel.DataSource = null;
                dgvTel.DataSource = dtTel;
            dgvTel.Columns[0].Visible = false;
            dgvTel.Columns[1].Visible = false;
            dgvTel.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTel.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        }

        private void textBoxCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbCodArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void btnNuevoTelDirEm_Click(object sender, EventArgs e)
        {
            limpiarDirTelMail();

            cbProvincia.Enabled = false;

        }

        private void btnBorrarAT_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                if(IdDri!=0)
                {
                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    conDir.BorrarDireccionID(IdDri);
                }
                if(IdTel!=0)
                {
                    Clases_Telefonos.ConsutaTelefonos contel = new Clases_Telefonos.ConsutaTelefonos();
                    contel.BorrarTelefonoID(IdTel);
                }
                if(IdMail!=0)
                {
                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    conMail.BorrarMailID(IdMail);
                }

                // cargar grilla 

                CargardgvDirMailTel();

                // cargar combo

                CargarCombo();

                // limpiar errores 
                Limpiar();

                Borrarerror();


            }





            }

        private void btnModificarID_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea modificar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                if (IdDri != 0)
                {
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Dir.ID = IdDri;
                    Dir.DNI_CUIT = textBoxCuit.Text;
                    Dir.Pais = cbPais.Text;
                    Dir.Provincia = cbProvincia.Text;
                    Dir.Localidad = textBoxLocalidad.Text;
                    Dir.CP = textBoxCP.Text;
                    Dir.Barrio = tbBarrio.Text;
                    Dir.Calle = textBoxDir.Text;
                    Dir.Altura = textBoxNumero.Text;
                    Dir.Piso = tbPiso.Text;
                    Dir.Dpto = tbDpto.Text;


                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    conDir.ModificarDireccion(Dir);
                }

                if (IdTel != 0)
                {
                    Clases_Telefonos.TelefonosR Tel = new Clases_Telefonos.TelefonosR();

                    Tel.Id = IdTel;
                    Tel.DNI_CUIT = textBoxCuit.Text;
                    Tel.Codigo_de_area = tbCodArea.Text;
                    Tel.Telefono = textBoxTel.Text;

                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    conTel.ModificarTelefono(Tel);
                }

                if (IdMail != 0)
                {
                    Clases_Emails.EmailR Mail = new Clases_Emails.EmailR();

                    Mail.Id = IdMail;
                    Mail.DNI_CUIT = textBoxCuit.Text;
                    Mail.Email = textBoxMail.Text;

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    conMail.ModificarMail(Mail);

                }



                // cargar grilla 

                
                CargardgvDirMailTel();

                // cargar combo

                CargarCombo();

                //limpiar errores
                limpiarDirTelMail();

                Borrarerror();

            }


         


        }

        private Boolean EstaCargado()
        {
            Consultas_Proveedores conProv = new Consultas_Proveedores();

            Boolean YaCargado = false;

            foreach(DataRow col in conProv.Listar(Activo).Rows)
            {
                if(col["CUIT"].ToString()==textBoxCuit.Text)
                {
                    YaCargado = true;
                }


            }

            return YaCargado;


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
            if(checkBox1.Checked==true)
            {
                Activo = "No";
            }
            else if (checkBox1.Checked==false)
            {
                Activo = "Si";
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea Restableser Proveedor";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                Consultas_Proveedores a = new Consultas_Proveedores();


                a.ReactivarProveedor(textBoxCuit.Text, "NULL");


                // cargar grilla 

                CargarGrilla();

                // cargar combo

                CargarCombo();

                // limpiar errores 
                Limpiar();

                Borrarerror();

            }
        }

        private void textBoxCuit_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas_Proveedores conPro = new Consultas_Proveedores();
            DataTable dt = new DataTable();
            dt = conPro.ListarporCuit(Activo,textBoxCuit.Text);

            dataGridViewListar.DataSource = null;
            dataGridViewListar.DataSource = dt;


        }

        private void textBoxRazonSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Consultas_Proveedores conPro = new Consultas_Proveedores();
            DataTable dt = new DataTable();
            dt = conPro.ListarporRazon(Activo, textBoxRazonSo.Text);

            dataGridViewListar.DataSource = null;
            dataGridViewListar.DataSource = dt;
        }

        private void textBoxNomFan_KeyPress(object sender, KeyPressEventArgs e)
        {
            Consultas_Proveedores conPro = new Consultas_Proveedores();
            DataTable dt = new DataTable();
            dt = conPro.ListarporFantasia(Activo, textBoxNomFan.Text);

            dataGridViewListar.DataSource = null;
            dataGridViewListar.DataSource = dt;
        }

        private void CarDirTelMail()
        {
            
                if (textBoxDir.Text != "" || tbBarrio.Text != "" || cbPais.Text != " Seleccione" || cbProvincia.Text != "Seleccione" || textBoxNumero.Text != "")
                {

                if (IdDri == 0)
                {
                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Dir.DNI_CUIT = textBoxCuit.Text;
                    Dir.Pais = cbPais.Text;
                    Dir.Provincia = cbProvincia.Text;
                    Dir.Localidad = textBoxLocalidad.Text;
                    Dir.CP = textBoxCP.Text;
                    Dir.Barrio = tbBarrio.Text;
                    Dir.Calle = textBoxDir.Text;
                    Dir.Altura = textBoxNumero.Text;
                    Dir.Piso = tbPiso.Text;
                    Dir.Dpto = tbDpto.Text;

                    conDir.CargarDireccion(Dir);

                }
                else
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "La direccion esta ya esta registrado para este proveedor";
                }
            }
           

           
                if (tbCodArea.Text != "" || textBoxTel.Text != "")
                {
                if (IdTel == 0)

                {

                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    Clases_Telefonos.TelefonosR Tel = new Clases_Telefonos.TelefonosR();

                    Tel.DNI_CUIT = textBoxCuit.Text;
                    Tel.Codigo_de_area = tbCodArea.Text;
                    Tel.Telefono = textBoxTel.Text;

                    conTel.CargarTelefono(Tel);

                }
                else
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "El telefono este ya esta registrado para este proveedor";
                }
            }



            if (textBoxMail.Text != "" && email_bien_escrito(textBoxMail.Text) == true)
            {
                if (IdMail == 0)
                {

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    Clases_Emails.EmailR Mail = new Clases_Emails.EmailR();

                    Mail.DNI_CUIT = textBoxCuit.Text;
                    Mail.Email = textBoxMail.Text;


                    conMail.CargarEmail(Mail);
                }
                else
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "El Email este ya esta registrado para este proveedor";
                }
            }
            else
            {
                if (email_bien_escrito(textBoxMail.Text) == false)
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "El Email esta mal escrito";
                }
            }
          
        }

        private void limpiarDirTelMail()
        {
            textBoxNumero.Text = "";
      
            textBoxDir.Text = "";
            textBoxTel.Text = "";
            textBoxCP.Text = "";


            textBoxMail.Text = "";
            cbProvincia.Text = "Seleccione";
            cbPais.SelectedIndex = 0;
            textBoxLocalidad.Clear();
            textBoxCP.Clear();
            tbBarrio.Clear();
            tbCodArea.Clear();
            tbDpto.Clear();
            tbPiso.Clear();

            IdMail = 0;
            IdDri = 0;
            IdTel = 0;
        }


    }
}
