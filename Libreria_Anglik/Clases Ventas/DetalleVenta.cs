using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Anglik.Clases_Ventas
{
    class DetalleVenta
    {
        //detalle

        public long ID { set; get; }
        public string Codigo_Producto { set; get; }
        public string Detalle { set; get; }
        public long N_Venta_Detalle { set; get; }
        public int Cantidad { set; get; }
        public float Precio { set; get; }
        public decimal Subtotal { set; get; }
        public float Descuento { set; get; }

    }
}
