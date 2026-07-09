using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.ProofDocument;

namespace Application.Services;

public class ProofDocumentService : CrudService<ProofDocument, ProofDocumentResponse, CreateProofDocumentRequest, UpdateProofDocumentRequest>, IProofDocumentService
{
    public ProofDocumentService(IProofDocumentRepository repository) : base(repository)
    {
    }

    protected override ProofDocument MapToEntity(CreateProofDocumentRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateProofDocumentRequest dto, ProofDocument entity) => throw new System.NotImplementedException();
    protected override ProofDocumentResponse MapToDto(ProofDocument entity) => throw new System.NotImplementedException();
}

