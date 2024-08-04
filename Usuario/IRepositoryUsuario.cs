using DataAccess;
using Domain;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryUsuario : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetByName(string name);

        public Usuario GetByEmail(string email);


    }
}
