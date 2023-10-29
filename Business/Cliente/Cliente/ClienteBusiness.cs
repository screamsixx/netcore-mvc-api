using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Cliente;
using Data.Cliente;
using System.Net.NetworkInformation;

namespace Business.Cliente.Cliente
{
    public class ClienteBusiness
    {
        public static List<ClienteModel> GetClientes()
        {
            return ClienteEntity.GetClientes();
        }
        public static int InsertClientes(ClienteModel cliente)
        {
            return ClienteEntity.InsertCliente(cliente);
        }
        public static int UpdateCliente(ClienteModel cliente)
        {
            return ClienteEntity.UpdateCliente(cliente);
        }
    }
}