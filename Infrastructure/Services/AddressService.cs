using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositiories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService(DataContext dataContext)
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<AddressEntity> GetAddressAsync(string UserId)
    {
        var addressEntity = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.UserId == UserId);
        return addressEntity!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        _dataContext.Addresses.Add(entity);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var existing = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.UserId == entity.UserId);
        if (existing != null)
        {
            _dataContext.Entry(existing).CurrentValues.SetValues(entity);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        return false;
    }
}
