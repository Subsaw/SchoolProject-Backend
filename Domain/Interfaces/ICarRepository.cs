using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(Guid id);
        Task<Car> AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Guid id);
    }
}
