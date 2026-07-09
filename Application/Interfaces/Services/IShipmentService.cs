using Domain.Entities;
using Application.DTOs.Shipment;

namespace Application.Interfaces.Services;

public interface IShipmentService : ICrudService<Shipment, ShipmentResponse, CreateShipmentRequest, UpdateShipmentRequest>
{
}

