using System.Linq;

namespace TLabs.ExchangeSdk.PaymentCards.Enums;

public enum PaymentCardPhysicalOrderStatus
{
    Open = 10,
    Delivered = 50,
    Completed = 60,
    Cancelled = 70,
}

public static class PaymentCardPhysicalOrderStatuses
{
    public static bool IsTerminal(PaymentCardPhysicalOrderStatus status) =>
        status is PaymentCardPhysicalOrderStatus.Completed or PaymentCardPhysicalOrderStatus.Cancelled;

    public static bool AllowsAdminTransition(
        PaymentCardPhysicalOrderStatus current,
        PaymentCardPhysicalOrderStatus next) =>
        AllowedAdminTransitions(current).Contains(next);

    public static PaymentCardPhysicalOrderStatus[] AllowedAdminTransitions(PaymentCardPhysicalOrderStatus current) =>
        current switch
        {
            PaymentCardPhysicalOrderStatus.Open => new[]
            {
                PaymentCardPhysicalOrderStatus.Open,
                PaymentCardPhysicalOrderStatus.Delivered,
                PaymentCardPhysicalOrderStatus.Cancelled,
            },
            PaymentCardPhysicalOrderStatus.Delivered => new[]
            {
                PaymentCardPhysicalOrderStatus.Delivered,
                PaymentCardPhysicalOrderStatus.Cancelled,
            },
            _ => new[] { current },
        };
}
