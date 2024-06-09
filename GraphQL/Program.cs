using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GraphQL.Mutations;
using GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using GraphQL.Roots;

namespace GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddDbContext<RentalContext>(options =>
                options.UseInMemoryDatabase("RentalDb"));
           
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IRentalRepository, RentalRepository>();

            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<CarType>()
                .AddType<CustomerType>()
                .AddType<RentalType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapGraphQL();

            app.Run();
        }
    }
}
