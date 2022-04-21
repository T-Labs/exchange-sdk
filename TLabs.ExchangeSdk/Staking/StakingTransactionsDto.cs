using System;
using System.Collections.Generic;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingTransactionsDto
    {
        public List<StakingAccrualTransactionDto> Transactions { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public int PagesCount => (int)Math.Ceiling(1.0 * TotalItemsCount / PageSize);
    }
}
