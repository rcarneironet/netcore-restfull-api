using Architecture.Demo.Core.Entities;
using Architecture.Demo.Core.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Demo.Core.Interfaces
{
    public interface ICustomerService
    {
        Customer Get(int id);
        IEnumerable<Customer> List();

        Customer Add(CustomerDTO dto);

        Customer Update(int id, CustomerDTO dto);
    }
}
