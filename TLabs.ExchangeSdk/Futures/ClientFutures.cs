#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

/// <summary>Ручки Stock.Futures через гейтвей — все роуты фьючерсов собраны здесь</summary>
public class ClientFutures
{
    public const string IdempotencyKeyHeader = "Idempotency-Key";

    /// <summary>Свечи — публичная маркет-дата</summary>
    public Task<List<CandleDto>> GetCandles(FuturesCandlesRequest request) =>
        "futures/candles".InternalApi()
            .SetQueryParam(nameof(request.CurrencyPair), request.CurrencyPair)
            .SetQueryParam(nameof(request.CandleTimePeriod), (int)request.CandleTimePeriod)
            .SetQueryParam(nameof(request.DateFrom), request.DateFrom?.ToString("o"))
            .SetQueryParam(nameof(request.DateTo), request.DateTo?.ToString("o"))
            .GetJsonAsync<List<CandleDto>>();

    /// <summary>Список торгуемых пар — публичная маркет-дата</summary>
    public Task<List<CurrencyPairDto>> GetCurrencyPairs() =>
        "futures/currency-pair".InternalApi().GetJsonAsync<List<CurrencyPairDto>>();

    public Task<List<CurrencyPriceAndVolumeDto>> GetPriceAndVolume() =>
        "futures/trade/price-and-volume".InternalApi().GetJsonAsync<List<CurrencyPriceAndVolumeDto>>();

    // регистр orderBook сохраняется: матчинг путей на гейтвее регистрозависимый
    public Task<FuturesOrderBookDto> GetOrderBook(string currencyPairCode) =>
        $"futures/order/orderBook/{WebUtility.UrlEncode(currencyPairCode)}".InternalApi()
            .GetJsonAsync<FuturesOrderBookDto>();

    public Task<GlobalSettingDto> GetGlobalSettings() =>
        "futures/settings/global".InternalApi().GetJsonAsync<GlobalSettingDto>();

    /// <summary>Публичная лента сделок; UserId на этот роут не уходит — бэк биндит его и на анонимном роуте</summary>
    public Task<FuturesPagedResult<TradeDto>> GetPublicTrades(FuturesTradesRequest request) =>
        TradesQuery("futures/trade", request).RemoveQueryParam(nameof(request.UserId))
            .GetJsonAsync<FuturesPagedResult<TradeDto>>();

    public Task<FuturesPagedResult<TradeDto>> GetUserTrades(FuturesTradesRequest request) =>
        TradesQuery("futures/trade/user-internal", request).GetJsonAsync<FuturesPagedResult<TradeDto>>();

    /// <param name="ensure">создать дефолтный счёт при отсутствии; false — только чтение (хабы)</param>
    public Task<List<FuturesAccountDto>> GetUserFuturesAccounts(string userId, bool ensure = true) =>
        $"futures/account/user-futures-accounts/{WebUtility.UrlEncode(userId)}".InternalApi()
            .SetQueryParam("ensure", ensure)
            .GetJsonAsync<List<FuturesAccountDto>>();

    public Task<bool> UpdateFuturesAccount(FuturesAccountUpdateRequest request) =>
        "futures/account/internal/update-futures-account".InternalApi()
            .PutJsonAsync(request).ReceiveJson<bool>();

    // Idempotency-Key передаётся заголовком: Stock.Futures читает его из header, не из тела
    public Task<FuturesTransferStatusDto> TransferFromSpot(
        FuturesTransferInternalRequest request, string? idempotencyKey) =>
        WithIdempotency("futures/account/internal/transfer-from-spot".InternalApi(), idempotencyKey)
            .PostJsonAsync(request).ReceiveJson<FuturesTransferStatusDto>();

    public Task<FuturesTransferStatusDto> TransferToSpot(
        FuturesTransferInternalRequest request, string? idempotencyKey) =>
        WithIdempotency("futures/account/internal/transfer-to-spot".InternalApi(), idempotencyKey)
            .PostJsonAsync(request).ReceiveJson<FuturesTransferStatusDto>();

    public Task<FuturesTransferStatusDto> GetTransferStatus(Guid transferId, string userId) =>
        $"futures/account/internal/futures-transfers/{transferId}".InternalApi()
            .SetQueryParam("userId", userId)
            .GetJsonAsync<FuturesTransferStatusDto>();

    public Task<FuturesPagedResult<TransactionHistoryDto>> GetTransactionHistory(FuturesTransactionHistoryRequest request) =>
        "futures/transaction-history/internal".InternalApi()
            .SetQueryParam(nameof(request.UserId), request.UserId)
            .SetQueryParam(nameof(request.FuturesAccountId), request.FuturesAccountId)
            .SetQueryParam(nameof(request.Page), request.Page)
            .SetQueryParam(nameof(request.PageSize), request.PageSize)
            .SetQueryParam(nameof(request.DateFrom), request.DateFrom?.ToString("o"))
            .SetQueryParam(nameof(request.DateTo), request.DateTo?.ToString("o"))
            .SetQueryParam(nameof(request.Type), request.Type)
            .GetJsonAsync<FuturesPagedResult<TransactionHistoryDto>>();

    public Task<FuturesCreateOrderResult> CreateOrder(FuturesOrderCreateRequest request) =>
        "futures/order/create-internal".InternalApi()
            .PostJsonAsync(request).ReceiveJson<FuturesCreateOrderResult>();

    /// <summary>Успех — 200 без тела; бизнес-отказ — 400 с FuturesCommandResult в исключении</summary>
    public Task CloseOrder(FuturesOrderCancelRequest request) =>
        "futures/order/close-internal".InternalApi().PutJsonAsync(request);

    public Task CloseAllOrders(FuturesOrdersCancelAllRequest request) =>
        "futures/order/close-all-internal".InternalApi().PostJsonAsync(request);

    public Task UpdateStopLoss(FuturesOrderStopLossRequest request) =>
        "futures/order/update-stop-loss-internal".InternalApi().PutJsonAsync(request);

    public Task UpdateTakeProfit(FuturesOrderTakeProfitRequest request) =>
        "futures/order/update-take-profit-internal".InternalApi().PutJsonAsync(request);

    public Task<FuturesAccountDto> CreateFuturesAccount(FuturesAccountCreateRequest request) =>
        "futures/account/internal/create-futures-account".InternalApi()
            .PostJsonAsync(request).ReceiveJson<FuturesAccountDto>();

    public Task<FuturesPagedResult<PositionDto>> GetPositions(FuturesPositionsRequest request) =>
        "futures/order/positions-internal".InternalApi()
            .SetQueryParam(nameof(request.UserId), request.UserId)
            .SetQueryParam(nameof(request.CurrencyPair), request.CurrencyPair)
            .SetQueryParam(nameof(request.Page), request.Page)
            .SetQueryParam(nameof(request.PageSize), request.PageSize)
            .SetQueryParam(nameof(request.DateFrom), request.DateFrom?.ToString("o"))
            .SetQueryParam(nameof(request.DateTo), request.DateTo?.ToString("o"))
            .SetQueryParam(nameof(request.FuturesAccountId), request.FuturesAccountId)
            .SetQueryParam(nameof(request.IsActive), request.IsActive)
            .GetJsonAsync<FuturesPagedResult<PositionDto>>();

    public Task<PositionsSummaryDto> GetPositionSummary(FuturesPositionSummaryRequest request) =>
        "futures/order/position-summary-internal".InternalApi()
            .SetQueryParam(nameof(request.UserId), request.UserId)
            .SetQueryParam(nameof(request.FuturesAccountId), request.FuturesAccountId)
            .GetJsonAsync<PositionsSummaryDto>();

    // ответ internal-ручки десериализуется в базовый OrderDto: служебные поля
    // (isMirror) до фасада не доезжают — выравнивание с публичным контрактом
    public Task<FuturesPagedResult<OrderDto>> GetOrdersHistory(FuturesOrdersHistoryRequest request) =>
        "futures/order/orders-history-internal".InternalApi()
            .PostJsonAsync(request).ReceiveJson<FuturesPagedResult<OrderDto>>();

    /// <summary>Полный internal-ответ с служебными полями (isMirror) — для админки, не для фасада</summary>
    public Task<FuturesPagedResult<OrderInternalDto>> GetOrdersHistoryInternal(FuturesOrdersHistoryRequest request) =>
        "futures/order/orders-history-internal".InternalApi()
            .PostJsonAsync(request).ReceiveJson<FuturesPagedResult<OrderInternalDto>>();

    private static IFlurlRequest TradesQuery(string url, FuturesTradesRequest request) =>
        url.InternalApi()
            .SetQueryParam(nameof(request.UserId), request.UserId)
            .SetQueryParam(nameof(request.CurrencyPair), request.CurrencyPair)
            .SetQueryParam(nameof(request.Page), request.Page)
            .SetQueryParam(nameof(request.PageSize), request.PageSize)
            .SetQueryParam(nameof(request.DateFrom), request.DateFrom?.ToString("o"))
            .SetQueryParam(nameof(request.DateTo), request.DateTo?.ToString("o"))
            .SetQueryParam(nameof(request.FuturesAccountId), request.FuturesAccountId);

    private static IFlurlRequest WithIdempotency(IFlurlRequest request, string? idempotencyKey) =>
        idempotencyKey.HasValue() ? request.WithHeader(IdempotencyKeyHeader, idempotencyKey) : request;
}
