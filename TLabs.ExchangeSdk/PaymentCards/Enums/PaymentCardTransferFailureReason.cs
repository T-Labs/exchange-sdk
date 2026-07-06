namespace TLabs.ExchangeSdk.PaymentCards.Enums;

public enum PaymentCardTransferFailureReason
{
    None = 0,
    ProviderError = 10,
    DepositoryError = 20,
    TopUpCancelled = 30,
}
