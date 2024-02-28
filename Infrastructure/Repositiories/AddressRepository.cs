using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositiories;

public class AddressRepository(DataContext context) : Repo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}