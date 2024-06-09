using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}
