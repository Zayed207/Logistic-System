using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<ICustomerContactRepository, CustomerContactRepository>();
        services.AddScoped<IShipmentRequestRepository, ShipmentRequestRepository>();
        services.AddScoped<IShipmentPackageRepository, ShipmentPackageRepository>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShipmentAssignmentRepository, ShipmentAssignmentRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IStateHistoryRepository, StateHistoryRepository>();
        services.AddScoped<IProofDocumentRepository, ProofDocumentRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        return services;
    }
}
