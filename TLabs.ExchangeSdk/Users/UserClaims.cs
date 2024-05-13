using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Users
{
    public class UserClaims
    {
        public const string CantChat = "CantChat";
        public const string PolicyCanChat = "PolicyCanChat";
        public const string CantTrade = "CantTrade";
        public const string PolicyCanTrade = "PolicyCanTrade";
        public const string CantRefill = "CantRefill";
        public const string PolicyCanRefill = "PolicyCanRefill";
        public const string CantWithdraw = "CantWithdraw";
        public const string PolicyCanWithdraw = "PolicyCanWithdraw";

        public const string NoTradeCommissions = "NoTradeCommissions";

        public const string PolicyBanOnP2P = "PolicyBanOnP2P";
        public const string BanOnP2P = "BanOnP2P";
        public const string TempBanOnP2PExpiryDate = "TempBanOnP2PExpiryDate";

        public const string Last2FAAccessToken = "Last2FAAccessToken";
        public const string LastWithdrawalEmailDate = "LastWithdrawalEmailDate";

        public const string WithdrawalEmailCode = "WithdrawalEmailCode";
        public const string WithdrawalEmailCodeExpireDate = "WithdrawalEmailCodeExpireDate";

        public const string LastLoginIp = "LastLoginIp";
        public const string LastLoginTime = "LastLoginTime";
        public const string SecondLastLoginIp = "SecondLastLoginIp";
        public const string SecondLastLoginTime = "SecondLastLoginTime";
    }
}
