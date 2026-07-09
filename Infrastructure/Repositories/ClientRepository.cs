using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(DbContext context) : base(context)
    {
    }
}
