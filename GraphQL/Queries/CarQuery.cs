using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    public class CarQuery
    {
        public async Task<IEnumerable<Car>> GetCars([Service] ICarRepository carRepository)
        {
            return await carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarById(Guid id, [Service] ICarRepository carRepository)
        {
            return await carRepository.GetByIdAsync(id);
        }
    }
}
