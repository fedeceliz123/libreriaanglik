using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Compras
{
    class ConsultasCompras : ConexionBD

    {

        public Boolean ContarDetalle(string contar)
        {
            string consulta = "select COUNT(Numero_Compra) as 'c' from Detalle_Compra where Numero_Compra=" + contar;
            Boolean a = false;

            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            if (lector.Read() == true)
            {
                int b = int.Parse(lector["c"].ToString());

                if (b != 0)
                {
                    a = true;
                }
            }

            return a;


        }


        public void CargarCompra(ComprasR com)
        {
            try
            {

                string cargar = "insert into Compras (N_Compra,Fecha,Proveedor,Recibo,Total,Pagado)VALUES (@id,@fecha,@proveedor,@recibo,@total,@pagado)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@id", com.N_Compra);

                comando.Parameters.AddWithValue("@fecha", com.Fecha);

                comando.Parameters.AddWithValue("@proveedor", com.Proveedor);

                comando.Parameters.AddWithValue("@recibo", com.Recibo);

                comando.Parameters.AddWithValue("@total", com.Total);

                comando.Parameters.AddWithValue("@pagado", com.Pagado);


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


        public void CargarDetalleCompra(Detalle_Compra com)
        {

            try
            {

                string cargar = "insert into Detalle_Compra (Codigo_Producto,Detalle,Numero_Compra,Cantidad,Precio,SubTotal)VALUES (@codigo,@detalle,@ncompra,@cantidad,@precio,@subtotal)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());



                comando.Parameters.AddWithValue("@codigo", com.Codigo_Producto);

                comando.Parameters.AddWithValue("@detalle", com.Detalle);

                comando.Parameters.AddWithValue("@ncompra", com.Numero_Compra);

                comando.Parameters.AddWithValue("@cantidad", com.Cantidad);

                comando.Parameters.AddWithValue("@precio", com.Precio);

                comando.Parameters.AddWithValue("@subtotal", com.SubTotal);

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


        public string codCompra()
        {

            string ticket = "";
            string Consulta = "select  MAX(N_Compra) as com from Compras";

            SqlCommand comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader leer = comando.ExecuteReader();



            if (leer.Read() == true)
            {

                if (leer["com"].ToString() != "0")
                {
                    ticket = (leer["com"].ToString());
                    return ticket;
                }
                else
                {
                    ticket = "";
                    return ticket;
                }


            }
            else
            {
                ticket = "";
                return ticket;
            }


        }


        public DataTable Detalleventa(long ven)
        {
            string Consulta = "select ID,Codigo_Producto as 'Codigo',Detalle,Cantidad,Precio,Subtotal from Detalle_Compra where Numero_Compra=" + ven;
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public void IngresarTotal(double total, long venta,  float pagado)
        {
            string consulta = "UPDATE Compras set Total=@total, Pagado=@pagado where N_Compra=" + venta;

            SqlCommand comando = new SqlCommand(consulta, Conetar());

            comando.Parameters.AddWithValue("@total", total);

           

            comando.Parameters.AddWithValue("@pagado", pagado);

            comando.ExecuteNonQuery();

        }





        public void BorrarproCom(long id)
        {
            try
            {
                string borrar = "delete from Detalle_Compra where ID=" + id;

                SqlCommand comando = new SqlCommand(borrar, Conetar());

                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }


        }



        public DataTable ListarDetCompra(string cuit)
        {
            string Consulta = "select ID,Codigo_Producto as 'Codigo',Detalle,Cantidad,Precio,Subtotal from  Detalle_Compra where Numero_Compra in (select N_Compra from Compras where Proveedor='"+cuit+"')";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable ListarCompra(string cuit)
        {
            string Consulta = "select * from Compras where Proveedor='"+cuit+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable ListarCompras()
        {

            string Consulta = "select * from Compras";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataRow CargarCampos(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Compras where N_Compra='" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }

        public void ModificarCompra(string total,string fecha, string codigo)
        {
            string modificar = "update Compras set Total=@total, Fecha=@fecha where N_Compra="+codigo;

            SqlCommand comando = new SqlCommand(modificar, Conetar());

            comando.Parameters.AddWithValue("@total", total);



            comando.Parameters.AddWithValue("@fecha", fecha);

            comando.ExecuteNonQuery();


        }

        public DataTable listarConFiltro(string prov,string fecha,string recibo)
        {

            string Consulta = "select * from Compras where Proveedor like '%"+prov+"%' and Fecha like '%"+fecha+ "%' and Recibo like '%"+recibo+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }



    }
}
