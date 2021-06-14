using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Pagos
{
    class Cosultas_Pagos:ConexionBD
    {

        public void CargarPago(PagosR pag)
        {
            try
            {


                string cargar = "insert into Pagos (Detalle,Recibo_Consepto,Valor,Fecha) VALUES (@detalle,@consepto,@valor,@fecha)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@detalle", pag.Detalle);

                comando.Parameters.AddWithValue("@consepto", pag.Recibo_Consepto);

                comando.Parameters.AddWithValue("@valor", pag.Valor);

                comando.Parameters.AddWithValue("@fecha", pag.Fecha);

                comando.ExecuteNonQuery();
                Conetar();
            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;

            }



        }

        public DataTable ListarPagos(string cuit)
        {
            string Consulta = "select * from Pagos where Detalle='" + cuit + "'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }


    }
}
