using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.Driver;

namespace Application.Services;

public class DriverService : CrudService<Driver, DriverResponse, CreateDriverRequest, UpdateDriverRequest>, IDriverService
{
    public DriverService(IDriverRepository repository) : base(repository)
    {
    }

    protected override Driver MapToEntity(CreateDriverRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateDriverRequest dto, Driver entity) => throw new System.NotImplementedException();
    protected override DriverResponse MapToDto(Driver entity) => throw new System.NotImplementedException();
}

