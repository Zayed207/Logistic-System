using Domain.Entities;
using Application.DTOs.User;

namespace Application.Interfaces.Services;

public interface IUserService : ICrudService<User, UserResponse, CreateUserRequest, UpdateUserRequest>
{
}

