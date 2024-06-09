using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RentalContext>(options =>
    options.UseInMemoryDatabase("RentalDatabase"));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RentalService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
