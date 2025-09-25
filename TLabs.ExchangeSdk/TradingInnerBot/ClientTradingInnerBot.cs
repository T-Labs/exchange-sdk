using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.TradingInnerBot;

public class ClientTradingInnerBot
{
    private const string BASE_URL = "tradinginnerbot";
    private const string SETTINGS_URL = $"{BASE_URL}/algorithms-settings";
    private const string EVENTS_URL = $"{BASE_URL}/external-events";
    private const string ALGORITHM_LIMITS_URL = $"{BASE_URL}/algorithm-loss-limits";

    public async Task<List<CurrencyPair>> GetCurrencyPairAsync()
    {
        return await $"{BASE_URL}/currencies/pairs"
            .InternalApi()
            .GetJsonAsync<List<CurrencyPair>>();
    }

    public async Task<TradingAlgorithmSettings> GetTradingAlgorithmSettingsAsync(
        string currencyPairCode
    )
    {
        return await $"{SETTINGS_URL}/trading"
            .InternalApi()
            .SetQueryParam(nameof(currencyPairCode), currencyPairCode)
            .GetJsonAsync<TradingAlgorithmSettings>();
    }

    public async Task AddOrUpdateTradingAlgorithmSettingAsync(TradingAlgorithmSettings settings)
    {
        await $"{SETTINGS_URL}/trading".InternalApi().PostJsonAsync(settings);
    }

    public async Task<LiquidityAlgorithmSettings> GetLiquidityAlgorithmSettingsAsync(
        string currencyPairCode
    )
    {
        return await $"{SETTINGS_URL}/liquidity"
            .InternalApi()
            .SetQueryParam(nameof(currencyPairCode), currencyPairCode)
            .GetJsonAsync<LiquidityAlgorithmSettings>();
    }

    public async Task AddOrUpdateLiquidityAlgorithmSettingAsync(LiquidityAlgorithmSettings settings)
    {
        await $"{SETTINGS_URL}/liquidity".InternalApi().PostJsonAsync(settings);
    }

    public async Task SendDealEventAsync(MatchingDeal deal)
    {
        await $"{EVENTS_URL}/deal".InternalApi().PostJsonAsync(deal);
    }

    public async Task<AlgorithmLossLimit> GetAlgorithmLossLimitAsync(string currencyPair)
    {
        return await ALGORITHM_LIMITS_URL
            .InternalApi()
            .SetQueryParam(nameof(currencyPair), currencyPair)
            .GetJsonAsync<AlgorithmLossLimit>();
    }

    public async Task CreateOrUpdateAlgorithmLossLimitAsync(AlgorithmLossLimit limit)
    {
        await ALGORITHM_LIMITS_URL.InternalApi().PostJsonAsync(limit);
    }
}
