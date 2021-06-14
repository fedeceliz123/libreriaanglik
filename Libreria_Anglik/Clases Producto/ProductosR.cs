using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Libreria_Anglik.Clases_Producto
{
    class ProductosR
    {
       public string Cod_producto { set; get; }
        public string Activo { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Marca { set; get; }
        public int Cantidad { set; get; }
        public double Precio { set; get; }
        public int Can_min { set; get; }
        public double Descuento1 { set; get; }
        public double Descuento2 { set; get; }
        public DateTime Fecha_Ultima_Compra { set; get; }
        public MemoryStream Imagen { set; get; }

        public MemoryStream Codigo_Barra { set; get; }

    }

}
