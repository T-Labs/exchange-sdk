using P2P.Requisites;
using System.Collections.Generic;

namespace P2P.Users;

public class UserOrderLimitsDto
{
    public bool CanOpenOrderWithSelectedPriceAndRequisites { get; set; }
    public bool CanOpenNewOrderAtSelectedTradingPair { get; set; }
    public bool CanOpenOrderWithinAppealLimit { get; set; }
    public bool CanOpenOrderWithinTotalLimits { get; set; }
}
