using Architecture.Demo.Core.Entities;
using Architecture.Demo.Core.Interfaces;

namespace Architecture.EF.Data
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
