using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class ClientP2P
{
    public async Task<List<Order>> GetOrders(string currencyCode = null,
        int? paymentSystemId = null,
        bool? isBuyingOnExchange = null,
        string userId = null,
        OrderStatus? status = null,
        DateTimeOffset? dateFrom = null,
        DateTimeOffset? dateTo = null,
        decimal? dealAmount = null)
    {
        var request = $"p2p/orders".InternalApi();

        request = request.SetQueryParam(nameof(currencyCode), currencyCode);
        request = request.SetQueryParam(nameof(paymentSystemId), paymentSystemId);
        request = request.SetQueryParam(nameof(isBuyingOnExchange), isBuyingOnExchange);
        request = request.SetQueryParam(nameof(userId), userId);
        request = request.SetQueryParam(nameof(status), status);
        request = request.SetQueryParam(nameof(dateFrom), dateFrom?.ToString("o"));
        request = request.SetQueryParam(nameof(dateTo), dateTo?.ToString("o"));
        request = request.SetQueryParam(nameof(dealAmount), dealAmount);

        return await request.GetJsonAsync<List<Order>>();
    }

    public async Task<Order> GetOrder(Guid id)
    {
        return await $"p2p/orders/{id}".InternalApi()
            .GetJsonAsync<Order>();
    }

    public async Task<IFlurlResponse> CreateOrder(OrderDto orderDto)
    {
        return await $"p2p/orders".InternalApi()
            .PostJsonAsync(orderDto);
    }

    public async Task<IFlurlResponse> CancelOrder(Guid id)
    {
        return await $"p2p/orders/{id}/cancel".InternalApi()
            .PostAsync();
    }

    public async Task<List<Deal>> GetDeals(string dealUserId = null)
    {
        return await $"p2p/deals".InternalApi()
            .SetQueryParam(nameof(dealUserId), dealUserId)
            .GetJsonAsync<List<Deal>>();
    }

    public async Task<Deal> GetDeal(Guid id)
    {
        return await $"p2p/deals/{id}".InternalApi()
            .GetJsonAsync<Deal>();
    }

    public async Task<IFlurlResponse> CreateDeal(DealDto dealDto)
    {
        return await $"p2p/deals".InternalApi()
            .PostJsonAsync(dealDto);
    }

    public async Task<IFlurlResponse> UpdateDealStatus(Guid id, DealStatus dealStatus)
    {
        return await $"p2p/deals/{id}/update-status".InternalApi()
            .SetQueryParam(nameof(dealStatus), dealStatus)
            .PostAsync();
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
        return await $"p2p/requisites/{id}/update".InternalApi()
            .PostJsonAsync(requisiteDto);
    }

    public async Task<IFlurlResponse> DeleteRequisite(Guid id)
    {
        return await $"p2p/requisites/{id}/delete".InternalApi()
            .PostJsonAsync(id);
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
            .GetJsonAsync();
    }

    public async Task<List<PaymentSystem>> GetPaymentSystems(string? currencyCode)
    {
        return await $"p2p/payment-systems".InternalApi()
            .SetQueryParam(nameof(currencyCode), currencyCode)
            .GetJsonAsync();
    }
}
