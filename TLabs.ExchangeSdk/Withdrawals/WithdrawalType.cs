using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public enum WithdrawalType
    {
        Crypto = 0, AdvCashInternal = 10, AdvCashYandex = 20, AdvCashQiwi = 30, AdvCashBankCard = 40, Swift = 50, Cash = 60,
    }
}
