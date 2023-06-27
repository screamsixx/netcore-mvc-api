using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Carrito
{
    public class Carrito
    {
        public int CarritoID { get; set; }
        public int ClienteID { get; set; }
        public int ArticuloID { get; set; }
        public int Cantidad { get; set; }
    }
}
