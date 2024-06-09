using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllAsync();
        Task<Rental> GetByIdAsync(Guid id);
        Task<Rental> AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task DeleteAsync(Guid id);
    }
}
