using Application.Dtos;
using Application.Services;
using Domain.Entities;
using GraphQL.Mutations;

namespace GraphQL.Roots
{
    public class Mutation
    {
        public CarMutation Car => new CarMutation();
        public RentalMutation Rental => new RentalMutation();
        public CustomerMutation Customer => new CustomerMutation();
    }
}
