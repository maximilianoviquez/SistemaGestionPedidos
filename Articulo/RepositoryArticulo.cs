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
    public class RepositorioArticulo : Repository<Articulo>, IRepositoryArticulo
    {
        public RepositorioArticulo(DbContext dbContext)
        {
            Contexto = dbContext;
        }

        public IEnumerable<Articulo> GetByName(string name)
        {
            IEnumerable<Articulo> articulos = Contexto.Set<Articulo>()
                                                      .Where(articulo => articulo.Nombre.Contains(name));
            
            return articulos;
        }

        public IEnumerable<Articulo> GetListaArticulos()
        {
            IEnumerable<Articulo> articulos = Contexto.Set<Articulo>()
                                                        .OrderBy(a => a.Nombre);
            return articulos;
        }
    }
}
