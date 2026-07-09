using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.StateHistory;

namespace Application.Services;

public class StateHistoryService : CrudService<StateHistory, StateHistoryResponse, CreateStateHistoryRequest, UpdateStateHistoryRequest>, IStateHistoryService
{
    public StateHistoryService(IStateHistoryRepository repository) : base(repository)
    {
    }

    protected override StateHistory MapToEntity(CreateStateHistoryRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateStateHistoryRequest dto, StateHistory entity) => throw new System.NotImplementedException();
    protected override StateHistoryResponse MapToDto(StateHistory entity) => throw new System.NotImplementedException();
}

