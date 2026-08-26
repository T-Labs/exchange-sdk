namespace TLabs.ExchangeSdk.Futures;

public class FuturesCommandResult
{
    public FuturesCommandResult()
    {
    }

    public FuturesCommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public FuturesCommandResult(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}

public class FuturesCommandResult<T>
{
    public FuturesCommandResult()
    {
    }

    public FuturesCommandResult(bool success, string error)
    {
        Success = success;
        ErrorMessage = error;
    }

    public FuturesCommandResult(bool success, T result)
    {
        Success = success;
        Result = result;
    }

    public bool Success { get; set; }
    public T Result { get; set; }
    public string ErrorMessage { get; set; }
}
