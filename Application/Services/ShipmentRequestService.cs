using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.ShipmentRequest;

namespace Application.Services;

public class ShipmentRequestService : CrudService<ShipmentRequest, ShipmentRequestResponse, CreateShipmentRequestRequest, UpdateShipmentRequestRequest>, IShipmentRequestService
{
    public ShipmentRequestService(IShipmentRequestRepository repository) : base(repository)
    {
    }

    protected override ShipmentRequest MapToEntity(CreateShipmentRequestRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateShipmentRequestRequest dto, ShipmentRequest entity) => throw new System.NotImplementedException();
    protected override ShipmentRequestResponse MapToDto(ShipmentRequest entity) => throw new System.NotImplementedException();
}

