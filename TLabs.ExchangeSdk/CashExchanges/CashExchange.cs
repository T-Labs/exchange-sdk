using System;
using System.ComponentModel.DataAnnotations.Schema;
using TLabs.ExchangeSdk.CashHandover;

namespace TLabs.ExchangeSdk.CashExchanges;

public class CashExchange
{
    public Guid Id { get; set; }

    /// <summary>Sheets row number</summary>
    public int? RowId { get; set; }

    /// <summary>if deal number is null it means that exchange is correction</summary>
    public int? DealNumber { get; set; }

    public string PersonName { get; set; }
    public CashHandoverClient Client { get; set; }
    public Guid? ClientId { get; set; }
    public string Comment { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid? DocumentPhotoId { get; set; }

    /// <summary>Using for corrections</summary>
    public bool IsDeleted { get; set; }

    public CashHandoverRequestStatus Status { get; set; }

    /// <summary>null if Spread wasn't filled in Sheets</summary>
    public decimal? SpreadFromSheets { get; set; }

    public decimal? TrustUsdtIn { get; set; }
    public decimal? TrustUsdtOut { get; set; }
    public decimal? TronlinkUsdtIn { get; set; }
    public decimal? TronlinkUsdtOut { get; set; }
    public decimal? TronlinkTRXIn { get; set; }
    public decimal? TronlinkTRXOut { get; set; }
    public decimal? CashIstanbulUsdIn { get; set; }
    public decimal? CashIstanbulUsdOut { get; set; }
    public decimal? CashIstanbulEurIn { get; set; }
    public decimal? CashIstanbulEurOut { get; set; }
    public decimal? CashIstanbulTryIn { get; set; }
    public decimal? CashIstanbulTryOut { get; set; }
    public decimal? BybitRUSDTIn { get; set; }
    public decimal? BybitRUSDTOut { get; set; }
    public decimal? TrustTRXIn { get; set; }
    public decimal? TrustTRXOut { get; set; }

    //corrections section
    public decimal? CorrectionUsdtValue { get; set; }
    public decimal? CorrectionTrxValue { get; set; }
    public decimal? CorrectionUsdValue { get; set; }
    public decimal? CorrectionTryValue { get; set; }
    public decimal? CorrectionEurValue { get; set; }

    [NotMapped]
    public ImageDto DocumentPhotoDto { get; set; }
}
