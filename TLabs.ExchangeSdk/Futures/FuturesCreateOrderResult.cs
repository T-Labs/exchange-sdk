#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesCreateOrderResult
{
    public FuturesCreateOrderResult()
    {
    }

    public FuturesCreateOrderResult(bool isSuccess, string message)
    {
        Success = isSuccess;
        Message = message;
    }

    public FuturesCreateOrderResult(bool isSuccess)
    {
        Success = isSuccess;
    }

    public string Id { get; set; } = null!;
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public string? ClientOrderId { get; set; }
}
