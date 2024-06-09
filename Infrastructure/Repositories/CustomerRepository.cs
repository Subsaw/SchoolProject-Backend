using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly RentalContext _context;

    public CustomerRepository(RentalContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> GetByEmailAsync(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}

