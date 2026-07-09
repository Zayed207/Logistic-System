using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.Vehicle;

namespace Application.Services;

public class VehicleService : CrudService<Vehicle, VehicleResponse, CreateVehicleRequest, UpdateVehicleRequest>, IVehicleService
{
    public VehicleService(IVehicleRepository repository) : base(repository)
    {
    }

    protected override Vehicle MapToEntity(CreateVehicleRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateVehicleRequest dto, Vehicle entity) => throw new System.NotImplementedException();
    protected override VehicleResponse MapToDto(Vehicle entity) => throw new System.NotImplementedException();
}

