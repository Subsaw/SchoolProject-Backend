using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Threading.Tasks;

namespace GraphQL.Mutations
{
    public class CustomerMutation
    {
        public async Task<Customer> AddCustomer(Customer customer, [Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.AddAsync(customer);
        }

        public async Task<Customer> UpdateCustomer(Customer customer, [Service] ICustomerRepository customerRepository)
        {
            await customerRepository.UpdateAsync(customer);
            return customer;
        }

        public async Task<bool> DeleteCustomer(Guid id, [Service] ICustomerRepository customerRepository)
        {
            await customerRepository.DeleteAsync(id);
            return true;
        }
    }
}
