using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.User;

namespace Application.Services;

public class UserService : CrudService<User, UserResponse, CreateUserRequest, UpdateUserRequest>, IUserService
{
    public UserService(IUserRepository repository) : base(repository)
    {
    }

    protected override User MapToEntity(CreateUserRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateUserRequest dto, User entity) => throw new System.NotImplementedException();
    protected override UserResponse MapToDto(User entity) => throw new System.NotImplementedException();
}

