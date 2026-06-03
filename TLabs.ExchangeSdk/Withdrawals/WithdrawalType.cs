using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public enum WithdrawalType
    {
        Crypto = 0, AdvCashInternal = 10, AdvCashYandex = 20, AdvCashQiwi = 30, AdvCashBankCard = 40, Swift = 50, Cash = 60,
        /// <summary>System-initiated send back to the depositor's address after an AML hold.</summary>
        AmlReturn = 70,
    }
}
