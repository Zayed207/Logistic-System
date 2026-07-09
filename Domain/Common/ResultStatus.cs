namespace Domain.Common;

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
