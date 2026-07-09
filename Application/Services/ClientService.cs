using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.Client;

namespace Application.Services;

public class ClientService : CrudService<Client, ClientResponse, CreateClientRequest, UpdateClientRequest>, IClientService
{
    public ClientService(IClientRepository repository) : base(repository)
    {
    }

    protected override Client MapToEntity(CreateClientRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateClientRequest dto, Client entity) => throw new System.NotImplementedException();
    protected override ClientResponse MapToDto(Client entity) => throw new System.NotImplementedException();
}

