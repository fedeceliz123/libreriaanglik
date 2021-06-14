using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Libreria_Anglik.Estadisticas
{
    class EstadisticasProductos:ConexionBD
    {

        public void ProductoFaltantes()
        {
            string consulta = "select Nombre,Cantidad from Productos where Cantidad<Can_min";

            SqlDataAdapter da = new SqlDataAdapter(consulta,Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            
        }

        public void ProductosMaxStock(string cantidad)
        {
            string consulta = "select top "+cantidad+" Nombre,Cantidad from Productos order by Cnatidad";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

        }

        public void ProductosMasVendidos(string MasVendidos)
        {
            string consulta = "select top " + MasVendidos + " Codigo,Detalle,sum(Cantidad) from Detalle_Venta group by Codigo order by Cantidad";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

        }


    }
}
