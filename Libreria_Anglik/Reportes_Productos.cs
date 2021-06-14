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
    public partial class Reportes_Productos : Form
    {
        public Reportes_Productos()
        {
            InitializeComponent();
        }
        ArrayList ProductoMas = new ArrayList();
        ArrayList CantidadMas = new ArrayList();

        ArrayList ProductoMin = new ArrayList();
        ArrayList CantidadMin = new ArrayList();

        ArrayList ProductoVenMax = new ArrayList();
        ArrayList CantidadVenMax = new ArrayList();

        ArrayList ProductoVenMin = new ArrayList();
        ArrayList CantidadVenMin = new ArrayList();


        private void Reportes_Productos_Load(object sender, EventArgs e)
        {

            Clases_Producto.ConsustasProductos conPro = new Clases_Producto.ConsustasProductos();

            Clases_Ventas.ConsultasVentas conVen = new Clases_Ventas.ConsultasVentas();

            foreach(DataRow row in conPro.ProductosMayorStock().Rows)
            {

                ProductoMas.Add(row["Producto"]);
                CantidadMas.Add(row["Cantidad"]);

            }

            chartProductosMayorStock.Series[0].Points.DataBindXY(ProductoMas, CantidadMas);


            foreach (DataRow row in conPro.ProductosMenorStock().Rows)
            {

                ProductoMin.Add(row["Producto"]);
                CantidadMin.Add(row["Cantidad"]);

            }

            chartProduntosMenor.Series[0].Points.DataBindXY(ProductoMin, CantidadMin);

            foreach (DataRow row in conVen.ProductosMasVendido().Rows)
            {

                ProductoVenMax.Add(row["Detalle"]);
                CantidadVenMax.Add(row["cantidad"]);

            }

            chartProductosMasVendidos.Series[0].Points.DataBindXY(ProductoVenMax, CantidadVenMax);


            foreach (DataRow row in conVen.ProductosMenosVendido().Rows)
            {

                ProductoVenMin.Add(row["Detalle"]);
                CantidadVenMin.Add(row["cantidad"]);

            }

            chartProMinVen.Series[0].Points.DataBindXY(ProductoVenMin, CantidadVenMin);

        }
    }
}
