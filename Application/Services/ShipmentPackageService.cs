using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.ShipmentPackage;

namespace Application.Services;

public class ShipmentPackageService : CrudService<ShipmentPackage, ShipmentPackageResponse, CreateShipmentPackageRequest, UpdateShipmentPackageRequest>, IShipmentPackageService
{
    public ShipmentPackageService(IShipmentPackageRepository repository) : base(repository)
    {
    }

    protected override ShipmentPackage MapToEntity(CreateShipmentPackageRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateShipmentPackageRequest dto, ShipmentPackage entity) => throw new System.NotImplementedException();
    protected override ShipmentPackageResponse MapToDto(ShipmentPackage entity) => throw new System.NotImplementedException();
}

