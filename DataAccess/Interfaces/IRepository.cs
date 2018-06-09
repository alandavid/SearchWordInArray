using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        int Save(T entity);

    
        IList<T> GetAll();
    }
}