using Domain.Entities;
using Application.DTOs.Vehicle;

namespace Application.Interfaces.Services;

public interface IVehicleService : ICrudService<Vehicle, VehicleResponse, CreateVehicleRequest, UpdateVehicleRequest>
{
}

