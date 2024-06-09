using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CarRepository : ICarRepository
{
    private readonly RentalContext _context;

    public CarRepository(RentalContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> GetByIdAsync(Guid id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<Car> AddAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task UpdateAsync(Car car)
    {
        _context.Entry(car).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}

