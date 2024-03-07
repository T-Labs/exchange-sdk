using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class ClientP2P
{
    public async Task<List<Order>> GetOrders(string exchangeCurrencyCode = null, string paymentCurrencyCode = null,
        int? paymentSystemId = null,
        bool? isBuyingOnExchange = null,
        string userId = null,
        OrderStatus? status = null,
        DateTimeOffset? dateFrom = null, DateTimeOffset? dateTo = null,
        decimal? dealCryptoAmount = null, decimal? dealFiatAmount = null)
    {
        var result = await $"p2p/orders".InternalApi()
            .SetQueryParam(nameof(exchangeCurrencyCode), exchangeCurrencyCode)
            .SetQueryParam(nameof(paymentCurrencyCode), paymentCurrencyCode)
            .SetQueryParam(nameof(paymentSystemId), paymentSystemId)
            .SetQueryParam(nameof(isBuyingOnExchange), isBuyingOnExchange)
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(status), status)
            .SetQueryParam(nameof(dateFrom), dateFrom?.ToString("o"))
            .SetQueryParam(nameof(dateTo), dateTo?.ToString("o"))
            .SetQueryParam(nameof(dealCryptoAmount), dealCryptoAmount)
            .SetQueryParam(nameof(dealFiatAmount), dealFiatAmount)
            .GetJsonAsync<List<Order>>();
        return result;
    }

    public async Task<Order> GetOrder(Guid id)
    {
        return await $"p2p/orders/{id}".InternalApi()
            .GetJsonAsync<Order>();
    }

    public async Task<Order> CreateOrder(OrderCreateDto orderDto)
    {
        return await $"p2p/orders".InternalApi()
            .PostJsonAsync<Order>(orderDto);
    }

    public async Task<Order> CloneOrder(Guid id, [FromBody] OrderCreateDto orderDto)
    {
        return await $"p2p/orders/{id}/clone".InternalApi()
            .PostJsonAsync<Order>(orderDto);
    }

    public async Task<IFlurlResponse> CancelOrder(Guid id)
    {
        return await $"p2p/orders/{id}/cancel".InternalApi()
            .PostAsync();
    }

    public async Task<List<Deal>> GetDeals(string dealUserId = null, string orderUserId = null,
        [FromQuery] List<DealStatus> statuses = null)
    {
        return await $"p2p/deals".InternalApi()
            .SetQueryParam(nameof(dealUserId), dealUserId)
            .SetQueryParam(nameof(orderUserId), orderUserId)
            .SetQueryParam(nameof(statuses), statuses)
            .GetJsonAsync<List<Deal>>();
    }

    public async Task<Deal> GetDeal(Guid id)
    {
        return await $"p2p/deals/{id}".InternalApi()
            .GetJsonAsync<Deal>();
    }

    public async Task<Deal> CreateDeal(DealCreateDto dealDto)
    {
        return await $"p2p/deals".InternalApi()
            .PostJsonAsync<Deal>(dealDto);
    }

    public async Task<Deal> UpdateDealStatus(Guid id, DealStatus dealStatus)
    {
        return await $"p2p/deals/{id}/update-status".InternalApi()
            .SetQueryParam(nameof(dealStatus), dealStatus)
            .PostJsonAsync<Deal>(null);
    }

    public async Task<List<Requisite>> GetActiveRequisites(string userId = null)
    {
        return await $"p2p/requisites".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<Requisite>>();
    }

    public async Task<Requisite> GetActiveRequisite(Guid id)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .GetJsonAsync<Requisite>();
    }

    public async Task<IFlurlResponse> CreateRequisite(RequisiteDto requisiteDto)
    {
        return await $"p2p/requisites".InternalApi()
            .PostJsonAsync(requisiteDto);
    }

    public async Task<IFlurlResponse> UpdateRequisite(Guid id, RequisiteDto requisiteDto)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .PutJsonAsync(requisiteDto);
    }

    public async Task<IFlurlResponse> DeleteRequisite(Guid id)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .DeleteAsync();
    }

    public async Task<PaymentMethod> GetPaymentMethodByCurrencyCode(string exchangeCurrencyCode)
    {
        return await $"p2p/payment-methods".InternalApi()
            .SetQueryParam(nameof(exchangeCurrencyCode), exchangeCurrencyCode)
            .GetJsonAsync<PaymentMethod>();
    }

    public async Task<List<PaymentCurrency>> GetPaymentCurrencies()
    {
        return await $"p2p/payment-currencies".InternalApi()
            .GetJsonAsync<List<PaymentCurrency>>();
    }

    public async Task<List<PaymentSystem>> GetPaymentSystems(string? currencyCode)
    {
        return await $"p2p/payment-systems".InternalApi()
            .SetQueryParam(nameof(currencyCode), currencyCode)
            .GetJsonAsync<List<PaymentSystem>>();
    }

    public async Task<UserInfoDto> GetUserOrdersInfo(string userId)
    {
        return await $"p2p/users/info/{userId}".InternalApi()
            .GetJsonAsync<UserInfoDto>();
    }

    public async Task<List<DealComment>> GetDealComments(Guid? dealId = null, string fromUserId = null,
        string toUserId = null)
    {
        return await $"p2p/deal-comments/".InternalApi()
            .SetQueryParam(nameof(dealId), dealId)
            .SetQueryParam(nameof(fromUserId), fromUserId)
            .SetQueryParam(nameof(toUserId), toUserId)
            .GetJsonAsync<List<DealComment>>();
    }

    public async Task<DealComment> CreateDealComment(DealCommentDto dealCommentDto)
    {
        return await $"p2p/deal-comments".InternalApi()
            .PostJsonAsync<DealComment>(dealCommentDto);
    }

    public async Task<DealComment> UpdateDealComment([FromBody] DealCommentDto dealCommentDto)
    {
        return await $"p2p/deal-comments/update".InternalApi()
            .PostJsonAsync<DealComment>(dealCommentDto);
    }

    public async Task<List<UserBlock>> GetUserBlockList(string userId = null, string blockedUserId = null)
    {
        return await $"p2p/user-blocks".InternalApi()
            .SetQueryParam(nameof(blockedUserId), blockedUserId)
            .GetJsonAsync<List<UserBlock>>();
    }

    public async Task<UserBlock> BlockUser([FromBody] UserBlockCreateDto userBlockCreateDto)
    {
        return await $"p2p/user-blocks".InternalApi()
            .PostJsonAsync<UserBlock>(userBlockCreateDto);
    }

    public async Task<IFlurlResponse> RemoveBlockUser(string userId, string unblockedUserId)
    {
        return await $"p2p/user-blocks/{userId}".InternalApi()
            .SetQueryParam(nameof(unblockedUserId), unblockedUserId)
            .DeleteAsync();
    }
}
