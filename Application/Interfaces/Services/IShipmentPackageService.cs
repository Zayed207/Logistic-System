using Domain.Entities;
using Application.DTOs.ShipmentPackage;

namespace Application.Interfaces.Services;

public interface IShipmentPackageService : ICrudService<ShipmentPackage, ShipmentPackageResponse, CreateShipmentPackageRequest, UpdateShipmentPackageRequest>
{
}

