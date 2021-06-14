using System;
using System.Collections;
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
    public partial class Reportes_Ventas : Form
    {
        public Reportes_Ventas()
        {
            InitializeComponent();
        }

        ArrayList N_venta_dia = new ArrayList();
        ArrayList Total_venta_dia = new ArrayList();

        ArrayList N_venta_mes = new ArrayList();
        ArrayList Total_venta_mes = new ArrayList();

        ArrayList Mes_año = new ArrayList();
        ArrayList Total_venta_año = new ArrayList();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            N_venta_dia.Clear();
            Total_venta_dia.Clear();

            double total=0;

            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            foreach (DataRow row in conVen.VentasDelDia(dtpVentaDia.Value).Rows)
            {
                N_venta_dia.Add(row["N° Venta"]);
                Total_venta_dia.Add(row["Total"]);

                total = total + double.Parse(row["Total"].ToString());

            }

            chartVentaDia.Series[0].Points.DataBindXY(N_venta_dia, Total_venta_dia);


            lblTotal.Text = total.ToString();


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            N_venta_mes.Clear();
            Total_venta_mes.Clear();

            string fecha = dtpMes.Value.ToString("yyyy-MM");
            double total = 0;

            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            foreach (DataRow row in conVen.VentasDelMes(fecha).Rows)
            {
                DateTime f = DateTime.Parse(row["Fecha"].ToString());

                N_venta_mes.Add(f.ToString("dd/MM"));
                Total_venta_mes.Add(row["Total"]);

                total = total + double.Parse(row["Total"].ToString());

            }

            charVentasMes.Series[0].Points.DataBindXY(N_venta_mes, Total_venta_mes);

            lblTotalmes.Text = total.ToString();

        }

        private void dtpVentaAño_ValueChanged(object sender, EventArgs e)
        {

            Mes_año.Clear();
            Total_venta_año.Clear();

            string fecha = dtpVentaAño.Value.ToString("yyyy");
            
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();


            foreach (DataRow row in conVen.VentasDelaño(fecha).Rows)
            {
                Mes_año.Add(row["Mes"]);

             

                if ((row["Total"].ToString()) !=null  )
                {
                    Total_venta_año.Add(row["Total"]);

                   
                }
                else
                {
                    Total_venta_año.Add(0);

                    
                }

               

            }

            chartVentaAño.Series[0].Points.DataBindXY(Mes_año, Total_venta_año);

           

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
          

            dgvLisarventa.DataSource = null;
            dgvLisarventa.DataSource = CargarVentaDia();
            dgvLisarventa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLisarventa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private DataTable CargarVentaDia()
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conVen.VentasDelDia(dtpVentaDia.Value);

            return dt;

        

        }

        private DataTable CargarVentaMes()
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            string fecha = dtpMes.Value.ToString("yyyy-MM");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conVen.VentasDelMes(fecha);

            return dt;



        }


        private DataTable CargarVentaAño()
        {
            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            string fecha = dtpMes.Value.ToString("yyyy");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = conVen.VentasDelaño(fecha);

            return dt;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            dgvLisarventa.DataSource = null;
            dgvLisarventa.DataSource = CargarVentaMes();
            dgvLisarventa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLisarventa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvLisarventa.DataSource = null;
            dgvLisarventa.DataSource = CargarVentaAño();
            dgvLisarventa.Columns[2].Visible = false;
            dgvLisarventa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
    }
}
