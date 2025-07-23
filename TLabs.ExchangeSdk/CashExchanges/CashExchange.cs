using System;
using TLabs.ExchangeSdk.CashHandover;

namespace TLabs.ExchangeSdk.CashExchanges;

public class CashExchange
{
    public Guid Id { get; set; }
    public string PersonName { get; set; }
    public CashHandoverClient Client { get; set; }
    public Guid? ClientId { get; set; }
    public string Comment { get; set; }
    public int DealNumber { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid DocumentPhotoId { get; set; }
    public ImageDto DocumentPhotoDto { get; set; }
    public CashHandoverRequestStatus Status { get; set; }

    public decimal? TrustUsdtIn { get; set; }
    public decimal? TrustUsdtOut { get; set; }
    public decimal? TronlinkUsdtIn { get; set; }
    public decimal? TronlinkUsdtOut { get; set; }
    public decimal? CashIstanbulUsdIn { get; set; }
    public decimal? CashIstanbulUsdOut { get; set; }
    public decimal? CashIstanbulEurIn { get; set; }
    public decimal? CashIstanbulEurOut { get; set; }
    public decimal? CashIstanbulTryIn { get; set; }
    public decimal? CashIstanbulTryOut { get; set; }
    public decimal? BankVakifUsdIn { get; set; }
    public decimal? BankVakifUsdOut { get; set; }
}
