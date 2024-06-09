using Domain.Entities;
using Domain.Interfaces;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    public class RentalQuery
    {
        public async Task<IEnumerable<Rental>> GetRentals([Service] IRentalRepository rentalRepository)
        {
            return await rentalRepository.GetAllAsync();
        }

        public async Task<Rental> GetRentalById(Guid id, [Service] IRentalRepository rentalRepository)
        {
            return await rentalRepository.GetByIdAsync(id);
        }
    }
}

