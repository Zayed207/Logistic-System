using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ShipmentRequestRepository : BaseRepository<ShipmentRequest>, IShipmentRequestRepository
{
    public ShipmentRequestRepository(DbContext context) : base(context)
    {
    }
}
