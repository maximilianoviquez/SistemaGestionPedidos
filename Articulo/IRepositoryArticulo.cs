using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryArticulo : IRepository<Articulo>
    {
        IEnumerable<Articulo> GetByName(string name);

        IEnumerable<Articulo> GetListaArticulos();
    }
}
