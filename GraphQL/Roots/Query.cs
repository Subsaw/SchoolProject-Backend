using Application.Dtos;
using Application.Services;
using GraphQL.Queries;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Roots
{
    public class Query
    {
        public CarQuery Car => new CarQuery();
        public RentalQuery Rental => new RentalQuery();
        public CustomerQuery Customer => new CustomerQuery();

    }
}
