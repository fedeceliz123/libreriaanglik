using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Ventas
{
    class ConsultasVentas:ConexionBD
    {
        public string NtoTicket()
        {

            string ticket;
                string Consulta = "select max(FORMAT(N_Venta+1,'00000000')) as tiket from Venta";

                SqlCommand comando = new SqlCommand(Consulta,Conetar());
                SqlDataReader leer = comando.ExecuteReader();

            

            if (leer.Read() == true)
            {

                if (leer["tiket"].ToString() != "")
                {
                    ticket = leer["tiket"].ToString();
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

        public Boolean ContarDetalle(string contar)
        {
            string consulta = "select COUNT(N_Ventas_Detalle) as 'c' from Detalle_Venta where N_Ventas_Detalle="+contar;
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



        public DataTable Detalleventa(long ven)
        {
            string Consulta = "select ID,Codigo_Producto as 'Codigo',Detalle,Cantidad,Precio,Subtotal from Detalle_Venta where N_Ventas_Detalle="+ven;
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }


        public void CargarDetalleVenta(DetalleVenta ven)
        {

           

            try
            {

                string cargar = "insert into Detalle_venta VALUES (@cod,@detalle,@nventa,@cantidad,@precio,@descuento,@subtotal)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@cod", ven.Codigo_Producto);

                comando.Parameters.AddWithValue("@detalle", ven.Detalle);

                comando.Parameters.AddWithValue("@nventa", ven.N_Venta_Detalle);

                comando.Parameters.AddWithValue("@cantidad", ven.Cantidad);

                comando.Parameters.AddWithValue("@precio", ven.Precio);

                comando.Parameters.AddWithValue("@descuento", ven.Descuento);

                comando.Parameters.AddWithValue("@subtotal", ven.Subtotal);

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


        public void CargarVenta(VentasR ven)
        {
           

            try
            {

                string cargar = "insert into Venta VALUES (@nventa,@puestoventa,@ticket,@dnivendedor,@cliente,@fecha,@total)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@nventa", ven.N_Venta);

                comando.Parameters.AddWithValue("@puestoventa", ven.Puesto_Venta);

                comando.Parameters.AddWithValue("@ticket", ven.N_Ticket);

                comando.Parameters.AddWithValue("@dnivendedor", ven.DNI_Vendedor);

                comando.Parameters.AddWithValue("@cliente", ven.Cliente);

                comando.Parameters.AddWithValue("@fecha", ven.Fecha);

                comando.Parameters.AddWithValue("@total", ven.Total);

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


        public void IngresarTotal(double total,long venta)
        {
            string consulta = "UPDATE Venta set Total=@total where N_Venta="+venta ;

            SqlCommand comando = new SqlCommand(consulta, Conetar());

            comando.Parameters.AddWithValue("@total", total);

            comando.ExecuteNonQuery();

        }


        public DataTable CargarPuestoVenta()
        {
            string Consulta = "select Id,FORMAT(N_Puesto, '0000') as puesto from Puesto_De_Venta order by N_Puesto";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;



        }

        public void BorrarProducto(long id)
        {
            try
            {
                string borrar = "delete from Detalle_Venta where ID=" + id ;

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

        public string CantVentasEmpleado(string dni, string fecha)
        {
            string consulta = "select COUNT(DNI_Vendedor) as 'Cantidad de ventas', SUM(Total) as 'Total venta'  from Venta where DNI_Vendedor='"+dni+"' and Fecha like '"+fecha+"%'  group by DNI_Vendedor";
           SqlCommand comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = comando.ExecuteReader();
            string canven = "";
            if (lector.Read() == true)
            { 
                canven = lector["Cantidad de ventas"].ToString();
            }

            return canven;
        }

        public string totalVentasEmpleado(string dni, string fecha)
        {
            string consulta = "select COUNT(DNI_Vendedor) as 'Cantidad de ventas', SUM(Total) as 'Total venta'  from Venta where DNI_Vendedor='" + dni + "' and Fecha like '" + fecha + "%'  group by DNI_Vendedor";
            SqlCommand comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = comando.ExecuteReader();
            string totven = "";
            if (lector.Read() == true)
            {
                totven = lector["Total venta"].ToString();
            }

            return totven;
        }

        public DataTable ventasEmpleado(string dni,string fecha)
        {
            string consulta = "select * from Venta where DNI_Vendedor='" + dni + "' and Fecha like '" + fecha + "%'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }


        public DataTable ProductosMasVendido()
        {
            string Consulta = "select top 10 Detalle,SUM(Cantidad) as cantidad from Detalle_Venta group by Detalle order by SUM(Cantidad)desc";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable ProductosMenosVendido()
        {
            string Consulta = "select top 10 Detalle,SUM(Cantidad) as cantidad from Detalle_Venta group by Detalle order by SUM(Cantidad)";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable VentasDelDia(DateTime fecha)
        {
            string Consulta = "select N_Venta as 'N° Venta',Total from Venta where Fecha='" + fecha+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable VentasDelMes(string fecha)
        {
            string Consulta = "select Fecha,SUM(Total) as 'Total' from Venta where Fecha like '"+fecha+"-%'group by Fecha";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable VentasDelaño(string fecha)
        {
            string Consulta = "select 'Enero' as 'Mes',SUM(Total) as 'Total', 1 as 'id' from Venta where Fecha like'" + fecha+ "-01%' union select 'Febrero' as 'Mes',SUM(Total) as 'Total', 2 as 'id' from Venta where Fecha like'" + fecha+ "-02%' union select 'Marzo' as 'Mes',SUM(Total) as 'Total',3 as 'id' from Venta where Fecha like'" + fecha+ "-03%' union select 'Abril' as 'Mes',SUM(Total) as 'Total',4 as 'id' from Venta where Fecha like'" + fecha+ "-04%' union select 'Mayo' as 'Mes',SUM(Total) as 'Total', 5 as 'id' from Venta where Fecha like'" + fecha+ "-05%' union select 'Junio' as 'Mes',SUM(Total) as 'Total', 6 as 'id' from Venta where Fecha like'" + fecha+ "-06%' union select 'Julio' as 'Mes',SUM(Total) as 'Total', 7 as 'id' from Venta where Fecha like'" + fecha+ "-07%' union select 'Agosto' as 'Mes',SUM(Total) as 'Total',8 as 'id' from Venta where Fecha like'" + fecha+ "-08%' union select 'Septiembre' as 'Mes',SUM(Total) as 'Total',9 as 'id' from Venta where Fecha like'" + fecha+ "-09%' union select 'Octubre' as 'Mes',SUM(Total) as 'Total', 10 as 'id' from Venta where Fecha like'" + fecha+ "-010%' union select 'Noviembre' as 'Mes',SUM(Total) as 'Total', 11 as 'id' from Venta where Fecha like'" + fecha+ "-11%' union select 'Diciembre' as 'Mes',SUM(Total) as 'Total', 12 as 'id' from Venta where Fecha like'" + fecha+"-12%' order by 'id'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable vendidos(string cantidad)
        {
            string consulta = "select Cod_producto,Nombre+' ,'+Descripcion as 'nombre',Cantidad,Precio,Imagen from Productos where Cod_producto in (select top 5 d.Codigo_Producto  from Detalle_Venta d where  Codigo_Producto in (select top "+cantidad+" Codigo_Producto from Detalle_Venta  group by Codigo_Producto order by sum(Cantidad) desc ) group by d.Codigo_Producto order by sum(d.Cantidad))";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        }

        public DataTable ImprimirDetalle(string nventa)
        {
            string consulta = "select Codigo_Producto,Detalle,Cantidad,Subtotal from Detalle_Venta where N_Ventas_Detalle="+nventa;
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

    }
}
