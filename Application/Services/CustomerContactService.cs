using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.CustomerContact;

namespace Application.Services;

public class CustomerContactService : CrudService<CustomerContact, CustomerContactResponse, CreateCustomerContactRequest, UpdateCustomerContactRequest>, ICustomerContactService
{
    public CustomerContactService(ICustomerContactRepository repository) : base(repository)
    {
    }

    protected override CustomerContact MapToEntity(CreateCustomerContactRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateCustomerContactRequest dto, CustomerContact entity) => throw new System.NotImplementedException();
    protected override CustomerContactResponse MapToDto(CustomerContact entity) => throw new System.NotImplementedException();
}

