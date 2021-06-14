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
    public partial class Reportes_Compras : Form
    {
        public Reportes_Compras()
        {
            InitializeComponent();
        }

        private void Reportes_Compras_Load(object sender, EventArgs e)
        {
            CargarCombo();
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

        private void comboBoxListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clases_Saldos.Consultas_Saldos consaldo = new Clases_Saldos.Consultas_Saldos();

            float saldo = consaldo.SaldoActual(comboBoxListar.SelectedValue.ToString());


            lblSaldo.Text = saldo.ToString();

            CargarGrilla();

            

        }

        private void CargarGrilla()
        {
            Clases_Compras.ConsultasCompras conco = new Clases_Compras.ConsultasCompras();
            Clases_Pagos.Cosultas_Pagos conpag = new Clases_Pagos.Cosultas_Pagos();


            
            DataTable dt = new DataTable();
            dt = conco.ListarDetCompra(comboBoxListar.SelectedValue.ToString());

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = dt;
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataTable dt2 = new DataTable();
            dt2 = conco.ListarCompra(comboBoxListar.SelectedValue.ToString());

            dgvCompra.DataSource = null;
            dgvCompra.DataSource = dt2;
            dgvCompra.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompra.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompra.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataTable dt3 = new DataTable();
            dt3 = conpag.ListarPagos(comboBoxListar.SelectedValue.ToString());

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = dt3;
            dgvPagos.Columns[0].Visible = false;



        }

        private void dgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                long nCompra= long.Parse(dgvCompra.Rows[e.RowIndex].Cells[0].Value.ToString());

                Clases_Compras.ConsultasCompras concom = new Clases_Compras.ConsultasCompras();

               
                DataTable dt = new DataTable();

               dt= concom.Detalleventa(nCompra);

                dgvDetalle.DataSource = null;
                dgvDetalle.DataSource = dt;
                dgvDetalle.Columns[0].Visible = false;
                
                dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch 
            {
                

            }
        }
    }
}
