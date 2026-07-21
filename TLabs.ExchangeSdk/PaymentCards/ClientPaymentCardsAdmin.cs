using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.PaymentCards.Dtos;

namespace TLabs.ExchangeSdk.PaymentCards;

public interface IClientPaymentCardsAdmin
{
    Task<PaymentCardPagedResult<PaymentCardDto>> GetCards(int skip = 0, int take = 50, string userId = null);

    Task<PaymentCardPagedResult<PaymentCardCallbackDto>> GetCallbacks(int skip = 0, int take = 50, Guid? cardId = null);

    Task<PaymentCardDto> BlockCard(Guid cardId, BlockPaymentCardDto dto);

    Task<PaymentCardDto> UnblockCard(Guid cardId, BlockPaymentCardDto dto);

    Task<List<PaymentCardProductDto>> GetProducts(bool? enabled = null);

    Task<PaymentCardProductSyncResultDto> SyncProducts();

    Task<PaymentCardProductDto> SetProductEnabled(Guid productId, UpdatePaymentCardProductEnabledDto dto);
}

public class ClientPaymentCardsAdmin : IClientPaymentCardsAdmin
{
    private const string BaseUrl = "brokerage/payment-cards";

    public Task<PaymentCardPagedResult<PaymentCardDto>> GetCards(int skip = 0, int take = 50, string userId = null)
    {
        var req = $"{BaseUrl}/admin/cards".InternalApi()
            .SetQueryParam(nameof(skip), skip)
            .SetQueryParam(nameof(take), take);
        if (userId.HasValue())
            req = req.SetQueryParam(nameof(userId), userId);
        return req.GetJsonAsync<PaymentCardPagedResult<PaymentCardDto>>();
    }

    public Task<PaymentCardPagedResult<PaymentCardCallbackDto>> GetCallbacks(int skip = 0, int take = 50, Guid? cardId = null)
    {
        var req = $"{BaseUrl}/admin/callbacks".InternalApi()
            .SetQueryParam(nameof(skip), skip)
            .SetQueryParam(nameof(take), take);
        if (cardId.HasValue)
            req = req.SetQueryParam(nameof(cardId), cardId.Value);
        return req.GetJsonAsync<PaymentCardPagedResult<PaymentCardCallbackDto>>();
    }

    public Task<PaymentCardDto> BlockCard(Guid cardId, BlockPaymentCardDto dto) =>
        $"{BaseUrl}/admin/{cardId}/block".InternalApi()
            .PostJsonAsync(dto)
            .ReceiveJson<PaymentCardDto>();

    public Task<PaymentCardDto> UnblockCard(Guid cardId, BlockPaymentCardDto dto) =>
        $"{BaseUrl}/admin/{cardId}/unblock".InternalApi()
            .PostJsonAsync(dto)
            .ReceiveJson<PaymentCardDto>();

    public Task<List<PaymentCardProductDto>> GetProducts(bool? enabled = null)
    {
        var req = $"{BaseUrl}/products".InternalApi();
        if (enabled.HasValue)
            req = req.SetQueryParam(nameof(enabled), enabled.Value);
        return req.GetJsonAsync<List<PaymentCardProductDto>>();
    }

    public Task<PaymentCardProductSyncResultDto> SyncProducts() =>
        $"{BaseUrl}/products/sync".InternalApi().PostAsync().ReceiveJson<PaymentCardProductSyncResultDto>();

    public Task<PaymentCardProductDto> SetProductEnabled(Guid productId, UpdatePaymentCardProductEnabledDto dto) =>
        $"{BaseUrl}/products/{productId}/enabled".InternalApi()
            .PatchJsonAsync(dto)
            .ReceiveJson<PaymentCardProductDto>();
}
