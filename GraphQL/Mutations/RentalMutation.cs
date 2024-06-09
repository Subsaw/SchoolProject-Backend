using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Threading.Tasks;

namespace GraphQL.Mutations
{
    public class RentalMutation
    {
        public async Task<Rental> AddRental(Rental rental, [Service] IRentalRepository rentalRepository)
        {
            return await rentalRepository.AddAsync(rental);
        }

        public async Task<Rental> UpdateRental(Rental rental, [Service] IRentalRepository rentalRepository)
        {
            await rentalRepository.UpdateAsync(rental);
            return rental;
        }

        public async Task<bool> DeleteRental(Guid id, [Service] IRentalRepository rentalRepository)
        {
            await rentalRepository.DeleteAsync(id);
            return true;
        }
    }
}
