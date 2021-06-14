using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik
{
    class Consultas_Proveedores:ConexionBD
    {

        public DataTable CargarCombo()
        {
            string Consulta = "select CUIT, Razon_Social +' ,'+ Nombre_Fantasia as prov from Proveedores where Activo='Si' order by prov";
            SqlDataAdapter da = new SqlDataAdapter(Consulta,Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
               

        }

        public DataRow CargarCampos(string Cuit)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Proveedores where CUIT='"+Cuit +"'";

            SqlDataAdapter da = new SqlDataAdapter(consulta,Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }

        public DataTable Listar(string activo)
        {
            string Consulta = "select CUIT,Razon_Social as 'Razon social', Nombre_Fantasia as 'Nombre fantasia',Condicion_IVA as 'IVA', Rubro, Fecha_Ingreso as 'Ingreso'   from Proveedores where Activo='"+activo+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarporCuit(string activo, string cuit)
        {
            string Consulta = "select CUIT,Razon_Social as 'Razon social', Nombre_Fantasia as 'Nombre fantasia',Condicion_IVA as 'IVA', Rubro, Fecha_Ingreso as 'Ingreso'   from Proveedores where Activo='" + activo + "' and CUIT like '%"+cuit+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarporRazon(string activo, string razon)
        {
            string Consulta = "select CUIT,Razon_Social as 'Razon social', Nombre_Fantasia as 'Nombre fantasia',Condicion_IVA as 'IVA', Rubro, Fecha_Ingreso as 'Ingreso'   from Proveedores where Activo='" + activo + "' and Razon_Social like '%" + razon + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarporFantasia(string activo, string razon)
        {
            string Consulta = "select CUIT,Razon_Social as 'Razon social', Nombre_Fantasia as 'Nombre fantasia',Condicion_IVA as 'IVA', Rubro, Fecha_Ingreso as 'Ingreso'   from Proveedores where Activo='" + activo + "' and Nombre_Fantasia like '%" + razon + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }



        public void ModificarProveedores(Clases_proveedores.ProveedoresR Pro)
        {
            try
            {

                string Modificar = "set dateformat dmy UPDATE Proveedores set CUIT='" + Pro.CUIT + "', Razon_Social='" + Pro.Razon_Social + "', Nombre_Fantasia='" + Pro.Nombre_Fantacia + "', Condicion_IVA='" + Pro.Condicion_IVA + "' ,Rubro='" + Pro.Rubro + "', Fecha_Ingreso='" + Pro.Fecha_Ingreso + "' where CUIT='" + Pro.CUIT + "'";

                SqlCommand comando = new SqlCommand(Modificar, Conetar());



                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;


            }




        }

        public void CargarProveedor(string CUIT,string Razon_Social,string Nombre_Fantacia,string Condicion_IVA,string Rubro ,DateTime Fecha_Ingreso)
        {
            try
            {

                string cargar = "insert into Proveedores VALUES (@cuit,@razon,@nomfantacia,@iva,@rubro,@fecha,@activo,@fechae)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@cuit", CUIT);

                comando.Parameters.AddWithValue("@razon", Razon_Social);

                comando.Parameters.AddWithValue("@nomfantacia", Nombre_Fantacia);

                comando.Parameters.AddWithValue("@iva", Condicion_IVA);

                comando.Parameters.AddWithValue("@rubro", Rubro);

                comando.Parameters.AddWithValue("@fecha", Fecha_Ingreso);

                comando.Parameters.AddWithValue("@activo", "Si");

                comando.Parameters.AddWithValue("@fechae", "");

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

         
        public void BorrarProveedor(string cuit, string fechaEgreso)
        {
            try
            {
                string borrar = "update Proveedores set Activo='No', Fecha_Egreso='" + fechaEgreso + "' where CUIT='" + cuit + "'";

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

        public void ReactivarProveedor(string cuit, string fechaEgreso)
        {
            try
            {
                string borrar = "update Proveedores set Activo='Si' where CUIT='" + cuit + "'";

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




    }
}
