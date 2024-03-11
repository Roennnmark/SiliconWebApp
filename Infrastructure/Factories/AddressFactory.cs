using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{
    public static AddressEntity Create()
    {
        try
        {
            return new AddressEntity();
        }
        catch { }
        return null!;
    }

    public static AddressEntity Create(string streetName_1, string streetName_2, string postalCode, string city)
    {
        try
        {
            return new AddressEntity
            {
                AddressLine_1 = streetName_1,
                AddressLine_2 = streetName_2,
                PostalCode = postalCode,
                City = city
            };
        }
        catch { }
        return null!;
    }

    public static AddressModel Create(AddressEntity entity)
    {
        try
        {
            return new AddressModel
            {
                Id = entity.Id,
                AddressLine_1 = entity.AddressLine_1,
                AddressLine_2 = entity.AddressLine_2,
                PostalCode = entity.PostalCode,
                City = entity.City
            };
        }
        catch { }
        return null!;
    }

}
