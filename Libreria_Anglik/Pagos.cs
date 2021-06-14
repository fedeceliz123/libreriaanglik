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
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
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

        private void Pagos_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void chbProv_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProv.Checked == true)
            {
                chbOtros.Checked = false;
                gbProv.Enabled = true;
                gbPago.Enabled = true;

            }
            else
            {
                gbProv.Enabled = false;
            }
        }

        private void chbOtros_CheckedChanged(object sender, EventArgs e)
        {
            if(chbOtros.Checked==true)
            {
                chbProv.Checked = false;
                gbOtros.Enabled = true;
                gbPago.Enabled = true;
                nudPago.Maximum = 9999999999;
            }
            else
            {
                gbOtros.Enabled = false;

            }
        }

        private void comboBoxListar_SelectedIndexChanged(object sender, EventArgs e)
        {

            Clases_Saldos.Consultas_Saldos consaldo = new Clases_Saldos.Consultas_Saldos();

            float saldo= consaldo.SaldoActual(comboBoxListar.SelectedValue.ToString());


            lblSaldo.Text = saldo.ToString();


            nudPago.Maximum = decimal.Parse(saldo.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbConsepto.Text == "" || nudPago.Value == 0)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Complete todos los campos";

            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea cargar nuevo proveedor";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_Pagos.PagosR pag = new Clases_Pagos.PagosR();
                    Clases_Pagos.Cosultas_Pagos conPag = new Clases_Pagos.Cosultas_Pagos();

                    if (gbProv.Enabled == true)
                    {
                        pag.Detalle = comboBoxListar.SelectedValue.ToString();

                        Clases_Saldos.Consultas_Saldos consal = new Clases_Saldos.Consultas_Saldos();

                        float saldo = float.Parse(lblSaldo.Text) - float.Parse(nudPago.Value.ToString());
                                                
                        consal.AumentarSaldo(saldo, comboBoxListar.SelectedValue.ToString());


                    }
                    else if (gbOtros.Enabled == true)
                    {
                        pag.Detalle = tbDescripcion.Text;

                      
                    }

                    pag.Recibo_Consepto = tbConsepto.Text;

                    pag.Valor = float.Parse(nudPago.Value.ToString());

                    pag.Fecha = dtpFecha.Value;

                    conPag.CargarPago(pag);

                    nudPago.Value = 0;
                    tbConsepto.Clear();
                    tbDescripcion.Clear();
                    chbOtros.Checked = false;
                    chbProv.Checked = false;
                    gbPago.Enabled = false;

                }
            }
        }
    }
}
