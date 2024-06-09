using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Threading.Tasks;

namespace GraphQL.Mutations
{
    public class CarMutation
    {
        public async Task<Car> AddCar(Car car, [Service] ICarRepository carRepository)
        {
            return await carRepository.AddAsync(car);
        }

        public async Task<Car> UpdateCar(Car car, [Service] ICarRepository carRepository)
        {
            await carRepository.UpdateAsync(car);
            return car;
        }

        public async Task<bool> DeleteCar(Guid id, [Service] ICarRepository carRepository)
        {
            await carRepository.DeleteAsync(id);
            return true;
        }
    }
}
