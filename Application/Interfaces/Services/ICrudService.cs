using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Interfaces.Services;

public interface ICrudService<TEntity, TResponse, CreateTRequest, UpdateTRequest>
{
    Task<Result<TResponse>> GetByIdAsync(int id);
    Task<Result<IEnumerable<TResponse>>> GetAllAsync();
    Task<Result<TResponse>> CreateAsync(CreateTRequest dto);
    Task<Result<TResponse>> UpdateAsync(int id, UpdateTRequest dto);
    Task<Result<bool>> DeleteAsync(int id);
}

