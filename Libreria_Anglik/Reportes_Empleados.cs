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
    public partial class Reportes_Empleados : Form
    {
        public Reportes_Empleados()
        {
            InitializeComponent();
        }

        private void Reportes_Empleados_Load(object sender, EventArgs e)
        {
            CargarCombo();

            dtpfecha.Value = DateTime.Now;
        }

        private void CargarCombo()
        {

            DataTable dt = new DataTable();
            Clases_Empleados.ConsultasEmpledos cE = new Clases_Empleados.ConsultasEmpledos();
            dt = cE.CargarCombo();
            cbEmpleado.DataSource = dt;
           cbEmpleado.DisplayMember = "Empl";
            cbEmpleado.ValueMember = "DNI";
        }

        private void btnVentadia_Click(object sender, EventArgs e)
        {
            Clases_Asistencia.ConsultasAsistencia conAsi = new Clases_Asistencia.ConsultasAsistencia();

            string fecha = dtpfecha.Value.ToString("yyyy-MM");

            dgvLisarAsistencia.DataSource = null;
            dgvLisarAsistencia.DataSource = conAsi.ListaFitrada(cbEmpleado.SelectedValue.ToString(),fecha);
            dgvLisarAsistencia.Columns[0].Width = 150;
            dgvLisarAsistencia.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLisarAsistencia.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLisarAsistencia.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLisarAsistencia.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblDias.Text = conAsi.DiasTrabajados(cbEmpleado.SelectedValue.ToString(), fecha);
            lblHoras.Text = conAsi.HorasTrabajadas(cbEmpleado.SelectedValue.ToString(), fecha);

            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            dgvVenta.DataSource = null;
            dgvVenta.DataSource = conVen.ventasEmpleado(cbEmpleado.SelectedValue.ToString(),fecha);
            dgvVenta.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[1].Visible = false;
            dgvVenta.Columns[3].Visible = false;
            dgvVenta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVenta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            lblVenM.Text = conVen.CantVentasEmpleado(cbEmpleado.SelectedValue.ToString(), fecha);
            lblToV.Text = conVen.totalVentasEmpleado(cbEmpleado.SelectedValue.ToString(), fecha);


        }
    }
}
