$dtosDir = "Application/DTOs"
if (-not (Test-Path $dtosDir)) {
    New-Item -ItemType Directory -Force -Path $dtosDir | Out-Null
}

$entities = @('User', 'Client', 'Driver', 'CustomerContact', 'ShipmentRequest', 'ShipmentPackage', 'Shipment', 'ShipmentAssignment', 'Vehicle', 'StateHistory', 'ProofDocument', 'Notification')

foreach ($entity in $entities) {
    $entityDir = "$dtosDir"
    # if (-not (Test-Path $entityDir)) {
    #     New-Item -ItemType Directory -Force -Path $entityDir | Out-Null
    # }
}

# 1. User
$userDto = @"
namespace Application.DTOs;

public record UserReadDto(int Id, string Username, string Email, string PhoneNumber, System.DateTime CreatedAt);
public record UserCreateDto(string Username, string Email, string PhoneNumber, string Password);
public record UserUpdateDto(string Username, string Email, string PhoneNumber);
"@
Set-Content -Path "$dtosDir/UserDtos.cs" -Value $userDto

# 2. Client
$clientDto = @"
namespace Application.DTOs;

public record ClientReadDto(int Id, int UserId, string CompanyName, string TaxNumber);
public record ClientCreateDto(int UserId, string CompanyName, string TaxNumber);
public record ClientUpdateDto(string CompanyName, string TaxNumber);
"@
Set-Content -Path "$dtosDir/ClientDtos.cs" -Value $clientDto

# 3. Driver
$driverDto = @"
namespace Application.DTOs;

public record DriverReadDto(int Id, int UserId, string LicenseNumber, byte Status);
public record DriverCreateDto(int UserId, string LicenseNumber, byte Status);
public record DriverUpdateDto(string LicenseNumber, byte Status);
"@
Set-Content -Path "$dtosDir/DriverDtos.cs" -Value $driverDto

# 4. CustomerContact
$customerContactDto = @"
namespace Application.DTOs;

public record CustomerContactReadDto(int Id, int UserId, string AddressLine, string City, string Country, string ContactPhone);
public record CustomerContactCreateDto(int UserId, string AddressLine, string City, string Country, string ContactPhone);
public record CustomerContactUpdateDto(string AddressLine, string City, string Country, string ContactPhone);
"@
Set-Content -Path "$dtosDir/CustomerContactDtos.cs" -Value $customerContactDto

# 5. ShipmentRequest
$shipmentRequestDto = @"
namespace Application.DTOs;

public record ShipmentRequestReadDto(int Id, int SenderId, int ReceiverId, int PickupContactId, int DeliveryContactId, byte RequestStatus, byte Priority, decimal EstimatedCost, System.DateTime CreatedAt);
public record ShipmentRequestCreateDto(int SenderId, int ReceiverId, int PickupContactId, int DeliveryContactId, byte Priority, decimal EstimatedCost);
public record ShipmentRequestUpdateDto(byte RequestStatus, byte Priority, decimal EstimatedCost);
"@
Set-Content -Path "$dtosDir/ShipmentRequestDtos.cs" -Value $shipmentRequestDto

# 6. ShipmentPackage
$shipmentPackageDto = @"
namespace Application.DTOs;

public record ShipmentPackageReadDto(int Id, int ShipmentRequestId, byte Category, decimal Weight, decimal Volume, string Description);
public record ShipmentPackageCreateDto(int ShipmentRequestId, byte Category, decimal Weight, decimal Volume, string Description);
public record ShipmentPackageUpdateDto(byte Category, decimal Weight, decimal Volume, string Description);
"@
Set-Content -Path "$dtosDir/ShipmentPackageDtos.cs" -Value $shipmentPackageDto

# 7. Shipment
$shipmentDto = @"
namespace Application.DTOs;

public record ShipmentReadDto(int Id, int ShipmentRequestId, string TrackingNumber, byte Status, decimal FinalCost, System.DateTime CreatedAt);
public record ShipmentCreateDto(int ShipmentRequestId, string TrackingNumber, byte Status, decimal FinalCost);
public record ShipmentUpdateDto(byte Status, decimal FinalCost);
"@
Set-Content -Path "$dtosDir/ShipmentDtos.cs" -Value $shipmentDto

# 8. ShipmentAssignment
$shipmentAssignmentDto = @"
namespace Application.DTOs;

public record ShipmentAssignmentReadDto(int Id, int ShipmentId, int DriverId, int VehicleId, System.DateTime AssignedAt, System.DateTime? UnassignedAt, bool IsActive);
public record ShipmentAssignmentCreateDto(int ShipmentId, int DriverId, int VehicleId, System.DateTime AssignedAt, bool IsActive);
public record ShipmentAssignmentUpdateDto(System.DateTime? UnassignedAt, bool IsActive);
"@
Set-Content -Path "$dtosDir/ShipmentAssignmentDtos.cs" -Value $shipmentAssignmentDto

# 9. Vehicle
$vehicleDto = @"
namespace Application.DTOs;

public record VehicleReadDto(int Id, string PlateNumber, string Model, byte Status);
public record VehicleCreateDto(string PlateNumber, string Model, byte Status);
public record VehicleUpdateDto(string PlateNumber, string Model, byte Status);
"@
Set-Content -Path "$dtosDir/VehicleDtos.cs" -Value $vehicleDto

# 10. StateHistory
$stateHistoryDto = @"
namespace Application.DTOs;

public record StateHistoryReadDto(int Id, int ShipmentId, byte Status, string Remarks, System.DateTime CreatedAt);
public record StateHistoryCreateDto(int ShipmentId, byte Status, string Remarks, System.DateTime CreatedAt);
public record StateHistoryUpdateDto(string Remarks);
"@
Set-Content -Path "$dtosDir/StateHistoryDtos.cs" -Value $stateHistoryDto

# 11. ProofDocument
$proofDocumentDto = @"
namespace Application.DTOs;

public record ProofDocumentReadDto(int Id, int ShipmentId, byte DocumentType, string FileUrl, System.DateTime UploadedAt);
public record ProofDocumentCreateDto(int ShipmentId, byte DocumentType, string FileUrl);
public record ProofDocumentUpdateDto(byte DocumentType, string FileUrl);
"@
Set-Content -Path "$dtosDir/ProofDocumentDtos.cs" -Value $proofDocumentDto

# 12. Notification
$notificationDto = @"
namespace Application.DTOs;

public record NotificationReadDto(int Id, int UserId, byte NotificationType, string Message, bool IsRead, System.DateTime CreatedAt);
public record NotificationCreateDto(int UserId, byte NotificationType, string Message);
public record NotificationUpdateDto(bool IsRead);
"@
Set-Content -Path "$dtosDir/NotificationDtos.cs" -Value $notificationDto
