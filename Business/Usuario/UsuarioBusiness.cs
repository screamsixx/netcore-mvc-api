using Data.Usuario;
using Entity.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Usuario
{
    public class UsuarioBusiness
    {
        public static bool Login(string email, string password)
        {
            return UsuarioEntity.Login(email, password);
        }
    }
}
