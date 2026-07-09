using Microsoft.AspNetCore.Mvc;
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
