using Domain.Entities;
using Application.DTOs.Notification;

namespace Application.Interfaces.Services;

public interface INotificationService : ICrudService<Notification, NotificationResponse, CreateNotificationRequest, UpdateNotificationRequest>
{
}
