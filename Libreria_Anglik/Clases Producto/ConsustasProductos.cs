using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Libreria_Anglik.Clases_Producto
{
    class ConsustasProductos : ConexionBD
    {

        public void CargarProducto(ProductosR prod)
        {
            try
            {

                string carga = "insert into Productos (Cod_producto,Activo,Nombre,Descripcion,Marca,Cantidad,Precio,Can_min,Descuento1,Descuento2,Fecha_Ultima_Compra,Imagen,Codigo_Barra) values(@codigo,@activo,@nombre,@descripcion,@marca,@cantidad,@precio,@canmin,@des1,@des2,@fecha,@imagen,@codBarra)";

                Conetar();
                SqlCommand comando = new SqlCommand(carga, Conetar());

                comando.Parameters.AddWithValue("@codigo", prod.Cod_producto);
                comando.Parameters.AddWithValue("@activo", prod.Activo);
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                comando.Parameters.AddWithValue("@marca", prod.Marca);
                comando.Parameters.AddWithValue("@cantidad", prod.Cantidad);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@canmin", prod.Can_min);
                comando.Parameters.AddWithValue("@des1", prod.Descuento1);
                comando.Parameters.AddWithValue("@des2", prod.Descuento2);
                comando.Parameters.AddWithValue("@fecha", prod.Fecha_Ultima_Compra);
                comando.Parameters.AddWithValue("@imagen", prod.Imagen.GetBuffer());
                
                comando.Parameters.AddWithValue("@codBarra", prod.Codigo_Barra.GetBuffer());


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

        public DataTable Listar(string activo)
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos where Activo='"+activo+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarporCodigo(string activo,string codigo)
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos where Activo='" + activo + "' and Cod_producto like '%"+codigo+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarporProducto(string activo, string codigo)
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos where Activo='" + activo + "' and Nombre like '%" + codigo + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarporDescripcion(string activo, string codigo)
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos where Activo='" + activo + "' and Descripcion like '%" + codigo + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarporMarca(string activo, string codigo)
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos where Activo='" + activo + "' and Marca like '%" + codigo + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }


        public DataRow CargarCampos(string Codigo)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Productos where Cod_producto='" + Codigo + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }

        public DataRow CargarCamposV(string Codigo)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select Cod_producto,Nombre+', '+Descripcion as 'Producto', Marca,Cantidad,Precio,Can_min,Descuento1,Descuento2,Fecha_Ultima_Compra,Imagen from Productos where Cod_producto='" + Codigo + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }


        public void ModificarProductos(ProductosR prod)
        {
            try
            {
                Conetar();

                

                string Modificar = "set dateformat dmy UPDATE Productos set Cod_producto=@codigo, Nombre=@nombre, Descripcion=@descripcion,Marca=@marca,Cantidad=@cantidad,Precio=@precio,Can_min=@canmin, Descuento1=@des1, Descuento2=@des2,Fecha_Ultima_Compra= @fecha, Imagen= @imagen, Codigo_Barra=@codBarra where Cod_producto=@codigo";

                SqlCommand comando = new SqlCommand(Modificar, Conetar());

                comando.Parameters.AddWithValue("@codigo", prod.Cod_producto);
               
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                comando.Parameters.AddWithValue("@marca", prod.Marca);
                comando.Parameters.AddWithValue("@cantidad", prod.Cantidad);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@canmin", prod.Can_min);
                comando.Parameters.AddWithValue("@des1", prod.Descuento1);
                comando.Parameters.AddWithValue("@des2", prod.Descuento2);
                comando.Parameters.AddWithValue("@fecha", prod.Fecha_Ultima_Compra);
                comando.Parameters.AddWithValue("@imagen", prod.Imagen.GetBuffer());
                comando.Parameters.AddWithValue("@codBarra", prod.Codigo_Barra.GetBuffer());





                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MensajeOk b = new MensajeOk();
                b.Show();
                b.lblMensaje.Text = ex.Message;
                
              
            }




        }

        public void BorrarProducto(string codigo,string egreso)
        {
            try
            {
                string borrar = "update Productos set Activo='No',Fecha_Egreso='"+egreso+"' where Cod_producto='" + codigo + "'";

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


        public DataTable ListarInventario()
        {
            string Consulta = "select Cod_producto as 'Codigo',Nombre,Descripcion,Marca,Cantidad from Productos";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarVenta()
        {
            string Consulta = "select Cod_Producto as 'Codigo',Nombre+', '+Descripcion as 'Producto',Marca from Productos where Activo='Si'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarVentaFiltro(string art)
        {
            string Consulta = "select Cod_Producto,Nombre+', '+Descripcion as 'Producto',Marca from Productos where Activo='Si' and Nombre+', '+Descripcion like '%"+art+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarVentaCod(string codigo)
        {
            string Consulta = "select Cod_Producto,Nombre,Descripcion,Marca from Productos where Cod_Producto like '%"+codigo +"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public void DiminucionProductoVenta(int stock, int venta,string codigo)
        {

            string consulta = "UPDATE Productos set Cantidad="+(stock-venta)+"where Cod_producto='"+codigo+"'";

            SqlCommand comando = new SqlCommand(consulta, Conetar());

            comando.ExecuteNonQuery();

        }

        public void DevolucionProducto(string codigo,int stock,int venta)
        {
            string consulta = "UPDATE Productos set Cantidad=" + (stock + venta) + "where Cod_producto='" + codigo + "'";

            SqlCommand comando = new SqlCommand(consulta, Conetar());

            comando.ExecuteNonQuery();


        }

        public int ProductoaDevolver(string codigo)
        {
            string consulta = "select Cantidad from Productos where Cod_producto='" + codigo + "'";
            int cant=0;
            Conetar();
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();



            if (lector.Read() == true)
            {
                cant = int.Parse(lector["Cantidad"].ToString());
            }

            Conetar();

            return cant;

        }


        public DataTable ProductosMayorStock()
        {
            string Consulta = "select top 5 Nombre+', '+Descripcion as Producto,Cantidad from Productos order by Cantidad desc";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable ProductosMenorStock()
        {
            string Consulta = "select top 5 Nombre+', '+Descripcion as Producto,Cantidad from Productos order by Cantidad";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable ListarParaClientes()
        {
            string Consulta = "select Cod_producto,Nombre+' '+Descripcion as 'Productos',Marca,Cantidad from Productos  ";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ProductosDescuento(string cant)
        {

            string Consulta = "select  Cod_producto,Nombre+' '+Descripcion as 'Productos',Cantidad,Precio ,Imagen, Descuento1,Descuento2 from Productos where Cod_producto in (select top "+cant +" Cod_producto from Productos where Descuento1<>0 or Descuento2<>0 order by Cantidad  ) and Descuento1<>0 or Descuento2<>0  order by Cantidad desc";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        }


        public DataTable ListarInventarioFiltro(string buscar)
        {
            
            
                string Consulta = "select Cod_producto, Nombre+' '+Descripcion as 'Productos',Marca,Cantidad from Productos where Nombre+' '+Descripcion like '%" + buscar+"%'";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                return dt;

            

        }


        public void ReActivarProducto(string codigo)
        {
            try
            {
                string reactivar = "update Productos set Activo='Si' where Cod_producto='" + codigo + "'";

                SqlCommand comando = new SqlCommand(reactivar, Conetar());

                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }


        }

        public void DiminucionProductoCompra( int venta, string codigo)
        {

            string consulta = "UPDATE Productos set Cantidad=Cantidad-" + venta + "where Cod_producto='" + codigo + "'";

            SqlCommand comando = new SqlCommand(consulta, Conetar());

            comando.ExecuteNonQuery();

        }
    }
}
