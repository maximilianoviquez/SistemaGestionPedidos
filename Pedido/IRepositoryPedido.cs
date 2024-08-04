using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        public IEnumerable<PedidoComun> GetAllComunes();
        public IEnumerable<PedidoExpress> GetAllExpress();

        public IEnumerable<Pedido> GetAllAnulados();

        public IEnumerable<Pedido> GetPedidosQueSuperen(double monto);

    }
}
