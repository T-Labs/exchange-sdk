namespace TLabs.ExchangeSdk
{
    public enum ClientType
    {
        User = 0, // Created by real user
        LiquidityImport = 1, // LiquidityImport from other Exchange (Binance, Okex, etc)
        DealsBot = 2, // InnerTradingBot (creates deals with itself)
        AffiliateBot = 3, // Affiliate program exchanges other assets into USDT
        ExchangerBot = 40, // Exchanger service (not used currently)
        CurrencyListingFairLaunchBot = 50, // LiquidityPool (FairLaunch) creates orderbook for new tokens
        TradingBot = 60, // Creates market orders to build trading chart
        LiquidityBot = 70, // Creates orderbooks
    }
}
