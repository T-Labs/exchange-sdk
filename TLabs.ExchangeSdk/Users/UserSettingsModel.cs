namespace TLabs.ExchangeSdk.Users
{
    public class UserSettingsModel
    {
        public string UserId { get; set; }
        public bool CantChat { get; set; }
        public bool CantTrade { get; set; }
        public bool CantRefill { get; set; }
        public bool CantWithdraw { get; set; }
        public bool NoTradeCommissions { get; set; }
        public bool AllowNegativeBalance { get; set; }
        public bool IsPriority { get; set; }
        public bool BanOnP2P { get; set; }

        /// <summary>Access to all farming Admin panels</summary>
        public bool FarmingSuperAdmin { get; set; }
        /// <summary>Access to farming Admin panel for a specefic token. Values: "BLZ", etc</summary>
        public string FarmingTokenAdmin { get; set; }
    }
}
