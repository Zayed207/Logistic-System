using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Common;

namespace Application.Services;

public abstract class CrudService<TEntity, TResponse, CreateTRequest, UpdateTRequest> : ICrudService<TEntity, TResponse, CreateTRequest, UpdateTRequest>
    where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository;

    protected CrudService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    protected abstract TEntity MapToEntity(CreateTRequest dto);
    protected abstract void MapToEntity(UpdateTRequest dto, TEntity entity);
    protected abstract TResponse MapToDto(TEntity entity);

    public virtual async Task<Result<TResponse>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result<TResponse>.NotFoundResult();

        return Result<TResponse>.SuccessResult(MapToDto(entity));
    }

    public virtual async Task<Result<IEnumerable<TResponse>>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = new List<TResponse>();
        foreach (var entity in entities)
            dtos.Add(MapToDto(entity));

        return Result<IEnumerable<TResponse>>.SuccessResult(dtos);
    }

    public virtual async Task<Result<TResponse>> CreateAsync(CreateTRequest dto)
    {
        var entity = MapToEntity(dto);
        await _repository.AddAsync(entity);
        return Result<TResponse>.CreatedResult(MapToDto(entity));
    }

    public virtual async Task<Result<TResponse>> UpdateAsync(int id, UpdateTRequest dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result<TResponse>.NotFoundResult();

        MapToEntity(dto, entity);
        await _repository.UpdateAsync(entity);
        return Result<TResponse>.UpdatedResult(MapToDto(entity));
    }

    public virtual async Task<Result<bool>> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result<bool>.NotFoundResult();

        await _repository.DeleteAsync(entity);
        return Result<bool>.DeletedResult();
    }
}

