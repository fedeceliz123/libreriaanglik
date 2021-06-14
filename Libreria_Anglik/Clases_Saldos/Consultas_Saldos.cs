using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Saldos
{
    class Consultas_Saldos:ConexionBD
    {

       public void CargarSaldo(SaldosR sal)
       {

            try
            {
                

                string cargar = "insert into Saldos (CUIT,Saldo) VALUES (@cuit,@saldo)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@cuit", sal.CUIT);

                comando.Parameters.AddWithValue("@saldo", sal.Saldo);
                

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


        public float SaldoActual(string cuit)
        {

            string consulta = "select Saldo from Saldos where CUIT='"+cuit+"'";
            float saldo = 0;
            Conetar();
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();



            if (lector.Read() == true)
            {
                saldo = float.Parse(lector["Saldo"].ToString());
            }

            Conetar();

            return saldo;


        }


        public void AumentarSaldo(float saldo, string cuit)
        {

            try
            {
                string consulta = "UPDATE Saldos set Saldo=" + saldo+" where CUIT='"+cuit+"'";

                SqlCommand comando = new SqlCommand(consulta, Conetar());

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }


        }

    }
}
