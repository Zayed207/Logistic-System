using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Application.DTOs.Notification;

namespace Application.Services;

public class NotificationService : CrudService<Notification, NotificationResponse, CreateNotificationRequest, UpdateNotificationRequest>, INotificationService
{
    public NotificationService(INotificationRepository repository) : base(repository)
    {
    }

    protected override Notification MapToEntity(CreateNotificationRequest dto) => throw new System.NotImplementedException();
    protected override void MapToEntity(UpdateNotificationRequest dto, Notification entity) => throw new System.NotImplementedException();
    protected override NotificationResponse MapToDto(Notification entity) => throw new System.NotImplementedException();
}

