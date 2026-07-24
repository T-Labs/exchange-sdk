using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.PaymentCards.Dtos;
using TLabs.ExchangeSdk.PaymentCards.Models;

namespace TLabs.ExchangeSdk.PaymentCards;

public interface IClientPaymentCards
{
    Task<List<PaymentCardDto>> GetCards(string userId);

    Task<PaymentCardDto> GetCard(Guid cardId, string userId);

    Task<PaymentCardDto> IssueCard(IssuePaymentCardDto dto);

    Task<PaymentCardTransferDto> CreateTransfer(Guid cardId, CreatePaymentCardTransferDto dto, string idempotencyKey = null);

    Task<PaymentCardBalanceDto> GetBalance(Guid cardId, string userId);

    Task<PaymentCardSensitiveDetailsDto> GetSensitiveDetails(Guid cardId, string userId);

    Task<List<PaymentCardCallbackDto>> GetCallbacks(Guid cardId, string userId, int take = 100);

    Task<List<PaymentCardCallbackDto>> GetVerificationCodes(Guid cardId, string userId, int take = 50);

    Task Confirm3Ds(Guid cardId, string userId, ConfirmPaymentCard3DsDto dto);

    Task<List<PaymentCardTransferDto>> GetTransfers(string userId, Guid? cardId = null);

    Task<List<PaymentCardProductDto>> GetProducts(bool? enabled = null);

    Task<List<PaymentCardProductDto>> GetAvailableProducts(string userId);
}

public class ClientPaymentCards : IClientPaymentCards
{
    private const string BaseUrl = "brokerage/payment-cards";

    public Task<List<PaymentCardDto>> GetCards(string userId) =>
        BaseUrl.InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<PaymentCardDto>>();

    public Task<PaymentCardDto> GetCard(Guid cardId, string userId) =>
        $"{BaseUrl}/{cardId}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<PaymentCardDto>();

    public Task<PaymentCardDto> IssueCard(IssuePaymentCardDto dto) =>
        BaseUrl.InternalApi().PostJsonAsync(dto).ReceiveJson<PaymentCardDto>();

    public Task<PaymentCardTransferDto> CreateTransfer(Guid cardId, CreatePaymentCardTransferDto dto, string idempotencyKey = null)
    {
        var request = $"{BaseUrl}/{cardId}/transfers".InternalApi();
        if (idempotencyKey.HasValue())
            request = request.WithHeader(PaymentCardHttpHeaders.IdempotencyKey, idempotencyKey);
        return request.PostJsonAsync(dto).ReceiveJson<PaymentCardTransferDto>();
    }

    public Task<PaymentCardBalanceDto> GetBalance(Guid cardId, string userId) =>
        $"{BaseUrl}/{cardId}/balance".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<PaymentCardBalanceDto>();

    public Task<PaymentCardSensitiveDetailsDto> GetSensitiveDetails(Guid cardId, string userId) =>
        $"{BaseUrl}/{cardId}/sensitive-details".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<PaymentCardSensitiveDetailsDto>();

    public Task<List<PaymentCardCallbackDto>> GetCallbacks(Guid cardId, string userId, int take = 100) =>
        $"{BaseUrl}/{cardId}/callbacks".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(take), take)
            .GetJsonAsync<List<PaymentCardCallbackDto>>();

    public Task<List<PaymentCardCallbackDto>> GetVerificationCodes(Guid cardId, string userId, int take = 50) =>
        $"{BaseUrl}/{cardId}/verification-codes".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(take), take)
            .GetJsonAsync<List<PaymentCardCallbackDto>>();

    public Task Confirm3Ds(Guid cardId, string userId, ConfirmPaymentCard3DsDto dto) =>
        $"{BaseUrl}/{cardId}/3ds/confirm".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync(dto);

    public Task<List<PaymentCardTransferDto>> GetTransfers(string userId, Guid? cardId = null)
    {
        var req = cardId.HasValue
            ? $"{BaseUrl}/{cardId}/transfers".InternalApi().SetQueryParam(nameof(userId), userId)
            : $"{BaseUrl}/transfers".InternalApi().SetQueryParam(nameof(userId), userId);
        return req.GetJsonAsync<List<PaymentCardTransferDto>>();
    }

    public Task<List<PaymentCardProductDto>> GetProducts(bool? enabled = null)
    {
        var req = $"{BaseUrl}/products".InternalApi();
        if (enabled.HasValue)
            req = req.SetQueryParam(nameof(enabled), enabled.Value);
        return req.GetJsonAsync<List<PaymentCardProductDto>>();
    }

    public Task<List<PaymentCardProductDto>> GetAvailableProducts(string userId) =>
        $"{BaseUrl}/available-products".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<PaymentCardProductDto>>();
}
