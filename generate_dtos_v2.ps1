$dtosDir = "Application/DTOs"
if (-not (Test-Path $dtosDir)) {
    New-Item -ItemType Directory -Force -Path $dtosDir | Out-Null
}

$entities = @('User', 'Client', 'Driver', 'CustomerContact', 'ShipmentRequest', 'ShipmentPackage', 'Shipment', 'ShipmentAssignment', 'Vehicle', 'StateHistory', 'ProofDocument', 'Notification')

# Delete old DTO files
Get-ChildItem -Path $dtosDir -Filter "*Dtos.cs" | Remove-Item -Force

# Generate new DTOs
# 1. User
$userDto = @"
namespace Application.DTOs;

public record UserResponse(int Id, string Username, string Email, string PhoneNumber, System.DateTime CreatedAt);
public record CreateUserRequest(string Username, string Email, string PhoneNumber, string Password);
public record UpdateUserRequest(string Username, string Email, string PhoneNumber);
"@
Set-Content -Path "$dtosDir/UserRequests.cs" -Value $userDto

# 2. Client
$clientDto = @"
namespace Application.DTOs;

public record ClientResponse(int Id, int UserId, string CompanyName, string TaxNumber);
public record CreateClientRequest(int UserId, string CompanyName, string TaxNumber);
public record UpdateClientRequest(string CompanyName, string TaxNumber);
"@
Set-Content -Path "$dtosDir/ClientRequests.cs" -Value $clientDto

# 3. Driver
$driverDto = @"
namespace Application.DTOs;

public record DriverResponse(int Id, int UserId, string LicenseNumber, byte Status);
public record CreateDriverRequest(int UserId, string LicenseNumber, byte Status);
public record UpdateDriverRequest(string LicenseNumber, byte Status);
"@
Set-Content -Path "$dtosDir/DriverRequests.cs" -Value $driverDto

# 4. CustomerContact
$customerContactDto = @"
namespace Application.DTOs;

public record CustomerContactResponse(int Id, int UserId, string AddressLine, string City, string Country, string ContactPhone);
public record CreateCustomerContactRequest(int UserId, string AddressLine, string City, string Country, string ContactPhone);
public record UpdateCustomerContactRequest(string AddressLine, string City, string Country, string ContactPhone);
"@
Set-Content -Path "$dtosDir/CustomerContactRequests.cs" -Value $customerContactDto

# 5. ShipmentRequest
$shipmentRequestDto = @"
namespace Application.DTOs;

public record ShipmentRequestResponse(int Id, int SenderId, int ReceiverId, int PickupContactId, int DeliveryContactId, byte RequestStatus, byte Priority, decimal EstimatedCost, System.DateTime CreatedAt);
public record CreateShipmentRequestRequest(int SenderId, int ReceiverId, int PickupContactId, int DeliveryContactId, byte Priority, decimal EstimatedCost);
public record UpdateShipmentRequestRequest(byte RequestStatus, byte Priority, decimal EstimatedCost);
"@
Set-Content -Path "$dtosDir/ShipmentRequestRequests.cs" -Value $shipmentRequestDto

# 6. ShipmentPackage
$shipmentPackageDto = @"
namespace Application.DTOs;

public record ShipmentPackageResponse(int Id, int ShipmentRequestId, byte Category, decimal Weight, decimal Volume, string Description);
public record CreateShipmentPackageRequest(int ShipmentRequestId, byte Category, decimal Weight, decimal Volume, string Description);
public record UpdateShipmentPackageRequest(byte Category, decimal Weight, decimal Volume, string Description);
"@
Set-Content -Path "$dtosDir/ShipmentPackageRequests.cs" -Value $shipmentPackageDto

# 7. Shipment
$shipmentDto = @"
namespace Application.DTOs;

public record ShipmentResponse(int Id, int ShipmentRequestId, string TrackingNumber, byte Status, decimal FinalCost, System.DateTime CreatedAt);
public record CreateShipmentRequest(int ShipmentRequestId, string TrackingNumber, byte Status, decimal FinalCost);
public record UpdateShipmentRequest(byte Status, decimal FinalCost);
"@
Set-Content -Path "$dtosDir/ShipmentRequests.cs" -Value $shipmentDto

# 8. ShipmentAssignment
$shipmentAssignmentDto = @"
namespace Application.DTOs;

public record ShipmentAssignmentResponse(int Id, int ShipmentId, int DriverId, int VehicleId, System.DateTime AssignedAt, System.DateTime? UnassignedAt, bool IsActive);
public record CreateShipmentAssignmentRequest(int ShipmentId, int DriverId, int VehicleId, System.DateTime AssignedAt, bool IsActive);
public record UpdateShipmentAssignmentRequest(System.DateTime? UnassignedAt, bool IsActive);
"@
Set-Content -Path "$dtosDir/ShipmentAssignmentRequests.cs" -Value $shipmentAssignmentDto

# 9. Vehicle
$vehicleDto = @"
namespace Application.DTOs;

public record VehicleResponse(int Id, string PlateNumber, string Model, byte Status);
public record CreateVehicleRequest(string PlateNumber, string Model, byte Status);
public record UpdateVehicleRequest(string PlateNumber, string Model, byte Status);
"@
Set-Content -Path "$dtosDir/VehicleRequests.cs" -Value $vehicleDto

# 10. StateHistory
$stateHistoryDto = @"
namespace Application.DTOs;

public record StateHistoryResponse(int Id, int ShipmentId, byte Status, string Remarks, System.DateTime CreatedAt);
public record CreateStateHistoryRequest(int ShipmentId, byte Status, string Remarks, System.DateTime CreatedAt);
public record UpdateStateHistoryRequest(string Remarks);
"@
Set-Content -Path "$dtosDir/StateHistoryRequests.cs" -Value $stateHistoryDto

# 11. ProofDocument
$proofDocumentDto = @"
namespace Application.DTOs;

public record ProofDocumentResponse(int Id, int ShipmentId, byte DocumentType, string FileUrl, System.DateTime UploadedAt);
public record CreateProofDocumentRequest(int ShipmentId, byte DocumentType, string FileUrl);
public record UpdateProofDocumentRequest(byte DocumentType, string FileUrl);
"@
Set-Content -Path "$dtosDir/ProofDocumentRequests.cs" -Value $proofDocumentDto

# 12. Notification
$notificationDto = @"
namespace Application.DTOs;

public record NotificationResponse(int Id, int UserId, byte NotificationType, string Message, bool IsRead, System.DateTime CreatedAt);
public record CreateNotificationRequest(int UserId, byte NotificationType, string Message);
public record UpdateNotificationRequest(bool IsRead);
"@
Set-Content -Path "$dtosDir/NotificationRequests.cs" -Value $notificationDto

# Refactor the codebase to use the new names
$filesToRefactor = Get-ChildItem -Path .\Application, .\API -Recurse -Filter *.cs -File

foreach ($file in $filesToRefactor) {
    if ($file.FullName -like "*\DTOs\*") { continue } # Skip DTO files

    $content = Get-Content -Path $file.FullName -Raw

    $newContent = [System.Text.RegularExpressions.Regex]::Replace($content, "\b(\w+)CreateDto\b", "Create`$1Request")
    $newContent = [System.Text.RegularExpressions.Regex]::Replace($newContent, "\b(\w+)UpdateDto\b", "Update`$1Request")
    $newContent = [System.Text.RegularExpressions.Regex]::Replace($newContent, "\b(\w+)ReadDto\b", "`$1Response")

    if ($content -ne $newContent) {
        Set-Content -Path $file.FullName -Value $newContent
    }
}
