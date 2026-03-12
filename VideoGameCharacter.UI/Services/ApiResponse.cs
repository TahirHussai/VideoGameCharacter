namespace VideoGameCharacter.UI.Services;

public class ApiResponse<T>
{
    public bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public string ErrorMessage { get; init; } = string.Empty;
    public int StatusCode { get; init; }

    public static ApiResponse<T> Success(T data) => new() { IsSuccess = true, Data = data, StatusCode = 200 };
    public static ApiResponse<T> Failure(string message, int statusCode) => new() { IsSuccess = false, ErrorMessage = message, StatusCode = statusCode };
}
