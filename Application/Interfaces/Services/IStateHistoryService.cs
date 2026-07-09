using Domain.Entities;
using Application.DTOs.StateHistory;

namespace Application.Interfaces.Services;

public interface IStateHistoryService : ICrudService<StateHistory, StateHistoryResponse, CreateStateHistoryRequest, UpdateStateHistoryRequest>
{
}

