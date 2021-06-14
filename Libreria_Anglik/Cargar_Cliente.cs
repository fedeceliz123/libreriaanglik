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
using System.Text.RegularExpressions;




namespace Libreria_Anglik
{
    public partial class Cargar_Cliente : Form
    {


        long IdDir,IdTel,IdMail;

        public Cargar_Cliente()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

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



   


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (textBoxNombre.Text==""|| textBoxApellido.Text==""||textBoxDNI.Text==""||comboBoxSexo.SelectedIndex==0||Calcularedad()<16)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Debe completar los campos obligatorios* y ser mayor de 16 años";
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea registrase";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {

                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    Clases_Emails.EmailR mail = new Clases_Emails.EmailR();

                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    Clases_Telefonos.TelefonosR Tel = new Clases_Telefonos.TelefonosR();

                    Clases_Clientes.ConsultasClientes conCliente = new Clases_Clientes.ConsultasClientes();
                    Clases_Clientes.ClientesR Cliente = new Clases_Clientes.ClientesR();

                      Cliente.Dni = textBoxDNI.Text;
                        Cliente.Nombre = textBoxNombre.Text;
                        Cliente.Apellido = textBoxApellido.Text;
                        Cliente.Fecha_Nacimiento = dtpFechaNac.Value;
                        Cliente.Sexo = comboBoxSexo.Text;
                        Cliente.Ocupacion = textBoxOcupacion.Text;
                        Cliente.Fecha_de_ingreso = DateTime.Now.ToString("yyyy-MM-dd");
                        if (cbIVA.SelectedIndex != 0)
                        {
                            Cliente.IVA = cbIVA.SelectedItem.ToString();
                        }
                        else
                        {
                            Cliente.IVA = "";
                        }


                        if (EstaCargado() == false)
                        {

                            conCliente.CargaCliene(Cliente);
                            CargarGrilla();
                        }




                   

                    if (textBoxLocalidad.Text != "" && textBoxDir.Text != "" && textBoxNumero.Text != "" && EstaCargado() == true && cbPais.SelectedIndex != 0)
                    {
                        Dir.DNI_CUIT = textBoxDNI.Text;
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
                    //else
                    //{
                    //  MensajeOk a = new MensajeOk();
                    //  a.Show();
                    //  a.lblMensaje.Text = "Complete los campos de direciones";
                    //}

                    if (textBoxMail.Text != "" && email_bien_escrito(textBoxMail.Text) == true && EstaCargado() == true)
                    {
                        mail.DNI_CUIT = textBoxDNI.Text;
                        mail.Email = textBoxMail.Text;

                        conMail.CargarEmail(mail);
                    }
                    //else
                    //{
                    //  MensajeOk a = new MensajeOk();
                    //  a.Show();
                    //  a.lblMensaje.Text = "Escriba el email correctamente";
                    //}

                    if (tbCodArea.Text != "" && textBoxTel.Text != "" && EstaCargado() == true)
                    {
                        Tel.DNI_CUIT = textBoxDNI.Text;
                        Tel.Codigo_de_area = tbCodArea.Text;
                        Tel.Telefono = textBoxTel.Text;

                        conTel.CargarTelefono(Tel);
                    }
                    //else
                    //{
                    //  MensajeOk a = new MensajeOk();
                    //  a.Show();
                    //  a.lblMensaje.Text = "Complete los campo de codigo de area y telefono";
                    //}


                    Limpiar();
                }

            }

        }

        //validar mail
        private Boolean email_bien_escrito(String email)
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

        private void Limpiar()
        {
            textBoxApellido.Clear();
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxDir.Clear();
           
            textBoxMail.Clear();
           
            textBoxTel.Clear();
           
            comboBoxSexo.SelectedIndex = 0;
            textBoxNumero.Clear();
            textBoxOcupacion.Clear();
            textBoxDNI.Focus();
            cbProvincia.Text = "Seleccione";
            cbPais.SelectedIndex = 0;
            textBoxLocalidad.Clear();
            textBoxCP.Clear();
            tbBarrio.Clear();
            tbCodArea.Clear();
            tbDpto.Clear();
            tbPiso.Clear();
            dtpFechaNac.Value = DateTime.Now;
            cbProvincia.Enabled = false;


            dgvDir.DataSource = null;
            dgvTel.DataSource = null;
            dgvMail.DataSource = null;

            button2.Enabled = false;
            button3.Enabled = false;

            cbIVA.SelectedIndex = 0;


        }

      

        private void Cargar_Cliente_Load(object sender, EventArgs e)
        {
            CargarComboPais();

            cbPais.SelectedIndex = 0;

            Limpiar();

            cbProvincia.Enabled = false;
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarComboProvincia();
            cbProvincia.Enabled = true;


        }

        private double Calcularedad()
        {
            TimeSpan Edad = DateTime.Now - dtpFechaNac.Value ;
            double años = Edad.Days / 365.25;

            return años;

        }


        string Activo = "Si";
        private void button1_Click(object sender, EventArgs e)
        {
            btnReactivar.Visible = false;


            CargarGrilla();
            Limpiar();


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


        private void CargarGrilla()
        {

            Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

            DataTable dt = new DataTable();

            dt = conCli.ListarClientes(Activo);


            dtvClientes.DataSource = null;
            dtvClientes.DataSource = dt;
            dtvClientes.Visible = true;
            dtvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvClientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

                conCli.BorrarCliente(textBoxDNI.Text);
            
            
            
            }

            CargarGrilla();


            Limpiar();


         }

        private void dgvDir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdDir = long.Parse(dgvDir.Rows[e.RowIndex].Cells[0].Value.ToString());

                Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                DataRow dr = conDir.CargarCampos(IdDir.ToString());




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
                IdTel= long.Parse(dgvTel.Rows[e.RowIndex].Cells[0].Value.ToString());

                Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                DataRow dr = conTel.CargarCampos(IdTel.ToString());

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
                IdMail= long.Parse(dgvMail.Rows[e.RowIndex].Cells[0].Value.ToString());

                Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                DataRow dr = conMail.CargarCampos(IdMail.ToString());

                if (Convert.ToString(dr["Id"]) != "")
                {

                    textBoxMail.Text = (dr["Email"]).ToString();

                }
            }
            catch
            {

            }
        }

        private void dtvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
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

                textBoxDNI.Text = dtvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();

                Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();


                DataRow dr = conCli.CargarCampos(textBoxDNI.Text);

                if (dr["Dni"] != null)
                {
                    textBoxNombre.Text = (dr["Nombre"]).ToString();
                    textBoxApellido.Text = (dr["Apellido"]).ToString();
                    comboBoxSexo.Text = (dr["Sexo"]).ToString();
                    
                    cbIVA.Text = (dr["IVA"].ToString());

                    textBoxOcupacion.Text = (dr["Ocupacion"]).ToString();

                    if (Convert.ToString(dr["Fecha_Nacimiento"]) != "")
                    {
                        dtpFechaNac.Value = Convert.ToDateTime(dr["Fecha_Nacimiento"]);
                    }
                    
                }

                CargarDirTelMail();

                button2.Enabled = true;
                button3.Enabled = true;

            }
            catch
            { }

        }

        private void btnNuevoTelDirEm_Click(object sender, EventArgs e)
        {
            limpiarDirTelMail();
        }

        private void btnBorrarAT_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                if (IdDir != 0)
                {
                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    conDir.BorrarDireccionID(IdDir);
                }
                if (IdTel != 0)
                {
                    Clases_Telefonos.ConsutaTelefonos contel = new Clases_Telefonos.ConsutaTelefonos();
                    contel.BorrarTelefonoID(IdTel);
                }
                if (IdMail != 0)
                {
                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    conMail.BorrarMailID(IdMail);
                }

                // cargar grilla 

                CargarDirTelMail();

                // cargar combo

               

                // limpiar errores 
                Limpiar();

                


            }
        }

        private void btnModificarID_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea modificar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                if (IdDir != 0)
                {
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Dir.ID = IdDir;
                    Dir.DNI_CUIT = textBoxDNI.Text;
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
                    Tel.DNI_CUIT = textBoxDNI.Text;
                    Tel.Codigo_de_area = tbCodArea.Text;
                    Tel.Telefono = textBoxTel.Text;

                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    conTel.ModificarTelefono(Tel);
                }

                if (IdMail != 0)
                {
                    Clases_Emails.EmailR Mail = new Clases_Emails.EmailR();

                    Mail.Id = IdMail;
                    Mail.DNI_CUIT = textBoxDNI.Text;
                    Mail.Email = textBoxMail.Text;

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    conMail.ModificarMail(Mail);

                }



                // cargar grilla 


                CargarDirTelMail();

                // cargar combo

               

                //limpiar errores
                limpiarDirTelMail();

                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea modificar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Clientes.ClientesR Cli = new Clases_Clientes.ClientesR();

                Cli.Dni = textBoxDNI.Text;
                Cli.Nombre = textBoxNombre.Text;
                Cli.Apellido = textBoxApellido.Text;
                Cli.Fecha_Nacimiento = dtpFechaNac.Value;
                Cli.Sexo = comboBoxSexo.SelectedItem.ToString();
                Cli.Ocupacion = textBoxOcupacion.Text;

                Cli.IVA = cbIVA.Text;
                
                
                    
                

                Clases_Clientes.ConsultasClientes conCLi = new Clases_Clientes.ConsultasClientes();

                conCLi.ModificarCliente(Cli);

                CargarGrilla();

                Limpiar();

            
            
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {

            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea reactivar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

                conCli.ReactivarCliente(textBoxDNI.Text);

                btnReactivar.Visible = false;
            }

            CargarGrilla();

            Limpiar();


        }

        private void CargarDirTelMail()
        {
           //// direcciones
            
            Clases_Direcciones.ConsultasDirecciones conCli = new Clases_Direcciones.ConsultasDirecciones();

            DataTable dt = new DataTable();

            dt = conCli.ListarFiltro(textBoxDNI.Text);

            dgvDir.DataSource = null;
            dgvDir.DataSource = dt;

            dgvDir.Columns[0].Visible = false;
            dgvDir.Columns[1].Visible = false;
            dgvDir.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            ///  telefonos 

            Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();

            DataTable dtT = new DataTable();

            dtT = conTel.ListarFiltro(textBoxDNI.Text);

            dgvTel.DataSource = null;
            dgvTel.DataSource = dtT;

            dgvTel.Columns[0].Visible = false;
            dgvTel.Columns[1].Visible = false;
            dgvTel.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTel.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTel.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            // mail

            Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();


            DataTable dtM = new DataTable();

            dtM = conMail.ListarFiltro(textBoxDNI.Text);

            dgvMail.DataSource = null;
            dgvMail.DataSource = dtM;

            dgvMail.Columns[0].Visible = false;
            dgvMail.Columns[1].Visible = false;
            dgvMail.Columns[2].Width = 200;
            dgvMail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
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

        private void textBoxDNI_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

            DataTable dt = new DataTable();

            dt = conCli.ListarClientesporDni(Activo,textBoxDNI.Text);


            dtvClientes.DataSource = null;
            dtvClientes.DataSource = dt;
            dtvClientes.Visible = true;
            dtvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvClientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void textBoxNombre_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

            DataTable dt = new DataTable();

            dt = conCli.ListarClientesporNombre(Activo, textBoxNombre.Text);


            dtvClientes.DataSource = null;
            dtvClientes.DataSource = dt;
            dtvClientes.Visible = true;
            dtvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvClientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void textBoxApellido_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

            DataTable dt = new DataTable();

            dt = conCli.ListarClientesporApellido(Activo, textBoxApellido.Text);


            dtvClientes.DataSource = null;
            dtvClientes.DataSource = dt;
            dtvClientes.Visible = true;
            dtvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvClientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            IdDir = 0;
            IdTel = 0;
        }


        private Boolean EstaCargado()
        {
            Clases_Clientes.ConsultasClientes conCli = new Clases_Clientes.ConsultasClientes();

            Boolean YaCargado = false;

            foreach (DataRow col in conCli.ListarClientes(Activo).Rows)
            {
                if (col["Dni"].ToString() == textBoxDNI.Text)
                {
                    YaCargado = true;
                }


            }

            return YaCargado;


        }

      


        
    }
}
