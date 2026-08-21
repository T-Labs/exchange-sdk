using System;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Futures;

/// <summary>
/// Ручки Stock.Futures через гейтвей — все роуты фьючерсов собраны здесь.
/// Клиент прозрачного прокси: AllowAnyHttpStatus и сырой IFlurlResponse,
/// чтобы фасад отдавал статус и тело ответа бэка как есть, без пересборки.
/// </summary>
public class ClientFutures
{
    public const string IdempotencyKeyHeader = "Idempotency-Key";

    /// <summary>Свечи — публичная маркет-дата. query проксируется как есть</summary>
    public Task<IFlurlResponse> GetCandles(string query) =>
        Get($"futures/candles{query}");

    /// <summary>Список торгуемых пар — публичная маркет-дата</summary>
    public Task<IFlurlResponse> GetCurrencyPairs(string query) =>
        Get($"futures/currency-pair{query}");

    /// <summary>Цена и объём за сутки — публичная маркет-дата</summary>
    public Task<IFlurlResponse> GetPriceAndVolume(string query) =>
        Get($"futures/trade/price-and-volume{query}");

    /// <summary>Сделки пользователя. userId обязателен в query</summary>
    public Task<IFlurlResponse> GetUserTrades(string query) =>
        Get($"futures/trade/user-internal{query}");

    /// <summary>Счета пользователя. ensure=true заводит счёт по умолчанию, если счетов нет</summary>
    public Task<IFlurlResponse> GetUserFuturesAccounts(string userId) =>
        Get($"futures/account/user-futures-accounts/{WebUtility.UrlEncode(userId)}?ensure=true");

    public Task<IFlurlResponse> UpdateFuturesAccount(JObject body) =>
        "futures/account/internal/update-futures-account".InternalApi().AllowAnyHttpStatus().PutJsonAsync(body);

    /// <summary>Перевод спот→фьючерсы. Ключ идемпотентности Stock.Futures читает из заголовка</summary>
    public Task<IFlurlResponse> TransferFromSpot(JObject body, string idempotencyKey) =>
        Post("futures/account/internal/transfer-from-spot", body, idempotencyKey);

    /// <summary>Перевод фьючерсы→спот. Ключ идемпотентности Stock.Futures читает из заголовка</summary>
    public Task<IFlurlResponse> TransferToSpot(JObject body, string idempotencyKey) =>
        Post("futures/account/internal/transfer-to-spot", body, idempotencyKey);

    /// <summary>Статус перевода: state перечитывается до Completed/Failed. userId обязателен в query</summary>
    public Task<IFlurlResponse> GetTransferStatus(Guid transferId, string query) =>
        Get($"futures/account/internal/futures-transfers/{transferId}{query}");

    /// <summary>История переводов между спотом и фьючерсными счетами. userId обязателен в query</summary>
    public Task<IFlurlResponse> GetTransactionHistory(string query) =>
        Get($"futures/transaction-history/internal{query}");

    public Task<IFlurlResponse> CreateOrder(JObject body) =>
        "futures/order/create-internal".InternalApi().AllowAnyHttpStatus().PostJsonAsync(body);

    public Task<IFlurlResponse> CloseOrder(JObject body) =>
        "futures/order/close-internal".InternalApi().AllowAnyHttpStatus().PutJsonAsync(body);

    public Task<IFlurlResponse> GetPositions(string query) =>
        Get($"futures/order/positions-internal{query}");

    public Task<IFlurlResponse> GetPositionSummary(string query) =>
        Get($"futures/order/position-summary-internal{query}");

    public Task<IFlurlResponse> GetOrdersHistory(JObject body) =>
        "futures/order/orders-history-internal".InternalApi().AllowAnyHttpStatus().PostJsonAsync(body);

    private static Task<IFlurlResponse> Get(string url) =>
        url.InternalApi().AllowAnyHttpStatus().GetAsync();

    private static Task<IFlurlResponse> Post(string url, JObject body, string idempotencyKey)
    {
        var request = url.InternalApi().AllowAnyHttpStatus();
        if (idempotencyKey.HasValue())
            request = request.WithHeader(IdempotencyKeyHeader, idempotencyKey);
        return request.PostJsonAsync(body);
    }
}
