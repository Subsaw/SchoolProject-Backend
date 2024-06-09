using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    public class CustomerQuery
    {
        public async Task<IEnumerable<Customer>> GetCustomers([Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id, [Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> GetCustomerByEmail(string email, [Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.GetByEmailAsync(email);
        }
    }
}
