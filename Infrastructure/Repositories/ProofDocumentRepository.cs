using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ProofDocumentRepository : BaseRepository<ProofDocument>, IProofDocumentRepository
{
    public ProofDocumentRepository(DbContext context) : base(context)
    {
    }
}
