using System.Globalization;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Features.Profeex;

/// <summary>
/// SDK client for the internal ProFeeX adapter route (profeex/*). The internal route is expected
/// to proxy to the external ProFeeX API (api.profeex.io/api/v1) and inject the X-API-Key on
/// behalf of the caller вЂ” SDK callers do not provide credentials.
/// </summary>
public class ClientCryptoAdapterProfeex
{
    private const string BaseRoute = "profeex";

    public ClientCryptoAdapterProfeex()
    {
    }

    #region Users / Balance / Orders

    public async Task<QueryResult<ProfeexUserInfoDto>> GetUserInfo() =>
        await $"{BaseRoute}/users/info".InternalApi()
            .GetJsonAsync<ProfeexUserInfoDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexBalanceDto>> GetBalance() =>
        await $"{BaseRoute}/balance".InternalApi()
            .GetJsonAsync<ProfeexBalanceDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexPaginatedOrderHistoryDto>> GetOrderHistory(ProfeexOrderHistoryQuery query)
    {
        query ??= new ProfeexOrderHistoryQuery();
        var request = $"{BaseRoute}/orders/history".InternalApi()
            .SetQueryParam("page", query.Page)
            .SetQueryParam("size", query.Size)
            .SetQueryParam("sort", query.Sort);

        if (query.DateFrom.HasValue)
            request = request.SetQueryParam("date_from", query.DateFrom.Value.UtcDateTime.ToString("O", CultureInfo.InvariantCulture));
        if (query.DateTo.HasValue)
            request = request.SetQueryParam("date_to", query.DateTo.Value.UtcDateTime.ToString("O", CultureInfo.InvariantCulture));
        if (query.Last.HasValue())
            request = request.SetQueryParam("last", query.Last);
        if (query.Status.HasValue)
            request = request.SetQueryParam("status", query.Status.Value.ToString().ToUpperInvariant());
        if (query.ResourceType.HasValue)
            request = request.SetQueryParam("resource_type", query.ResourceType.Value.ToString().ToUpperInvariant());

        return await request.GetJsonAsync<ProfeexPaginatedOrderHistoryDto>().GetQueryResult();
    }

    #endregion Users / Balance / Orders

    #region Precount

    public async Task<QueryResult<ProfeexPricingDto>> PrecountEnergy(ProfeexPrecountRequest request) =>
        await BuildPrecountRequest("energy", request).GetJsonAsync<ProfeexPricingDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexPricingDto>> PrecountBandwidth(ProfeexPrecountRequest request) =>
        await BuildPrecountRequest("bandwidth", request).GetJsonAsync<ProfeexPricingDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexPricingDto>> PrecountBatchEnergy(ProfeexPrecountRequest request) =>
        await BuildPrecountRequest("batchenergy", request).GetJsonAsync<ProfeexPricingDto>().GetQueryResult();

    private static IFlurlRequest BuildPrecountRequest(string resource, ProfeexPrecountRequest request) =>
        $"{BaseRoute}/delegation/precount/{resource}".InternalApi()
            .SetQueryParam("volume", request.Volume)
            .SetQueryParam("days", request.Days)
            .SetQueryParam("currency", request.Currency.ToString().ToUpperInvariant());

    #endregion Precount

    #region Buy

    public async Task<QueryResult<ProfeexOrderAcceptedDto>> BuyEnergy(ProfeexBuyResourceRequest request) =>
        await BuildBuyRequest("buyenergy", request)
            .PostJsonAsync(null).ReceiveJson<ProfeexOrderAcceptedDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexOrderAcceptedDto>> BuyBatchEnergy(ProfeexBuyResourceRequest request) =>
        await BuildBuyRequest("batchenergy", request)
            .PostJsonAsync(null).ReceiveJson<ProfeexOrderAcceptedDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexOrderAcceptedDto>> BuyBandwidth(ProfeexBuyResourceRequest request) =>
        await BuildBuyRequest("buybandwidth", request)
            .PostJsonAsync(null).ReceiveJson<ProfeexOrderAcceptedDto>().GetQueryResult();

    private static IFlurlRequest BuildBuyRequest(string resource, ProfeexBuyResourceRequest request) =>
        $"{BaseRoute}/delegation/{resource}".InternalApi()
            .SetQueryParam("target", request.Target)
            .SetQueryParam("volume", request.Volume)
            .SetQueryParam("days", request.Days)
            .SetQueryParam("currency", request.Currency.ToString().ToUpperInvariant());

    #endregion Buy

    #region Status / Fee

    public async Task<QueryResult<ProfeexOrderStatusDto>> GetOrderStatus(string taskId) =>
        await $"{BaseRoute}/delegation/status/{taskId}".InternalApi()
            .GetJsonAsync<ProfeexOrderStatusDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexFeeCalculationDto>> CalculateUsdtTransferFee(string receiverAddress) =>
        await $"{BaseRoute}/delegation/fee".InternalApi()
            .SetQueryParam("receiver_address", receiverAddress)
            .GetJsonAsync<ProfeexFeeCalculationDto>().GetQueryResult();

    #endregion Status / Fee

    #region Activation

    public async Task<QueryResult<ProfeexActivationAcceptedDto>> RequestActivation(ProfeexActivationRequest request) =>
        await $"{BaseRoute}/activation/activate".InternalApi()
            .SetQueryParam("address", request.Address)
            .SetQueryParam("currency", request.Currency.ToString().ToUpperInvariant())
            .PostJsonAsync(null).ReceiveJson<ProfeexActivationAcceptedDto>().GetQueryResult();

    public async Task<QueryResult<ProfeexActivationCostDto>> GetActivationCost() =>
        await $"{BaseRoute}/activation/cost".InternalApi()
            .GetJsonAsync<ProfeexActivationCostDto>().GetQueryResult();

    #endregion Activation
}
