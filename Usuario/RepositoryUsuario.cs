using DataAccess;
using Domain;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioUsuario : Repository<Usuario>, IRepositoryUsuario
    {
        public RepositorioUsuario(DbContext dbContext)
        {
            Contexto = dbContext;
        }


        public Usuario GetByEmail(string email)
        {
            Usuario usuario = Contexto.Set<Usuario>().FirstOrDefault(u => u.Email == email);
                                                    
            return usuario;
        }

        public IEnumerable<Usuario> GetByName(string name)
        {
            IEnumerable<Usuario> usuarios = Contexto.Set<Usuario>()
                                                    .Where(usuario => usuario.Nombre.Contains(name));

            return usuarios;
        }

    
    }
}
