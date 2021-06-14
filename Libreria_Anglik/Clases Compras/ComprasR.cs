using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Anglik.Clases_Compras
{
    class ComprasR
    {
        public long N_Compra { set; get; }
        public DateTime Fecha  { set; get; }
        public string Proveedor { set; get; }
        public string Recibo { set; get; }
        public float  Total { set; get; }
        public float Pagado { set; get; }
        

    }
}
