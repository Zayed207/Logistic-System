using Domain.Entities;
using Application.DTOs.ProofDocument;

namespace Application.Interfaces.Services;

public interface IProofDocumentService : ICrudService<ProofDocument, ProofDocumentResponse, CreateProofDocumentRequest, UpdateProofDocumentRequest>
{
}

