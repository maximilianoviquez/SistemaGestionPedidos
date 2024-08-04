using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T>
    {
        T Add(T item);
        void Update(T item);
        void Remove(T item);
        T Get(int id);

    }
}
