import os

entities = ['User', 'Client', 'Driver', 'CustomerContact', 'ShipmentRequest', 'ShipmentPackage', 'Shipment', 'ShipmentAssignment', 'Vehicle', 'StateHistory', 'ProofDocument', 'Notification']

os.makedirs('Domain/Common', exist_ok=True)
os.makedirs('Application/Interfaces/Repositories', exist_ok=True)
os.makedirs('Application/Interfaces/Services', exist_ok=True)
os.makedirs('Application/Services', exist_ok=True)
os.makedirs('Infrastructure/Repositories', exist_ok=True)
os.makedirs('API/Helpers', exist_ok=True)
os.makedirs('API/Controllers', exist_ok=True)

# 1. ResultStatus
with open('Domain/Common/ResultStatus.cs', 'w') as f:
    f.write("""namespace Domain.Common;

public enum ResultStatus
{
    Success,
    Created,
    Updated,
    Deleted,
    NotFound,
    ValidationError,
    Conflict,
    Unauthorized,
    Forbidden,
    BadRequest,
    Error
}
""")

# 2. Result
with open('Domain/Common/Result.cs', 'w') as f:
    f.write("""namespace Domain.Common;

public class Result<T>
{
    public ResultStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static Result<T> SuccessResult(T data, string message = "") => new() { Status = ResultStatus.Success, Data = data, Message = message };
    public static Result<T> CreatedResult(T data, string message = "") => new() { Status = ResultStatus.Created, Data = data, Message = message };
    public static Result<T> UpdatedResult(T data, string message = "") => new() { Status = ResultStatus.Updated, Data = data, Message = message };
    public static Result<T> DeletedResult(string message = "") => new() { Status = ResultStatus.Deleted, Message = message };
    public static Result<T> NotFoundResult(string message = "Not Found") => new() { Status = ResultStatus.NotFound, Message = message };
    public static Result<T> BadRequestResult(string message = "Bad Request") => new() { Status = ResultStatus.BadRequest, Message = message };
    public static Result<T> ErrorResult(string message = "Error") => new() { Status = ResultStatus.Error, Message = message };
}
""")

# 3. IBaseRepository
with open('Application/Interfaces/Repositories/IBaseRepository.cs', 'w') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<bool> ExistsAsync(int id);
}
""")

# 4. ICrudService
with open('Application/Interfaces/Services/ICrudService.cs', 'w') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Interfaces.Services;

public interface ICrudService<TEntity, TReadDto, TCreateDto, TUpdateDto>
{
    Task<Result<TReadDto>> GetByIdAsync(int id);
    Task<Result<IEnumerable<TReadDto>>> GetAllAsync();
    Task<Result<TReadDto>> CreateAsync(TCreateDto dto);
    Task<Result<TReadDto>> UpdateAsync(int id, TUpdateDto dto);
    Task<Result<bool>> DeleteAsync(int id);
}
""")

# 5. CrudService
with open('Application/Services/CrudService.cs', 'w') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Common;

namespace Application.Services;

public abstract class CrudService<TEntity, TReadDto, TCreateDto, TUpdateDto> : ICrudService<TEntity, TReadDto, TCreateDto, TUpdateDto>
    where TEntity : class
{
    protected readonly IBaseRepository<TEntity> _repository;

    protected CrudService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    protected abstract TEntity MapToEntity(TCreateDto dto);
    protected abstract void MapToEntity(TUpdateDto dto, TEntity entity);
    protected abstract TReadDto MapToDto(TEntity entity);

    public virtual async Task<Result<TReadDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result<TReadDto>.NotFoundResult();

        return Result<TReadDto>.SuccessResult(MapToDto(entity));
    }

    public virtual async Task<Result<IEnumerable<TReadDto>>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = new List<TReadDto>();
        foreach (var entity in entities)
            dtos.Add(MapToDto(entity));

        return Result<IEnumerable<TReadDto>>.SuccessResult(dtos);
    }

    public virtual async Task<Result<TReadDto>> CreateAsync(TCreateDto dto)
    {
        var entity = MapToEntity(dto);
        await _repository.AddAsync(entity);
        return Result<TReadDto>.CreatedResult(MapToDto(entity));
    }

    public virtual async Task<Result<TReadDto>> UpdateAsync(int id, TUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result<TReadDto>.NotFoundResult();

        MapToEntity(dto, entity);
        await _repository.UpdateAsync(entity);
        return Result<TReadDto>.UpdatedResult(MapToDto(entity));
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
""")

# 6. BaseRepository
with open('Infrastructure/Repositories/BaseRepository.cs', 'w') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<bool> ExistsAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null;
    }
}
""")

# 7. ApiResultMapper
with open('API/Helpers/ApiResultMapper.cs', 'w') as f:
    f.write("""using Microsoft.AspNetCore.Mvc;
using Domain.Common;

namespace API.Helpers;

public static class ApiResultMapper
{
    public static IActionResult ToActionResult<T>(Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => new OkObjectResult(result),
            ResultStatus.Created => new ObjectResult(result) { StatusCode = 201 },
            ResultStatus.Updated => new OkObjectResult(result),
            ResultStatus.Deleted => new NoContentResult(),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Forbidden => new ObjectResult(result) { StatusCode = 403 },
            ResultStatus.BadRequest => new BadRequestObjectResult(result),
            ResultStatus.Error => new ObjectResult(result) { StatusCode = 500 },
            _ => new ObjectResult(result) { StatusCode = 500 }
        };
    }
}
""")

for entity in entities:
    # IRepository
    with open(f'Application/Interfaces/Repositories/I{entity}Repository.cs', 'w') as f:
        f.write(f"""using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface I{entity}Repository : IBaseRepository<{entity}>
{{
}}
""")
    # Repository
    with open(f'Infrastructure/Repositories/{entity}Repository.cs', 'w') as f:
        f.write(f"""using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class {entity}Repository : BaseRepository<{entity}>, I{entity}Repository
{{
    public {entity}Repository(DbContext context) : base(context)
    {{
    }}
}}
""")
    # IService
    with open(f'Application/Interfaces/Services/I{entity}Service.cs', 'w') as f:
        f.write(f"""using Domain.Entities;
using Application.DTOs;

namespace Application.Interfaces.Services;

public interface I{entity}Service : ICrudService<{entity}, {entity}ReadDto, {entity}CreateDto, {entity}UpdateDto>
{{
}}
""")
    # Service
    with open(f'Application/Services/{entity}Service.cs', 'w') as f:
        f.write(f"""using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs;

namespace Application.Services;

public class {entity}Service : CrudService<{entity}, {entity}ReadDto, {entity}CreateDto, {entity}UpdateDto>, I{entity}Service
{{
    public {entity}Service(I{entity}Repository repository) : base(repository)
    {{
    }}

    protected override {entity} MapToEntity({entity}CreateDto dto) => throw new System.NotImplementedException();
    protected override void MapToEntity({entity}UpdateDto dto, {entity} entity) => throw new System.NotImplementedException();
    protected override {entity}ReadDto MapToDto({entity} entity) => throw new System.NotImplementedException();
}}
""")
    # Controller
    with open(f'API/Controllers/{entity}Controller.cs', 'w') as f:
        f.write(f"""using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.DTOs;
using API.Helpers;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class {entity}Controller : ControllerBase
{{
    private readonly I{entity}Service _service;

    public {entity}Controller(I{entity}Service service)
    {{
        _service = service;
    }}

    [HttpGet("{{id}}")]
    public async Task<IActionResult> GetById(int id)
    {{
        var result = await _service.GetByIdAsync(id);
        return ApiResultMapper.ToActionResult(result);
    }}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {{
        var result = await _service.GetAllAsync();
        return ApiResultMapper.ToActionResult(result);
    }}

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] {entity}CreateDto dto)
    {{
        var result = await _service.CreateAsync(dto);
        return ApiResultMapper.ToActionResult(result);
    }}

    [HttpPut("{{id}}")]
    public async Task<IActionResult> Update(int id, [FromBody] {entity}UpdateDto dto)
    {{
        var result = await _service.UpdateAsync(id, dto);
        return ApiResultMapper.ToActionResult(result);
    }}

    [HttpDelete("{{id}}")]
    public async Task<IActionResult> Delete(int id)
    {{
        var result = await _service.DeleteAsync(id);
        return ApiResultMapper.ToActionResult(result);
    }}
}}
""")

# Application DI
with open('Application/DependencyInjection.cs', 'w') as f:
    f.write("""using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Services;
using Application.Services;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
""")
    for entity in entities:
        f.write(f'        services.AddScoped<I{entity}Service, {entity}Service>();\n')
    f.write("""        return services;
    }
}
""")

# Infrastructure DI
with open('Infrastructure/DependencyInjection.cs', 'w') as f:
    f.write("""using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
""")
    for entity in entities:
        f.write(f'        services.AddScoped<I{entity}Repository, {entity}Repository>();\n')
    f.write("""        return services;
    }
}
""")

# Program.cs
with open('API/Program.cs', 'w') as f:
    f.write("""using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.RateLimiting;
using Infrastructure;
using Application;
using Microsoft.EntityFrameworkCore;
// using Infrastructure.Data; // Assuming DbContext is here

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Fixed", opt =>
    {
        opt.Window = System.TimeSpan.FromSeconds(10);
        opt.PermitLimit = 100;
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Assuming DbContext registration
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\\\mssqllocaldb;Database=LogisticDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

// Dependency Injection from Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
""")
