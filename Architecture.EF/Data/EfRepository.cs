using System.Collections.Generic;
using System.Linq;
using Architecture.Demo.Core.Entities.Base;
using Architecture.Demo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Architecture.EF.Data
{
    public class EfRepository<T> : IRepository<T>
        where T : BaseEntity
    {

        private readonly ApplicationContext _dbContext;

        public EfRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().AsNoTracking().First(x => x.ID == id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
