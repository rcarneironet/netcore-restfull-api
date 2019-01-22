using Architecture.Demo.Core.Entities;
using Architecture.Demo.Core.Entities.DTO;
using Architecture.Demo.Core.Interfaces;
using System.Collections.Generic;

namespace Architecture.Demo.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Add(CustomerDTO dto)
        {
            var customer = new Customer(dto.Name, dto.IsActive);
            return _customerRepository.Add(customer);
        }

        public Customer Get(int id)
        {            
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> List()
        {
            return _customerRepository.List();
        }

        public Customer Update(int id, CustomerDTO dto)
        {
            var customer = new Customer(dto.Name, dto.IsActive);
            customer.ID = id;

            _customerRepository.Update(customer);
            return Get(id);
        }
    }
}
