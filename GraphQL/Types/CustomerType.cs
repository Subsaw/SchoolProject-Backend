using Domain.Entities;
using HotChocolate.Types;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQL.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Field(c => c.CustomerId).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.FirstName).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.LastName).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.Email).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.PhoneNumber).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.DateOfBirth).Type<NonNullType<DateTimeType>>();
            descriptor.Field(c => c.DriverLicenseNumber).Type<NonNullType<StringType>>();

            descriptor.Field(c => c.Rentals).Type<ListType<RentalType>>()
                .ResolveWith<CustomerResolver>(c => c.GetRentals(default!, default!))
                .UseDbContext<RentalContext>();
        }

        private class CustomerResolver
        {
            public async Task<IEnumerable<Rental>> GetRentals([Parent] Customer customer, [Service] RentalContext context)
            {
                return await context.Rentals.Where(r => r.CustomerId == customer.CustomerId).ToListAsync();
            }
        }
    }
}
