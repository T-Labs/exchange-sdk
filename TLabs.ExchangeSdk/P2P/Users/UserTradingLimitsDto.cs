using System.Collections.Generic;

namespace TLabs.ExchangeSdk.P2P.Users;

public class UserLimits
{
    public bool IsOrderLimitReachedByCurrency { get; set; }
    public bool IsOrderOpeningLimit { get; set; }
    public bool IsDealOpeningLimit { get; set; }
    public bool IsBlockedDealOpeningByActiveAppeals { get; set; }
    public List<ExistingOrdersWithPaymentMethod> ExistingOrdersWithPaymentMethods { get; set; }
}

public class ExistingOrdersWithPaymentMethod
{
    public decimal Price { get; set; }
    public string PaymentCurrencyCode { get; set; }
    public List<Requisite> Requisites { get; set; }
}
