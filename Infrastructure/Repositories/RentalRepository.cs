using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RentalRepository : IRentalRepository
{
    private readonly RentalContext _context;

    public RentalRepository(RentalContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rental>> GetAllAsync()
    {
        return await _context.Rentals
                             .Include(r => r.Customer)
                             .Include(r => r.Car)
                             .ToListAsync();
    }

    public async Task<Rental> GetByIdAsync(Guid id)
    {
        return await _context.Rentals
                             .Include(r => r.Customer)
                             .Include(r => r.Car)
                             .FirstOrDefaultAsync(r => r.RentalId == id);
    }

    public async Task<Rental> AddAsync(Rental rental)
    {
        rental.RentalId = Guid.NewGuid();
        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();
        return rental;
    }

    public async Task UpdateAsync(Rental rental)
    {
        _context.Entry(rental).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var rental = await _context.Rentals.FindAsync(id);
        if (rental != null)
        {
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
        }
    }
}

