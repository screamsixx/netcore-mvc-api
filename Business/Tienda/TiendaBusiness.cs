using Data.Tienda;
using Entity.Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tienda
{
    public class TiendaBusiness
    {
        public static List<TiendaModel> GetTiendas()
        {
            return TiendaEntity.GetTiendas();
        }

        public static int InsertTienda(TiendaModel Tienda)
        {
            return TiendaEntity.InsertTienda(Tienda);
        }

        public static int UpdateTienda(TiendaModel Tienda)
        {
            return TiendaEntity.UpdateTienda(Tienda);
        }
    }
}
