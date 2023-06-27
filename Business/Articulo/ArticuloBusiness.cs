using Data.Articulo;
using Entity.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Articulo
{
    public class ArticuloBusiness
    {
        public static List<ArticuloModel> GetArticulos()
        {
            return ArticuloEntity.GetArticulos();
        }

        public static int InsertArticulo(ArticuloModel articulo)
        {
            return ArticuloEntity.InsertArticulo(articulo);
        }

        public static int UpdateArticulo(ArticuloModel articulo)
        {
            return ArticuloEntity.UpdateArticulo(articulo);
        }
    }
}
