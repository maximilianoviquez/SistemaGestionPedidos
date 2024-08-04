using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Exceptions;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class , IIdGenerico
    {
        protected DbContext Contexto { get; set; }


        public T Add(T item)
        {

            try
            {
                Contexto.Set<T>().Add(item);
                Contexto.SaveChanges();
            }catch (DbUpdateException ex)
            {
                throw new ElementoInvalidoException("El mail le pertenece a un usuario ya ingresado");          //para que no acepte mail repetidos (INCOMPLETO)
            }
            return item;
        }



        public void Remove(T item)
        {
            Contexto.Set<T>().Remove(item);
            Contexto.SaveChanges();
        }

        public void Update(T item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public T Get(int id)
        {
            T entidad = Contexto.Set<T>().FirstOrDefault(t => t.Id == id);
            return entidad;
        }
    }
}
