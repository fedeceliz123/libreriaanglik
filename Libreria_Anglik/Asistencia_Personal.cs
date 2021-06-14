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
    public partial class Asistencia_Personal : Form
    {
        public Asistencia_Personal()
        {
            InitializeComponent();
        }

        private void checkBoxIngreso_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSalida.Checked = false;
            gbIngreso.Enabled = true;
            gbSalida.Enabled = false;
        }

        private void checkBoxSalida_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxIngreso.Checked = false;
            gbIngreso.Enabled = false;
            gbSalida.Enabled = true;
        }

        private void Asistencia_Personal_Load(object sender, EventArgs e)
        {
            CargarCombo();

            dtpHoraEn.Value = DateTime.Now;
            dtpHoraSal.Value = DateTime.Now;
            dtpIngreso.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now;


        }

        private void CargarCombo()
        {

            DataTable dt = new DataTable();
            Clases_Empleados.ConsultasEmpledos cE = new Clases_Empleados.ConsultasEmpledos();
            dt = cE.CargarCombo();
            cbDniIng.DataSource = dt;
            cbDniIng.DisplayMember = "Empl";
            cbDniIng.ValueMember = "DNI";

            cbDniSal.DataSource = dt;
            cbDniSal.DisplayMember = "Empl";
            cbDniSal.ValueMember = "DNI";
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea Cargar producto";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
                Clases_Asistencia.AsistenciasR asist = new Clases_Asistencia.AsistenciasR();
                Clases_Asistencia.ConsultasAsistencia conAS = new Clases_Asistencia.ConsultasAsistencia();
                if (gbIngreso.Enabled == true)
                {

                     dtpHoraEn.Value.ToString("HH:mm:ss");

                    asist.DNI_Empledo = cbDniIng.SelectedValue.ToString();
                    asist.Fecha = dtpIngreso.Value;
                    asist.Hora_Ingreso = dtpHoraEn.Value.ToString("HH:mm:ss"); ;

                    conAS.CargarIngreso(asist);

                }
                else if (gbSalida.Enabled == true)
                {
                    


                    asist.Hora_salida = dtpHoraSal.Value.ToString("HH:mm:ss");

                    DateTime Ing = conAS.reHoraIng(cbDniSal.SelectedValue.ToString(), dtpSalida.Value);
                    DateTime sal = dtpHoraSal.Value;
                     
                    double resultado =Math.Round(sal.Subtract(Ing).TotalHours,2);



                    asist.Hora_total = resultado;

                    conAS.Cargarsalida(asist, cbDniSal.SelectedValue.ToString(), dtpSalida.Value);

                }
            }

        }
    }
}
