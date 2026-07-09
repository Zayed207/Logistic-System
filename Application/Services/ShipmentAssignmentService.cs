using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.ShipmentAssignment;

namespace Application.Services;

public class ShipmentAssignmentService : CrudService<ShipmentAssignment, ShipmentAssignmentResponse, CreateShipmentAssignmentRequest, UpdateShipmentAssignmentRequest>, IShipmentAssignmentService
{
    public ShipmentAssignmentService(IShipmentAssignmentRepository repository) : base(repository)
    {
    }

    protected override ShipmentAssignment MapToEntity(CreateShipmentAssignmentRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateShipmentAssignmentRequest dto, ShipmentAssignment entity) => throw new System.NotImplementedException();
    protected override ShipmentAssignmentResponse MapToDto(ShipmentAssignment entity) => throw new System.NotImplementedException();
}

