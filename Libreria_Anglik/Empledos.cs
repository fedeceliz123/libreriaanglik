using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//validar mail
using System.Text.RegularExpressions;


namespace Libreria_Anglik
{
    public partial class Empledos : Form
    {
        public Empledos()
        {
            InitializeComponent();
        }


        long IdTel, IdDri, IdMail=0;


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




        private void btnListar_Click(object sender, EventArgs e)
        {
            gbEmpleados.Visible = true;
            CargarGrilla();

            btnReactivar.Visible = false;
        }

        private void Empledos_Load(object sender, EventArgs e)
        {
            CargarComboPais();

            Limpiar();
            CargarCombo();

            tbDNI.Focus();


            dtpFechaIng.MaxDate = DateTime.Now;
         
        }

        private void CargarCombo()
        {

            DataTable dt = new DataTable();
            Clases_Empleados.ConsultasEmpledos cE = new Clases_Empleados.ConsultasEmpledos();
            dt = cE.CargarCombo();
            cbListaEmpl.DataSource = dt;
            cbListaEmpl.DisplayMember = "Empl";
            cbListaEmpl.ValueMember = "DNI";
        }

        private void Limpiar()
        {
            tbDNI.Clear();
            tbNombre.Clear();
            tbApellido.Clear();
            dtpFechaNac.Value = DateTime.Now;
            cbSexo.SelectedIndex = 0;
            cbProvincia.Text="Seleccione";
           textBoxLocalidad.Clear();
            tbBarrio.Clear();
            tbCodArea.Clear();
            tbDpto.Clear();
            tbPiso.Clear();
            textBoxCP.Clear();
            textBoxDir.Clear();
            textBoxNumero.Clear();
            textBoxTel.Clear();
            cbPais.SelectedIndex = 0;
            cbPuesto.SelectedIndex = 0;
            tbMail.Clear();

            // errorprivide

            epApellido.Clear();
            epDNI.Clear();
            epMail.Clear();
            epNombre.Clear();
            epPuesto.Clear();

        }

        private void cbListaEmpl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbDNI.Text = cbListaEmpl.SelectedValue.ToString();
            Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();

            DataRow dr = con.CargarCampos(tbDNI.Text);

            if (dr["DNI"] != null)
            {
                tbNombre.Text = (dr["Nombre"]).ToString();
                tbApellido.Text = (dr["Apellido"]).ToString();
                cbSexo.SelectedItem = (dr["Sexo"]).ToString();

                if ((dr["Fecha_Nacimeinto"].ToString()) != "")
                {
                    dtpFechaNac.Value = Convert.ToDateTime(dr["Fecha_Nacimeinto"]);
                }
                
                cbPuesto.SelectedItem = (dr["Puesto"]).ToString();
               
                if ((dr["Fecha_Ingreso"]).ToString() != "")
                {
                    dtpFechaIng.Value = Convert.ToDateTime(dr["Fecha_Ingreso"]);
                }

                CargardgvDirMailTel();
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void ErrorCampoVacio()
        {
            if(tbDNI.Text=="")
            {
                epDNI.SetError(tbDNI, "Ingrese DNI");
            }
            else
            {
                epDNI.Clear();
            }
            if (tbNombre.Text == "")
            {
                epNombre.SetError(tbNombre, "Ingrese Nombre");
            }
            else
            {
                epNombre.Clear();
            }
            if (tbApellido.Text == "")
            {
                epApellido.SetError(tbApellido, "Ingrese Ingrese Apellido");
            }
            else
            {
                epApellido.Clear();
            }
            if (cbPuesto.SelectedIndex == 0)
            {
                epPuesto.SetError(cbPuesto, "Ingrese Puesto");
            }
            else
            {
                epPuesto.Clear();
            }
            if(Calcularedad()<16)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "No se puede registrar menores de 16 años";
            }

            //if (tbMail.Text == "" || email_bien_escrito(tbMail.Text)==false)
            //{
            //    epMail.SetError(tbMail, "Ingrese Mail");
            //}
            //else
            //{
            //    epDNI.Clear();
            //}


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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbApellido.Text == "" || cbPuesto.SelectedIndex == 0 || Calcularedad()<16 )
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Complete los compos obligatorios *, y debe ser mayor de 16 años";
                mjs.Show();
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea cargar nuevo Empleado";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    if (EstaCargado() == false)
                    {
                        Clases_Empleados.ConsultasEmpledos a = new Clases_Empleados.ConsultasEmpledos();
                        a.CargarEmpleado(tbDNI.Text, tbNombre.Text, tbApellido.Text, cbSexo.SelectedItem.ToString(), dtpFechaNac.Value, cbPuesto.SelectedItem.ToString(), dtpFechaIng.Value);
                    }

                    CarDirTelMail();

                    CargarCombo();
                    CargarGrilla();
                    Limpiar();


                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tbDNI.Text == "" || tbNombre.Text == "" || tbApellido.Text == "" || cbPuesto.SelectedIndex == 0 )
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Seleccione un empleado para modificar";
                mjs.Show();
            }
            else
            {

                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea modificar";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_Empleados.EmpleadosR em = new Clases_Empleados.EmpleadosR();
                    Clases_Empleados.ConsultasEmpledos consulta = new Clases_Empleados.ConsultasEmpledos();

                    em.DNI = tbDNI.Text;

                    em.Nombre = tbNombre.Text;

                    em.Apellido = tbApellido.Text;

                    em.Sexo = cbSexo.SelectedItem.ToString();

                    em.Fecha_Nacimiento = dtpFechaNac.Value;

                    em.Puesto = cbPuesto.SelectedItem.ToString();
                 
                    em.Fecha_Ingreso = dtpFechaIng.Value;

                    consulta.ModificarEmpledos(em);

                    CargarGrilla();

                    CargarCombo();

                    Limpiar();

                }


            }
        }


        private void CargarGrilla()
        {
            Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.Listar(Activo);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }



        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbAltura1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbTel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

       

        private void dgvListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(checkBox1.Checked==true)
            {
                btnReactivar.Visible = true;
            }
            else if (checkBox1.Checked==false)
            {
                btnReactivar.Visible = false;
            }



            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;


            try
            {

                tbDNI.Text = dgvListar.Rows[e.RowIndex].Cells[0].Value.ToString();

                Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();

                DataRow dr = con.CargarCampos(tbDNI.Text);

                if (dr["DNI"] != null)
                {
                    tbNombre.Text = (dr["Nombre"]).ToString();
                    tbApellido.Text = (dr["Apellido"]).ToString();
                    cbSexo.SelectedItem = (dr["Sexo"]).ToString();

                    if ((dr["Fecha_Nacimeinto"].ToString()) != "")
                    {
                        dtpFechaNac.Value = Convert.ToDateTime(dr["Fecha_Nacimeinto"]);
                    }
                 
                    cbPuesto.SelectedItem = (dr["Puesto"]).ToString();
                    
                    if ((dr["Fecha_Ingreso"]).ToString() != "")
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


        string Activo = "Si";

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea borrar";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                Clases_Empleados.ConsultasEmpledos a = new Clases_Empleados.ConsultasEmpledos();


                a.BorrarEmpledo(tbDNI.Text,DateTime.Now.ToString("yyyy-MM-dd"));

                // cargar grilla 

                CargarGrilla();

                // cargar combo

                CargarCombo();

                // limpiar errores 
                Limpiar();

              

            }
        }

        private Boolean EstaCargado()
        {
            Clases_Empleados.ConsultasEmpledos conEmp = new Clases_Empleados.ConsultasEmpledos();

            Boolean YaCargado = false;

            foreach (DataRow col in conEmp.Listar(Activo).Rows)
            {
                if (col["DNI"].ToString() == tbDNI.Text)
                {
                    YaCargado = true;
                }


            }

            return YaCargado;


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

                    tbMail.Text = (dr["Email"]).ToString();

                }

            }


            catch 
            {
              
            }

        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboProvincia();
            cbProvincia.Enabled = true;
        }

        int cont = 0;

        private void CarDirTelMail()
        {
          
            if (textBoxDir.Text != "" || tbBarrio.Text != "" || cbPais.Text != " Seleccione" || cbProvincia.Text != "Seleccione" || textBoxNumero.Text != "")
             {

                if (IdDri == 0)
                {
                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Dir.DNI_CUIT = tbDNI.Text;
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
                    a.lblMensaje.Text = "La direccion esta ya esta registrado para este empleado";
                }

            }
           

            
        if (tbCodArea.Text != "" || textBoxTel.Text != "")
          {

                if (IdTel == 0)

                {
                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    Clases_Telefonos.TelefonosR Tel = new Clases_Telefonos.TelefonosR();

                    Tel.DNI_CUIT = tbDNI.Text;
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



            if (tbMail.Text != "" && email_bien_escrito(tbMail.Text) == true)
            {

                if (IdMail == 0)
                {

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    Clases_Emails.EmailR Mail = new Clases_Emails.EmailR();

                    Mail.DNI_CUIT = tbDNI.Text;
                    Mail.Email = tbMail.Text;


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
                if (email_bien_escrito(tbMail.Text) == false)
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "El Email esta mal escrito";
                }

            }

            
           

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

                if (IdDri != 0)
                {
                    Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                    conDir.BorrarDireccionID(IdDri);
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

                CargardgvDirMailTel();

                // cargar combo

                CargarCombo();

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
                if (IdDri != 0)
                {
                    Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                    Dir.ID = IdDri;
                    Dir.DNI_CUIT = tbDNI.Text;
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
                    Tel.DNI_CUIT = tbDNI.Text;
                    Tel.Codigo_de_area = tbCodArea.Text;
                    Tel.Telefono = textBoxTel.Text;

                    Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                    conTel.ModificarTelefono(Tel);
                }

                if (IdMail != 0)
                {
                    Clases_Emails.EmailR Mail = new Clases_Emails.EmailR();

                    Mail.Id = IdMail;
                    Mail.DNI_CUIT = tbDNI.Text;
                    Mail.Email = tbMail.Text;

                    Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                    conMail.ModificarMail(Mail);

                }



                // cargar grilla 

           

                CargardgvDirMailTel();

                // cargar combo

                CargarCombo();

                //limpiar errores
                limpiarDirTelMail();

             

            }

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

        private void CargardgvDirMailTel()
        {


            Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();


            DataSet dsDir = new DataSet();
            DataTable dtDir = new DataTable();
            dtDir = conDir.ListarFiltro(tbDNI.Text);

            dgvDir.DataSource = null;
            dgvDir.DataSource = dtDir;
            dgvDir.Columns[0].Visible = false;
            dgvDir.Columns[1].Visible = false;
            dgvDir.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDir.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


            Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();

            DataSet dsMail = new DataSet();
            DataTable dtMail = new DataTable();
            dtMail = conMail.ListarFiltro(tbDNI.Text);

            dgvMail.DataSource = null;
            dgvMail.DataSource = dtMail;
            dgvMail.Columns[0].Visible = false;
            dgvMail.Columns[1].Visible = false;
            dgvMail.Columns[2].Width = 200;
            dgvMail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();

            DataSet dsTel = new DataSet();
            DataTable dtTel = new DataTable();
            dtTel = conTel.ListarFiltro(tbDNI.Text);

            dgvTel.DataSource = null;
            dgvTel.DataSource = dtTel;
            dgvTel.Columns[0].Visible = false;
            dgvTel.Columns[1].Visible = false;
            dgvTel.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTel.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTel.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

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
            mensaje.lblMensaje.Text = "Seguro que desea restableser empleado";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {

                Clases_Empleados.ConsultasEmpledos a = new Clases_Empleados.ConsultasEmpledos();


                a.RestableserEmpleado(tbDNI.Text);

                // cargar grilla 

                CargarGrilla();

                // cargar combo

                CargarCombo();

                // limpiar errores 
                Limpiar();

                btnReactivar.Visible = false;


            }
        }

        private void tbDNI_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporDni(Activo,tbDNI.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }

        private void tbNombre_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporNombre(Activo, tbNombre.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void tbApellido_KeyUp(object sender, KeyEventArgs e)
        {
            Clases_Empleados.ConsultasEmpledos con = new Clases_Empleados.ConsultasEmpledos();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = con.ListarporApellido(Activo, tbApellido.Text);

            dgvListar.DataSource = null;
            dgvListar.DataSource = dt;
            dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvListar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void limpiarDirTelMail()
        {
            textBoxNumero.Text = "";
           
            textBoxDir.Text = "";
            textBoxTel.Text = "";
            textBoxCP.Text = "";


            tbMail.Text = "";
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

            btnReactivar.Visible = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;


        }


        private double Calcularedad()
        {
            TimeSpan Edad = DateTime.Now - dtpFechaNac.Value;
            double años = Edad.Days / 365.25;

            return años;

        }

    }
}
