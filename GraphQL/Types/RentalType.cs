using Domain.Entities;
using HotChocolate.Types;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQL.Types
{
    public class RentalType : ObjectType<Rental>
    {
        protected override void Configure(IObjectTypeDescriptor<Rental> descriptor)
        {
            descriptor.Field(r => r.RentalId).Type<NonNullType<IdType>>();
            descriptor.Field(r => r.CustomerId).Type<NonNullType<IdType>>();
            descriptor.Field(r => r.CarId).Type<NonNullType<IdType>>();
            descriptor.Field(r => r.StartDate).Type<NonNullType<DateTimeType>>();
            descriptor.Field(r => r.EndDate).Type<NonNullType<DateTimeType>>();
            descriptor.Field(r => r.TotalCost).Type<NonNullType<DecimalType>>();

            descriptor.Field(r => r.Customer).Type<CustomerType>()
                .ResolveWith<RentalResolver>(r => r.GetCustomer(default!, default!))
                .UseDbContext<RentalContext>();
            descriptor.Field(r => r.Car).Type<CarType>()
                .ResolveWith<RentalResolver>(r => r.GetCar(default!, default!))
                .UseDbContext<RentalContext>();
        }

        private class RentalResolver
        {
            public async Task<Customer> GetCustomer([Parent] Rental rental, [Service] RentalContext context)
            {
                return await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == rental.CustomerId)
                    ?? throw new KeyNotFoundException($"Customer with id: {rental.CustomerId} not found");
            }

            public async Task<Car> GetCar([Parent] Rental rental, [Service] RentalContext context)
            {
                return await context.Cars.FirstOrDefaultAsync(c => c.CarId == rental.CarId)
                    ?? throw new KeyNotFoundException($"Car with id: {rental.CarId} not found");
            }
        }
    }
}
