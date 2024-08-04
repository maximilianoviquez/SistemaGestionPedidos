using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        public IEnumerable<Cliente> GetByRazonSocial(string razonsocial);

        public IEnumerable<Cliente> GetClienteByMonto(double monto);

     

    }
}
