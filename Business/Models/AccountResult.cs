
namespace Business.Models;

public class AccountResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class AccountResult<T> : AccountResult
{
    public T? Result { get; set; }
}
