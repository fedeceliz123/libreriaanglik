using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Anglik.Clases_Ventas
{
    class VentasR
    {
        /// venta 
        public long N_Venta { set; get; }
        public string Puesto_Venta { set; get; }
        public string N_Ticket { set; get; }
        public string DNI_Vendedor { set; get; }
        public string Cliente { set; get; }
        public DateTime Fecha { set; get; }
        public float Total { set; get; }

        
        
    }
}
