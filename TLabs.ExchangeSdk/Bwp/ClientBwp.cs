using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Bwp.Merchants;

namespace TLabs.ExchangeSdk.Bwp;

public class ClientBwp
{
    #region invoices

    public async Task<InvoiceDto> GetInvoice(long id)
    {
        return await $"bwp/internal/invoices/{id}".InternalApi()
            .GetJsonAsync<InvoiceDto>();
    }

    public async Task<List<InvoiceDto>> GetInvoices(string userId = null)
    {
        return await "bwp/internal/invoices".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<InvoiceDto>>();
    }

    public async Task<InvoiceCreateResponse> CreateInvoice(
        [FromBody] InvoiceCreateRequest invoiceCreateRequest)
    {
        return await "bwp/internal/invoices".InternalApi()
            .PostJsonAsync<InvoiceCreateResponse>(invoiceCreateRequest);
    }

    public async Task<IFlurlResponse> CancelInvoice(long id)
    {
        return await $"bwp/internal/invoices/{id}/cancel".InternalApi()
            .PostAsync();
    }

    #endregion invoices

    #region deals

    public async Task<List<TraderDeal>> GetDeals(string userId = null)
    {
        return await $"bwp/deals".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<TraderDeal>>();
    }

    public async Task<TraderDeal> GetDeal(long id)
    {
        return await $"bwp/deals/{id}".InternalApi()
            .GetJsonAsync<TraderDeal>();
    }

    public async Task<IFlurlResponse> ConfirmInvoiceAndCreateDeal(Invoice invoice)
    {
        return await $"bwp/deals".InternalApi()
            .PostJsonAsync(invoice);
    }

    #endregion deals

    #region traderSettings

    public async Task<TraderSetting> GetTraderSettings(string id)
    {
        return await $"bwp/tradersettings/{id}".InternalApi()
            .GetJsonAsync<TraderSetting>();
    }

    public async Task<IFlurlResponse> SetTraderOnlineStatus(string id, [Required] bool isOnline)
    {
        return await $"bwp/tradersettings/{id}/online-status".InternalApi()
            .SetQueryParam("isOnline", isOnline)
            .PostAsync();
    }

    public async Task<IFlurlResponse> SetTraderActiveStatus(string id, [Required] bool isAdminSetActive)
    {
        return await $"bwp/tradersettings/{id}/active-status".InternalApi()
            .SetQueryParam("isAdminSetActive", isAdminSetActive)
            .PostAsync();
    }

    public async Task<IFlurlResponse> SetAllowedNegativeBalances(string id, [Required] bool allowedNegativeBalances)
    {
        return await $"bwp/tradersettings/{id}/allowed-negative-balances".InternalApi()
            .SetQueryParam("allowedNegativeBalances", allowedNegativeBalances)
            .PostAsync();
    }

    #endregion traderSettings

    public async Task<List<TraderPaymentMethod>> GetPaymentMethods()
    {
        return await "bwp/requisites/payment-methods".InternalApi()
            .GetJsonAsync<List<TraderPaymentMethod>>();
    }
}
