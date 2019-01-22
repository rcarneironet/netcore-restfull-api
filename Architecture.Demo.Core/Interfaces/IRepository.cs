using Architecture.Demo.Core.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Demo.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> List();
        T Add(T entity);
        void Update(T entity);
    }
}
