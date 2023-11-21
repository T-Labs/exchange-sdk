using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Bwp;

public class ClientBwp
{
    #region invoices

    public async Task<Invoice> GetInvoice(long id)
    {
        return await $"bwp/internal/invoices/{id}".InternalApi()
            .GetJsonAsync<Invoice>();
    }

    public async Task<List<Invoice>> GetInvoices()
    {
        return await "bwp/internal/invoices".InternalApi()
            .GetJsonAsync<List<Invoice>>();
    }

    public async Task<InvoiceCreateResponse> CreateInvoice(
        [FromBody] InvoiceCreateRequest invoiceCreateRequest)
    {
        return await "bwp/internal/invoices".InternalApi()
            .PostJsonAsync<InvoiceCreateResponse>(invoiceCreateRequest);
    }

    #endregion invoices

    #region deals

    public async Task<List<TraderDeal>> GetDeals(string userId = null)
    {
        return await $"bwp/deals".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<TraderDeal>>();
    }

    public async Task<TraderDeal> GetDeal(Guid id)
    {
        return await $"bwp/deals/{id}".InternalApi()
            .GetJsonAsync<TraderDeal>();
    }

    public async Task<IFlurlResponse> CreateDeal(Invoice invoice)
    {
        return await $"bwp/deals".InternalApi()
            .PostJsonAsync(invoice);
    }

    #endregion deals

    public async Task<List<TraderPaymentMethod>> GetPaymentMethods()
    {
        return await "bwp/requisites/payment-methods".InternalApi()
            .GetJsonAsync<List<TraderPaymentMethod>>();
    }
}
