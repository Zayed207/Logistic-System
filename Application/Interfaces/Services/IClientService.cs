using Domain.Entities;
using Application.DTOs.Client;

namespace Application.Interfaces.Services;

public interface IClientService : ICrudService<Client, ClientResponse, CreateClientRequest, UpdateClientRequest>
{
}

