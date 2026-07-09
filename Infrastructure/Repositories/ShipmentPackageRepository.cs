using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ShipmentPackageRepository : BaseRepository<ShipmentPackage>, IShipmentPackageRepository
{
    public ShipmentPackageRepository(DbContext context) : base(context)
    {
    }
}
