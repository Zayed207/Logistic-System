using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ShipmentAssignmentRepository : BaseRepository<ShipmentAssignment>, IShipmentAssignmentRepository
{
    public ShipmentAssignmentRepository(DbContext context) : base(context)
    {
    }
}
