using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Services;
using Application.Services;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<ICustomerContactService, CustomerContactService>();
        services.AddScoped<IShipmentRequestService, ShipmentRequestService>();
        services.AddScoped<IShipmentPackageService, ShipmentPackageService>();
        services.AddScoped<IShipmentService, ShipmentService>();
        services.AddScoped<IShipmentAssignmentService, ShipmentAssignmentService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IStateHistoryService, StateHistoryService>();
        services.AddScoped<IProofDocumentService, ProofDocumentService>();
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}
