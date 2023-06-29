using Data.Articulo;
using Data.Carrito;
using Entity.Articulo;
using Entity.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Carrito
{
    public class CarritoBusiness
    {
        public static int InsertCarrito(CarritoModel articulo)
        {
            return CarritoEntity.InsertarCarrito(articulo);
        }

        public static int SumarCantidadCarrito(Detallecarrito detallecarrito)
        {
            return CarritoEntity.SumarCantidadCarrito(detallecarrito);
        }

        public static int RestarCantidadCarrito(Detallecarrito detallecarrito)
        {
            return CarritoEntity.RestarCantidadCarrito(detallecarrito);
        }


        public static List<Detallecarrito> GetCarritoByClienteID(int id)
        {
            return CarritoEntity.GetCarritoByClienteID(id);
        }
    }
}
