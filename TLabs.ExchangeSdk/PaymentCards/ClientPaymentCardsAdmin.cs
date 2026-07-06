using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.PaymentCards.Dtos;

namespace TLabs.ExchangeSdk.PaymentCards;

public interface IClientPaymentCardsAdmin
{
    Task<PaymentCardProviderFundBalanceDto> GetProviderFundBalance(string adminUserId, string currencyCode = null);

    Task<PaymentCardProviderFundDepositDto> RecordProviderFundDeposit(CreatePaymentCardProviderFundDepositDto dto);

    Task<List<PaymentCardProviderFundDepositDto>> GetProviderFundDeposits(string adminUserId);
}

public class ClientPaymentCardsAdmin : IClientPaymentCardsAdmin
{
    private const string BaseUrl = "brokerage/payment-cards/admin";

    public Task<PaymentCardProviderFundBalanceDto> GetProviderFundBalance(string adminUserId, string currencyCode = null)
    {
        var req = $"{BaseUrl}/provider-fund/balance".InternalApi()
            .SetQueryParam(nameof(adminUserId), adminUserId);
        if (currencyCode != null)
            req = req.SetQueryParam(nameof(currencyCode), currencyCode);
        return req.GetJsonAsync<PaymentCardProviderFundBalanceDto>();
    }

    public Task<PaymentCardProviderFundDepositDto> RecordProviderFundDeposit(CreatePaymentCardProviderFundDepositDto dto) =>
        $"{BaseUrl}/provider-fund/deposits".InternalApi().PostJsonAsync(dto).ReceiveJson<PaymentCardProviderFundDepositDto>();

    public Task<List<PaymentCardProviderFundDepositDto>> GetProviderFundDeposits(string adminUserId) =>
        $"{BaseUrl}/provider-fund/deposits".InternalApi()
            .SetQueryParam(nameof(adminUserId), adminUserId)
            .GetJsonAsync<List<PaymentCardProviderFundDepositDto>>();
}
