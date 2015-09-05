using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BL.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetByPage(int page, int size = 10);
        T AddOrUpdate(T entity);
        bool Delete(T entity);
    }
}
