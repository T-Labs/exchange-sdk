using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    internal class WithdrawalConfirmationDto
    {
        public Guid TransactionId { get; set; }

        public decimal NetworkCommission { get; set; }

        public string NetworkCommissionCurrencyCode { get; set; }
    }
}
