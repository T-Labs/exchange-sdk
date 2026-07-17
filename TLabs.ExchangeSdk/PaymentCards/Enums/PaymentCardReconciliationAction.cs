namespace TLabs.ExchangeSdk.PaymentCards.Enums;


public enum PaymentCardReconciliationAction
{
    /// <summary>
    /// Повторить финальное зачисление/списание в Depository.
    /// </summary>
    Complete = 10,

    /// <summary>
    /// Повторить компенсирующую отмену TopUp.
    /// </summary>
    Cancel = 20
}
