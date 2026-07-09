using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class CustomerContactRepository : BaseRepository<CustomerContact>, ICustomerContactRepository
{
    public CustomerContactRepository(DbContext context) : base(context)
    {
    }
}
