using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Bwp;

public class ClientBwp
{
    public async Task<List<TraderRequisite>> GetPaymentMethods()
    {
        return await "bwp/requisites/payment-methods".InternalApi()
            .GetJsonAsync();
    }

    public async Task<Invoice> GetInvoice(long id)
    {
        return await $"bwp/internal/invoices/{id}".InternalApi()
            .GetJsonAsync();
    }

    public async Task<List<Invoice>> GetInvoices()
    {
        return await "bwp/internal/invoices".InternalApi()
            .GetJsonAsync();
    }

    public async Task<InvoiceCreateResponse> CreateInvoice(
        [FromBody] InvoiceCreateRequest invoiceCreateRequest)
    {
        return await "bwp/internal/invoices".InternalApi()
            .PostJsonAsync<InvoiceCreateResponse>(invoiceCreateRequest);
    }
}