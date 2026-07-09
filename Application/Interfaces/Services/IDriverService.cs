using Domain.Entities;
using Application.DTOs.Driver;

namespace Application.Interfaces.Services;

public interface IDriverService : ICrudService<Driver, DriverResponse, CreateDriverRequest, UpdateDriverRequest>
{
}

