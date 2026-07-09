using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class StateHistoryRepository : BaseRepository<StateHistory>, IStateHistoryRepository
{
    public StateHistoryRepository(DbContext context) : base(context)
    {
    }
}
