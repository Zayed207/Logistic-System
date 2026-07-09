using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.Shipment;

namespace Application.Services;

public class ShipmentService : CrudService<Shipment, ShipmentResponse, CreateShipmentRequest, UpdateShipmentRequest>, IShipmentService
{
    public ShipmentService(IShipmentRepository repository) : base(repository)
    {
    }

    protected override Shipment MapToEntity(CreateShipmentRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateShipmentRequest dto, Shipment entity) => throw new System.NotImplementedException();
    protected override ShipmentResponse MapToDto(Shipment entity) => throw new System.NotImplementedException();
}

