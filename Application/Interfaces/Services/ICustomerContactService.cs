using Domain.Entities;
using Application.DTOs.CustomerContact;

namespace Application.Interfaces.Services;

public interface ICustomerContactService : ICrudService<CustomerContact, CustomerContactResponse, CreateCustomerContactRequest, UpdateCustomerContactRequest>
{
}

