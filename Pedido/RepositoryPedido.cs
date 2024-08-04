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
    public class RepositorioPedido : Repository<Pedido>, IRepositoryPedido
    {
        public RepositorioPedido(DbContext dbContext)
        {
            Contexto = dbContext;
        }

        public IEnumerable<PedidoComun> GetAllComunes()
        {
            IEnumerable<PedidoComun> pedidosComunes = Contexto.Set<PedidoComun>()
                                                                .OrderBy(p => p.FechaPedido)
                                                                .Where(p => p.PedidoAnulado == false);

            return pedidosComunes;
        }

        public IEnumerable<PedidoExpress> GetAllExpress()
        {
            IEnumerable<PedidoExpress> pedidosExpress = Contexto.Set<PedidoExpress>()
                                                                .OrderBy(p => p.FechaPedido)
                                                                .Where(p => p.PedidoAnulado == false);

            return pedidosExpress;
        }

        public IEnumerable<Pedido> GetAllAnulados()
        {
            IEnumerable<Pedido> pedidosAnulados = Contexto.Set<Pedido>()
                                                            .OrderByDescending(p => p.FechaPedido)
                                                            .Where(p => p.PedidoAnulado == true);
                                                            
            return pedidosAnulados;
        }

        public IEnumerable<Pedido> GetPedidosQueSuperen(double monto)
        {
            IEnumerable<Pedido> pedidos = Contexto.Set<Pedido>()
                                                    .Where(p => p.PrecioFinal > monto)
                                                    .Include(p => p.Cliente).ToList();


            return pedidos;
        }
    }
}
