using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Anglik.Clases_Compras
{
    class Detalle_Compra
    {
        public long ID { set; get; }
        public string Codigo_Producto { set; get; }
        public string Detalle { set; get; }
        public long Numero_Compra { set; get; }
        public int Cantidad { set; get; }
        public float Precio { set; get; }
        public float SubTotal { set; get; }

    }
}
