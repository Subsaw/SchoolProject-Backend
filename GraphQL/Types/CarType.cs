using Domain.Entities;
using HotChocolate.Types;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQL.Types
{
    public class CarType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.Field(c => c.CarId).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.Model).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.Year).Type<NonNullType<IntType>>();
            descriptor.Field(c => c.LicensePlate).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.DailyRate).Type<NonNullType<DecimalType>>();
            descriptor.Field(c => c.Status).Type<NonNullType<StringType>>();

            descriptor.Field(c => c.Rentals).Type<ListType<RentalType>>()
                .ResolveWith<CarResolver>(c => c.GetRentals(default!, default!))
                .UseDbContext<RentalContext>();
        }

        private class CarResolver
        {
            public async Task<IEnumerable<Rental>> GetRentals([Parent] Car car, [Service] RentalContext context)
            {
                return await context.Rentals.Where(r => r.CarId == car.CarId).ToListAsync();
            }
        }
    }
}
