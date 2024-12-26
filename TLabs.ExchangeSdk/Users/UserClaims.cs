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

        public const string P2POrdersEmailNotification = "P2POrdersEmailNotification";
        public const string P2PDealsEmailNotification = "P2PDealsEmailNotification";
        public const string P2PAppealsEmailNotification = "P2PAppealsEmailNotification";
        public const string P2PChatMessagesEmailNotification = "P2PChatMessagesEmailNotification";

        public const string Last2FAAccessToken = "Last2FAAccessToken";
        public const string LastWithdrawalEmailDate = "LastWithdrawalEmailDate";

        public const string EmailVerificationCode = "EmailVerificationCode";
        public const string EmailVerificationCodeExpireDate = "EmailVerificationCodeExpireDate";

        public const string LastLoginIp = "LastLoginIp";
        public const string LastLoginTime = "LastLoginTime";
        public const string SecondLastLoginIp = "SecondLastLoginIp";
        public const string SecondLastLoginTime = "SecondLastLoginTime";

        /// <summary>Access to all farming Admin panels. Values: "true"</summary>
        public const string FarmingSuperAdmin = nameof(FarmingSuperAdmin);

        /// <summary>Access to farming Admin panel for a specefic token. Values: "BLZ", etc</summary>
        public const string FarmingTokenAdmin = nameof(FarmingTokenAdmin);
    }
}
