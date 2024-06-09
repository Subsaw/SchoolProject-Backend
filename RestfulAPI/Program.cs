using Microsoft.EntityFrameworkCore;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using RestfulApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RentalContext>(options =>
    options.UseInMemoryDatabase("RentalDatabase"));


builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();


builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RentalService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SuperHeaderMiddleware>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
