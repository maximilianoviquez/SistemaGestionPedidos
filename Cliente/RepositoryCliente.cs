using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioCliente : Repository<Cliente>, IRepositoryCliente
    {
        private readonly IRepositoryPedido _repositoryPedido; 
        public RepositorioCliente(DbContext dbContext, IRepositoryPedido repositoryPedido)
        {
            Contexto = dbContext;
            _repositoryPedido = repositoryPedido;
        }

        public IEnumerable<Cliente> GetByRazonSocial(string razonsocial)
        {
            IEnumerable<Cliente> clientes = Contexto.Set<Cliente>()
                                                    .Include(d => d.Direccion)
                                                    .Where(cliente => cliente.RazonSocial.Contains(razonsocial));

            return clientes;
        }

        public IEnumerable<Cliente> GetClienteByMonto(double monto)
        {
            var clientes = new HashSet<Cliente>(); //"distinct"
            IEnumerable<Pedido> pedidos = _repositoryPedido.GetPedidosQueSuperen(monto);
            foreach(Pedido p in pedidos)
            {
                clientes.Add(p.Cliente);
            }
            return clientes;
        }

      
    }
}
