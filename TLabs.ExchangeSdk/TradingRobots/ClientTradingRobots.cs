using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.TradingRobots.Models;
using TLabs.ExchangeSdk.TradingRobots.Models.MasterTrade;

namespace TLabs.ExchangeSdk.TradingRobots;

public class ClientTradingRobots
{
    private const string BaseUrl = "brokerage/trading-robots";

    private readonly ILogger _logger;

    public ClientTradingRobots(ILogger<ClientTradingRobots> logger)
    {
        _logger = logger;
    }

    // ---- Exchange accounts ----

    public async Task<List<ExchangeAccountDto>> GetExchangeAccounts(string userId)
    {
        return await $"{BaseUrl}/exchange/list".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<ExchangeAccountDto>>();
    }

    public async Task<ExchangeAccountDto> GetExchangeAccount(string userId, long id)
    {
        return await $"{BaseUrl}/exchange/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ExchangeAccountDto>();
    }

    public async Task<long> AddExchangeAccount(string userId, AddExchangeAccountRequest request)
    {
        var result = await $"{BaseUrl}/exchange".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync(request)
            .ReceiveJson<CreateRobotResult>();
        return result.Id;
    }

    public async Task UpdateExchangeAccount(string userId, long id, AddExchangeAccountRequest request)
    {
        await $"{BaseUrl}/exchange/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PutJsonAsync(request);
    }

    public async Task<DisableExchangeAccountResult> DisableExchangeAccount(string userId, long id, bool force = false)
    {
        return await $"{BaseUrl}/exchange/{id}/disable".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(force), force)
            .PostJsonAsync(null)
            .ReceiveJson<DisableExchangeAccountResult>();
    }

    public async Task<bool> CheckExchangeAccount(string userId, long id)
    {
        var response = await $"{BaseUrl}/exchange/{id}/check".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetAsync();
        return response.StatusCode == 200;
    }

    // ---- Balances ----

    public async Task<ExchangeBalanceDto> GetExchangeBalance(string userId, long exchangeId, string coin = null)
    {
        var url = $"{BaseUrl}/exchange/{exchangeId}/balance".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (coin.HasValue())
            url = url.SetQueryParam(nameof(coin), coin);
        return await url.GetJsonAsync<ExchangeBalanceDto>();
    }

    public async Task<decimal> GetExchangeTotalBalance(string userId, long exchangeId, string coin)
    {
        return await $"{BaseUrl}/exchange/{exchangeId}/balance/total".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(coin), coin)
            .GetJsonAsync<decimal>();
    }

    // ---- Robots ----

    public async Task<List<RobotDto>> GetRobots(string userId)
    {
        return await $"{BaseUrl}/robots".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<RobotDto>>();
    }

    public async Task<long> CreateRobot(string userId, CreateRobotRequest request)
    {
        var result = await $"{BaseUrl}/robots".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync(request)
            .ReceiveJson<CreateRobotResult>();
        return result.Id;
    }

    public async Task<RobotDto> EditRobotSettings(string userId, long robotId, EditRobotSettingsRequest request)
    {
        return await $"{BaseUrl}/robots/{robotId}/settings".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PutJsonAsync(request)
            .ReceiveJson<RobotDto>();
    }

    public async Task ToggleRobot(string userId, long robotId, RobotWorkStatus status)
    {
        await $"{BaseUrl}/robots/{robotId}/toggle".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync(new ToggleRobotRequest { Status = status });
    }

    public async Task<List<RobotOrderDto>> GetRobotOrders(string userId, long robotId, int? limit = null)
    {
        var url = $"{BaseUrl}/robots/{robotId}/orders".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (limit.HasValue)
            url = url.SetQueryParam(nameof(limit), limit.Value);
        return await url.GetJsonAsync<List<RobotOrderDto>>();
    }

    public async Task<RobotCalculations> GetRobotCalculations(
        string userId,
        long robotId,
        RobotCalculationsTarget target,
        string state = null,
        string exchange = null,
        string coin = null)
    {
        var url = $"{BaseUrl}/robots/{robotId}/calculations".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(target), target.ToString().ToLowerInvariant());
        if (state.HasValue()) url = url.SetQueryParam(nameof(state), state);
        if (exchange.HasValue()) url = url.SetQueryParam(nameof(exchange), exchange);
        if (coin.HasValue()) url = url.SetQueryParam(nameof(coin), coin);
        return await url.GetJsonAsync<RobotCalculations>();
    }

    public async Task<string> Healthcheck() =>
        await $"{BaseUrl}/healthcheck".InternalApi().GetStringAsync();

    // ---- Master-trade: channels ----

    public async Task<List<ChannelDto>> GetChannels(string userId)
    {
        return await $"{BaseUrl}/master-trade/channels".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<ChannelDto>>();
    }

    public async Task<ChannelInfoDto> GetChannelInfo(string userId, long channelId)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChannelInfoDto>();
    }

    public async Task<ChannelOrdersListResponse> GetChannelSignalOrders(string userId, long channelId,
        int? offset = null, int? limit = null)
    {
        var url = $"{BaseUrl}/master-trade/channels/{channelId}/signal-orders".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (offset.HasValue) url = url.SetQueryParam(nameof(offset), offset.Value);
        if (limit.HasValue) url = url.SetQueryParam(nameof(limit), limit.Value);
        return await url.GetJsonAsync<ChannelOrdersListResponse>();
    }

    public async Task<ChannelStatSummary> GetChannelStatSummary(string userId, long channelId)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/stat/summary".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChannelStatSummary>();
    }

    public async Task<UserStatSummary> GetChannelUserStatSummary(string userId, long channelId)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/stat/user-summary".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<UserStatSummary>();
    }

    public async Task<string> GetChannelProfits(string userId, long channelId)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/stat/profits".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<string>();
    }

    public async Task<UserProfitsResponse> GetUserProfits(string userId, long channelId,
        DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, string session = null)
    {
        var url = $"{BaseUrl}/master-trade/channels/{channelId}/stat/user-profits".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (startDate.HasValue) url = url.SetQueryParam(nameof(startDate), startDate.Value.ToString("o"));
        if (endDate.HasValue) url = url.SetQueryParam(nameof(endDate), endDate.Value.ToString("o"));
        if (session.HasValue()) url = url.SetQueryParam(nameof(session), session);
        return await url.GetJsonAsync<UserProfitsResponse>();
    }

    // ---- Master-trade: user trade ----

    public async Task<UserPositionsListResponse> GetOpenPositions(string userId, long channelId,
        int? offset = null, int? limit = null)
    {
        var url = $"{BaseUrl}/master-trade/channels/{channelId}/positions/open".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (offset.HasValue) url = url.SetQueryParam(nameof(offset), offset.Value);
        if (limit.HasValue) url = url.SetQueryParam(nameof(limit), limit.Value);
        return await url.GetJsonAsync<UserPositionsListResponse>();
    }

    public async Task<UserPositionsListResponse> GetClosedPositions(string userId, long channelId,
        int? offset = null, int? limit = null)
    {
        var url = $"{BaseUrl}/master-trade/channels/{channelId}/positions/close".InternalApi()
            .SetQueryParam(nameof(userId), userId);
        if (offset.HasValue) url = url.SetQueryParam(nameof(offset), offset.Value);
        if (limit.HasValue) url = url.SetQueryParam(nameof(limit), limit.Value);
        return await url.GetJsonAsync<UserPositionsListResponse>();
    }

    public async Task<UserConfigDto> GetUserConfig(string userId, long channelId)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/config".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<UserConfigDto>();
    }

    public async Task<UserConfigDto> SaveUserConfig(string userId, long channelId, SaveUserConfigRequest request)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/config".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PutJsonAsync(request)
            .ReceiveJson<UserConfigDto>();
    }

    public async Task<UserConfigDto> LaunchUserChannel(string userId, long channelId, int work)
    {
        return await $"{BaseUrl}/master-trade/channels/{channelId}/launch".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync(new LaunchUserChannelRequest { Work = work })
            .ReceiveJson<UserConfigDto>();
    }
}
