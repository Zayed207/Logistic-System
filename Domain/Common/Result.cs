namespace Domain.Common;

public class Result<T>
{
    public ResultStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static Result<T> SuccessResult(T data, string message = "") => new() { Status = ResultStatus.Success, Data = data, Message = message };
    public static Result<T> CreatedResult(T data, string message = "") => new() { Status = ResultStatus.Created, Data = data, Message = message };
    public static Result<T> UpdatedResult(T data, string message = "") => new() { Status = ResultStatus.Updated, Data = data, Message = message };
    public static Result<T> DeletedResult(string message = "") => new() { Status = ResultStatus.Deleted, Message = message };
    public static Result<T> NotFoundResult(string message = "Not Found") => new() { Status = ResultStatus.NotFound, Message = message };
    public static Result<T> BadRequestResult(string message = "Bad Request") => new() { Status = ResultStatus.BadRequest, Message = message };
    public static Result<T> ErrorResult(string message = "Error") => new() { Status = ResultStatus.Error, Message = message };
}
