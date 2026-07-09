using Domain.Entities;
using Application.DTOs.ShipmentRequest;

namespace Application.Interfaces.Services;

public interface IShipmentRequestService : ICrudService<ShipmentRequest, ShipmentRequestResponse, CreateShipmentRequestRequest, UpdateShipmentRequestRequest>
{
}

