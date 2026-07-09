using Domain.Entities;
using Application.DTOs.ShipmentAssignment;

namespace Application.Interfaces.Services;

public interface IShipmentAssignmentService : ICrudService<ShipmentAssignment, ShipmentAssignmentResponse, CreateShipmentAssignmentRequest, UpdateShipmentAssignmentRequest>
{
}

